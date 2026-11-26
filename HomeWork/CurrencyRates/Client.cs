using System;
using System.IO;
using System.Net.Sockets;
using System.Text;

namespace CurrencyRates
{
    public class Client : IDisposable
    {
        TcpClient client;
        StreamReader reader;
        StreamWriter writer;
        public bool Connected { get; private set; }

        public string Connect(string host, int port, string login = "", string password = "")
        {
            client = new TcpClient();
            client.Connect(host, port);
            reader = new StreamReader(client.GetStream(), Encoding.UTF8);
            writer = new StreamWriter(client.GetStream(), new UTF8Encoding(false)) { AutoFlush = true };
            writer.WriteLine(login + "\t" + password);
            string answer = reader.ReadLine();
            Connected = answer == "OK";
            if (!Connected)
                Dispose();
            return answer ?? "Сервер закрыл соединение";
        }

        public string Send(string text)
        {
            writer.WriteLine(text);
            string answer = reader.ReadLine();
            if (answer == null || answer.StartsWith("CLOSE|"))
                Dispose();
            return answer == null ? "Сервер закрыл соединение" : answer.StartsWith("CLOSE|") ? answer.Substring(6) : answer;
        }

        public void Dispose()
        {
            Connected = false;
            if (client != null)
                client.Close();
        }
    }
}

