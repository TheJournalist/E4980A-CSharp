using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Microsoft.WindowsAPICodePack.Dialogs;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;
using System.Globalization;
using System.IO.Ports;

namespace E4980A
{
    public partial class Form1 : Form
    {
        SerialPort serialPort;
        byte[] msgAllON = new byte[10] { 0xAA, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x55 };
        byte[] msgAllOFF = new byte[10] { 0xAA, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0x55 };

        void measThread()
        {
            try
            {
                var session = (Ivi.Visa.IMessageBasedSession)Ivi.Visa.GlobalResourceManager.Open(tbDevice.Text);
                //var session = (Ivi.Visa.IMessageBasedSession)Ivi.Visa.GlobalResourceManager.Open("USB0::0x0957::0x0909::MY46204796::0::INSTR");
                //var session = (Ivi.Visa.IMessageBasedSession)Ivi.Visa.GlobalResourceManager.Open("TCPIP0::10.12.2.93::inst0::INSTR");
                session.Clear();
                session = (Ivi.Visa.IMessageBasedSession)Ivi.Visa.GlobalResourceManager.Open(tbDevice.Text);
                //session = (Ivi.Visa.IMessageBasedSession)Ivi.Visa.GlobalResourceManager.Open("USB0::0x0957::0x0909::MY46204796::0::INSTR");
                //session = (Ivi.Visa.IMessageBasedSession)Ivi.Visa.GlobalResourceManager.Open("TCPIP0::10.12.2.93::inst0::INSTR");
                session.TimeoutMilliseconds = 600000;
                session.FormattedIO.WriteLine("*IDN?");
                string idName = session.FormattedIO.ReadLine();


                /// E4980A VISA Commands
                /// https://www.cmc.ca/wp-content/uploads/2019/07/E4980A-User-Guide.pdf

                session.FormattedIO.WriteLine("RST;*CLS");
                //session.FormattedIO.WriteLine("DISP:ENAB OFF");
                session.FormattedIO.WriteLine("TRIG:SOUR BUS");
                //session.FormattedIO.WriteLine("AMP:ALC 1"); // Automatic signal level control
                session.FormattedIO.WriteLine("DISP:PAGE LIST");

                /// Sampling time
                if (rbLong.Checked)
                    session.FormattedIO.WriteLine("APER LONG,1");
                else if (rbMedium.Checked)
                    session.FormattedIO.WriteLine("APER MED,1");
                else
                    session.FormattedIO.WriteLine("APER SHORT,1");


                session.FormattedIO.WriteLine("LIST:CLE:ALL");

                /// Data format
                session.FormattedIO.WriteLine("FUNC:IMP CPRP");
                //session.FormattedIO.WriteLine("FUNC:IMP RX");
                // session.FormattedIO.WriteLine("FUNC:IMP ZTD");

                //session.FormattedIO.WriteLine("FORM REAL,64");
                session.FormattedIO.WriteLine("FORM ASC");


                /// Frequency sweep list
                session.FormattedIO.WriteLine("LIST:MODE SEQ");
                //string frequencyList = "2E1, 1E2,2E2,5E2,1E3,2E3,5E3,1E4,2E4,5E4,1E5,2E5,5E5,1E6,2E6";
                //string frequencyList = "24.33080292, 32.71270752, 44.00499344, 59.13898468, 79.51166534, 106.8692703, 143.6565094, 193.1330261, 259.7225952, 349.2459717, 469.6194153, 631.4367065, 848.9005737, 1141.452271, 1534.819702, 2063.810791, 2774.992188, 3731.227539, 5016.918457, 6745.802246, 9070.383789, 12196.01855, 16398.61133, 22049.64453, 29647.83984, 39864.44922, 53601.57422, 72072.60938, 96908.65625, 130303.0938, 175205.2969, 235580.6094, 316761.2188, 425916.2813, 572686.125, 770032.3125, 1035383.563, 1392174.375, 1871914.375, 2000000";
                //string frequencyList = "2E1, 1E2, 2E2, 5E2, 1E3, 2E3, 2E4, 2E5, 2E6";
                string frequencyList = tbFlist.Text;

                var frq = frequencyList.Split(',');
                string header = "timestamp, ";
                if (cbCalib.Checked)
                    header = header + "R, C, ";

                for (int i = 0; i < frq.Count(); i++)
                {
                    header += frq[i].Trim() + " Cp, ";
                    header += frq[i].Trim() + " Rp, ";
                }
                header = header.TrimEnd();
                header = header.TrimEnd(',');



                byte[] msg = new byte[10] { 0xAA, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0x55 };
                UInt32 R = 0;
                UInt32 C = 0;

                if (cbCalib.Checked)
                    serialPort.Write(msg, 0, 10);

                Thread.Sleep(200);

                session.FormattedIO.WriteLine("LIST:FREQ " + frequencyList);
                session.FormattedIO.WriteLine("INIT:CONT ON");
                session.FormattedIO.WriteLine("TRIG:IMM");

                var timer = new Stopwatch();
                TimeSpan timeTaken;
                bool firstLine = true;

                char[] ans;

                bool preexistingFile = File.Exists(tbFilePath.Text + "\\" + tbFilename.Text + ".csv");

                /// Write to local file
                using (StreamWriter writer = new StreamWriter(tbFilePath.Text + "\\" + tbFilename.Text + ".csv", true))
                {
                    writer.AutoFlush = true;

                    /// Continuos measurement/TRIG
                    for (int i = 0; i < nudSamples.Value; i++)
                    {
                        timer.Restart();
                        Thread.Sleep(200);
                        DateTime foo = DateTime.Now;
                        long unixTime = ((DateTimeOffset)foo).ToUnixTimeMilliseconds();
                        session.FormattedIO.WriteLine("*TRG");
                        ans = session.FormattedIO.ReadLine().ToCharArray();

                        timer.Stop();

                        timeTaken = timer.Elapsed;
                        string time = "Time taken: " + timeTaken.ToString(@"m\:ss\.ffffff");
                        string s = new string(ans);
                        s = s.Replace(",+0,+0", "");
                        s = s.Replace(",+1,+0", "");

                        if (firstLine && (!preexistingFile))
                        {
                            string fs = "timestamp, ";
                            if (cbCalib.Checked)
                                fs = "timestamp, R, C,";

                            foreach (var f in frq)
                            {
                                fs += f.ToString() + ", ";
                                fs += f.ToString() + ", ";
                            }

                            fs = fs.Trim().TrimEnd(',');
                            writer.WriteLine(header);
                            writer.WriteLine(fs);

                            firstLine = false;
                        }

                        string sline = "";
                        List<string> splitResult = s.Split(',').ToList();
                        List<double> result = splitResult.Select(x => double.Parse(x)).ToList();
                        for (int j = 0; j < frq.Length; j++)
                        {
                            double mag = result[j * 2];
                            double ph = result[j * 2 + 1];
                            sline += mag.ToString() + ", " + ph.ToString() + ", ";
                        }

                        sline = sline.Trim().TrimEnd(',');



                        if (cbCalib.Checked)
                        {
                            writer.WriteLine(unixTime.ToString() + ", " + R.ToString() + ", " + C.ToString() + ", " + sline);
                            writer.Flush();
                        }
                        else
                        {
                            writer.WriteLine(unixTime.ToString() + ", " + sline);
                            writer.Flush();
                        }

                        if (cbCalib.Checked)
                        {
                            R = (UInt32)Math.Pow(2, i);

                            msg = new byte[10] { 0xAA, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0x55 };

                            msg[1] = ((byte)~(R >> 8));
                            msg[2] = ((byte)~(R >> 0));
                            msg[3] = ((byte)~(R >> 24));
                            msg[4] = ((byte)~(R >> 16));

                            BeginInvoke(new Action(() =>
                            {
                                Thread.Sleep(500);
                                serialPort.Write(msg, 0, 10);
                                richTextBox1.Text += BitConverter.ToString(msg).Replace("-", "") + "\n";
                            }));


                        }

                        /// Print in textbox
                        BeginInvoke(new Action(() =>
                        {
                            richTextBox1.Text += DateTime.Now.ToString() + " - Measurement number " + i.ToString() + "\r\n" + time + "\r\n" + unixTime.ToString() + ", " + s + "\r\n";


                        }));
                        Console.WriteLine(time);
                    }


                    /*

                    // Binary mode
                    if(ans[0] == '#')
                    {
                        int nBytesToTransfer = ans[1] - 48;
                        int len = 0;

                        for(int i = 0; i < nBytesToTransfer; i++)
                        {
                            len += (ans[1 + nBytesToTransfer-i]-48) * ((int)Math.Pow(10, i));
                        }

                        string dub;
                        for (int i = 0; i <= ans.Length - 8 - 2 - nBytesToTransfer; i += 8)
                        {
                            dub = "";
                            for (int j = 0; j < 8; j++)
                            {
                                dub += Convert.ToString(ans[2 + nBytesToTransfer + j + i], 2).PadLeft(8, '0');
                            }

                            double value = BinaryStringToDouble(dub);


                            using (StreamWriter writer = new StreamWriter("C:\\Users\\Natan\\Desktop\\test.txt", true))
                            {
                                writer.WriteLine(value);
                            }
                        }
                        timer.Stop();

                        TimeSpan timeTaken = timer.Elapsed;
                        string foo = "Time taken: " + timeTaken.ToString(@"m\:ss\.ffffff");
                        ;
                    }
                    */

                }

                BeginInvoke(new Action(() =>
                {
                    btnStart.Enabled = true;
                    richTextBox1.Text += "Measurement finished!\r\n";
                }));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                BeginInvoke(new Action(() =>
                {
                    btnStart.Enabled = true;
                    richTextBox1.Text += "Error!\r\n";
                }));
            }
        }

        public IEnumerable<double> logspace(double start, double end, int count)
        {
            double d = (double)(count - 1), p = Math.Pow(end / start, 1 / d);
            var list = Enumerable.Range(0, count).Select(i => start * Math.Pow(p, i));
            return list.Select(n => Math.Round(n, 3, MidpointRounding.AwayFromZero));
        }

        public static IEnumerable<double> Arange(double start, int count)
        {
            var list = Enumerable.Range((int)start, count).Select(v => (double)v);
            return list.Select(n => Math.Round(n, 3, MidpointRounding.AwayFromZero));
        }

        public static IEnumerable<double> Power(IEnumerable<double> exponents, double baseValue = 10.0d)
        {
            return exponents.Select(v => Math.Pow(baseValue, v));
        }

        public static IEnumerable<double> linspace(double start, double stop, int num, bool endpoint = true)
        {
            var result = new List<double>();
            if (num <= 0)
            {
                return result;
            }

            if (endpoint)
            {
                if (num == 1)
                {
                    return new List<double>() { start };
                }

                var step = (stop - start) / ((double)num - 1.0d);
                result = Arange(0, num).Select(v => (v * step) + start).ToList();
            }
            else
            {
                var step = (stop - start) / (double)num;
                result = Arange(0, num).Select(v => (v * step) + start).ToList();
            }

            return result;
        }

        void updateAutoFreqList()
        {
            if (rbLog.Checked)
                tbFlist.Text = string.Join(", ", logspace(Convert.ToDouble(nudStart.Value), Convert.ToDouble(nudEnd.Value), Convert.ToInt16(nudN.Value)));
            else if (rbLinear.Checked)
                tbFlist.Text = string.Join(", ", linspace(Convert.ToDouble(nudStart.Value), Convert.ToDouble(nudEnd.Value), Convert.ToInt16(nudN.Value)));
        }

        void saveAll()
        {
            Properties.Settings.Default["DeviceID"] = tbDevice.Text;
            Properties.Settings.Default["StartFreq"] = (int)nudStart.Value;
            Properties.Settings.Default["EndFreq"] = (int)nudEnd.Value;
            Properties.Settings.Default["NPoints"] = (int)nudN.Value;
            Properties.Settings.Default["Log"] = rbLog.Checked;
            Properties.Settings.Default["SamplingTime"] = (int)(rbShort.Checked ? 0 : rbMedium.Checked ? 1 : 2);
            Properties.Settings.Default["NSamples"] = (int)nudSamples.Value;
            Properties.Settings.Default["Filename"] = tbFilename.Text;
            if (Directory.Exists(tbFilePath.Text))
                Properties.Settings.Default["Path"] = tbFilePath.Text;
            Properties.Settings.Default.Save();
        }

        private void InitializeSavedValues()
        {
            tbDevice.Text = (string)Properties.Settings.Default["DeviceID"];
            nudStart.Value = (int)Properties.Settings.Default["StartFreq"];
            nudEnd.Value = (int)Properties.Settings.Default["EndFreq"];
            nudN.Value = (int)Properties.Settings.Default["NPoints"];
            rbLog.Checked = (bool)Properties.Settings.Default["Log"];
            rbLinear.Checked = !rbLog.Checked;
            rbShort.Checked = (int)Properties.Settings.Default["SamplingTime"] == 0;
            rbMedium.Checked = (int)Properties.Settings.Default["SamplingTime"] == 1;
            rbLong.Checked = (int)Properties.Settings.Default["SamplingTime"] == 2;
            nudSamples.Value = (int)Properties.Settings.Default["NSamples"];
            tbFilename.Text = (string)Properties.Settings.Default["Filename"];

            if (Directory.Exists((string)Properties.Settings.Default["Path"]))
            {
                tbFilePath.Text = (string)Properties.Settings.Default["Path"];
            }
            else
            {
                tbFilePath.Text = System.IO.Path.GetDirectoryName(Application.ExecutablePath);
            }

        }

        public Form1()
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");

            InitializeComponent();

            InitializeSavedValues();

            updateAutoFreqList();

            //Thread t = new Thread(measThread);
            //t.Start();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            richTextBox1.SelectionStart = richTextBox1.Text.Length;
            // scroll automatically
            richTextBox1.ScrollToCaret();
        }

        private void nudStart_ValueChanged(object sender, EventArgs e)
        {
            updateAutoFreqList();
        }

        private void rbLinear_CheckedChanged(object sender, EventArgs e)
        {
            updateAutoFreqList();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (Directory.Exists(tbFilePath.Text))
            {
                if (tbFilename.Text == "")
                {
                    MessageBox.Show("Invalid Filename!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    btnStart.Enabled = false;
                    richTextBox1.Text = "Starting measurement...\r\n";

                    Thread t = new Thread(measThread);
                    t.Start();
                }
            }
            else
            {
                MessageBox.Show("Invalid Path!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            saveAll();
        }

        private void btnPath_Click(object sender, EventArgs e)
        {
            CommonOpenFileDialog dialog = new CommonOpenFileDialog();
            if (Directory.Exists(tbFilePath.Text))
                dialog.InitialDirectory = tbFilePath.Text;
            dialog.IsFolderPicker = true;
            if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                tbFilePath.Text = dialog.FileName;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var ports = SerialPort.GetPortNames();
            cmbSerialPorts.DataSource = ports;

        }

        private void btnOp_Click(object sender, EventArgs e)
        {
            serialPort = new SerialPort(cmbSerialPorts.SelectedItem.ToString());
            if (!serialPort.IsOpen)
            {
                serialPort.BaudRate = 115200;
                serialPort.Open();

                serialPort.Write(msgAllON, 0, 10);
            }
        }

        private void btnCalib_Click(object sender, EventArgs e)
        {
            byte[] msg = new byte[10] { 0xAA, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0x55 };
            UInt16 R = 0;
            UInt16 C = 0;

            for (UInt16 i = 0; i < 16; i++)
            {
                if (R == 0)
                    R = 1;
                else
                    R *= 2;

                msg = new byte[10] { 0xAA, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0x55 };

                msg[1] = ((byte)~(R >> 8));
                msg[2] = ((byte)~(R >> 0));

                serialPort.Write(msg, 0, 10);

                richTextBox1.Text += BitConverter.ToString(msg).Replace("-", "") + "\n";
                Thread.Sleep(1250);
            }
        }
    }
}
