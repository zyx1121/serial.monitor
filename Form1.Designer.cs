using System.IO.Ports;
using System.Text;

namespace SerialMonitor
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            ASCIIEncoding asciiEncodingSealed1 = new ASCIIEncoding();
            DecoderReplacementFallback decoderReplacementFallback1 = new DecoderReplacementFallback();
            EncoderReplacementFallback encoderReplacementFallback1 = new EncoderReplacementFallback();
            serialPort = new SerialPort(components);
            Monitor = new TextBox();
            textBoxSend = new TextBox();
            buttonSend = new Button();
            comboBoxPort = new ComboBox();
            labelPort = new Label();
            labelBaudRate = new Label();
            labelParity = new Label();
            comboBoxParity = new ComboBox();
            buttonOpen = new Button();
            comboBoxBautRate = new ComboBox();
            labelMonitorMode = new Label();
            comboBoxMonitorMode = new ComboBox();
            buttonClear = new Button();
            labelSendMode = new Label();
            comboBoxSendMode = new ComboBox();
            SuspendLayout();
            // 
            // serialPort
            // 
            serialPort.BaudRate = 9600;
            serialPort.DataBits = 8;
            serialPort.DiscardNull = false;
            serialPort.DtrEnable = false;
            serialPort.Handshake = Handshake.None;
            serialPort.NewLine = "\n";
            serialPort.Parity = Parity.None;
            serialPort.ParityReplace = 63;
            serialPort.PortName = "COM1";
            serialPort.ReadBufferSize = 1024;
            serialPort.ReadTimeout = 100;
            serialPort.ReceivedBytesThreshold = 1024;
            serialPort.RtsEnable = false;
            serialPort.StopBits = StopBits.One;
            serialPort.WriteBufferSize = 1024;
            serialPort.WriteTimeout = 100;
            serialPort.DataReceived += SerialPort_DataReceived;
            // 
            // Monitor
            // 
            Monitor.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            Monitor.BackColor = SystemColors.Window;
            Monitor.CausesValidation = false;
            Monitor.Font = new Font("Consolas", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Monitor.Location = new Point(12, 40);
            Monitor.MaxLength = 32;
            Monitor.Multiline = true;
            Monitor.Name = "Monitor";
            Monitor.ReadOnly = true;
            Monitor.ScrollBars = ScrollBars.Vertical;
            Monitor.Size = new Size(624, 356);
            Monitor.TabIndex = 6;
            Monitor.TabStop = false;
            Monitor.Text = "Hello, Serial Monitor!";
            // 
            // textBoxSend
            // 
            textBoxSend.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            textBoxSend.Enabled = false;
            textBoxSend.Font = new Font("Consolas", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBoxSend.Location = new Point(12, 430);
            textBoxSend.Name = "textBoxSend";
            textBoxSend.Size = new Size(538, 22);
            textBoxSend.TabIndex = 0;
            textBoxSend.KeyPress += TextBoxSend_KeyPress;
            // 
            // buttonSend
            // 
            buttonSend.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonSend.Enabled = false;
            buttonSend.Location = new Point(556, 431);
            buttonSend.Name = "buttonSend";
            buttonSend.Size = new Size(80, 23);
            buttonSend.TabIndex = 7;
            buttonSend.Text = "Send";
            buttonSend.UseVisualStyleBackColor = true;
            buttonSend.Click += ButtonSend_Click;
            // 
            // comboBoxPort
            // 
            comboBoxPort.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxPort.FormattingEnabled = true;
            comboBoxPort.Location = new Point(60, 12);
            comboBoxPort.Name = "comboBoxPort";
            comboBoxPort.Size = new Size(80, 22);
            comboBoxPort.TabIndex = 8;
            // 
            // labelPort
            // 
            labelPort.AutoSize = true;
            labelPort.Location = new Point(12, 15);
            labelPort.Name = "labelPort";
            labelPort.Size = new Size(42, 14);
            labelPort.TabIndex = 9;
            labelPort.Text = "Port:";
            // 
            // labelBaudRate
            // 
            labelBaudRate.AutoSize = true;
            labelBaudRate.Location = new Point(160, 15);
            labelBaudRate.Name = "labelBaudRate";
            labelBaudRate.Size = new Size(70, 14);
            labelBaudRate.TabIndex = 10;
            labelBaudRate.Text = "BautRate:";
            // 
            // labelParity
            // 
            labelParity.AutoSize = true;
            labelParity.Location = new Point(339, 15);
            labelParity.Name = "labelParity";
            labelParity.Size = new Size(56, 14);
            labelParity.TabIndex = 12;
            labelParity.Text = "Parity:";
            // 
            // comboBoxParity
            // 
            comboBoxParity.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxParity.FormattingEnabled = true;
            comboBoxParity.Items.AddRange(new object[] { "NONE", "ODD", "EVEN" });
            comboBoxParity.Location = new Point(401, 12);
            comboBoxParity.Name = "comboBoxParity";
            comboBoxParity.RightToLeft = RightToLeft.No;
            comboBoxParity.Size = new Size(60, 22);
            comboBoxParity.TabIndex = 13;
            // 
            // buttonOpen
            // 
            buttonOpen.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            buttonOpen.Location = new Point(536, 11);
            buttonOpen.Name = "buttonOpen";
            buttonOpen.Size = new Size(100, 23);
            buttonOpen.TabIndex = 14;
            buttonOpen.Text = "Open Port";
            buttonOpen.UseVisualStyleBackColor = true;
            buttonOpen.Click += ButtonOpen_Click;
            // 
            // comboBoxBautRate
            // 
            comboBoxBautRate.FormattingEnabled = true;
            comboBoxBautRate.Items.AddRange(new object[] { "300", "1200", "2400", "9600", "19200", "38400", "115200", "921600" });
            comboBoxBautRate.Location = new Point(236, 12);
            comboBoxBautRate.Name = "comboBoxBautRate";
            comboBoxBautRate.Size = new Size(80, 22);
            comboBoxBautRate.TabIndex = 15;
            comboBoxBautRate.Text = "115200";
            // 
            // labelMonitorMode
            // 
            labelMonitorMode.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            labelMonitorMode.AutoSize = true;
            labelMonitorMode.Location = new Point(12, 405);
            labelMonitorMode.Name = "labelMonitorMode";
            labelMonitorMode.Size = new Size(91, 14);
            labelMonitorMode.TabIndex = 18;
            labelMonitorMode.Text = "MonitorMode:";
            // 
            // comboBoxMonitorMode
            // 
            comboBoxMonitorMode.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            comboBoxMonitorMode.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxMonitorMode.FormattingEnabled = true;
            comboBoxMonitorMode.Items.AddRange(new object[] { "Ascii", "Binary", "Hex", "MagTest" });
            comboBoxMonitorMode.Location = new Point(109, 402);
            comboBoxMonitorMode.Name = "comboBoxMonitorMode";
            comboBoxMonitorMode.Size = new Size(80, 22);
            comboBoxMonitorMode.TabIndex = 19;
            comboBoxMonitorMode.SelectedIndexChanged += ComboBoxMonitorMode_SelectedIndexChanged;
            // 
            // buttonClear
            // 
            buttonClear.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonClear.Location = new Point(536, 402);
            buttonClear.Name = "buttonClear";
            buttonClear.Size = new Size(100, 23);
            buttonClear.TabIndex = 20;
            buttonClear.Text = "Clear";
            buttonClear.UseVisualStyleBackColor = true;
            buttonClear.Click += ButtonClear_Click;
            // 
            // labelSendMode
            // 
            labelSendMode.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            labelSendMode.AutoSize = true;
            labelSendMode.Enabled = false;
            labelSendMode.Location = new Point(216, 406);
            labelSendMode.Name = "labelSendMode";
            labelSendMode.Size = new Size(70, 14);
            labelSendMode.TabIndex = 16;
            labelSendMode.Text = "SendMode:";
            // 
            // comboBoxSendMode
            // 
            comboBoxSendMode.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            comboBoxSendMode.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxSendMode.Enabled = false;
            comboBoxSendMode.FormattingEnabled = true;
            comboBoxSendMode.Items.AddRange(new object[] { "Ascii", "Binary", "Hex" });
            comboBoxSendMode.Location = new Point(292, 402);
            comboBoxSendMode.Name = "comboBoxSendMode";
            comboBoxSendMode.Size = new Size(80, 22);
            comboBoxSendMode.TabIndex = 17;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 14F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            ClientSize = new Size(648, 465);
            Controls.Add(buttonClear);
            Controls.Add(comboBoxMonitorMode);
            Controls.Add(labelMonitorMode);
            Controls.Add(comboBoxSendMode);
            Controls.Add(labelSendMode);
            Controls.Add(comboBoxBautRate);
            Controls.Add(buttonOpen);
            Controls.Add(comboBoxParity);
            Controls.Add(labelParity);
            Controls.Add(labelBaudRate);
            Controls.Add(labelPort);
            Controls.Add(comboBoxPort);
            Controls.Add(buttonSend);
            Controls.Add(Monitor);
            Controls.Add(textBoxSend);
            Font = new Font("Consolas", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Name = "Form1";
            ShowIcon = false;
            Text = "Serial Monitor - Device Offline";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private SerialPort serialPort;
        private TextBox Monitor;
        private TextBox textBoxSend;
        private Button buttonSend;
        private ComboBox comboBoxPort;
        private Label labelPort;
        private Label labelBaudRate;
        private Label labelParity;
        private ComboBox comboBoxParity;
        private Button buttonOpen;
        private ComboBox comboBoxBautRate;
        private Label labelMonitorMode;
        private ComboBox comboBoxMonitorMode;
        private Button buttonClear;
        private Label labelSendMode;
        private ComboBox comboBoxSendMode;
    }
}