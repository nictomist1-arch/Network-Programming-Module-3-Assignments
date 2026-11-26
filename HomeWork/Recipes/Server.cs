using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace Recipes
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
                    string address = ((IPEndPoint)client.Client.RemoteEndPoint).Address.ToString();
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

        
        int maxRequests = 10;
        TimeSpan period = TimeSpan.FromHours(1);
        readonly Dictionary<string, Queue<DateTime>> requests = new Dictionary<string, Queue<DateTime>>();
        readonly Recipe[] recipes = {
            new Recipe("Омлет", "яйца,молоко,соль", "Взбейте яйца с молоком и солью. Готовьте на сковороде 5 минут."),
            new Recipe("Блины", "яйца,молоко,мука,сахар,соль", "Смешайте продукты до жидкого теста. Жарьте тонкие блины с двух сторон."),
            new Recipe("Сырники", "творог,яйца,мука,сахар", "Смешайте продукты, сформируйте сырники и обжарьте с двух сторон."),
            new Recipe("Овощной салат", "помидоры,огурцы,масло,соль", "Нарежьте овощи, добавьте масло и соль, перемешайте."),
            new Recipe("Картофельное пюре", "картофель,молоко,масло,соль", "Отварите картофель, разомните с тёплым молоком и маслом."),
            new Recipe("Куриный суп", "курица,картофель,морковь,лук,соль", "Сварите курицу, добавьте нарезанные овощи и варите до готовности."),
            new Recipe("Гречка с грибами", "гречка,грибы,лук,масло,соль", "Отварите гречку. Обжарьте грибы с луком и смешайте с гречкой."),
            new Recipe("Гренки", "хлеб,яйца,молоко,масло", "Обмакните хлеб в смесь яиц и молока, обжарьте на масле.")
        };

        public void SetLimits(int count, int minutes)
        {
            lock (sync) { maxRequests = count; period = TimeSpan.FromMinutes(minutes); }
        }

        public string FindRecipes(string products)
        {
            string[] wanted = products.ToLower().Split(new[] { ',', ';' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(p => p.Trim()).Where(p => p.Length > 0).ToArray();
            if (wanted.Length == 0) return "Введите продукты через запятую";
            var found = recipes.Where(r => wanted.All(p => r.Products.Contains(p)))
                .Select(r => r.Name + " [" + string.Join(", ", r.Products) + "]. " + r.Description);
            string result = string.Join(" || ", found);
            return result.Length == 0 ? "Рецепты не найдены" : result;
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
                        bool allowed;
                        int wait;
                        lock (sync)
                        {
                            if (!requests.ContainsKey(address)) requests[address] = new Queue<DateTime>();
                            Queue<DateTime> times = requests[address];
                            DateTime now = DateTime.UtcNow;
                            while (times.Count > 0 && now - times.Peek() >= period) times.Dequeue();
                            allowed = times.Count < maxRequests;
                            wait = allowed ? 0 : (int)Math.Ceiling((times.Peek() + period - now).TotalSeconds);
                            if (allowed) times.Enqueue(now);
                        }
                        string answer = allowed ? FindRecipes(request) : "Лимит запросов. Повторите через " + wait + " сек.";
                        Log(address + " запрос: " + request + "; ответ: " + answer);
                        writer.WriteLine(answer);
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



