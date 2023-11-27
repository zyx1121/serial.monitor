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
            contextMenuStripMonitor = new ContextMenuStrip(components);
            toolStripComboBoxCOM = new ToolStripComboBox();
            toolStripComboBoxParity = new ToolStripComboBox();
            toolStripTextBoxBaudRate = new ToolStripTextBox();
            toolStripSeparator1 = new ToolStripSeparator();
            encodingToolStripMenuItem = new ToolStripMenuItem();
            asciiToolStripMenuItem = new ToolStripMenuItem();
            binaryToolStripMenuItem = new ToolStripMenuItem();
            hexToolStripMenuItem = new ToolStripMenuItem();
            toolStripMenuItemClear = new ToolStripMenuItem();
            toolStripSeparator2 = new ToolStripSeparator();
            toolStripMenuItemOpen = new ToolStripMenuItem();
            toolStripMenuItemClose = new ToolStripMenuItem();
            statusStrip = new StatusStrip();
            toolStripStatusCOM = new ToolStripStatusLabel();
            toolStripStatusBaudrate = new ToolStripStatusLabel();
            toolStripStatusParity = new ToolStripStatusLabel();
            Monitor = new TextBox();
            textBoxSend = new TextBox();
            contextMenuStripMonitor.SuspendLayout();
            statusStrip.SuspendLayout();
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
            // contextMenuStripMonitor
            // 
            contextMenuStripMonitor.Font = new Font("Fira Code", 8.999999F, FontStyle.Regular, GraphicsUnit.Point, 0);
            contextMenuStripMonitor.Items.AddRange(new ToolStripItem[] { toolStripComboBoxCOM, toolStripComboBoxParity, toolStripTextBoxBaudRate, toolStripSeparator1, encodingToolStripMenuItem, toolStripMenuItemClear, toolStripSeparator2, toolStripMenuItemOpen, toolStripMenuItemClose });
            contextMenuStripMonitor.Name = "contextMenuStrip1";
            contextMenuStripMonitor.ShowImageMargin = false;
            contextMenuStripMonitor.Size = new Size(161, 182);
            // 
            // toolStripComboBoxCOM
            // 
            toolStripComboBoxCOM.DropDownStyle = ComboBoxStyle.DropDownList;
            toolStripComboBoxCOM.Font = new Font("Fira Code", 8.999999F, FontStyle.Regular, GraphicsUnit.Point, 0);
            toolStripComboBoxCOM.Name = "toolStripComboBoxCOM";
            toolStripComboBoxCOM.Size = new Size(125, 23);
            toolStripComboBoxCOM.SelectedIndexChanged += toolStripComboBoxCOM_SelectedIndexChanged;
            // 
            // toolStripComboBoxParity
            // 
            toolStripComboBoxParity.DropDownStyle = ComboBoxStyle.DropDownList;
            toolStripComboBoxParity.DropDownWidth = 125;
            toolStripComboBoxParity.Font = new Font("Fira Code", 8.999999F, FontStyle.Regular, GraphicsUnit.Point, 0);
            toolStripComboBoxParity.Items.AddRange(new object[] { "NONE", "ODD", "EVEN" });
            toolStripComboBoxParity.Name = "toolStripComboBoxParity";
            toolStripComboBoxParity.Size = new Size(125, 23);
            toolStripComboBoxParity.SelectedIndexChanged += toolStripComboBoxParity_SelectedIndexChanged;
            // 
            // toolStripTextBoxBaudRate
            // 
            toolStripTextBoxBaudRate.Font = new Font("Fira Code", 8.999999F, FontStyle.Regular, GraphicsUnit.Point, 0);
            toolStripTextBoxBaudRate.Name = "toolStripTextBoxBaudRate";
            toolStripTextBoxBaudRate.Size = new Size(125, 22);
            toolStripTextBoxBaudRate.Text = "9600";
            toolStripTextBoxBaudRate.TextChanged += toolStripTextBoxBaudRate_TextChanged;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(157, 6);
            // 
            // encodingToolStripMenuItem
            // 
            encodingToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { asciiToolStripMenuItem, binaryToolStripMenuItem, hexToolStripMenuItem });
            encodingToolStripMenuItem.Name = "encodingToolStripMenuItem";
            encodingToolStripMenuItem.Size = new Size(160, 22);
            encodingToolStripMenuItem.Text = "ENCODING";
            // 
            // asciiToolStripMenuItem
            // 
            asciiToolStripMenuItem.Checked = true;
            asciiToolStripMenuItem.CheckState = CheckState.Checked;
            asciiToolStripMenuItem.Name = "asciiToolStripMenuItem";
            asciiToolStripMenuItem.Size = new Size(116, 22);
            asciiToolStripMenuItem.Text = "Ascii";
            asciiToolStripMenuItem.Click += asciiToolStripMenuItem_Click;
            // 
            // binaryToolStripMenuItem
            // 
            binaryToolStripMenuItem.Name = "binaryToolStripMenuItem";
            binaryToolStripMenuItem.Size = new Size(116, 22);
            binaryToolStripMenuItem.Text = "Binary";
            binaryToolStripMenuItem.Click += binaryToolStripMenuItem_Click;
            // 
            // hexToolStripMenuItem
            // 
            hexToolStripMenuItem.Name = "hexToolStripMenuItem";
            hexToolStripMenuItem.Size = new Size(116, 22);
            hexToolStripMenuItem.Text = "Hex";
            hexToolStripMenuItem.Click += hexToolStripMenuItem_Click;
            // 
            // toolStripMenuItemClear
            // 
            toolStripMenuItemClear.DisplayStyle = ToolStripItemDisplayStyle.Text;
            toolStripMenuItemClear.Name = "toolStripMenuItemClear";
            toolStripMenuItemClear.Size = new Size(160, 22);
            toolStripMenuItemClear.Text = "CLEAR";
            toolStripMenuItemClear.Click += toolStripMenuItemClear_Click;
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new Size(157, 6);
            // 
            // toolStripMenuItemOpen
            // 
            toolStripMenuItemOpen.Name = "toolStripMenuItemOpen";
            toolStripMenuItemOpen.Size = new Size(160, 22);
            toolStripMenuItemOpen.Text = "OPEN";
            toolStripMenuItemOpen.Click += toolStripMenuItemOpen_Click;
            // 
            // toolStripMenuItemClose
            // 
            toolStripMenuItemClose.Name = "toolStripMenuItemClose";
            toolStripMenuItemClose.Size = new Size(160, 22);
            toolStripMenuItemClose.Text = "CLOSE";
            toolStripMenuItemClose.Click += toolStripMenuItemClose_Click;
            // 
            // statusStrip
            // 
            statusStrip.Font = new Font("Fira Code", 8.999999F, FontStyle.Regular, GraphicsUnit.Point, 0);
            statusStrip.Items.AddRange(new ToolStripItem[] { toolStripStatusCOM, toolStripStatusBaudrate, toolStripStatusParity });
            statusStrip.Location = new Point(0, 539);
            statusStrip.Name = "statusStrip";
            statusStrip.RightToLeft = RightToLeft.No;
            statusStrip.Size = new Size(794, 22);
            statusStrip.TabIndex = 8;
            statusStrip.Text = "statusStrip";
            // 
            // toolStripStatusCOM
            // 
            toolStripStatusCOM.DisplayStyle = ToolStripItemDisplayStyle.Text;
            toolStripStatusCOM.Margin = new Padding(0, 3, 8, 2);
            toolStripStatusCOM.Name = "toolStripStatusCOM";
            toolStripStatusCOM.Size = new Size(28, 17);
            toolStripStatusCOM.Text = "COM";
            // 
            // toolStripStatusBaudrate
            // 
            toolStripStatusBaudrate.DisplayStyle = ToolStripItemDisplayStyle.Text;
            toolStripStatusBaudrate.Margin = new Padding(0, 3, 8, 2);
            toolStripStatusBaudrate.Name = "toolStripStatusBaudrate";
            toolStripStatusBaudrate.Size = new Size(63, 17);
            toolStripStatusBaudrate.Text = "BAUTRATE";
            // 
            // toolStripStatusParity
            // 
            toolStripStatusParity.DisplayStyle = ToolStripItemDisplayStyle.Text;
            toolStripStatusParity.Name = "toolStripStatusParity";
            toolStripStatusParity.Size = new Size(49, 17);
            toolStripStatusParity.Text = "PARITY";
            // 
            // Monitor
            // 
            Monitor.BorderStyle = BorderStyle.None;
            Monitor.CausesValidation = false;
            Monitor.ContextMenuStrip = contextMenuStripMonitor;
            Monitor.Dock = DockStyle.Fill;
            Monitor.Font = new Font("Fira Code", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Monitor.Location = new Point(0, 0);
            Monitor.MaxLength = 32;
            Monitor.Multiline = true;
            Monitor.Name = "Monitor";
            Monitor.ReadOnly = true;
            Monitor.ScrollBars = ScrollBars.Vertical;
            Monitor.Size = new Size(794, 517);
            Monitor.TabIndex = 6;
            Monitor.TabStop = false;
            Monitor.Text = "Hello, Serial Monitor!";
            // 
            // textBoxSend
            // 
            textBoxSend.BorderStyle = BorderStyle.FixedSingle;
            textBoxSend.Dock = DockStyle.Bottom;
            textBoxSend.Enabled = false;
            textBoxSend.Font = new Font("Fira Code", 8.999999F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBoxSend.Location = new Point(0, 517);
            textBoxSend.Name = "textBoxSend";
            textBoxSend.Size = new Size(794, 22);
            textBoxSend.TabIndex = 0;
            textBoxSend.KeyPress += textBoxSend_KeyPress;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            ClientSize = new Size(794, 561);
            Controls.Add(Monitor);
            Controls.Add(textBoxSend);
            Controls.Add(statusStrip);
            Font = new Font("Fira Code", 8.999999F);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "Form1";
            ShowIcon = false;
            Text = "Serial Monitor";
            Load += Form1_Load;
            contextMenuStripMonitor.ResumeLayout(false);
            contextMenuStripMonitor.PerformLayout();
            statusStrip.ResumeLayout(false);
            statusStrip.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private SerialPort serialPort;
        private StatusStrip statusStrip;
        private ContextMenuStrip contextMenuStripMonitor;
        private ToolStripMenuItem toolStripMenuItemClear;
        private ToolStripMenuItem encodingToolStripMenuItem;
        private ToolStripMenuItem asciiToolStripMenuItem;
        private ToolStripMenuItem binaryToolStripMenuItem;
        private ToolStripMenuItem hexToolStripMenuItem;
        private ToolStripComboBox toolStripComboBoxCOM;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripTextBox toolStripTextBoxBaudRate;
        private ToolStripMenuItem toolStripMenuItemOpen;
        private ToolStripMenuItem toolStripMenuItemClose;
        private TextBox Monitor;
        private TextBox textBoxSend;
        private ContextMenuStrip contextMenuStripSend;
        private ToolStripComboBox toolStripComboBoxParity;
        private ToolStripStatusLabel toolStripStatusBaudrate;
        private ToolStripStatusLabel toolStripStatusCOM;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripStatusLabel toolStripStatusParity;
    }
}