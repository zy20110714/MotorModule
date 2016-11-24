using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Runtime.InteropServices;

/// <summary>
/// Inclusion of PEAK PCAN-Basic namespace
/// </summary>
using Peak.Can.Basic;
using TPCANHandle = System.UInt16;
using TPCANBitrateFD = System.String;
using TPCANTimestampFD = System.UInt64;

namespace ICDIBasic
{
    public partial class MainForm : Form
    {
     
        #region Delegates
        /// Read-Delegate Handler
        private delegate void ReadDelegateHandler();
        public delegate void changeID();
        public delegate void MessageHandler(MessageEventArgs e);
        #endregion

        #region Members

        private bool m_IsFD;                                 // Saves the desired connection mode

        public static TPCANHandle m_PcanHandle;             // Saves the handle of a PCAN hardware
        /// <summary>
        /// Saves the baudrate register for a conenction
        /// </summary>
        private TPCANBaudrate m_Baudrate;

        /// <summary>
        /// Read Delegate for calling the function "ReadMessages"
        /// </summary>
        //private ReadDelegateHandler m_ReadDelegate;
        //private changeID m_changeIDDelegate;

        /// <summary>
        /// Receive-Event
        /// </summary>
        public static AutoResetEvent m_ReceiveEvent;//通知正在等待的线程已发生接收事件

        /// <summary>
        /// Handles of the current available PCAN-Hardware
        /// </summary>
        private TPCANHandle[] m_HandlesArray;

        MotionControl mc;

        PCan pc;

        public static MainForm pCurrentWin = null;//句柄

        public MessageProccessing mthread = new MessageProccessing();

        public static bool FirstQRequest = false;

        ParametersForm pf;

        OscilloScope os;

        TestRun tr;

        Monitor mo;

        #endregion

        #region Methods
        public static MainForm GetInstance()
        {
            if (pCurrentWin == null)
            {
                pCurrentWin = new MainForm();
            }
            return pCurrentWin;
        }

        #region Help functions
        /// <summary>
        /// Convert a CAN DLC value into the actual data length of the CAN/CAN-FD frame.
        /// </summary>
        /// <param name="dlc">A value between 0 and 15 (CAN and FD DLC range)</param>
        /// <param name="isSTD">A value indicating if the msg is a standard CAN (FD Flag not checked)</param>
        /// <returns>The length represented by the DLC</returns>
        public static int GetLengthFromDLC(int dlc, bool isSTD)
        {
            if (dlc <= 8)
                return dlc;

             if (isSTD)
                return 8;

             switch (dlc)
             {
                case 9: return 12;
                case 10: return 16;
                case 11: return 20;
                case 12: return 24;
                case 13: return 32;
                case 14: return 48;
                case 15: return 64;
                default: return dlc;
            }
        }

        /// <summary>
        /// Initialization of PCAN-Basic components
        /// </summary>
        private void InitializeBasicComponents()
        {


            //Creates the list for received messages

            //m_LastMsgsList = new System.Collections.ArrayList();
            //Creates the delegate used for message reading


            //m_ReadDelegate = new ReadDelegateHandler(ReadMessages);

            //m_changeIDDelegate = new changeID(OnIDChange);

            //Creates the event used for signalize(发送信号指示) incomming messages
            m_ReceiveEvent = new AutoResetEvent(false);
            // Creates an array with all possible PCAN-Channels
            m_HandlesArray = new TPCANHandle[] 
            { 
                PCANBasic.PCAN_ISABUS1,
                PCANBasic.PCAN_ISABUS2,
                PCANBasic.PCAN_ISABUS3,
                PCANBasic.PCAN_ISABUS4,
                PCANBasic.PCAN_ISABUS5,
                PCANBasic.PCAN_ISABUS6,
                PCANBasic.PCAN_ISABUS7,
                PCANBasic.PCAN_ISABUS8,
                PCANBasic.PCAN_DNGBUS1,
                PCANBasic.PCAN_PCIBUS1,
                PCANBasic.PCAN_PCIBUS2,
                PCANBasic.PCAN_PCIBUS3,
                PCANBasic.PCAN_PCIBUS4,
                PCANBasic.PCAN_PCIBUS5,
                PCANBasic.PCAN_PCIBUS6,
                PCANBasic.PCAN_PCIBUS7,
                PCANBasic.PCAN_PCIBUS8,
                PCANBasic.PCAN_PCIBUS9,
                PCANBasic.PCAN_PCIBUS10,
                PCANBasic.PCAN_PCIBUS11,
                PCANBasic.PCAN_PCIBUS12,
                PCANBasic.PCAN_PCIBUS13,
                PCANBasic.PCAN_PCIBUS14,
                PCANBasic.PCAN_PCIBUS15,
                PCANBasic.PCAN_PCIBUS16,
                PCANBasic.PCAN_USBBUS1,
                PCANBasic.PCAN_USBBUS2,
                PCANBasic.PCAN_USBBUS3,
                PCANBasic.PCAN_USBBUS4,
                PCANBasic.PCAN_USBBUS5,
                PCANBasic.PCAN_USBBUS6,
                PCANBasic.PCAN_USBBUS7,
                PCANBasic.PCAN_USBBUS8,
                PCANBasic.PCAN_USBBUS9,
                PCANBasic.PCAN_USBBUS10,
                PCANBasic.PCAN_USBBUS11,
                PCANBasic.PCAN_USBBUS12,
                PCANBasic.PCAN_USBBUS13,
                PCANBasic.PCAN_USBBUS14,
                PCANBasic.PCAN_USBBUS15,
                PCANBasic.PCAN_USBBUS16,
                PCANBasic.PCAN_PCCBUS1,
                PCANBasic.PCAN_PCCBUS2,
                PCANBasic.PCAN_LANBUS1,
                PCANBasic.PCAN_LANBUS2,
                PCANBasic.PCAN_LANBUS3,
                PCANBasic.PCAN_LANBUS4,
                PCANBasic.PCAN_LANBUS5,
                PCANBasic.PCAN_LANBUS6,
                PCANBasic.PCAN_LANBUS7,
                PCANBasic.PCAN_LANBUS8,
                PCANBasic.PCAN_LANBUS9,
                PCANBasic.PCAN_LANBUS10,
                PCANBasic.PCAN_LANBUS11,
                PCANBasic.PCAN_LANBUS12,
                PCANBasic.PCAN_LANBUS13,
                PCANBasic.PCAN_LANBUS14,
                PCANBasic.PCAN_LANBUS15,
                PCANBasic.PCAN_LANBUS16,
            };

            // Fills and configures the Data of several comboBox components
            //
            FillComboBoxData();

            // Prepares the PCAN-Basic's debug-Log file
            //
            ConfigureLogFile();
        }

        /// <summary>
        /// Configures the Debug-Log file of PCAN-Basic
        /// </summary>
        private void ConfigureLogFile()
        {
            UInt32 iBuffer;

            // Sets the mask to catch all events
            //
            iBuffer = PCANBasic.LOG_FUNCTION_ALL;

            // Configures the log file. 
            // NOTE: The Log capability is to be used with the NONEBUS Handle. Other handle than this will 
            // cause the function fail.
            //
            PCANBasic.SetValue(PCANBasic.PCAN_NONEBUS, TPCANParameter.PCAN_LOG_CONFIGURE, ref iBuffer, sizeof(UInt32));
        }

        /// <summary>
        /// Configures the PCAN-Trace file for a PCAN-Basic Channel
        /// </summary>
        private void ConfigureTraceFile()
        {
            UInt32 iBuffer;
            TPCANStatus stsResult;

            // Configure the maximum size of a trace file to 5 megabytes
            //
            iBuffer = 5;
            stsResult = PCANBasic.SetValue(m_PcanHandle, TPCANParameter.PCAN_TRACE_SIZE, ref iBuffer, sizeof(UInt32));
            if (stsResult != TPCANStatus.PCAN_ERROR_OK)
                IncludeTextMessage(GetFormatedError(stsResult));

            // Configure the way how trace files are created: 
            // * Standard name is used
            // * Existing file is ovewritten, 
            // * Only one file is created.
            // * Recording stopts when the file size reaches 5 megabytes.
            //
            iBuffer = PCANBasic.TRACE_FILE_SINGLE | PCANBasic.TRACE_FILE_OVERWRITE;
            stsResult = PCANBasic.SetValue(m_PcanHandle, TPCANParameter.PCAN_TRACE_CONFIGURE, ref iBuffer, sizeof(UInt32));
            if (stsResult != TPCANStatus.PCAN_ERROR_OK)
                IncludeTextMessage(GetFormatedError(stsResult));
        }

        /// <summary>
        /// Help Function used to get an error as text
        /// </summary>
        /// <param name="error">Error code to be translated</param>
        /// <returns>A text with the translated error</returns>
        private string GetFormatedError(TPCANStatus error)
        {
            StringBuilder strTemp;

            // Creates a buffer big enough for a error-text
            //
            strTemp = new StringBuilder(256);
            // Gets the text using the GetErrorText API function
            // If the function success, the translated error is returned. If it fails,
            // a text describing the current error is returned.
            //
            if (PCANBasic.GetErrorText(error, 0, strTemp) != TPCANStatus.PCAN_ERROR_OK)
                return string.Format("An error occurred. Error-code's text ({0:X}) couldn't be retrieved", error);
            else
                return strTemp.ToString();
        }

        /// <summary>
        /// Includes a new line of text into the information Listview
        /// </summary>
        /// <param name="strMsg">Text to be included</param>
        private void IncludeTextMessage(string strMsg)
        {
            lbxInfo.Items.Add(strMsg);
            lbxInfo.SelectedIndex = lbxInfo.Items.Count - 1;
        }

        /// <summary>
        /// Gets the current status of the PCAN-Basic message filter
        /// </summary>
        /// <param name="status">Buffer to retrieve the filter status</param>
        /// <returns>If calling the function was successfull or not</returns>
        private bool GetFilterStatus(out uint status)
        {
            TPCANStatus stsResult;

            // Tries to get the sttaus of the filter for the current connected hardware
            //
            stsResult = PCANBasic.GetValue(m_PcanHandle, TPCANParameter.PCAN_MESSAGE_FILTER, out status, sizeof(UInt32));

            // If it fails, a error message is shown
            //
            if (stsResult != TPCANStatus.PCAN_ERROR_OK)
            {
                MessageBox.Show(GetFormatedError(stsResult));
                return false;
            }
            return true;
        }

        /// <summary>
        /// Configures the data of all ComboBox components of the main-form
        /// </summary>
        private void FillComboBoxData()
        {
            // Channels will be check
            //
            btnHwRefresh_Click(this, new EventArgs());

            // FD Bitrate: 
            //      Arbitration: 1 Mbit/sec 
            //      Data: 2 Mbit/sec
            //
            txtBitrate.Text = "f_clock_mhz=20, nom_brp=5, nom_tseg1=2, nom_tseg2=1, nom_sjw=1, data_brp=2, data_tseg1=3, data_tseg2=1, data_sjw=1";

            // Baudrates 
            //
            cbbBaudrates.SelectedIndex = 2; // 500 K

            // Hardware Type for no plugAndplay hardware
            //
            cbbHwType.SelectedIndex = 0;

            // Interrupt for no plugAndplay hardware
            //
            cbbInterrupt.SelectedIndex = 0;

            // IO Port for no plugAndplay hardware
            //
            cbbIO.SelectedIndex = 0;

            // Parameters for GetValue and SetValue function calls
            //
            cbbParameter.SelectedIndex = 0;
        }


        /// <summary>
        /// Gets the formated text for a PCAN-Basic channel handle
        /// </summary>
        /// <param name="handle">PCAN-Basic Handle to format</param>
        /// <param name="isFD">If the channel is FD capable</param>
        /// <returns>The formatted text for a channel</returns>
        private string FormatChannelName(TPCANHandle handle, bool isFD)
        {
            TPCANDevice devDevice;
            byte byChannel;

            // Gets the owner device and channel for a 
            // PCAN-Basic handle
            //
            if (handle < 0x100)
            {
                devDevice = (TPCANDevice)(handle >> 4);
                byChannel = (byte)(handle & 0xF);
            }
            else
            {
                devDevice = (TPCANDevice)(handle >> 8);
                byChannel = (byte)(handle & 0xFF);
            }

            // Constructs the PCAN-Basic Channel name and return it
            //
            if (isFD)
                return string.Format("{0}:FD {1} ({2:X2}h)", devDevice, byChannel, handle);
            else
                return string.Format("{0} {1} ({2:X2}h)", devDevice, byChannel, handle);
        }

        /// <summary>
        /// Gets the formated text for a PCAN-Basic channel handle
        /// </summary>
        /// <param name="handle">PCAN-Basic Handle to format</param>
        /// <returns>The formatted text for a channel</returns>
        private string FormatChannelName(TPCANHandle handle)
        {
            return FormatChannelName(handle, false);
        }
        #endregion


        #region Event Handlers
        #region Form event-handlers
        /// <summary>
        /// Consturctor
        /// </summary>
        public MainForm()
        {
            // Initializes Form's component
            //this.Location = new Point(Screen.PrimaryScreen.Bounds.Width - 400, Screen.PrimaryScreen.Bounds.Height - 400);
            InitializeComponent();

            mc = new MotionControl();
            pc = new PCan();

            // Initializes specific components
            InitializeBasicComponents();

            InitialMainForm();

            this.mc.MessageSend += new MotionControl.MessageEventHandler(this.mThread_MessageSend);


        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            //mthread.MessageSend += new MessageProccessing.MessageEventHandler(this.mThread_MessageSend);
            mthread.StartSend();

            //搜索CAN总线上的模块
            pc.SearchModuleID();
            //等待返回ID号
            Thread.Sleep(150);
            try
            {
                for (int i = 0; i < MessageProccessing.allID.Count; i++)
                {
                    if (!cBID.Items.Contains(MessageProccessing.allID[i]))
                    {
                        cBID.Items.Add(MessageProccessing.allID[i]);
                    }
                }
            }
            catch (System.Exception ex)
            {
                MainForm.GetInstance().sBFeedbackShow(ex.Message, 1);
            }

            InitialMemoryControlTable();

           // btnParameters_Click(this, new EventArgs());

            //pc.WriteOneWord(Configuration.SCP_TRI_FLG, 1, PCan.currentID);   //用户触发
        }

        //子线程代理
        private void mThread_MessageSend(object sender, MessageEventArgs e)
        {
            //实例化代理
            MessageHandler handler = new MessageHandler(Message);
            //调用Invoke
            this.Invoke(handler, new object[] { e });
        }

          //线程间消息传递函数
        public void Message(MessageEventArgs e)
        {
            MainForm.GetInstance().sBFeedbackShow(e.Action, 0);
        }

        /// <summary>
        /// Form-Closing Function / Finish function
        /// </summary>
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            // 结束运动
            if(tr != null)
            {
                tr.clearValue();
            }
           
            tMMainFormRefresh.Stop();

            // Releases the used PCAN-Basic channel
            if (btnRelease.Enabled)
                btnRelease_Click(this, new EventArgs());
            //释放CAN总线线程
            if (mthread != null)
            {
                mthread.Abort();
                mthread.Join();//Abort和Join配合使用，结束线程，参考http://www.cnblogs.com/colin2011/archive/2011/11/19/2255212.html
                mthread = null;
            }
            //释放运动控制线程
            mc.Stop();
            mc = null;
           
            UnInitialModule();
        }

        private void InitialMainForm()
        {
            tMMainFormRefresh.Start();
            Configuration cf = new Configuration();
       
            //this.IsMdiContainer = true;    Done with the property of MainForm
            btnHwRefresh_Click(this, new EventArgs());
            Thread.Sleep(1);
            bool IsInitialSucessed = InitPcan();
            Thread.Sleep(10);
            if (IsInitialSucessed)
            {
                sBFeedbackShow("PCAN USB", 0);
                sBFeedbackShow("CAN总线初始化成功！", 1);
            }
            else
            {
                MessageBox.Show("CAN总线初始化失败！");
            }

            ////调试用，临时允许出现5个窗口
            //btnParameters.Enabled = true;
            //btnRun.Enabled = true;
            //btnWave.Enabled = true;
            //btnMonitor.Enabled = true;
            //btnFlash.Enabled = true;
        }


        public void InitialMemoryControlTable()
        {
            if (cBID.Text == "")
            {
                //MessageBox.Show("没有模块！");
            } 
            else
            {
                FirstQRequest = true;
                PCan.currentID = Convert.ToByte(cBID.Text);
                pc.ReadWords(0x00, 16, PCan.currentID);
                Thread.Sleep(1);
                pc.ReadWords(0x10, 16, PCan.currentID);
                Thread.Sleep(1);
                pc.ReadWords(0x20, 16, PCan.currentID);
                Thread.Sleep(1);
                pc.ReadWords(0x30, 16, PCan.currentID);
                Thread.Sleep(1);
                pc.ReadWords(0x40, 16, PCan.currentID);
                Thread.Sleep(1);
                pc.ReadWords(0x50, 16, PCan.currentID);
                Thread.Sleep(1);
                pc.ReadWords(0x60, 16, PCan.currentID);
                Thread.Sleep(1);
                pc.ReadWords(0x70, 16, PCan.currentID);
                Thread.Sleep(1);
                pc.ReadWords(0x80, 16, PCan.currentID);
                Thread.Sleep(1);
                pc.ReadWords(0x90, 16, PCan.currentID);
                Thread.Sleep(1);
                //最后一个数据用于确认信息
                pc.ReadWords(Configuration.SCP_MEAPOS_H, 1, PCan.currentID);
                Thread.Sleep(1);
            }
        }

        void UnInitialModule()
        {
            pc.WriteOneWord(Configuration.SCP_MASK, 0x00, PCan.currentID);       //向下位机
        }
        #endregion


        #region Radio- and Check- Buttons event-handlers
        private void chbShowPeriod_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void chbCanFD_CheckedChanged(object sender, EventArgs e)
        {
            m_IsFD = chbCanFD.Checked;

            cbbBaudrates.Visible = !m_IsFD;
            cbbHwType.Visible = !m_IsFD;
            cbbInterrupt.Visible = !m_IsFD;
            cbbIO.Visible = !m_IsFD;

            txtBitrate.Visible = m_IsFD;
        }

        #endregion

        #endregion

        #endregion
        [DllImport("user32")]
        public static extern int SetParent(int hWndChild, int hWndNewParent);

        public static bool IsDataRecieved = false;
        public static short IDName = 0;

        #region ComboBox event-handlers
        private void cbbChannel_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool bNonPnP;
            string strTemp;

            // Get the handle fromt he text being shown
            //
            strTemp = cbbChannel.Text;
            strTemp = strTemp.Substring(strTemp.IndexOf('(') + 1, 3);

            strTemp = strTemp.Replace('h', ' ').Trim(' ');

            // Determines if the handle belong to a No Plug&Play hardware 
            //
            m_PcanHandle = Convert.ToUInt16(strTemp, 16);
            bNonPnP = m_PcanHandle <= PCANBasic.PCAN_DNGBUS1;
            // Activates/deactivates configuration controls according with the 
            // kind of hardware
            //
            cbbHwType.Enabled = bNonPnP;
            cbbIO.Enabled = bNonPnP;
            cbbInterrupt.Enabled = bNonPnP;
        }

        private void cbbBaudrates_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Saves the current selected baudrate register code
            //
            switch (cbbBaudrates.SelectedIndex)
            {
                case 0:
                    m_Baudrate = TPCANBaudrate.PCAN_BAUD_1M;
                    break;
                case 1:
                    m_Baudrate = TPCANBaudrate.PCAN_BAUD_800K;
                    break;
                case 2:
                    m_Baudrate = TPCANBaudrate.PCAN_BAUD_500K;
                    break;
                case 3:
                    m_Baudrate = TPCANBaudrate.PCAN_BAUD_250K;
                    break;
                case 4:
                    m_Baudrate = TPCANBaudrate.PCAN_BAUD_125K;
                    break;
                case 5:
                    m_Baudrate = TPCANBaudrate.PCAN_BAUD_100K;
                    break;
                case 6:
                    m_Baudrate = TPCANBaudrate.PCAN_BAUD_95K;
                    break;
                case 7:
                    m_Baudrate = TPCANBaudrate.PCAN_BAUD_83K;
                    break;
                case 8:
                    m_Baudrate = TPCANBaudrate.PCAN_BAUD_50K;
                    break;
                case 9:
                    m_Baudrate = TPCANBaudrate.PCAN_BAUD_47K;
                    break;
                case 10:
                    m_Baudrate = TPCANBaudrate.PCAN_BAUD_33K;
                    break;
                case 11:
                    m_Baudrate = TPCANBaudrate.PCAN_BAUD_20K;
                    break;
                case 12:
                    m_Baudrate = TPCANBaudrate.PCAN_BAUD_10K;
                    break;
                case 13:
                    m_Baudrate = TPCANBaudrate.PCAN_BAUD_5K;
                    break;
            }
        }

        private void cbbHwType_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        #endregion

        #region Button event-handlers
        private void btnHwRefresh_Click(object sender, EventArgs e)
        {
            UInt32 iBuffer;
            TPCANStatus stsResult;
            bool isFD;

            // Clears the Channel combioBox and fill it again with 
            // the PCAN-Basic handles for no-Plug&Play hardware and
            // the detected Plug&Play hardware
            //
            cbbChannel.Items.Clear();
            try
            {
                for (int i = 0; i < m_HandlesArray.Length; i++)
                {
                    // Includes all no-Plug&Play Handles
                    if (m_HandlesArray[i] <= PCANBasic.PCAN_DNGBUS1)
                        cbbChannel.Items.Add(FormatChannelName(m_HandlesArray[i]));
                    else
                    {
                        // Checks for a Plug&Play Handle and, according with the return value, includes it
                        // into the list of available hardware channels.
                        //
                        stsResult = PCANBasic.GetValue(m_HandlesArray[i], TPCANParameter.PCAN_CHANNEL_CONDITION, out iBuffer, sizeof(UInt32));
                        if ((stsResult == TPCANStatus.PCAN_ERROR_OK) && ((iBuffer & PCANBasic.PCAN_CHANNEL_AVAILABLE) == PCANBasic.PCAN_CHANNEL_AVAILABLE))
                        {
                            stsResult = PCANBasic.GetValue(m_HandlesArray[i], TPCANParameter.PCAN_CHANNEL_FEATURES, out iBuffer, sizeof(UInt32));
                            isFD = (stsResult == TPCANStatus.PCAN_ERROR_OK) && ((iBuffer & PCANBasic.FEATURE_FD_CAPABLE) == PCANBasic.FEATURE_FD_CAPABLE);
                            cbbChannel.Items.Add(FormatChannelName(m_HandlesArray[i], isFD));
                        }
                    }
                }
                cbbChannel.SelectedIndex = cbbChannel.Items.Count - 1;
                btnInit.Enabled = cbbChannel.Items.Count > 0;
            }
            catch (DllNotFoundException)
            {
                MessageBox.Show("Unable to find the library: PCANBasic.dll !", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(-1);
            }
        }

        private bool InitPcan()
        {
            TPCANStatus stsResult;

            // Connects a selected PCAN-Basic channel
            //
            if (m_IsFD)
                stsResult = PCANBasic.InitializeFD(
                    m_PcanHandle,
                    txtBitrate.Text);
            else
                m_Baudrate = TPCANBaudrate.PCAN_BAUD_1M;
            stsResult = PCANBasic.Initialize(
                m_PcanHandle,
                m_Baudrate,
                0,
                0,
                0);

            if (stsResult != TPCANStatus.PCAN_ERROR_OK)
                if (stsResult != TPCANStatus.PCAN_ERROR_CAUTION)
                    MessageBox.Show(GetFormatedError(stsResult));
                else
                {
                    IncludeTextMessage("******************************************************");
                    IncludeTextMessage("The bitrate being used is different than the given one");
                    IncludeTextMessage("******************************************************");
                    stsResult = TPCANStatus.PCAN_ERROR_OK;
                }
            else
                // Prepares the PCAN-Basic's PCAN-Trace file
                //
                ConfigureTraceFile();

            // Sets the connection status of the main-form
            //
            //SetConnectionStatus(stsResult == TPCANStatus.PCAN_ERROR_OK);
            if (stsResult == TPCANStatus.PCAN_ERROR_OK)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void btnRelease_Click(object sender, EventArgs e)
        {
            // Releases a current connected PCAN-Basic channel
            PCANBasic.Uninitialize(m_PcanHandle);
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            TPCANStatus stsResult;

            // Resets the receive and transmit queues of a PCAN Channel.
            //
            stsResult = PCANBasic.Reset(m_PcanHandle);

            // If it fails, a error message is shown
            //
            if (stsResult != TPCANStatus.PCAN_ERROR_OK)
                MessageBox.Show(GetFormatedError(stsResult));
            else
                IncludeTextMessage("Receive and transmit queues successfully reset");
        }

        private void btnStatus_Click(object sender, EventArgs e)
        {
            TPCANStatus stsResult;
            String errorName;

            // Gets the current BUS status of a PCAN Channel.
            //
            stsResult = PCANBasic.GetStatus(m_PcanHandle);

            // Switch On Error Name
            //
            switch (stsResult)
            {
                case TPCANStatus.PCAN_ERROR_INITIALIZE:
                    errorName = "PCAN_ERROR_INITIALIZE";
                    break;

                case TPCANStatus.PCAN_ERROR_BUSLIGHT:
                    errorName = "PCAN_ERROR_BUSLIGHT";
                    break;

                case TPCANStatus.PCAN_ERROR_BUSHEAVY: // TPCANStatus.PCAN_ERROR_BUSWARNING
                    errorName = m_IsFD ? "PCAN_ERROR_BUSWARNING" : "PCAN_ERROR_BUSHEAVY";
                    break;

                case TPCANStatus.PCAN_ERROR_BUSPASSIVE:
                    errorName = "PCAN_ERROR_BUSPASSIVE";
                    break;

                case TPCANStatus.PCAN_ERROR_BUSOFF:
                    errorName = "PCAN_ERROR_BUSOFF";
                    break;

                case TPCANStatus.PCAN_ERROR_OK:
                    errorName = "PCAN_ERROR_OK";
                    break;

                default:
                    errorName = "See Documentation";
                    break;
            }

            // Display Message
            //
            IncludeTextMessage(String.Format("Status: {0} ({1:X}h)", errorName, stsResult));
        }

        #endregion

        #region Timer event-handler

        private void tMMainFormRefresh_Tick(object sender, EventArgs e)
        {
            //用定时器更新MainForm底部的时间显示。ID = 3，对应sBFeedback里的statusBarPanel4，即tt4
            sBFeedbackShow(DateTime.Today.ToShortDateString() + " " + DateTime.Now.ToLongTimeString(), 3);
        }

        #endregion

        private void btnParameters_Click(object sender, EventArgs e)
        {
            pf = ParametersForm.GetInstance();
            pf.StartPosition = FormStartPosition.Manual;
            pf.Location = new Point(0, 60);
            pf.MdiParent = this;
            pf.BringToFront();
            pf.Show();
            //SetParent((int)pf.Handle, (int)this.Handle);
        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            tr = TestRun.GetInstance();
            tr.StartPosition = FormStartPosition.Manual;
            tr.Location = new Point(1100, 60);
            tr.MdiParent = this;
            tr.BringToFront();
            //SetParent((int)tr.Handle, (int)this.Handle);
            tr.Show();
        }


        private void btnWave_Click(object sender, EventArgs e)
        {
            os = OscilloScope.GetInstance();
            os.StartPosition = FormStartPosition.Manual;
            os.Location = new Point(0, 60);
            os.MdiParent = this;
            //os.Parent = pLMain;
            os.BringToFront();
            os.Show();
            //SetParent((int)os.Handle, (int)this.Handle);
        }

        private void btnMonitor_Click(object sender, EventArgs e)
        {
            mo = Monitor.GetInstance();
            mo.StartPosition = FormStartPosition.Manual;
            mo.Location = new Point(0, 60);
            mo.MdiParent = this;
            //mo.Parent = pLMain;
            mo.BringToFront();
            mo.Show();
            //SetParent((int)mo.Handle, (int)this.Handle);
        }

        //获取ID的菜单下拉事件
        private void cBID_DropDown(object sender, EventArgs e)
        {
            cBID.Items.Clear();
            MessageProccessing.allID.Clear();
            pc.SearchModuleID();
            //等待返回ID号
            Thread.Sleep(150);
            try
            {
                for (int i = 0; i < MessageProccessing.allID.Count; i++)
                {
                    if (!cBID.Items.Contains(MessageProccessing.allID[i]))//allID[]中添加元素的方案已经确定了不会有重复项，没必要再判断
                    {
                        cBID.Items.Add(MessageProccessing.allID[i]);
                    }
                }
            }
            catch (System.Exception ex)
            {
                MainForm.GetInstance().sBFeedbackShow(ex.Message, 1);
            }
        }

        public void sBFeedbackShow(string message, int index)
        {
            sBFeedback.Panels[index].Text = message;
        }

        private void cBID_TextChanged(object sender, EventArgs e)
        {
            //关闭试运行的运动控制，相当于按了“红叉”和“停止”“停止随机”
            if (tr != null)
            {
                tr.StopManCtrl();//若手动控制运行中，则会产生停止效果
                tr.StopRandomMotion();//若随机运动控制运行中，则会产生停止效果
                tr.clearValue();//若波形发生器运行中，则会产生停止效果
            }



            if (cBID.Text != "")
            {
                //btnParameters.Enabled = true;//暂时不提供参数表功能
                btnRun.Enabled = true;
                btnWave.Enabled = true;
                btnMonitor.Enabled = true;
                btnFlash.Enabled = true;
                PCan.currentID = Convert.ToByte(cBID.Text);
                pc.WriteOneWord(Configuration.SYS_ID, PCan.currentID, PCan.currentID);
                InitialMemoryControlTable();
                if (pf != null)
                {
                    pf.RefreshlVParam(ParametersForm.tVIndex);
                }
                //更新底部模块类型显示
                string modelType = "";
                switch (Configuration.MemoryControlTable[0x02])
                {
                    case 16: modelType = "M14"; break;
                    case 17: modelType = "M14E"; break;
                    case 2:
                    case 32: modelType = "M17"; break;
                    case 33: modelType = "M17E"; break;
                    case 48: modelType = "M20"; break;
                    case 64: modelType = "LIFT"; break;
                }
                GetInstance().sBFeedbackShow("驱动器型号：" + modelType, 4);
                //更新底部模块减速比显示
                GetInstance().sBFeedbackShow("模块减速比：" + Configuration.MemoryControlTable[0x07].ToString(), 5);
            }
            else
            {
                btnParameters.Enabled = false;
                btnRun.Enabled = false;
                btnWave.Enabled = false;
                btnMonitor.Enabled = false;
                btnFlash.Enabled = false;
                //更新底部模块类型显示
                GetInstance().sBFeedbackShow("驱动器型号：", 4);
                //更新底部模块减速比显示
                GetInstance().sBFeedbackShow("模块减速比：", 5);
            }
        }

        //单击烧写flash
        private void btnFlash_Click(object sender, EventArgs e)
        {
            WriteParameters wp;
            wp = WriteParameters.GetInstance();
            wp.StartPosition = FormStartPosition.Manual;
            wp.Location = new Point(205, 125);
            wp.MdiParent = this;
            wp.BringToFront();
            wp.Show();
        }
    }
}
