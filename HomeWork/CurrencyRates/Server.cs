using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace CurrencyRates
{
    public class Server
    {
        TcpListener listener;
        volatile bool running;
        readonly object sync = new object();
        readonly HashSet<TcpClient> clients = new HashSet<TcpClient>();
        public event Action<string> Message;
        public string LogPath { get; set; } = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "server.log");

        public void Start(string address, int port)
        {
            listener = new TcpListener(IPAddress.Parse(address), port);
            listener.Start();
            running = true;
            new Thread(AcceptClients) { IsBackground = true }.Start();
            Log("Сервер запущен: " + address + ":" + port);
        }

        void AcceptClients()
        {
            try
            {
                while (running)
                {
                    TcpClient client = listener.AcceptTcpClient();
                    string address = client.Client.RemoteEndPoint.ToString();
                    bool accepted;
                    lock (sync)
                    {
                        accepted = running && clients.Count < maxClients;
                        if (accepted)
                            clients.Add(client);
                    }
                    if (!accepted)
                    {
                        Log("Отклонено подключение " + address + ": максимум клиентов");
                        try
                        {
                            using (client)
                            using (var writer = new StreamWriter(client.GetStream(), new UTF8Encoding(false)) { AutoFlush = true })
                                writer.WriteLine("Сервер под максимальной нагрузкой. Попробуйте позже.");
                        }
                        catch (IOException) { }
                        catch (SocketException) { }
                        continue;
                    }
                    new Thread(() => HandleClient(client, address)) { IsBackground = true }.Start();
                }
            }
            catch (SocketException) { }
            catch (ObjectDisposedException) { }
            catch (IOException) { }
        }

        public void Stop()
        {
            running = false;
            if (listener != null)
                listener.Stop();
            lock (sync)
                foreach (TcpClient client in clients)
                    client.Close();
        }

        void Log(string text)
        {
            string line = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + " " + text;
            lock (sync)
                File.AppendAllText(LogPath, line + Environment.NewLine, Encoding.UTF8);
            Message?.Invoke(line);
        }

        
        int maxClients = 10;
        int maxRequests = 5;
        readonly Dictionary<string, string> users = new Dictionary<string, string> { { "student", "123" } };
        readonly Dictionary<string, DateTime> blockedUntil = new Dictionary<string, DateTime>();
        readonly Dictionary<string, int> requestCounts = new Dictionary<string, int>();
        readonly Dictionary<string, decimal> rates = new Dictionary<string, decimal> {
            { "RUB", 1m }, { "USD", 90m }, { "EURO", 100m }, { "GBP", 120m }, { "CNY", 12m }
        };

        public void SetLimits(int requests, int connections)
        {
            lock (sync) { maxRequests = requests; maxClients = connections; }
        }

        public void AddUser(string login, string password)
        {
            lock (sync) users[login] = password;
        }

        public void SetRate(string currency, decimal rubles)
        {
            if (rubles <= 0) throw new ArgumentException("Курс должен быть больше нуля");
            lock (sync) rates[currency.ToUpper()] = rubles;
        }

        public string GetRate(string request)
        {
            string[] parts = request.ToUpper().Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
            if (parts.Length != 2) return "Введите две валюты, например USD EURO";
            string from = parts[0] == "EUR" ? "EURO" : parts[0];
            string to = parts[1] == "EUR" ? "EURO" : parts[1];
            lock (sync)
            {
                if (!rates.ContainsKey(from) || !rates.ContainsKey(to)) return "Неизвестная валюта";
                return "1 " + from + " = " + (rates[from] / rates[to]).ToString("0.######", CultureInfo.InvariantCulture) + " " + to;
            }
        }

        void HandleClient(TcpClient client, string address)
        {
            string login = "неизвестный";
            Log("Подключился " + address);
            try
            {
                using (client)
                using (var reader = new StreamReader(client.GetStream(), Encoding.UTF8))
                using (var writer = new StreamWriter(client.GetStream(), new UTF8Encoding(false)) { AutoFlush = true })
                {
                    string auth = reader.ReadLine();
                    string[] parts = (auth ?? "").Split('\t');
                    string error = null;
                    lock (sync)
                    {
                        if (parts.Length != 2 || !users.ContainsKey(parts[0]) || users[parts[0]] != parts[1])
                            error = "Неверный логин или пароль";
                        else
                        {
                            login = parts[0];
                            if (blockedUntil.ContainsKey(login) && blockedUntil[login] > DateTime.UtcNow)
                                error = "Лимит запросов. Повторное подключение через " +
                                    Math.Ceiling((blockedUntil[login] - DateTime.UtcNow).TotalSeconds) + " сек.";
                            else if (blockedUntil.ContainsKey(login))
                            {
                                blockedUntil.Remove(login);
                                requestCounts[login] = 0;
                            }
                        }
                    }
                    if (error != null) { writer.WriteLine(error); Log(address + ": " + error); return; }
                    writer.WriteLine("OK");
                    Log(address + " вошёл как " + login);
                    string request;
                    while ((request = reader.ReadLine()) != null)
                    {
                        string answer;
                        bool limit;
                        lock (sync)
                        {
                            if (blockedUntil.ContainsKey(login) && blockedUntil[login] > DateTime.UtcNow)
                            {
                                writer.WriteLine("CLOSE|Лимит запросов. Повторите подключение через минуту.");
                                break;
                            }
                            if (!requestCounts.ContainsKey(login)) requestCounts[login] = 0;
                            requestCounts[login]++;
                            answer = GetRate(request);
                            limit = requestCounts[login] >= maxRequests;
                            if (limit) blockedUntil[login] = DateTime.UtcNow.AddMinutes(1);
                        }
                        Log(login + " (" + address + ") запрос: " + request + "; ответ: " + answer);
                        writer.WriteLine(limit ? "CLOSE|" + answer + ". Лимит запросов, соединение закрыто на минуту." : answer);
                        if (limit) break;
                    }
                }
            }
            catch (IOException) { }
            catch (SocketException) { }
            catch (ObjectDisposedException) { }
            finally
            {
                lock (sync) clients.Remove(client);
                Log("Отключился " + login + " (" + address + ")");
            }
        }

    }
}


