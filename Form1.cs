using System.Configuration;
using System.IO.Ports;
using System.Text;

namespace SerialMonitor
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private delegate void Receive(byte[] buffer);

        private int encoding = 0;

        private void ReceiveData(byte[] buffer)
        {
            foreach (byte b in buffer)
            {
                switch (encoding)
                {
                    case 0:
                        Monitor.Text += b.ToString();
                        break;

                    case 1:
                        for (int i = 0b10000000; i > 0; i >>= 1)
                            Monitor.Text += ((b & i) == 0) ? 0 : 1;
                        Monitor.Text += ' ';
                        break;

                    case 2:
                        byte[] bs = { b };
                        Monitor.Text += BitConverter.ToString(bs) + ' ';
                        break;
                }

                Monitor.ScrollBars = ScrollBars.Vertical;
                Monitor.SelectionStart = Monitor.Text.Length;
                Monitor.ScrollToCaret();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string[] ports = SerialPort.GetPortNames();

            foreach (string port in ports)
            {
                toolStripComboBoxCOM.Items.Add(port);
            }

            toolStripComboBoxCOM.SelectedIndex = toolStripComboBoxCOM.Items.Count - 1;
            toolStripComboBoxParity.SelectedIndex = 0;
            toolStripStatusBaudrate.Text = "9600";

            toolStripStatusCOM.Text = toolStripComboBoxCOM.SelectedItem.ToString();
            toolStripStatusParity.Text = toolStripComboBoxParity.SelectedItem.ToString();
            toolStripStatusBaudrate.Text = toolStripTextBoxBaudRate.Text;
        }

        private void SerialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            SerialPort sp = (SerialPort)sender;
            byte[] buffer = new byte[sp.BytesToRead];
            int lenght = sp.Read(buffer, 0, buffer.Length);
            Invoke(new Receive(ReceiveData), new object[] { buffer });
        }

        private void toolStripMenuItemOpen_Click(object sender, EventArgs e)
        {
            serialPort.PortName = toolStripComboBoxCOM.SelectedItem.ToString();
            serialPort.BaudRate = int.Parse(toolStripTextBoxBaudRate.Text);
            serialPort.Parity = (Parity)toolStripComboBoxParity.SelectedIndex;

            try
            {
                serialPort.Open();
            }
            catch
            {
                MessageBox.Show("Can't Open the Port!");
            }

            if (serialPort.IsOpen)
            {
                textBoxSend.Enabled = true;
                toolStripComboBoxCOM.Enabled = false;
                toolStripTextBoxBaudRate.Enabled = false;
                toolStripMenuItemOpen.Enabled = false;
                toolStripMenuItemClose.Enabled = true;
                this.Text = "Serial Monitor - Device Online";
            }
        }

        private void toolStripMenuItemClose_Click(object sender, EventArgs e)
        {
            if (serialPort.IsOpen)
            {
                serialPort.Close();
                textBoxSend.Enabled = false;
                toolStripComboBoxCOM.Enabled = true;
                toolStripTextBoxBaudRate.Enabled = true;
                toolStripMenuItemOpen.Enabled = true;
                toolStripMenuItemClose.Enabled = false;
                this.Text = "Serial Monitor";
            }
        }

        private void textBoxSend_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = char.ToUpper(e.KeyChar);

            if ("0123456789ABCDEF".Contains(e.KeyChar) || (e.KeyChar == (char)Keys.Back))
                e.Handled = false;
            else
                e.Handled = true;

            if (e.KeyChar == (char)Keys.Enter)
            {
                byte[] data = Encoding.Default.GetBytes(textBoxSend.Text);
                
                if (data.Length % 2 == 0)
                {
                    this.Text = "Serial Monitor - Device Online - " + textBoxSend.Text;
                    for (int i = 0; i < data.Length; i += 2)
                    {
                        char[] c = [(char)data[i], (char)data[i + 1]];

                        for (int j = 0; j < 2; j++)
                        {
                            if ("0123456789".Contains(c[j]))
                                c[j] -= '0';
                            else if ("ABCDEF".Contains(c[j]))
                                c[j] -= (char)0x37;
                        }

                        c[0] <<= 4;

                        byte[] d = [(byte)(c[0] + c[1])];

                        serialPort.Write(d, 0, 1);
                    }
                }
            }
        }

        private void toolStripMenuItemClear_Click(object sender, EventArgs e)
        {
            Monitor.Clear();
        }

        private void asciiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            encoding = 0;
            asciiToolStripMenuItem.Checked = true;
            binaryToolStripMenuItem.Checked = false;
            hexToolStripMenuItem.Checked = false;
        }

        private void binaryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            encoding = 1;
            asciiToolStripMenuItem.Checked = false;
            binaryToolStripMenuItem.Checked = true;
            hexToolStripMenuItem.Checked = false;
        }

        private void hexToolStripMenuItem_Click(object sender, EventArgs e)
        {
            encoding = 2;
            asciiToolStripMenuItem.Checked = false;
            binaryToolStripMenuItem.Checked = false;
            hexToolStripMenuItem.Checked = true;
        }

        private void toolStripTextBoxBaudRate_TextChanged(object sender, EventArgs e)
        {
            toolStripStatusBaudrate.Text = toolStripTextBoxBaudRate.Text;
        }

        private void toolStripComboBoxCOM_SelectedIndexChanged(object sender, EventArgs e)
        {
            toolStripStatusCOM.Text = toolStripComboBoxCOM.SelectedItem.ToString();
        }

        private void toolStripComboBoxParity_SelectedIndexChanged(object sender, EventArgs e)
        {
            toolStripStatusParity.Text = toolStripComboBoxParity.SelectedItem.ToString();
        }
    }
}