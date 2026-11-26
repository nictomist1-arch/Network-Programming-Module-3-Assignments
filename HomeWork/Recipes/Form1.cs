using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Recipes
{
    public partial class Form1 : Form
    {
        readonly Server server = new Server();
        readonly Client client = new Client();

        public Form1()
        {
            InitializeComponent();
            server.Message += Server_Message;
        }

        private void Server_Message(string text)
        {
            if (IsDisposed || !IsHandleCreated)
                return;

            BeginInvoke(new Action(() =>
            {
                if (!IsDisposed)
                    serverLog.Items.Add(text);
            }));
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            server.SetLimits((int)requestLimit.Value, (int)periodMinutes.Value);
            server.Start(serverIp.Text, (int)serverPort.Value);
            startButton.Enabled = false;
            serverIp.Enabled = false;
            serverPort.Enabled = false;
        }

        private async void connectButton_Click(object sender, EventArgs e)
        {
            string host = clientIp.Text;
            int port = (int)clientPort.Value;

            connectButton.Enabled = false;
            try
            {
                string answer = await Task.Run(() => client.Connect(host, port));
                clientLog.AppendText((answer == "OK" ? "Подключено" : answer) + Environment.NewLine);
            }
            catch (System.Net.Sockets.SocketException ex)
            {
                client.Dispose();
                clientLog.AppendText(ex.Message + Environment.NewLine);
            }
            catch (System.IO.IOException ex)
            {
                client.Dispose();
                clientLog.AppendText(ex.Message + Environment.NewLine);
            }
            connectButton.Enabled = !client.Connected;
            sendButton.Enabled = disconnectButton.Enabled = client.Connected;
        }

        private async void sendButton_Click(object sender, EventArgs e)
        {
            string text = requestText.Text;
            sendButton.Enabled = false;
            disconnectButton.Enabled = false;
            clientLog.AppendText("Запрос: " + requestText.Text + Environment.NewLine);
            try
            {
                string answer = await Task.Run(() => client.Send(text));
                clientLog.AppendText(answer.Replace(" || ", Environment.NewLine + Environment.NewLine) + Environment.NewLine);
            }
            catch (System.IO.IOException ex)
            {
                client.Dispose();
                clientLog.AppendText(ex.Message + Environment.NewLine);
            }
            catch (System.Net.Sockets.SocketException ex)
            {
                client.Dispose();
                clientLog.AppendText(ex.Message + Environment.NewLine);
            }
            connectButton.Enabled = !client.Connected;
            sendButton.Enabled = disconnectButton.Enabled = client.Connected;
        }

        private void disconnectButton_Click(object sender, EventArgs e)
        {
            client.Dispose();
            clientLog.AppendText("Отключено" + Environment.NewLine);
            connectButton.Enabled = true;
            sendButton.Enabled = disconnectButton.Enabled = false;
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            server.Message -= Server_Message;
            client.Dispose();
            server.Stop();
            base.OnFormClosing(e);
        }

        private void settingsButton_Click(object sender, EventArgs e)
        {
            server.SetLimits((int)requestLimit.Value, (int)periodMinutes.Value);
            serverLog.Items.Add("Ограничения обновлены");
        }
    }
}
