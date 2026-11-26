namespace CurrencyRates
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.tabs = new System.Windows.Forms.TabControl();
            this.serverTab = new System.Windows.Forms.TabPage();
            this.clientTab = new System.Windows.Forms.TabPage();
            this.serverAddressLabel = new System.Windows.Forms.Label();
            this.serverIp = new System.Windows.Forms.TextBox();
            this.serverPortLabel = new System.Windows.Forms.Label();
            this.serverPort = new System.Windows.Forms.NumericUpDown();
            this.startButton = new System.Windows.Forms.Button();
            this.limitsGroup = new System.Windows.Forms.GroupBox();
            this.limitLabel = new System.Windows.Forms.Label();
            this.requestLimit = new System.Windows.Forms.NumericUpDown();
            this.connectionsLabel = new System.Windows.Forms.Label();
            this.connectionLimit = new System.Windows.Forms.NumericUpDown();
            this.settingsButton = new System.Windows.Forms.Button();
            this.userGroup = new System.Windows.Forms.GroupBox();
            this.usersLabel = new System.Windows.Forms.Label();
            this.newLogin = new System.Windows.Forms.TextBox();
            this.userPasswordLabel = new System.Windows.Forms.Label();
            this.newPassword = new System.Windows.Forms.TextBox();
            this.addUserButton = new System.Windows.Forms.Button();
            this.rateGroup = new System.Windows.Forms.GroupBox();
            this.rateLabel = new System.Windows.Forms.Label();
            this.rateCurrency = new System.Windows.Forms.ComboBox();
            this.rateValue = new System.Windows.Forms.TextBox();
            this.rublesLabel = new System.Windows.Forms.Label();
            this.rateButton = new System.Windows.Forms.Button();
            this.logFileLabel = new System.Windows.Forms.Label();
            this.serverLog = new System.Windows.Forms.ListBox();
            this.clientAddressLabel = new System.Windows.Forms.Label();
            this.clientIp = new System.Windows.Forms.TextBox();
            this.clientPortLabel = new System.Windows.Forms.Label();
            this.clientPort = new System.Windows.Forms.NumericUpDown();
            this.connectButton = new System.Windows.Forms.Button();
            this.disconnectButton = new System.Windows.Forms.Button();
            this.loginLabel = new System.Windows.Forms.Label();
            this.loginText = new System.Windows.Forms.TextBox();
            this.passwordLabel = new System.Windows.Forms.Label();
            this.passwordText = new System.Windows.Forms.TextBox();
            this.requestLabel = new System.Windows.Forms.Label();
            this.requestText = new System.Windows.Forms.TextBox();
            this.sendButton = new System.Windows.Forms.Button();
            this.responseLabel = new System.Windows.Forms.Label();
            this.clientLog = new System.Windows.Forms.TextBox();
            this.tabs.SuspendLayout();
            this.serverTab.SuspendLayout();
            this.clientTab.SuspendLayout();
            this.limitsGroup.SuspendLayout();
            this.userGroup.SuspendLayout();
            this.rateGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.serverPort)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.requestLimit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.connectionLimit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.clientPort)).BeginInit();
            this.SuspendLayout();
            //
            // tabs
            //
            this.tabs.Controls.Add(this.serverTab);
            this.tabs.Controls.Add(this.clientTab);
            this.tabs.Location = new System.Drawing.Point(12, 12);
            this.tabs.Name = "tabs";
            this.tabs.SelectedIndex = 0;
            this.tabs.Size = new System.Drawing.Size(596, 450);
            this.tabs.TabIndex = 0;
            //
            // serverTab
            //
            this.serverTab.Controls.Add(this.serverAddressLabel);
            this.serverTab.Controls.Add(this.serverIp);
            this.serverTab.Controls.Add(this.serverPortLabel);
            this.serverTab.Controls.Add(this.serverPort);
            this.serverTab.Controls.Add(this.startButton);
            this.serverTab.Controls.Add(this.limitsGroup);
            this.serverTab.Controls.Add(this.userGroup);
            this.serverTab.Controls.Add(this.rateGroup);
            this.serverTab.Controls.Add(this.logFileLabel);
            this.serverTab.Controls.Add(this.serverLog);
            this.serverTab.Location = new System.Drawing.Point(4, 22);
            this.serverTab.Name = "serverTab";
            this.serverTab.Padding = new System.Windows.Forms.Padding(3);
            this.serverTab.Size = new System.Drawing.Size(588, 424);
            this.serverTab.TabIndex = 0;
            this.serverTab.Text = "Сервер";
            this.serverTab.UseVisualStyleBackColor = true;
            //
            // clientTab
            //
            this.clientTab.Controls.Add(this.clientAddressLabel);
            this.clientTab.Controls.Add(this.clientIp);
            this.clientTab.Controls.Add(this.clientPortLabel);
            this.clientTab.Controls.Add(this.clientPort);
            this.clientTab.Controls.Add(this.connectButton);
            this.clientTab.Controls.Add(this.disconnectButton);
            this.clientTab.Controls.Add(this.loginLabel);
            this.clientTab.Controls.Add(this.loginText);
            this.clientTab.Controls.Add(this.passwordLabel);
            this.clientTab.Controls.Add(this.passwordText);
            this.clientTab.Controls.Add(this.requestLabel);
            this.clientTab.Controls.Add(this.requestText);
            this.clientTab.Controls.Add(this.sendButton);
            this.clientTab.Controls.Add(this.responseLabel);
            this.clientTab.Controls.Add(this.clientLog);
            this.clientTab.Location = new System.Drawing.Point(4, 22);
            this.clientTab.Name = "clientTab";
            this.clientTab.Padding = new System.Windows.Forms.Padding(3);
            this.clientTab.Size = new System.Drawing.Size(588, 424);
            this.clientTab.TabIndex = 1;
            this.clientTab.Text = "Клиент";
            this.clientTab.UseVisualStyleBackColor = true;
            //
            // serverAddressLabel
            //
            this.serverAddressLabel.AutoSize = true;
            this.serverAddressLabel.Location = new System.Drawing.Point(16, 20);
            this.serverAddressLabel.Name = "serverAddressLabel";
            this.serverAddressLabel.Size = new System.Drawing.Size(65, 13);
            this.serverAddressLabel.TabIndex = 0;
            this.serverAddressLabel.Text = "IP-адрес";
            //
            // serverIp
            //
            this.serverIp.Location = new System.Drawing.Point(83, 17);
            this.serverIp.Name = "serverIp";
            this.serverIp.Size = new System.Drawing.Size(127, 20);
            this.serverIp.TabIndex = 1;
            this.serverIp.Text = "127.0.0.1";
            //
            // serverPortLabel
            //
            this.serverPortLabel.AutoSize = true;
            this.serverPortLabel.Location = new System.Drawing.Point(232, 30);
            this.serverPortLabel.Name = "serverPortLabel";
            this.serverPortLabel.Size = new System.Drawing.Size(35, 13);
            this.serverPortLabel.TabIndex = 2;
            this.serverPortLabel.Text = "Порт";
            //
            // serverPort
            //
            this.serverPort.Location = new System.Drawing.Point(276, 26);
            this.serverPort.Maximum = new decimal(new int[] { 65535, 0, 0, 0 });
            this.serverPort.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            this.serverPort.Name = "serverPort";
            this.serverPort.Size = new System.Drawing.Size(57, 20);
            this.serverPort.TabIndex = 3;
            this.serverPort.Value = new decimal(new int[] { 5102, 0, 0, 0 });
            //
            // startButton
            //
            this.startButton.Location = new System.Drawing.Point(366, 16);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(139, 27);
            this.startButton.TabIndex = 4;
            this.startButton.Text = "Запустить сервер";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            //
            // limitsGroup
            //
            this.limitsGroup.Controls.Add(this.limitLabel);
            this.limitsGroup.Controls.Add(this.requestLimit);
            this.limitsGroup.Controls.Add(this.connectionsLabel);
            this.limitsGroup.Controls.Add(this.connectionLimit);
            this.limitsGroup.Controls.Add(this.settingsButton);
            this.limitsGroup.Location = new System.Drawing.Point(14, 66);
            this.limitsGroup.Name = "limitsGroup";
            this.limitsGroup.Size = new System.Drawing.Size(268, 113);
            this.limitsGroup.TabIndex = 5;
            this.limitsGroup.TabStop = false;
            this.limitsGroup.Text = "Ограничения";
            //
            // limitLabel
            //
            this.limitLabel.AutoSize = true;
            this.limitLabel.Location = new System.Drawing.Point(12, 24);
            this.limitLabel.Name = "limitLabel";
            this.limitLabel.Size = new System.Drawing.Size(120, 13);
            this.limitLabel.TabIndex = 0;
            this.limitLabel.Text = "Запросов на логин";
            //
            // requestLimit
            //
            this.requestLimit.Location = new System.Drawing.Point(146, 25);
            this.requestLimit.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
            this.requestLimit.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            this.requestLimit.Name = "requestLimit";
            this.requestLimit.Size = new System.Drawing.Size(65, 20);
            this.requestLimit.TabIndex = 1;
            this.requestLimit.Value = new decimal(new int[] { 5, 0, 0, 0 });
            //
            // connectionsLabel
            //
            this.connectionsLabel.AutoSize = true;
            this.connectionsLabel.Location = new System.Drawing.Point(15, 53);
            this.connectionsLabel.Name = "connectionsLabel";
            this.connectionsLabel.Size = new System.Drawing.Size(75, 13);
            this.connectionsLabel.TabIndex = 2;
            this.connectionsLabel.Text = "Клиентов";
            //
            // connectionLimit
            //
            this.connectionLimit.Location = new System.Drawing.Point(146, 49);
            this.connectionLimit.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            this.connectionLimit.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            this.connectionLimit.Name = "connectionLimit";
            this.connectionLimit.Size = new System.Drawing.Size(60, 20);
            this.connectionLimit.TabIndex = 3;
            this.connectionLimit.Value = new decimal(new int[] { 10, 0, 0, 0 });
            //
            // settingsButton
            //
            this.settingsButton.Location = new System.Drawing.Point(142, 78);
            this.settingsButton.Name = "settingsButton";
            this.settingsButton.Size = new System.Drawing.Size(100, 24);
            this.settingsButton.TabIndex = 4;
            this.settingsButton.Text = "Применить";
            this.settingsButton.UseVisualStyleBackColor = true;
            this.settingsButton.Click += new System.EventHandler(this.settingsButton_Click);
            //
            // userGroup
            //
            this.userGroup.Controls.Add(this.usersLabel);
            this.userGroup.Controls.Add(this.newLogin);
            this.userGroup.Controls.Add(this.userPasswordLabel);
            this.userGroup.Controls.Add(this.newPassword);
            this.userGroup.Controls.Add(this.addUserButton);
            this.userGroup.Location = new System.Drawing.Point(305, 72);
            this.userGroup.Name = "userGroup";
            this.userGroup.Size = new System.Drawing.Size(269, 114);
            this.userGroup.TabIndex = 6;
            this.userGroup.TabStop = false;
            this.userGroup.Text = "Пользователь";
            //
            // usersLabel
            //
            this.usersLabel.AutoSize = true;
            this.usersLabel.Location = new System.Drawing.Point(14, 25);
            this.usersLabel.Name = "usersLabel";
            this.usersLabel.Size = new System.Drawing.Size(48, 13);
            this.usersLabel.TabIndex = 0;
            this.usersLabel.Text = "Логин";
            //
            // newLogin
            //
            this.newLogin.Location = new System.Drawing.Point(83, 21);
            this.newLogin.Name = "newLogin";
            this.newLogin.Size = new System.Drawing.Size(153, 20);
            this.newLogin.TabIndex = 1;
            this.newLogin.Text = "student";
            //
            // userPasswordLabel
            //
            this.userPasswordLabel.AutoSize = true;
            this.userPasswordLabel.Location = new System.Drawing.Point(14, 53);
            this.userPasswordLabel.Name = "userPasswordLabel";
            this.userPasswordLabel.Size = new System.Drawing.Size(50, 13);
            this.userPasswordLabel.TabIndex = 2;
            this.userPasswordLabel.Text = "Пароль";
            //
            // newPassword
            //
            this.newPassword.Location = new System.Drawing.Point(83, 54);
            this.newPassword.Name = "newPassword";
            this.newPassword.Size = new System.Drawing.Size(127, 20);
            this.newPassword.TabIndex = 3;
            this.newPassword.Text = "123";
            this.newPassword.UseSystemPasswordChar = true;
            //
            // addUserButton
            //
            this.addUserButton.Location = new System.Drawing.Point(130, 78);
            this.addUserButton.Name = "addUserButton";
            this.addUserButton.Size = new System.Drawing.Size(106, 25);
            this.addUserButton.TabIndex = 4;
            this.addUserButton.Text = "Сохранить";
            this.addUserButton.UseVisualStyleBackColor = true;
            this.addUserButton.Click += new System.EventHandler(this.addUserButton_Click);
            //
            // rateGroup
            //
            this.rateGroup.Controls.Add(this.rateLabel);
            this.rateGroup.Controls.Add(this.rateCurrency);
            this.rateGroup.Controls.Add(this.rateValue);
            this.rateGroup.Controls.Add(this.rublesLabel);
            this.rateGroup.Controls.Add(this.rateButton);
            this.rateGroup.Location = new System.Drawing.Point(22, 200);
            this.rateGroup.Name = "rateGroup";
            this.rateGroup.Size = new System.Drawing.Size(504, 55);
            this.rateGroup.TabIndex = 7;
            this.rateGroup.TabStop = false;
            this.rateGroup.Text = "Учебные курсы";
            //
            // rateLabel
            //
            this.rateLabel.AutoSize = true;
            this.rateLabel.Location = new System.Drawing.Point(12, 25);
            this.rateLabel.Name = "rateLabel";
            this.rateLabel.Size = new System.Drawing.Size(65, 13);
            this.rateLabel.TabIndex = 0;
            this.rateLabel.Text = "1 единица";
            //
            // rateCurrency
            //
            this.rateCurrency.Items.AddRange(new object[] {
                "USD",
                "EURO",
                "GBP",
                "CNY",
                "RUB"});
            this.rateCurrency.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.rateCurrency.FormattingEnabled = true;
            this.rateCurrency.Location = new System.Drawing.Point(82, 21);
            this.rateCurrency.Name = "rateCurrency";
            this.rateCurrency.Size = new System.Drawing.Size(88, 21);
            this.rateCurrency.TabIndex = 1;
            //
            // rateValue
            //
            this.rateValue.Location = new System.Drawing.Point(248, 28);
            this.rateValue.Name = "rateValue";
            this.rateValue.Size = new System.Drawing.Size(70, 20);
            this.rateValue.TabIndex = 2;
            this.rateValue.Text = "90";
            //
            // rublesLabel
            //
            this.rublesLabel.AutoSize = true;
            this.rublesLabel.Location = new System.Drawing.Point(194, 31);
            this.rublesLabel.Name = "rublesLabel";
            this.rublesLabel.Size = new System.Drawing.Size(50, 13);
            this.rublesLabel.TabIndex = 3;
            this.rublesLabel.Text = "Рублей";
            //
            // rateButton
            //
            this.rateButton.Location = new System.Drawing.Point(340, 17);
            this.rateButton.Name = "rateButton";
            this.rateButton.Size = new System.Drawing.Size(131, 26);
            this.rateButton.TabIndex = 4;
            this.rateButton.Text = "Установить курс";
            this.rateButton.UseVisualStyleBackColor = true;
            this.rateButton.Click += new System.EventHandler(this.rateButton_Click);
            //
            // logFileLabel
            //
            this.logFileLabel.AutoSize = true;
            this.logFileLabel.Location = new System.Drawing.Point(17, 269);
            this.logFileLabel.Name = "logFileLabel";
            this.logFileLabel.Size = new System.Drawing.Size(564, 13);
            this.logFileLabel.TabIndex = 8;
            this.logFileLabel.Text = "Журнал (server.log)";
            //
            // serverLog
            //
            this.serverLog.FormattingEnabled = true;
            this.serverLog.HorizontalScrollbar = true;
            this.serverLog.IntegralHeight = false;
            this.serverLog.Location = new System.Drawing.Point(14, 288);
            this.serverLog.Name = "serverLog";
            this.serverLog.Size = new System.Drawing.Size(552, 124);
            this.serverLog.TabIndex = 9;
            this.serverLog.TabStop = false;
            //
            // clientAddressLabel
            //
            this.clientAddressLabel.AutoSize = true;
            this.clientAddressLabel.Location = new System.Drawing.Point(16, 20);
            this.clientAddressLabel.Name = "clientAddressLabel";
            this.clientAddressLabel.Size = new System.Drawing.Size(65, 13);
            this.clientAddressLabel.TabIndex = 0;
            this.clientAddressLabel.Text = "IP-адрес";
            //
            // clientIp
            //
            this.clientIp.Location = new System.Drawing.Point(81, 17);
            this.clientIp.Name = "clientIp";
            this.clientIp.Size = new System.Drawing.Size(136, 20);
            this.clientIp.TabIndex = 1;
            this.clientIp.Text = "127.0.0.1";
            //
            // clientPortLabel
            //
            this.clientPortLabel.AutoSize = true;
            this.clientPortLabel.Location = new System.Drawing.Point(232, 31);
            this.clientPortLabel.Name = "clientPortLabel";
            this.clientPortLabel.Size = new System.Drawing.Size(35, 13);
            this.clientPortLabel.TabIndex = 2;
            this.clientPortLabel.Text = "Порт";
            //
            // clientPort
            //
            this.clientPort.Location = new System.Drawing.Point(275, 27);
            this.clientPort.Maximum = new decimal(new int[] { 65535, 0, 0, 0 });
            this.clientPort.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            this.clientPort.Name = "clientPort";
            this.clientPort.Size = new System.Drawing.Size(62, 20);
            this.clientPort.TabIndex = 3;
            this.clientPort.Value = new decimal(new int[] { 5102, 0, 0, 0 });
            //
            // connectButton
            //
            this.connectButton.Location = new System.Drawing.Point(403, 12);
            this.connectButton.Name = "connectButton";
            this.connectButton.Size = new System.Drawing.Size(122, 25);
            this.connectButton.TabIndex = 4;
            this.connectButton.Text = "Подключиться";
            this.connectButton.UseVisualStyleBackColor = true;
            this.connectButton.Click += new System.EventHandler(this.connectButton_Click);
            //
            // disconnectButton
            //
            this.disconnectButton.Enabled = false;
            this.disconnectButton.Location = new System.Drawing.Point(425, 45);
            this.disconnectButton.Name = "disconnectButton";
            this.disconnectButton.Size = new System.Drawing.Size(100, 25);
            this.disconnectButton.TabIndex = 5;
            this.disconnectButton.Text = "Отключиться";
            this.disconnectButton.UseVisualStyleBackColor = true;
            this.disconnectButton.Click += new System.EventHandler(this.disconnectButton_Click);
            //
            // loginLabel
            //
            this.loginLabel.AutoSize = true;
            this.loginLabel.Location = new System.Drawing.Point(16, 62);
            this.loginLabel.Name = "loginLabel";
            this.loginLabel.Size = new System.Drawing.Size(50, 13);
            this.loginLabel.TabIndex = 6;
            this.loginLabel.Text = "Логин";
            //
            // loginText
            //
            this.loginText.Location = new System.Drawing.Point(81, 59);
            this.loginText.Name = "loginText";
            this.loginText.Size = new System.Drawing.Size(120, 20);
            this.loginText.TabIndex = 7;
            this.loginText.Text = "student";
            //
            // passwordLabel
            //
            this.passwordLabel.AutoSize = true;
            this.passwordLabel.Location = new System.Drawing.Point(218, 74);
            this.passwordLabel.Name = "passwordLabel";
            this.passwordLabel.Size = new System.Drawing.Size(50, 13);
            this.passwordLabel.TabIndex = 8;
            this.passwordLabel.Text = "Пароль";
            //
            // passwordText
            //
            this.passwordText.Location = new System.Drawing.Point(276, 70);
            this.passwordText.Name = "passwordText";
            this.passwordText.Size = new System.Drawing.Size(110, 20);
            this.passwordText.TabIndex = 9;
            this.passwordText.Text = "123";
            this.passwordText.UseSystemPasswordChar = true;
            //
            // requestLabel
            //
            this.requestLabel.AutoSize = true;
            this.requestLabel.Location = new System.Drawing.Point(17, 105);
            this.requestLabel.Name = "requestLabel";
            this.requestLabel.Size = new System.Drawing.Size(564, 13);
            this.requestLabel.TabIndex = 10;
            this.requestLabel.Text = "Две валюты через пробел (например USD EURO)";
            //
            // requestText
            //
            this.requestText.Location = new System.Drawing.Point(16, 124);
            this.requestText.Name = "requestText";
            this.requestText.Size = new System.Drawing.Size(400, 20);
            this.requestText.TabIndex = 11;
            this.requestText.Text = "USD EURO";
            //
            // sendButton
            //
            this.sendButton.Enabled = false;
            this.sendButton.Location = new System.Drawing.Point(35, 155);
            this.sendButton.Name = "sendButton";
            this.sendButton.Size = new System.Drawing.Size(120, 25);
            this.sendButton.TabIndex = 12;
            this.sendButton.Text = "Отправить";
            this.sendButton.UseVisualStyleBackColor = true;
            this.sendButton.Click += new System.EventHandler(this.sendButton_Click);
            //
            // responseLabel
            //
            this.responseLabel.AutoSize = true;
            this.responseLabel.Location = new System.Drawing.Point(17, 198);
            this.responseLabel.Name = "responseLabel";
            this.responseLabel.Size = new System.Drawing.Size(100, 13);
            this.responseLabel.TabIndex = 13;
            this.responseLabel.Text = "Ответы сервера";
            //
            // clientLog
            //
            this.clientLog.Location = new System.Drawing.Point(14, 218);
            this.clientLog.Multiline = true;
            this.clientLog.Name = "clientLog";
            this.clientLog.ReadOnly = true;
            this.clientLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.clientLog.Size = new System.Drawing.Size(552, 194);
            this.clientLog.TabIndex = 14;
            this.clientLog.TabStop = false;
            //
            // Form1
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(620, 474);
            this.Controls.Add(this.tabs);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Курс валют";
            ((System.ComponentModel.ISupportInitialize)(this.serverPort)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.requestLimit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.connectionLimit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.clientPort)).EndInit();
            this.rateGroup.ResumeLayout(false);
            this.rateGroup.PerformLayout();
            this.userGroup.ResumeLayout(false);
            this.userGroup.PerformLayout();
            this.limitsGroup.ResumeLayout(false);
            this.limitsGroup.PerformLayout();
            this.clientTab.ResumeLayout(false);
            this.clientTab.PerformLayout();
            this.serverTab.ResumeLayout(false);
            this.serverTab.PerformLayout();
            this.tabs.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.TabControl tabs;
        private System.Windows.Forms.TabPage serverTab;
        private System.Windows.Forms.TabPage clientTab;
        private System.Windows.Forms.Label serverAddressLabel;
        private System.Windows.Forms.TextBox serverIp;
        private System.Windows.Forms.Label serverPortLabel;
        private System.Windows.Forms.NumericUpDown serverPort;
        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.GroupBox limitsGroup;
        private System.Windows.Forms.Label limitLabel;
        private System.Windows.Forms.NumericUpDown requestLimit;
        private System.Windows.Forms.Label connectionsLabel;
        private System.Windows.Forms.NumericUpDown connectionLimit;
        private System.Windows.Forms.Button settingsButton;
        private System.Windows.Forms.GroupBox userGroup;
        private System.Windows.Forms.Label usersLabel;
        private System.Windows.Forms.TextBox newLogin;
        private System.Windows.Forms.Label userPasswordLabel;
        private System.Windows.Forms.TextBox newPassword;
        private System.Windows.Forms.Button addUserButton;
        private System.Windows.Forms.GroupBox rateGroup;
        private System.Windows.Forms.Label rateLabel;
        private System.Windows.Forms.ComboBox rateCurrency;
        private System.Windows.Forms.TextBox rateValue;
        private System.Windows.Forms.Label rublesLabel;
        private System.Windows.Forms.Button rateButton;
        private System.Windows.Forms.Label logFileLabel;
        private System.Windows.Forms.ListBox serverLog;
        private System.Windows.Forms.Label clientAddressLabel;
        private System.Windows.Forms.TextBox clientIp;
        private System.Windows.Forms.Label clientPortLabel;
        private System.Windows.Forms.NumericUpDown clientPort;
        private System.Windows.Forms.Button connectButton;
        private System.Windows.Forms.Button disconnectButton;
        private System.Windows.Forms.Label loginLabel;
        private System.Windows.Forms.TextBox loginText;
        private System.Windows.Forms.Label passwordLabel;
        private System.Windows.Forms.TextBox passwordText;
        private System.Windows.Forms.Label requestLabel;
        private System.Windows.Forms.TextBox requestText;
        private System.Windows.Forms.Button sendButton;
        private System.Windows.Forms.Label responseLabel;
        private System.Windows.Forms.TextBox clientLog;
    }
}
