namespace Recipes
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

        #region Код, созданный конструктором форм Windows

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
            this.periodLabel = new System.Windows.Forms.Label();
            this.periodMinutes = new System.Windows.Forms.NumericUpDown();
            this.settingsButton = new System.Windows.Forms.Button();
            this.logFileLabel = new System.Windows.Forms.Label();
            this.serverLog = new System.Windows.Forms.ListBox();
            this.clientAddressLabel = new System.Windows.Forms.Label();
            this.clientIp = new System.Windows.Forms.TextBox();
            this.clientPortLabel = new System.Windows.Forms.Label();
            this.clientPort = new System.Windows.Forms.NumericUpDown();
            this.connectButton = new System.Windows.Forms.Button();
            this.disconnectButton = new System.Windows.Forms.Button();
            this.requestLabel = new System.Windows.Forms.Label();
            this.requestText = new System.Windows.Forms.TextBox();
            this.sendButton = new System.Windows.Forms.Button();
            this.responseLabel = new System.Windows.Forms.Label();
            this.clientLog = new System.Windows.Forms.TextBox();
            this.tabs.SuspendLayout();
            this.serverTab.SuspendLayout();
            this.clientTab.SuspendLayout();
            this.limitsGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.serverPort)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.requestLimit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.periodMinutes)).BeginInit();
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
            this.tabs.Size = new System.Drawing.Size(596, 334);
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
            this.serverTab.Controls.Add(this.logFileLabel);
            this.serverTab.Controls.Add(this.serverLog);
            this.serverTab.Location = new System.Drawing.Point(4, 22);
            this.serverTab.Name = "serverTab";
            this.serverTab.Padding = new System.Windows.Forms.Padding(3);
            this.serverTab.Size = new System.Drawing.Size(588, 308);
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
            this.clientTab.Controls.Add(this.requestLabel);
            this.clientTab.Controls.Add(this.requestText);
            this.clientTab.Controls.Add(this.sendButton);
            this.clientTab.Controls.Add(this.responseLabel);
            this.clientTab.Controls.Add(this.clientLog);
            this.clientTab.Location = new System.Drawing.Point(4, 22);
            this.clientTab.Name = "clientTab";
            this.clientTab.Padding = new System.Windows.Forms.Padding(3);
            this.clientTab.Size = new System.Drawing.Size(588, 308);
            this.clientTab.TabIndex = 1;
            this.clientTab.Text = "Клиент";
            this.clientTab.UseVisualStyleBackColor = true;
            //
            // serverAddressLabel
            //
            this.serverAddressLabel.AutoSize = true;
            this.serverAddressLabel.Location = new System.Drawing.Point(16, 16);
            this.serverAddressLabel.Name = "serverAddressLabel";
            this.serverAddressLabel.Size = new System.Drawing.Size(65, 13);
            this.serverAddressLabel.TabIndex = 0;
            this.serverAddressLabel.Text = "IP-адрес";
            //
            // serverIp
            //
            this.serverIp.Location = new System.Drawing.Point(16, 34);
            this.serverIp.Name = "serverIp";
            this.serverIp.Size = new System.Drawing.Size(140, 20);
            this.serverIp.TabIndex = 1;
            this.serverIp.Text = "127.0.0.1";
            //
            // serverPortLabel
            //
            this.serverPortLabel.AutoSize = true;
            this.serverPortLabel.Location = new System.Drawing.Point(174, 28);
            this.serverPortLabel.Name = "serverPortLabel";
            this.serverPortLabel.Size = new System.Drawing.Size(35, 13);
            this.serverPortLabel.TabIndex = 2;
            this.serverPortLabel.Text = "Порт";
            //
            // serverPort
            //
            this.serverPort.Location = new System.Drawing.Point(174, 47);
            this.serverPort.Maximum = new decimal(new int[] { 65535, 0, 0, 0 });
            this.serverPort.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            this.serverPort.Name = "serverPort";
            this.serverPort.Size = new System.Drawing.Size(57, 20);
            this.serverPort.TabIndex = 3;
            this.serverPort.Value = new decimal(new int[] { 5103, 0, 0, 0 });
            //
            // startButton
            //
            this.startButton.Location = new System.Drawing.Point(34, 74);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(133, 26);
            this.startButton.TabIndex = 4;
            this.startButton.Text = "Запустить сервер";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            //
            // limitsGroup
            //
            this.limitsGroup.Controls.Add(this.limitLabel);
            this.limitsGroup.Controls.Add(this.requestLimit);
            this.limitsGroup.Controls.Add(this.periodLabel);
            this.limitsGroup.Controls.Add(this.periodMinutes);
            this.limitsGroup.Controls.Add(this.settingsButton);
            this.limitsGroup.Location = new System.Drawing.Point(257, 18);
            this.limitsGroup.Name = "limitsGroup";
            this.limitsGroup.Size = new System.Drawing.Size(314, 115);
            this.limitsGroup.TabIndex = 5;
            this.limitsGroup.TabStop = false;
            this.limitsGroup.Text = "Ограничения";
            //
            // limitLabel
            //
            this.limitLabel.AutoSize = true;
            this.limitLabel.Location = new System.Drawing.Point(14, 24);
            this.limitLabel.Name = "limitLabel";
            this.limitLabel.Size = new System.Drawing.Size(80, 13);
            this.limitLabel.TabIndex = 0;
            this.limitLabel.Text = "Запросов";
            //
            // requestLimit
            //
            this.requestLimit.Location = new System.Drawing.Point(125, 26);
            this.requestLimit.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
            this.requestLimit.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            this.requestLimit.Name = "requestLimit";
            this.requestLimit.Size = new System.Drawing.Size(65, 20);
            this.requestLimit.TabIndex = 1;
            this.requestLimit.Value = new decimal(new int[] { 10, 0, 0, 0 });
            //
            // periodLabel
            //
            this.periodLabel.AutoSize = true;
            this.periodLabel.Location = new System.Drawing.Point(14, 52);
            this.periodLabel.Name = "periodLabel";
            this.periodLabel.Size = new System.Drawing.Size(78, 13);
            this.periodLabel.TabIndex = 2;
            this.periodLabel.Text = "Период, мин.";
            //
            // periodMinutes
            //
            this.periodMinutes.Location = new System.Drawing.Point(125, 49);
            this.periodMinutes.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
            this.periodMinutes.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            this.periodMinutes.Name = "periodMinutes";
            this.periodMinutes.Size = new System.Drawing.Size(60, 20);
            this.periodMinutes.TabIndex = 3;
            this.periodMinutes.Value = new decimal(new int[] { 60, 0, 0, 0 });
            //
            // settingsButton
            //
            this.settingsButton.Location = new System.Drawing.Point(188, 79);
            this.settingsButton.Name = "settingsButton";
            this.settingsButton.Size = new System.Drawing.Size(104, 25);
            this.settingsButton.TabIndex = 4;
            this.settingsButton.Text = "Применить";
            this.settingsButton.UseVisualStyleBackColor = true;
            this.settingsButton.Click += new System.EventHandler(this.settingsButton_Click);
            //
            // logFileLabel
            //
            this.logFileLabel.AutoSize = true;
            this.logFileLabel.Location = new System.Drawing.Point(17, 145);
            this.logFileLabel.Name = "logFileLabel";
            this.logFileLabel.Size = new System.Drawing.Size(564, 13);
            this.logFileLabel.TabIndex = 6;
            this.logFileLabel.Text = "Журнал (server.log)";
            //
            // serverLog
            //
            this.serverLog.FormattingEnabled = true;
            this.serverLog.HorizontalScrollbar = true;
            this.serverLog.IntegralHeight = false;
            this.serverLog.Location = new System.Drawing.Point(14, 164);
            this.serverLog.Name = "serverLog";
            this.serverLog.Size = new System.Drawing.Size(552, 130);
            this.serverLog.TabIndex = 7;
            this.serverLog.TabStop = false;
            //
            // clientAddressLabel
            //
            this.clientAddressLabel.AutoSize = true;
            this.clientAddressLabel.Location = new System.Drawing.Point(16, 17);
            this.clientAddressLabel.Name = "clientAddressLabel";
            this.clientAddressLabel.Size = new System.Drawing.Size(65, 13);
            this.clientAddressLabel.TabIndex = 0;
            this.clientAddressLabel.Text = "IP-адрес";
            //
            // clientIp
            //
            this.clientIp.Location = new System.Drawing.Point(86, 14);
            this.clientIp.Name = "clientIp";
            this.clientIp.Size = new System.Drawing.Size(142, 20);
            this.clientIp.TabIndex = 1;
            this.clientIp.Text = "127.0.0.1";
            //
            // clientPortLabel
            //
            this.clientPortLabel.AutoSize = true;
            this.clientPortLabel.Location = new System.Drawing.Point(19, 47);
            this.clientPortLabel.Name = "clientPortLabel";
            this.clientPortLabel.Size = new System.Drawing.Size(35, 13);
            this.clientPortLabel.TabIndex = 2;
            this.clientPortLabel.Text = "Порт";
            //
            // clientPort
            //
            this.clientPort.Location = new System.Drawing.Point(86, 43);
            this.clientPort.Maximum = new decimal(new int[] { 65535, 0, 0, 0 });
            this.clientPort.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            this.clientPort.Name = "clientPort";
            this.clientPort.Size = new System.Drawing.Size(57, 20);
            this.clientPort.TabIndex = 3;
            this.clientPort.Value = new decimal(new int[] { 5103, 0, 0, 0 });
            //
            // connectButton
            //
            this.connectButton.Location = new System.Drawing.Point(278, 22);
            this.connectButton.Name = "connectButton";
            this.connectButton.Size = new System.Drawing.Size(121, 26);
            this.connectButton.TabIndex = 4;
            this.connectButton.Text = "Подключиться";
            this.connectButton.UseVisualStyleBackColor = true;
            this.connectButton.Click += new System.EventHandler(this.connectButton_Click);
            //
            // disconnectButton
            //
            this.disconnectButton.Enabled = false;
            this.disconnectButton.Location = new System.Drawing.Point(418, 34);
            this.disconnectButton.Name = "disconnectButton";
            this.disconnectButton.Size = new System.Drawing.Size(110, 24);
            this.disconnectButton.TabIndex = 5;
            this.disconnectButton.Text = "Отключиться";
            this.disconnectButton.UseVisualStyleBackColor = true;
            this.disconnectButton.Click += new System.EventHandler(this.disconnectButton_Click);
            //
            // requestLabel
            //
            this.requestLabel.AutoSize = true;
            this.requestLabel.Location = new System.Drawing.Point(16, 86);
            this.requestLabel.Name = "requestLabel";
            this.requestLabel.Size = new System.Drawing.Size(564, 13);
            this.requestLabel.TabIndex = 6;
            this.requestLabel.Text = "Продукты через запятую";
            //
            // requestText
            //
            this.requestText.Location = new System.Drawing.Point(15, 105);
            this.requestText.Name = "requestText";
            this.requestText.Size = new System.Drawing.Size(485, 20);
            this.requestText.TabIndex = 7;
            this.requestText.Text = "яйца, молоко";
            //
            // sendButton
            //
            this.sendButton.Enabled = false;
            this.sendButton.Location = new System.Drawing.Point(402, 138);
            this.sendButton.Name = "sendButton";
            this.sendButton.Size = new System.Drawing.Size(109, 25);
            this.sendButton.TabIndex = 8;
            this.sendButton.Text = "Отправить";
            this.sendButton.UseVisualStyleBackColor = true;
            this.sendButton.Click += new System.EventHandler(this.sendButton_Click);
            //
            // responseLabel
            //
            this.responseLabel.AutoSize = true;
            this.responseLabel.Location = new System.Drawing.Point(17, 171);
            this.responseLabel.Name = "responseLabel";
            this.responseLabel.Size = new System.Drawing.Size(100, 13);
            this.responseLabel.TabIndex = 9;
            this.responseLabel.Text = "Ответы сервера";
            //
            // clientLog
            //
            this.clientLog.Location = new System.Drawing.Point(14, 190);
            this.clientLog.Multiline = true;
            this.clientLog.Name = "clientLog";
            this.clientLog.ReadOnly = true;
            this.clientLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.clientLog.Size = new System.Drawing.Size(553, 104);
            this.clientLog.TabIndex = 10;
            this.clientLog.TabStop = false;
            //
            // Form1
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(620, 358);
            this.Controls.Add(this.tabs);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Кулинарные рецепты";
            ((System.ComponentModel.ISupportInitialize)(this.serverPort)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.requestLimit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.periodMinutes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.clientPort)).EndInit();
            this.limitsGroup.ResumeLayout(false);
            this.limitsGroup.PerformLayout();
            this.clientTab.ResumeLayout(false);
            this.clientTab.PerformLayout();
            this.serverTab.ResumeLayout(false);
            this.serverTab.PerformLayout();
            this.tabs.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion

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
        private System.Windows.Forms.Label periodLabel;
        private System.Windows.Forms.NumericUpDown periodMinutes;
        private System.Windows.Forms.Button settingsButton;
        private System.Windows.Forms.Label logFileLabel;
        private System.Windows.Forms.ListBox serverLog;
        private System.Windows.Forms.Label clientAddressLabel;
        private System.Windows.Forms.TextBox clientIp;
        private System.Windows.Forms.Label clientPortLabel;
        private System.Windows.Forms.NumericUpDown clientPort;
        private System.Windows.Forms.Button connectButton;
        private System.Windows.Forms.Button disconnectButton;
        private System.Windows.Forms.Label requestLabel;
        private System.Windows.Forms.TextBox requestText;
        private System.Windows.Forms.Button sendButton;
        private System.Windows.Forms.Label responseLabel;
        private System.Windows.Forms.TextBox clientLog;
    }
}
