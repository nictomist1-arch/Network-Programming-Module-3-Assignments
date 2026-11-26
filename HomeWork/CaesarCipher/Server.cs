using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace CaesarCipher
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
                        accepted = running;
                        if (accepted)
                            clients.Add(client);
                    }
                    if (!accepted)
                    {
                        using (client)
                        using (var writer = new StreamWriter(client.GetStream(), new UTF8Encoding(false)) { AutoFlush = true })
                            writer.WriteLine("Сервер под максимальной нагрузкой. Попробуйте позже.");
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

        
        public static string Encrypt(string text, int shift)
        {
            string[] alphabets = {
                "abcdefghijklmnopqrstuvwxyz", "ABCDEFGHIJKLMNOPQRSTUVWXYZ",
                "абвгдеёжзийклмнопрстуфхцчшщъыьэюя", "АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ"
            };
            StringBuilder result = new StringBuilder();
            foreach (char symbol in text)
            {
                char encrypted = symbol;
                foreach (string alphabet in alphabets)
                {
                    int index = alphabet.IndexOf(symbol);
                    if (index >= 0)
                    {
                        int offset = shift % alphabet.Length;
                        encrypted = alphabet[(index + offset + alphabet.Length) % alphabet.Length];
                        break;
                    }
                }
                result.Append(encrypted);
            }
            return result.ToString();
        }

        void HandleClient(TcpClient client, string address)
        {
            Log("Подключился " + address);
            try
            {
                using (client)
                using (var reader = new StreamReader(client.GetStream(), Encoding.UTF8))
                using (var writer = new StreamWriter(client.GetStream(), new UTF8Encoding(false)) { AutoFlush = true })
                {
                    writer.WriteLine("OK");
                    string request;
                    while ((request = reader.ReadLine()) != null)
                    {
                        Log(address + " отправил: " + request);
                        int separator = request.IndexOf('|');
                        int shift;
                        if (separator < 0 || !int.TryParse(request.Substring(0, separator), out shift))
                        {
                            writer.WriteLine("Укажите сдвиг и текст");
                            continue;
                        }
                        string answer = Encrypt(request.Substring(separator + 1), shift);
                        writer.WriteLine(answer);
                        Log(address + " получил: " + answer);
                    }
                }
            }
            catch (IOException) { }
            catch (SocketException) { }
            catch (ObjectDisposedException) { }
            finally
            {
                lock (sync) clients.Remove(client);
                Log("Отключился " + address);
            }
        }

    }
}



