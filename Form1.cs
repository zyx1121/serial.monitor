using System.IO.Ports;
using System.Text;

namespace SerialMonitor
{
    public partial class Form1 : Form
    {
        private delegate void Receive(byte[] buffer);
        private byte[] testData = new byte[50];
        private int countC;
        private int encoding = 0;

        public Form1()
        {
            InitializeComponent();
            comboBoxParity.SelectedIndex = 0;
            comboBoxMonitorMode.SelectedIndex = 2;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string[] ports = SerialPort.GetPortNames();
            comboBoxPort.Items.AddRange(ports);
            comboBoxPort.SelectedIndex = comboBoxPort.Items.Count - 1;
        }

        private void ButtonOpen_Click(object sender, EventArgs e)
        {
            if (buttonOpen.Text == "Close Port")
            {
                try { serialPort.Close(); }
                catch { }
                this.Text = "Serial Monitor - Device Offline";
                buttonOpen.Text = "Open Port";
                EnableControls(true);
                return;
            }

            if (buttonOpen.Text == "Open Port")
            {
                serialPort.PortName = comboBoxPort.Text;
                serialPort.BaudRate = int.Parse(comboBoxBautRate.Text);
                serialPort.Parity = (Parity)comboBoxParity.SelectedIndex;
                try { serialPort.Open(); }
                catch { }
                this.Text = "Serial Monitor - Device Online";
                buttonOpen.Text = "Close Port";
                EnableControls(false);
            }
        }

        private static string ConverFGM(byte[] data)
        {
            double dataInt = 0;
            for (int i = 1; i < 6; i++)
                dataInt += (data[i] - 0x30) * Math.Pow(10, (5 - i));
            dataInt = dataInt * 10 / 32767;
            byte[] result = [data[0]];
            return Encoding.ASCII.GetString(result) + dataInt.ToString("0.000") + "V";
        }

        private void PrintFGM()
        {
            byte[] adc1 = [testData[0], testData[1], testData[2], testData[3], testData[4], testData[5]];
            byte[] adc2 = [testData[6], testData[7], testData[8], testData[9], testData[10], testData[11]];
            byte[] adc3 = [testData[12], testData[13], testData[14], testData[15], testData[16], testData[17]];
            byte[] adc4 = [testData[18], testData[19], testData[20], testData[21], testData[22], testData[23]];
            byte[] adc5 = [testData[24], testData[25], testData[26], testData[27], testData[28], testData[29]];
            byte[] adc6 = [testData[30], testData[31], testData[32], testData[33], testData[34], testData[35]];

            string temp = DateTime.Now.ToString("ttHH:mm:ss") + "    ";

            temp += "P4(MAG1)    ";

            temp += "X ";
            temp += ConverFGM(adc1) + "    ";

            temp += "Y ";
            temp += ConverFGM(adc2) + "    ";

            temp += "Z ";
            temp += ConverFGM(adc3) + "    ";

            temp += Environment.NewLine + "                P5(MAG2)    ";

            temp += "X ";
            temp += ConverFGM(adc4) + "    ";

            temp += "Y ";
            temp += ConverFGM(adc5) + "    ";

            temp += "Z ";
            temp += ConverFGM(adc6) + "    ";

            temp += Environment.NewLine + Environment.NewLine;

            Monitor.AppendText(temp);
        }

        private void ReceiveData(byte[] buffer)
        {
            StringBuilder sb = new();

            foreach (byte b in buffer)
            {
                switch (encoding)
                {
                    case 0:
                        sb.Append(b);
                        break;
                    case 1:
                        for (int j = 0b10000000; j > 0; j >>= 1)
                            sb.Append(((b & j) != 0) ? "1" : "0");
                        sb.Append(' ');
                        break;
                    case 2:
                        byte[] t2 = [b];
                        sb.Append(BitConverter.ToString(t2) + ' ');
                        break;
                    case 3:
                        testData[countC] = b;
                        if (++countC == 50)
                        {
                            countC = 0;
                            PrintFGM();
                        }
                        break;
                }
            }

            Monitor.AppendText(sb.ToString());

            Monitor.ScrollBars = ScrollBars.Vertical;
            Monitor.SelectionStart = Monitor.Text.Length;
            Monitor.ScrollToCaret();
        }

        private void SerialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            SerialPort sp = (SerialPort)sender;
            byte[] buffer = new byte[sp.BytesToRead];
            int length = sp.Read(buffer, 0, buffer.Length);
            Invoke(new Receive(ReceiveData), new object[] { buffer });
        }

        private void SerialPort_SendData()
        {
            byte[] data = Encoding.Default.GetBytes(textBoxSend.Text);

            if (data.Length % 2 == 0)
            {
                this.Text = "Serial Monitor - Device Online - " + textBoxSend.Text;
                for (int i = 0; i < data.Length; i += 2)
                {
                    char[] c = { (char)data[i], (char)data[i + 1] };

                    for (int j = 0; j < 2; j++)
                    {
                        if (char.IsDigit(c[j]))
                            c[j] -= '0';
                        else if (char.ToUpper(c[j]) >= 'A' && char.ToUpper(c[j]) <= 'F')
                            c[j] -= (char)0x37;
                    }

                    c[0] <<= 4;

                    byte[] d = { (byte)(c[0] + c[1]) };

                    serialPort.Write(d, 0, 1);
                }
            }
        }

        private void TextBoxSend_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = char.ToUpper(e.KeyChar);

            if ("0123456789ABCDEF".Contains(e.KeyChar) || (e.KeyChar == (char)Keys.Back))
                e.Handled = false;
            else
                e.Handled = true;

            if (e.KeyChar == (char)Keys.Enter)
            {
                SerialPort_SendData();
            }
        }

        private void ComboBoxMonitorMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            encoding = comboBoxMonitorMode.SelectedIndex;
        }

        private void ButtonClear_Click(object sender, EventArgs e)
        {
            Monitor.Clear();
        }

        private void ButtonSend_Click(object sender, EventArgs e)
        {
            SerialPort_SendData();
        }

        private void EnableControls(bool enable)
        {
            comboBoxPort.Enabled = enable;
            comboBoxBautRate.Enabled = enable;
            comboBoxParity.Enabled = enable;
            textBoxSend.Enabled = !enable;
            buttonSend.Enabled = !enable;
        }
    }
}