using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using SPORTident;
using SPORTident.Common;
using SPORTident.Communication;
using SPORTident.Communication.UsbDevice;
using SPORTident.Db;
using System.Drawing;
using System.Drawing.Printing;

namespace ReaderSampleProject
{
    public partial class FormDemo : Form
    {
        private readonly Reader _reader;
        
        private bool _connected;
        private Dictionary<int, DeviceInfo> _deviceInfoList;

        private Font printFont;

        private SportidentCard kiolvasott;

        private uint[][] palyak = new uint[4][];
        private int palya = 0;
        private bool siker = false;


        private void _refreshDeviceList()
        {
            cmbSerialPort.Items.Clear();

            _deviceInfoList = new Dictionary<int, DeviceInfo>();

            var devList = DeviceInfo.GetAvailableDeviceList(true, (int)DeviceType.Serial | (int)DeviceType.UsbHid);

            var n = 0;
            DeviceInfo addItem;

            foreach (var item in devList)
            {
                addItem = item;

                cmbSerialPort.Items.Add(DeviceInfo.GetPrettyDeviceName(item));

                _deviceInfoList.Add(n++, addItem);
            }

            if (cmbSerialPort.Items.Count > 0) cmbSerialPort.SelectedIndex = 0;
        }   

        public FormDemo()
        {
            InitializeComponent();

            palyak[0] = new uint[] { 37, 34, 35, 42, 40, 45 };
            palyak[1] = new uint[] { 46, 42, 41, 33, 34, 44 };
            palyak[2] = new uint[] { 39, 34, 33, 32, 35, 38, 46, 40, 42, 47, 43 };
            palyak[3] = new uint[] { 31, 34, 38, 46, 47, 41, 33, 40, 36, 44 };

            _reader = new Reader
            {
                WriteBackupFile = true,
                BackupFileName = Path.Combine(Environment.CurrentDirectory, string.Format(@"backup\{0:yyyy-MM-dd}_stamps.bak", DateTime.Now)),
                WriteLogFile = false
            };

            _reader.InputDeviceChanged += _reader_InputDeviceChanged;
            _reader.OutputDeviceChanged += _reader_OutputDeviceChanged;
            _reader.InputDeviceStateChanged += _reader_InputDeviceStateChanged;
            _reader.OutputDeviceStateChanged += _reader_OutputDeviceStateChanged;
            _reader.LogEvent += _reader_LogEvent;
            _reader.ErrorOccured += _reader_ErrorOccured;
            _reader.OnlineStampRead += _reader_OnlineStampRead;
            _reader.CardRead += _reader_CardRead;
            _reader.DeviceConfigurationRead += _reader_DeviceConfigurationRead;
            _reader.DatabaseIntegrityFailure += _reader_DatabaseIntegrityFailure;
            _reader.RadioReadoutCardCompleted += _reader_RadioReadoutCardCompleted;
            _reader.RadioReadoutCardIncomplete += _reader_RadioReadoutCardIncomplete;

            _refreshDeviceList();
        }

        #region Reader event handlers
        /// <summary>Handles the event that is thrown when the reader class read a card completely</summary>
        private void _reader_CardRead(object sender, SportidentDataEventArgs e)
        {
            //handle this event to further process a read out card
            //you will find the card data in the e.Card array that may contain several cards
            //wod here please
            int[] distance = { 0, 0, 0, 0 };
            SportidentCard c = e.Cards[0];
            kiolvasott = c;

            //pályafelismerés
            for (int p = 0; p < 4; ++p)
            {
                int p_y = 0;
                for (int x = 0;x< c.ControlPunchList.Count; ++x)
                    if(p_y < palyak[p].Length && palyak[p][p_y] == c.ControlPunchList[x].CodeNumber)
                        ++p_y;
                    else
                        ++distance[p];

                if (p_y != palyak[p].Length)
                    distance[p] += 100;
            }

            int min = 0;
            for (int i = 1; i < 4; ++i)
                if (distance[i] < distance[min])
                    min = i;

            palya = min;
            siker = distance[min] < 100;

            //nyomtatás
            printFont = new Font("Open Sans Semibold", 12);
            //printFont = new Font("Times New Roman", 10);
            PrintDocument pd = new PrintDocument();
            pd.PrinterSettings.PrinterName = "EPSON TM-T20 Receipt";
            pd.PrintPage += new PrintPageEventHandler(this.pd_PrintPage);
            pd.Print();

        }
        /// <summary>Handles the event that is thrown when the reader class read an online stamp completely</summary>
        private void _reader_OnlineStampRead(object sender, SportidentDataEventArgs e)
        {
            //handle this event to further process a read card punch or online record
            //you will find the card data in the e.PunchData array hat may contain several records
        }
        /// <summary>Handles the event that is thrown when the reader class logs a message (info, warning, error...)</summary>
        private static void _reader_LogEvent(object sender, FileLoggerEventArgs e)
        {
            
        }

        /// <summary>Handles the event that is thrown when the reader class indicates a state change for the input device</summary>
        private void _reader_InputDeviceStateChanged(object sender, ReaderDeviceStateChangedEventArgs e)
        {
            if (InvokeRequired)
            {
                Invoke(new ReaderDeviceStateChangedEventHandler(_reader_InputDeviceStateChanged), sender, e);
                return;
            }

            switch (e.CurrentState)
            {
                case DeviceState.D0Online:
                    txtInfo.Text += "INPUT device connected" + Environment.NewLine;

                    break;
                case DeviceState.D5Busy:
                    txtInfo.Text += "INPUT device working" + Environment.NewLine;

                    break;
                default:
                    txtInfo.Text += "INPUT device disconnected" + Environment.NewLine;

                    break;
            }
        }
        /// <summary>Handles the event that is thrown when the reader class indicates a state change for the output device</summary>
        private void _reader_OutputDeviceStateChanged(object sender, ReaderDeviceStateChangedEventArgs e)
        {
            if (InvokeRequired)
            {
                Invoke(new ReaderDeviceStateChangedEventHandler(_reader_OutputDeviceStateChanged), sender, e);
                return;
            }

            switch (e.CurrentState)
            {
                case DeviceState.D0Online:
                    txtInfo.Text += "OUTPUT device connected" + Environment.NewLine;

                    break;
                case DeviceState.D5Busy:
                    txtInfo.Text += "OUTPUT device working" + Environment.NewLine;

                    break;
                default:
                    txtInfo.Text += "OUTPUT device disconnected" + Environment.NewLine;

                    break;
            }
        }
        /// <summary>Handles the event that is thrown when the reader class indicates that the input device has changed</summary>
        private void _reader_InputDeviceChanged(object sender, ReaderDeviceChangedEventArgs e)
        {
            if (InvokeRequired)
            {
                Invoke(new ReaderDeviceChangedEventHandler(_reader_InputDeviceChanged), sender, e);
                return;
            }

            var inputSource = string.Empty;

            switch (e.CurrentDevice.ReaderDeviceType)
            {
                case ReaderDeviceType.SiDevice:
                    inputSource = DeviceInfo.GetPrettyDeviceName(e.CurrentDevice);
                    break;
                case ReaderDeviceType.SiLiveSoapService:
                    inputSource = "SPORTident Live SOAP Service";
                    break;
                default:
                    inputSource = e.CurrentDevice.ReaderDeviceType.ToString();
                    break;
            }

            txtInfo.Text += "INPUT via " + inputSource + Environment.NewLine;
        }
        /// <summary>Handles the event that is thrown when the reader class indicates that the output device has changed</summary>
        private void _reader_OutputDeviceChanged(object sender, ReaderDeviceChangedEventArgs e)
        {
            if (InvokeRequired)
            {
                Invoke(new ReaderDeviceChangedEventHandler(_reader_OutputDeviceChanged), sender, e);
                return;
            }

            var outputSourceLong = string.Empty;

            switch (e.CurrentDevice.ReaderDeviceType)
            {
                case ReaderDeviceType.Network:
                    outputSourceLong = string.Format("NET@{0}:{1}", e.CurrentDevice.Hostname, e.CurrentDevice.Port);
                    break;
                case ReaderDeviceType.Textfile:
                    outputSourceLong = e.CurrentDevice.FilePath;
                    break;
                case ReaderDeviceType.Database:
                    outputSourceLong = string.Format("{1}@{0}", e.CurrentDevice.Hostname, e.CurrentDevice.DatabaseType);
                    break;
                case ReaderDeviceType.None:
                    outputSourceLong = "None";
                    break;
                case ReaderDeviceType.Plugin:
                    outputSourceLong = "Plugin: " + e.CurrentDevice.DeviceName;
                    break;
            }

            txtInfo.Text += "OUTPUT via " + outputSourceLong + Environment.NewLine;
        }
        private void _reader_ErrorOccured(object sender, FileLoggerEventArgs e)
        {
            if (InvokeRequired)
            {
                Invoke(new FileLoggerEventHandler(_reader_ErrorOccured), sender, e);
                return;
            }

            MessageBox.Show(string.Format("{0}\n\n{1}", e.Message, e.ThrownException.Message), "ReaderDemoProject", MessageBoxButtons.OK, MessageBoxIcon.Error);

            if (e.ThrownException.Message != "Disconnected" || !_connected) return;

            _closeDevices();
            _refreshDeviceList();
        }
        /// <summary>Handles the event that is raised when a card has been pending too long to complete via radio readout and has been cancelled</summary>
        private void _reader_RadioReadoutCardIncomplete(object sender, SportidentDataEventArgs e)
        {
            
        }
        /// <summary>Handles the event that is raised when a card has been completely read via radio readout</summary>
        private void _reader_RadioReadoutCardCompleted(object sender, SportidentDataEventArgs e)
        {
            
        }

        /// <summary>Handles the event that is thrown when the reader class indicates that the stations config has been read successfully</summary>
        private void _reader_DeviceConfigurationRead(object sender, StationConfigurationEventArgs e)
        {
            if (InvokeRequired)
            {
                Invoke(new DeviceConfigurationReadEventHandler(_reader_DeviceConfigurationRead), sender, e);
                return;
            }

            if (InvokeRequired)
            {
                Invoke(new DeviceConfigurationReadEventHandler(_reader_DeviceConfigurationRead), sender, e);
                return;
            }

            txtInfo.Text = "Unknown device";

            var msg = "no description available";
            var failed = false;
            switch (e.Result)
            {
                case StationConfigurationResult.OperatingModeNotSupported:
                    msg = "The selected operating mode is not supported on the current device.";
                    failed = true;
                    break;
                case StationConfigurationResult.DeviceDoesNotHaveBackup:
                    msg = "The device does not have a backup memory storage.";
                    failed = true;
                    break;
                case StationConfigurationResult.ReadoutMasterBackupNotSupported:
                    msg = "Reading the backup of SI-Master with firmware < FW595 is not supported.";
                    failed = true;
                    break;
            }

            if (failed)
            {
                MessageBox.Show(
                    string.Format(
                        "The device configuration could not be read successfully. Reason is probably: {0} ({1})",
                        e.Result, msg), "ReaderDemo", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            switch (e.Device.Product.ProductFamily)
            {
                case ProductFamily.SimSrr:
                case ProductFamily.SiGsmDn:
                    txtInfo.Text = string.Format("S/N: {0}, FW: {1}, OpMode: {2}, Protocol: {3}, Channel: {4}{5}",
                        e.Device.SerialNumber, e.Device.FirmwareVersion, e.Device.Product.ProductType,
                        e.Device.SimSrrUseModD3Protocol, e.Device.SimSrrChannel, Environment.NewLine);

                    //check device configuration
                    if (e.Device.SimSrrUseModD3Protocol != 1)
                    {
                        MessageBox.Show(
                            "The device is not configured to use AIR+ protocol. To use extended features it is recommended to enable AIR+ protocol for this device.",
                            "ReaderDemo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }

                    break;
                case ProductFamily.Bs8SiMaster:
                case ProductFamily.Bsx7:
                case ProductFamily.Bsx8:
                case ProductFamily.Bs11Large:
                case ProductFamily.Bs11Small:
                    txtInfo.Text =
                        string.Format("Code no.: {0} (S/N: {1}, FW: {2}), OpMode: {3}, AutoSend: {4}, Legacy prot: {5}{6}",
                            e.Device.CodeNumber, e.Device.SerialNumber, e.Device.FirmwareVersion, e.Device.OperatingMode,
                            e.Device.AutoSendMode, e.Device.LegacyProtocolMode, Environment.NewLine);

                    //check device configuration
                    if (e.Device.OperatingMode != OperatingMode.Readout && !e.Device.AutoSendMode)
                    {
                        MessageBox.Show(
                            "The device is not configured to read cards and has not set autosend flag. No data can be processed from this station.\n\nPlease reconfigure!",
                            "ReaderDemo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                    }
                    else if (e.Device.LegacyProtocolMode)
                    {
                        MessageBox.Show(
                            "The device is configured to use legacy protocol.\nThis application does not support legacy protocol.\n\nPlease reconfigure!",
                            "ReaderDemo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }

                    break;
            }
        }

        /// <summary>Handles the event that is thrown when the reader class indicates that the database structure is not as it is expected to be</summary>
        private void _reader_DatabaseIntegrityFailure(object sender, DatabaseIntegrityFailureEventArgs e)
        {
            txtInfo.Text += string.Format(
                    "##### BEGIN Database integrity check, found issues ############################################################{0}",
                    Environment.NewLine);

            foreach (var item in e.Items)
                txtInfo.Text += string.Format("   {0}{1}", item, Environment.NewLine);

            txtInfo.Text += string.Format(
                    "##### END Database integrity check, found issues ##############################################################{0}",
                    Environment.NewLine);
        }
        #endregion
        /// <summary>
        /// Close input and output devices for Reader
        /// </summary>
        private void _closeDevices()
        {
            //release input device
            if (_reader.InputDeviceIsOpen) _reader.CloseInputDevice();

            //release output device
            if (_reader.OutputDeviceIsOpen) _reader.CloseOutputDevice();

            _connected = false;
        }

        /// <summary>
        /// Sets the input device for the current Reader instance
        /// </summary>
        private bool _setInputDevice()
        {
            ReaderDeviceInfo device = null;

            if (!_deviceInfoList.ContainsKey(cmbSerialPort.SelectedIndex) ||
                !ReaderDeviceInfo.IsDeviceValid(_deviceInfoList[cmbSerialPort.SelectedIndex].DeviceName))
            {
                MessageBox.Show("Could not determine device. Please refresh the device list and retry.",
                    "ReaderDemo", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return false;
            }

            device = new ReaderDeviceInfo(_deviceInfoList[cmbSerialPort.SelectedIndex], ReaderDeviceType.SiDevice);

            try
            {
                _reader.InputDevice = device;
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("An exception occured preparing the device {0}: \n\n{1}.",
                                device, ex.Message), "ReaderDemoProject", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }
        private bool _setOutputDevice()
        {
            ReaderDeviceInfo newDevice = null;
            if (rdoOutputNone.Checked)
            {
                newDevice = new ReaderDeviceInfo(ReaderDeviceType.None);
            }
            else if (rdoOutputTextFile.Checked)
            {
                if (txtOutputTextFile.Text == string.Empty)
                {
                    return false;
                }

                newDevice = new ReaderDeviceInfo(ReaderDeviceType.Textfile, string.Empty);

                switch (cmbOutputFileFormat.SelectedIndex)
                {
                    case 1:     //SI_CONFIG_READOUT
                        newDevice.ListFormat = ListFormat.SiConfigReadout;
                        break;
                    case 2:     //SI_CONFIG_CONTROL
                        newDevice.ListFormat = ListFormat.SiConfigControl;
                        break;
                    case 3:     //SI_TIMING
                        newDevice.ListFormat = ListFormat.SiTiming;
                        break;
                    default:    //SI_READER
                        newDevice.ListFormat = ListFormat.SiReader;
                        break;
                }

                newDevice.FilePath = txtOutputTextFile.Text;
            }
            else if (rdoOutputDatabase.Checked)
            {
                if (cmbOutputDatabase.Text == string.Empty)
                {
                    MessageBox.Show("Please define a database host to output data to.", "ReaderDemoProject", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return false;
                }

                newDevice = new ReaderDeviceInfo(ReaderDeviceType.Database)
                {
                    Hostname = cmbOutputDatabase.Text,
                    UserName = "sportident",
                    Password = "sportident",
                    SchemaName = "lcsportident_events"
                };

                switch (cmbDatabaseType.SelectedIndex)
                {
                    case 1:
                        newDevice.DatabaseType = DatabaseType.MsSql;
                        newDevice.Port = 1433;
                        break;
                    case 2:
                        newDevice.DatabaseType = DatabaseType.SqLite;
                        newDevice.Port = 0;
                        break;
                    case 3:
                        newDevice.DatabaseType = DatabaseType.MsAccess;
                        newDevice.Port = 0;
                        break;
                    default:
                        newDevice.DatabaseType = DatabaseType.MySql;
                        newDevice.Port = 3306;
                        break;
                }
            }
            else if (rdoOutputNetwork.Checked)
            {
                if (string.IsNullOrEmpty(cmbOutputNetworkHost.Text))
                {
                    MessageBox.Show("Please define a database host to output data to.", "ReaderDemoProject", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return false;
                }

                newDevice = new ReaderDeviceInfo(ReaderDeviceType.Network, string.Empty)
                {
                    Hostname = cmbOutputNetworkHost.Text,
                    Port = (int)udOutputNetworkPort.Value,
                    NetworkType = EthernetType.Multicast
                };
            }

            //publish the selected device to the Reader class
            if (newDevice == null) return false;
            
            try
            {
                _reader.OutputDevice = newDevice;
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("An exception occured preparing the device {0}: \n\n{1}.",
                                newDevice, ex.Message), "ReaderDemoProject", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private void _connectDisconnect()
        {
            //if connected -> disconnect or vice versa
            if (_connected)
            {
                _closeDevices();
                grpInputDevice.Enabled = true;
                grpOutputDevice.Enabled = true;
            }
            else
            {
                //set input and output device
                if (!_setInputDevice()) return;
                if (!_setOutputDevice()) return;

                //open input and output device
                try
                {
                    _reader.OpenInputDevice();
                }
                catch (Exception)
                {
                    _closeDevices();

                    MessageBox.Show("Could not open the input device, please check device configuration.",
                        "ReaderDemoProject", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    return;
                }

                try
                {
                    _reader.OpenOutputDevice();
                }
                catch (Exception)
                {
                    _closeDevices();

                    MessageBox.Show("Could not open the output device, please check device configuration.",
                        "ReaderDemoProject", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    return;
                }                

                _connected = true;
                grpInputDevice.Enabled = false;
                grpOutputDevice.Enabled = false;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            _connectDisconnect();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _refreshDeviceList();
        }

        private void btnOutputTextFile_Click(object sender, EventArgs e)
        {
            var myOf = new SaveFileDialog
            {
                Title = "Please select location of text file...",
                SupportMultiDottedExtensions = true,
                ShowHelp = false,
                OverwritePrompt = false,
                RestoreDirectory = true,
                Filter = "Comma separated value|*.csv|All files|*.*",
                FileName = "event.csv",
                DefaultExt = "csv"
            };

            if (myOf.ShowDialog() != DialogResult.OK) return;

            txtOutputTextFile.Text = myOf.FileName;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                printFont = new Font("Open Sans Semibold", 12);
                PrintDocument pd = new PrintDocument();
                pd.PrinterSettings.PrinterName = "EPSON TM-T20 Receipt";
               // pd.PrinterSettings.
                pd.PrintPage += new PrintPageEventHandler(this.pd_PrintPage);
                //pd.PrintPage += new PrintPageEventHandler(this.pd_PrintPage);
                pd.Print();
            }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
}
        private void pd_PrintPage(object sender, PrintPageEventArgs ev)
        {
            //yPos =  (count * printFont.GetHeight(ev.Graphics));
            StringFormat sf1 = new StringFormat();
            StringFormat sf2 = new StringFormat();
            sf2.Alignment = StringAlignment.Far;
            StringFormat sf3 = new StringFormat();
            sf3.Alignment = StringAlignment.Center;

            //wod logo
            ev.Graphics.DrawImage(Image.FromFile("D:\\work\\wod\\v1\\wod-logo-black.png"),0,0,272,101);

            //szövegek
            float szovegekhossza = 101;
            ev.Graphics.DrawString("Köszönjük a részvételt!", printFont, Brushes.Black, new RectangleF(new PointF(0,szovegekhossza),new SizeF(272,printFont.GetHeight(ev.Graphics))), sf3);
            szovegekhossza += printFont.GetHeight(ev.Graphics);
            ev.Graphics.DrawString("Edzések a besztercei iskolában", printFont, Brushes.Black, new RectangleF(new PointF(0, szovegekhossza), new SizeF(272, printFont.GetHeight(ev.Graphics))), sf3);
            szovegekhossza += printFont.GetHeight(ev.Graphics);
            ev.Graphics.DrawString("érdeklődés: Sramkó Tibor edzőnél", printFont, Brushes.Black, new RectangleF(new PointF(0, szovegekhossza), new SizeF(272, printFont.GetHeight(ev.Graphics))), sf3);
            szovegekhossza += printFont.GetHeight(ev.Graphics);
            ev.Graphics.DrawString("Pálya: ", printFont, Brushes.Black, new RectangleF(new PointF(0, szovegekhossza), new SizeF(133, printFont.GetHeight(ev.Graphics))), sf2);
            ev.Graphics.DrawString(((char)('A'+palya)).ToString(), printFont, Brushes.Black, new RectangleF(new PointF(138, szovegekhossza), new SizeF(90, printFont.GetHeight(ev.Graphics))), sf1);
            szovegekhossza += printFont.GetHeight(ev.Graphics);
            ev.Graphics.DrawString("Eredmény: ", printFont, Brushes.Black, new RectangleF(new PointF(0, szovegekhossza), new SizeF(133, printFont.GetHeight(ev.Graphics))), sf2);
            ev.Graphics.DrawString((kiolvasott.FinishPunch.PunchDateTime - kiolvasott.StartPunch.PunchDateTime).ToString(), printFont, Brushes.Black, new RectangleF(new PointF(135, szovegekhossza), new SizeF(90, printFont.GetHeight(ev.Graphics))), sf1);
            if (!siker)
            {
                szovegekhossza += printFont.GetHeight(ev.Graphics);
                ev.Graphics.DrawString("Hibás eredmény!", printFont, Brushes.Black, new RectangleF(new PointF(0, szovegekhossza), new SizeF(272, printFont.GetHeight(ev.Graphics))), sf3);
            }

            //részidőzgetés
            float reszidokhossza = szovegekhossza+2*printFont.GetHeight(ev.Graphics);

            int j = 0;
            int k = 0;
            ev.Graphics.DrawString("", printFont, Brushes.Black, new RectangleF(new PointF(0, szovegekhossza), new SizeF(272, printFont.GetHeight(ev.Graphics))), sf3);
            for (int i = 0; i < kiolvasott.ControlPunchList.Count; ++i)
            {
                if (palyak[palya][j] == kiolvasott.ControlPunchList[i].CodeNumber)
                {
                    ev.Graphics.DrawString(("("+(j+1)+"):").ToString(), printFont, Brushes.Black, new RectangleF(new PointF(0, reszidokhossza + j * printFont.GetHeight(ev.Graphics)), new SizeF(45, printFont.GetHeight(ev.Graphics))), sf2);
                    ev.Graphics.DrawString(kiolvasott.ControlPunchList[i].CodeNumber.ToString(), printFont, Brushes.Black, new RectangleF(new PointF(45, reszidokhossza + j * printFont.GetHeight(ev.Graphics)), new SizeF(45, printFont.GetHeight(ev.Graphics))), sf2);
                    ev.Graphics.DrawString((kiolvasott.ControlPunchList[i].PunchDateTime - kiolvasott.StartPunch.PunchDateTime).ToString(), printFont, Brushes.Black, new RectangleF(new PointF(90, reszidokhossza + j * printFont.GetHeight(ev.Graphics)), new SizeF(90, printFont.GetHeight(ev.Graphics))), sf2);
                    if (j != 0)
                        ev.Graphics.DrawString((kiolvasott.ControlPunchList[i].PunchDateTime - kiolvasott.ControlPunchList[k].PunchDateTime).ToString(), printFont, Brushes.Black, new RectangleF(new PointF(180, reszidokhossza + j * printFont.GetHeight(ev.Graphics)), new SizeF(90, printFont.GetHeight(ev.Graphics))), sf2);
                    k = i;
                    j++;
                }
                else
                {
                    ev.Graphics.DrawString(("(+):").ToString(), printFont, Brushes.Black, new RectangleF(new PointF(0, reszidokhossza + (palyak[palya].Length + i - j + 2) * printFont.GetHeight(ev.Graphics)), new SizeF(45, printFont.GetHeight(ev.Graphics))), sf2);
                    ev.Graphics.DrawString(kiolvasott.ControlPunchList[i].CodeNumber.ToString(), printFont, Brushes.Black, new RectangleF(new PointF(45, reszidokhossza + (palyak[palya].Length + i - j + 2) * printFont.GetHeight(ev.Graphics)), new SizeF(45, printFont.GetHeight(ev.Graphics))), sf2);
                    ev.Graphics.DrawString((kiolvasott.ControlPunchList[i].PunchDateTime - kiolvasott.StartPunch.PunchDateTime).ToString(), printFont, Brushes.Black, new RectangleF(new PointF(90, reszidokhossza + (palyak[palya].Length + i - j + 2) * printFont.GetHeight(ev.Graphics)), new SizeF(90, printFont.GetHeight(ev.Graphics))), sf2);
                }
            }


            //végére szövegek

            ev.HasMorePages = false;

        }
    }
}
