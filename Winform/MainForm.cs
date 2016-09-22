﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading;
using System.Windows.Forms;

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
        /// Activates/deaactivates the different controls of the main-form according
        /// with the current connection status
        /// </summary>
        /// <param name="bConnected">Current status. True if connected, false otherwise</param>
        //private void SetConnectionStatus(bool bConnected)
        //{
        //    // Buttons
        //    //
        //    btnInit.Enabled = !bConnected;
        //    //btnRead.Enabled = bConnected && rdbManual.Checked;
        //    //btnWrite.Enabled = bConnected;
        //    btnRelease.Enabled = bConnected;
        //    btnFilterApply.Enabled = bConnected;
        //    btnFilterQuery.Enabled = bConnected;
        //    btnGetVersions.Enabled = bConnected;
        //    btnHwRefresh.Enabled = !bConnected;
        //    btnStatus.Enabled = bConnected;
        //    btnReset.Enabled = bConnected;

        //    // ComboBoxs
        //    //
        //    cbbChannel.Enabled = !bConnected;
        //    cbbBaudrates.Enabled = !bConnected;
        //    cbbHwType.Enabled = !bConnected;
        //    cbbIO.Enabled = !bConnected;
        //    cbbInterrupt.Enabled = !bConnected;

        //    // Check-Buttons
        //    //
        //    chbCanFD.Enabled = !bConnected;

        //    // Hardware configuration and read mode
        //    //
        //    if (!bConnected)
        //        cbbChannel_SelectedIndexChanged(this, new EventArgs());
        //    else
        //        rdbTimer_CheckedChanged(this, new EventArgs());

        //    // Display messages in grid
        //    //
           
        //}

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
                if (MessageProccessing.allID.Count > 0)
                {
                     tMCheck.Enabled = true;
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
            
            //Int32 speed = 337892;
            //byte[] tt = BitConverter.GetBytes(speed);
            //short a = (short)speed;
            //short b = (short)(speed >> 16);
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


        //#region Message List-View event-handler
        //private void lstMessages_DoubleClick(object sender, EventArgs e)
        //{
        //    // Clears the content of the Message List-View
        //    //
        //    btnMsgClear_Click(this, new EventArgs());
        //}
        //#endregion

        //#region Information List-Box event-handler
        //private void lbxInfo_DoubleClick(object sender, EventArgs e)
        //{
        //    // Clears the content of the Information List-Box
        //    //
        //    btnInfoClear_Click(this, new EventArgs());
        //}
        //#endregion

        //#region Textbox event handlers
        //private void txtID_Leave(object sender, EventArgs e)
        //{
        //    int iTextLength;
        //    uint uiMaxValue;

        //    // Calculates the text length and Maximum ID value according
        //    // with the Message Type
        //    //
        //    iTextLength = (chbExtended.Checked) ? 8 : 3;
        //    uiMaxValue = (chbExtended.Checked) ? (uint)0x1FFFFFFF : (uint)0x7FF;

        //    // The Textbox for the ID is represented with 3 characters for 
        //    // Standard and 8 characters for extended messages.
        //    // Therefore if the Length of the text is smaller than TextLength,  
        //    // we add "0"
        //    //
        //    while (txtID.Text.Length != iTextLength)
        //        txtID.Text = ("0" + txtID.Text);

        //    // We check that the ID is not bigger than current maximum value
        //    //
        //    if (Convert.ToUInt32(txtID.Text, 16) > uiMaxValue)
        //        txtID.Text = string.Format("{0:X" + iTextLength.ToString() + "}", uiMaxValue);
        //}

        //private void txtID_KeyPress(object sender, KeyPressEventArgs e)
        //{
        //    char chCheck;

        //    // We convert the Character to its Upper case equivalent
        //    //
        //    chCheck = char.ToUpper(e.KeyChar);

        //    // The Key is the Delete (Backspace) Key
        //    //
        //    if (chCheck == 8)
        //        return;
        //    // The Key is a number between 0-9
        //    //
        //    if ((chCheck > 47) && (chCheck < 58))
        //        return;
        //    // The Key is a character between A-F
        //    //
        //    if ((chCheck > 64) && (chCheck < 71))
        //        return;

        //    // Is neither a number nor a character between A(a) and F(f)
        //    //
        //    e.Handled = true;
        //}

        //private void txtData0_Leave(object sender, EventArgs e)
        //{
        //    TextBox txtbCurrentTextbox;

        //    // all the Textbox Data fields are represented with 2 characters.
        //    // Therefore if the Length of the text is smaller than 2, we add
        //    // a "0"
        //    //
        //    if (sender.GetType().Name == "TextBox")
        //    {
        //        txtbCurrentTextbox = (TextBox)sender;
        //        while (txtbCurrentTextbox.Text.Length != 2)
        //            txtbCurrentTextbox.Text = ("0" + txtbCurrentTextbox.Text);
        //    }
        //}
        //#endregion

        #region Radio- and Check- Buttons event-handlers
        private void chbShowPeriod_CheckedChanged(object sender, EventArgs e)
        {
            // According with the check-value of this checkbox,
            // the recieved time of a messages will be interpreted as 
            // period (time between the two last messages) or as time-stamp
            // (the elapsed time since windows was started)
            //
            //lock (m_LastMsgsList.SyncRoot)
            //{
            //    foreach (MessageStatus msg in m_LastMsgsList)
            //        msg.ShowingPeriod = chbShowPeriod.Checked;
            //}
        }

        //private void chbExtended_CheckedChanged(object sender, EventArgs e)
        //{
        //    uint uiTemp;

        //    txtID.MaxLength = (chbExtended.Checked) ? 8 : 3;

        //    // the only way that the text length can be bigger als MaxLength
        //    // is when the change is from Extended to Standard message Type.
        //    // We have to handle this and set an ID not bigger than the Maximum
        //    // ID value for a Standard Message (0x7FF)
        //    //
        //    if (txtID.Text.Length > txtID.MaxLength)
        //    {
        //        uiTemp = Convert.ToUInt32(txtID.Text, 16);
        //        txtID.Text = (uiTemp < 0x7FF) ? string.Format("{0:X3}", uiTemp) : "7FF";
        //    }

        //}

        //private void chbFilterExt_CheckedChanged(object sender, EventArgs e)
        //{
        //    int iMaxValue;

        //    iMaxValue = (chbFilterExt.Checked) ? 0x1FFFFFFF : 0x7FF;

        //    // We check that the maximum value for a selected filter 
        //    // mode is used
        //    //
        //    if (nudIdTo.Value > iMaxValue)
        //        nudIdTo.Value = iMaxValue;
        //    nudIdTo.Maximum = iMaxValue;

        //    if (nudIdFrom.Value > iMaxValue)
        //        nudIdFrom.Value = iMaxValue;
        //    nudIdFrom.Maximum = iMaxValue;
        //}

        //private void rdbTimer_CheckedChanged(object sender, EventArgs e)
        //{
        //    if (!btnRelease.Enabled)
        //        return;

        //    // According with the kind of reading, a timer, a thread or a button will be enabled
        //    //
        //    if (rdbTimer.Checked)
        //    {
        //        // Abort Read Thread if it exists
        //        //
        //        //if (m_ProcessThread != null)
        //        //{
        //        //    m_ProcessThread.Abort();
        //        //    m_ProcessThread.Join();
        //        //    m_ProcessThread = null;
        //        //}

        //        // Enable Timer
        //        //
        //        //tMMainFormRefresh.Enabled = btnRelease.Enabled;
        //    }
        //    if (rdbEvent.Checked)
        //    {
        //        // Disable Timer
        //        //
        //        //tMMainFormRefresh.Enabled = false;
        //        // Create and start the tread to read CAN Message using SetRcvEvent()
        //        //

        //    }
        //    if (rdbManual.Checked)
        //    {
        //        // Abort Read Thread if it exists
        //        //
        //        //if (m_ProcessThread != null)
        //        //{
        //        //    m_ProcessThread.Abort();
        //        //    m_ProcessThread.Join();
        //        //    m_ProcessThread = null;
        //        //}
        //        // Disable Timer
        //        //
        //        //tMMainFormRefresh.Enabled = false;
        //    }
        //    //btnRead.Enabled = btnRelease.Enabled && rdbManual.Checked;
        //}
        private void chbCanFD_CheckedChanged(object sender, EventArgs e)
        {
            m_IsFD = chbCanFD.Checked;

            cbbBaudrates.Visible = !m_IsFD;
            cbbHwType.Visible = !m_IsFD;
            cbbInterrupt.Visible = !m_IsFD;
            cbbIO.Visible = !m_IsFD;
            //laBaudrate.Visible = !m_IsFD;
            //laHwType.Visible = !m_IsFD;
            //laIOPort.Visible = !m_IsFD;
            //laInterrupt.Visible = !m_IsFD;

            txtBitrate.Visible = m_IsFD;
            //laBitrate.Visible = m_IsFD;
            //chbFD.Visible = m_IsFD;
            //chbBRS.Visible = m_IsFD;

            //if ((nudLength.Maximum > 8) && !m_IsFD)
            //    chbFD.Checked = false;
        }



        #endregion

        #endregion

        #endregion

        private void cBID_TextChanged(object sender, EventArgs e)
        {
            if (cBID.Text != "")
            {
                btnParameters.Enabled = true;
                btnRun.Enabled = true;
                btnWave.Enabled = true;
                btnMonitor.Enabled = true;
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
                //更新底部模块类型显示
                GetInstance().sBFeedbackShow("驱动器型号：", 4);
                //更新底部模块减速比显示
                GetInstance().sBFeedbackShow("模块减速比：", 5);
            }
        }
    }
}
