using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.IO;

namespace ICDIBasic
{
    public partial class Monitor : Form
    {
        private static Monitor pCurrentWin = null;
        private PCan pc;

        public static Monitor GetInstance()
        {
            if (pCurrentWin == null)
            {
                pCurrentWin = new Monitor();
            }
            return pCurrentWin;
        }

        private delegate void FlushClient();

        private Monitor()
        {
            InitializeComponent();
            pc = new PCan();
            refresh();
        }

        private void Monitor_FormClosed(object sender, FormClosedEventArgs e)
        {
            pCurrentWin = null;
            IsMonitorError1 = false;//在未停止查询的情况下，关闭查询线程
        }

        #region 对编码器寄存器读写线程

        #region 输入tBRegisterNumber

        private short registerNumber = 0x7700;

        private void tBRegisterNumber_InputDone()
        {
            try
            {
                registerNumber = Convert.ToInt16(tBRegisterNumber.Text, 16);
            }
            catch (System.Exception ex)
            {
                tBRegisterNumber.Text = Convert.ToString(registerNumber, 16);
                MessageBox.Show("请输入合法的数值！");
                MainForm.GetInstance().sBFeedbackShow(ex.Message, 1);
            }
        }

        private void tBRegisterNumber_Leave(object sender, EventArgs e)
        {
            tBRegisterNumber_InputDone();
        }

        private void tBRegisterNumber_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                tBRegisterNumber_InputDone();
            }
        }
        #endregion

        #region 输入tBInterval
        private int interval = 1000;

        private void tBInterval_InputDone()
        {
            try
            {
                interval = Convert.ToInt32(tBInterval.Text);
            }
            catch (System.Exception ex)
            {
                tBInterval.Text = Convert.ToString(interval);
                MessageBox.Show("请输入合法的数值！");
                MainForm.GetInstance().sBFeedbackShow(ex.Message, 1);
            }
        }

        private void tBInterval_Leave(object sender, EventArgs e)
        {
            tBInterval_InputDone();
        }

        private void tBInterval_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                tBInterval_InputDone();
            }
        }
        #endregion

        private void Log(String logMessage, TextWriter w)
        {
            //w.Write("{0} ", w.);//行号？
            w.Write("{0} {1} ", DateTime.Now.ToLongDateString(), DateTime.Now.ToLongTimeString());
            w.WriteLine("{0}", logMessage);
            // Update the underlying file.
            w.Flush();
        }
        private void IsFileExist()
        {
            if (!File.Exists("MonitorErrorData" + DateTime.Now.ToLongDateString() + ".log"))
            {
                StreamWriter fs = File.CreateText("MonitorErrorData" + DateTime.Now.ToLongDateString() + ".log");
                fs.Write("日    期      时间     ", DateTime.Now.ToLongDateString(), DateTime.Now.ToLongTimeString());
                fs.WriteLine("查询 返回");
                fs.Close();
            }
        }
        private void CheckFile()
        {
            //FileStream fs = new FileStream("MonitorErrorData" + DateTime.Now.ToLongDateString() + ".log", FileMode.Open);
            //StreamReader m_streamReader = new StreamReader(fs);
            ////fs.Seek(-1, SeekOrigin.Current);//定位在当前位置上移动一个位置
            ////using (StreamReader sr = new StreamReader("MonitorErrorData" + DateTime.Now.ToLongDateString() + ".log"))
            ////{
            ////    String line = sr.
            ////    ResultBlock.Text = line;
            ////}
            //m_streamReader.BaseStream.Seek(0, SeekOrigin.End);
            //m_streamReader.BaseStream.Seek(-1, SeekOrigin.Current);
            //string arry = "";

            //string strLine = m_streamReader.ReadLine();
            //do
            //{
            //    string[] split = strLine.Split(' ');
            //    string a = split[0];
            //    if (a == "2016年7月22日")
            //    {
            //        arry += strLine + "\n";
            //    }
            //    strLine = m_streamReader.ReadLine();
            //} while (strLine != null && strLine != "");
            //fs.Close();
            //fs.Dispose();
            //MessageBox.Show(arry);
            //arry = "";
        }
        private void WriteLog(string registerID)
        {
            IsFileExist();
            using (StreamWriter w = File.AppendText("MonitorErrorData" + DateTime.Now.ToLongDateString() + ".log"))
            {
                string tempStr = registerID + " " + Configuration.MemoryControlTable[0x08].ToString("x4");
                Log(tempStr, w);
                // Close the writer and underlying file.
                w.Close();
            }
            CheckFile();
        }

        //监视错误用线程（并不是精确地每1000 ms）
        private void ThreadMonitorError()
        {
            while (IsMonitorError1)
            {
                pc.WriteOneWord(0x08, registerNumber, PCan.currentID);
                //Thread.Sleep(10);
                pc.ReadOneWord(0x08, PCan.currentID);
                //Thread.Sleep(10);
                MonitorError();

                Thread.Sleep(interval);
                //关闭窗口之后报错：
                //“System.InvalidOperationException”类型的未经处理的异常在 System.Windows.Forms.dll 中发生
                //其他信息: 在创建窗口句柄之前，不能在控件上调用 Invoke 或 BeginInvoke。
                //Invoke((EventHandler)(delegate
                //{
                //    if ((Configuration.MemoryControlTable[0x0d] >> 8) == registerNumber2)
                //    {
                //        Monitor77.Text = Configuration.MemoryControlTable[0x0d].ToString("x4");
                //    }
                //    else
                //    {
                //        Monitor77.Text = "未及时更新";
                //    }
                //}));
            }
            threadMonitorError = null;
        }

        private void MonitorError()
        {
            if (label1.InvokeRequired)//等待异步
            {
                FlushClient ME = new FlushClient(MonitorError);
                Invoke(ME); //通过代理调用刷新方法
                //关闭窗口之后有一次报错
            }
            else
            {
                if ((Configuration.MemoryControlTable[0x0d] >> 8) == 00 && PCan.currentID != 0)
                {
                    Monitor76.Text = Configuration.MemoryControlTable[0x08].ToString("x4");
                    WriteLog(registerNumber.ToString("x4"));
                }
                //else if ((Configuration.MemoryControlTable[0x0d] >> 8) == registerNumber2)
                //{
                //    Monitor77.Text = Configuration.MemoryControlTable[0x0d].ToString("x4");
                //}
                else
                {
                    Monitor76.Text = "未及时更新";
                    //Monitor77.Text = "未及时更新";
                }
            }
        }

        //监视错误启停按钮，创建后台线程
        Thread threadMonitorError = null;
        private bool IsMonitorError1 = false;

        private void btnMonitorStart_Click(object sender, EventArgs e)
        {
            if (tBRegisterNumber.Text == "")
            {
                MessageBox.Show("还未输入！");
            }
            else
            {
                if (threadMonitorError == null)
                {
                    threadMonitorError = new Thread(ThreadMonitorError);
                    threadMonitorError.IsBackground = true;

                    IsMonitorError1 = true;
                    btnMonitorStart.Text = "停止发送";

                    threadMonitorError.Start();
                }
                else
                {
                    if (IsMonitorError1 == false)
                    {
                        IsMonitorError1 = true;
                        btnMonitorStart.Text = "停止发送";
                    }
                    else
                    {
                        IsMonitorError1 = false;
                        Monitor76.Text = "未启动";
                        btnMonitorStart.Text = "开始查询";
                    }
                }
            }
        }

        #region 写寄存器

        #region 输入tBRegisterNumber2
        private short registerNumber2 = 0x0000;
        private void tBRegisterNumber2_InputDone()
        {
            try
            {
                registerNumber2 = Convert.ToInt16(tBRegisterNumber2.Text, 16);
            }
            catch (System.Exception ex)
            {
                tBRegisterNumber2.Text = Convert.ToString(registerNumber2, 16);
                MessageBox.Show("请输入合法的数值！");
                MainForm.GetInstance().sBFeedbackShow(ex.Message, 1);
            }
        }

        private void tBRegisterNumber2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                tBRegisterNumber2_InputDone();
            }
        }

        private void tBRegisterNumber2_Leave(object sender, EventArgs e)
        {
            tBRegisterNumber2_InputDone();
        }
        #endregion

        //写寄存器
        private void btnMonitorStart2_Click(object sender, EventArgs e)
        {
            if (tBRegisterNumber2.Text == "")
            {
                MessageBox.Show("还未输入！");
            }
            else
            {
                pc.WriteOneWord(0x0d, registerNumber2, PCan.currentID);
                Thread.Sleep(10);
                pc.ReadOneWord(0x0d, PCan.currentID);
                Thread.Sleep(10);
                if (Configuration.MemoryControlTable[0x0d] == 0x0001)
                {
                    Monitor77.Text = "写入成功";
                }
                else
                {
                    Monitor77.Text = "写入失败";
                }
                tBRegisterNumber2.Text = "";
            }
        }

        #endregion

        #endregion

        #region 一键设置全部模块当前位置为0（临时）

        private void btnSetZeroForAll_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < MessageProccessing.allID.Count; i++)
            {
                pc.WriteOneWord(Configuration.SYS_SET_ZERO_POS, 0x01, MessageProccessing.allID[i]);
                Thread.Sleep(1);
                pc.WriteOneWord(Configuration.SYS_SAVE_TO_FLASH, 0x01, MessageProccessing.allID[i]);
                Thread.Sleep(1);
            }
            MessageBox.Show("完成");
        }

        #endregion

        //由给定的在参数表中的低位，返回高位+低位的32位数值
        private int know32bitValue(byte low16bit)
        {
            pc.ReadWords(low16bit, 2, PCan.currentID);
            Thread.Sleep(10);
            byte[] tempL = BitConverter.GetBytes(Configuration.MemoryControlTable[low16bit]);
            byte[] tempH = BitConverter.GetBytes(Configuration.MemoryControlTable[low16bit + 1]);
            byte[] tempResult = new byte[] { tempL[0], tempL[1], tempH[0], tempH[1] };
            int the32bitValue = BitConverter.ToInt32(tempResult, 0);
            return the32bitValue;
        }

        //刷新监视器页面内容
        private void refresh()
        {
            if (MessageProccessing.allID.Count > 0)
            {
                //显示当前圈数，功能不完善的临时用法，精确到小数点后2位
                int currentPosition = know32bitValue(Configuration.SYS_POSITION_L);
                float currentTurn = currentPosition / 65536f;
                tBMultiTurn.Text = currentTurn.ToString("F2");

                //显示当前电流
                int currentCurrent = know32bitValue(Configuration.SYS_CURRENT_L);
                tBCur.Text = currentCurrent.ToString();

                //显示当前电压
                pc.ReadWords(Configuration.SYS_VOLTAGE, 1, PCan.currentID);
                Thread.Sleep(10);
                short currentVoltage = Configuration.MemoryControlTable[Configuration.SYS_VOLTAGE];
                tBVol.Text = currentVoltage.ToString();

                //显示编码器读数
                pc.ReadWords(Configuration.SYS_POSITION_L, 1, PCan.currentID);
                pc.ReadWords(Configuration.SYS_POSITION_H, 1, PCan.currentID);
                Thread.Sleep(10);
                short SingleTurn = Configuration.MemoryControlTable[Configuration.SYS_POSITION_L];
                short Multi_Turn = Configuration.MemoryControlTable[Configuration.SYS_POSITION_H];
                tBSingleTurn.Text = SingleTurn.ToString();
                tBMulti_Turn.Text = Multi_Turn.ToString();

                //显示错误类型
                pc.ReadWords(Configuration.SYS_ERROR, 1, PCan.currentID);
                Thread.Sleep(10);
                switch (Configuration.MemoryControlTable[Configuration.SYS_ERROR])
                {
                    case 1: tBError.Text = "过流"; break;
                    case 2: tBError.Text = "过压"; break;
                    case 4: tBError.Text = "欠压"; break;
                    case 8: tBError.Text = "过温"; break;
                    case 32: tBError.Text = "码盘错误"; break;
                    case 128: tBError.Text = "电流检测错误"; break;
                    default: tBError.Text = "无错误"; break;
                }
                tBVol.Text = currentVoltage.ToString();

                //显示ID
                pc.ReadWords(Configuration.SYS_ID, 1, PCan.currentID);
                Thread.Sleep(10);
                txtID.Text = Configuration.MemoryControlTable[Configuration.SYS_ID].ToString();

                //上电使能情况
                pc.ReadWords(Configuration.SYS_ENABLE_ON_POWER, 1, PCan.currentID);
                Thread.Sleep(10);
                switch (Configuration.MemoryControlTable[Configuration.SYS_ENABLE_ON_POWER])
                {
                    case 0: rdoDisable.Checked = true; rdoEnable.Checked = false; break;
                    case 1: rdoDisable.Checked = false; rdoEnable.Checked = true; break;
                    default: rdoDisable.Checked = false; rdoEnable.Checked = false; break;
                }
            }
        }

        //单击清除错误按钮
        private void btnClearError_Click(object sender, EventArgs e)
        {
            pc.WriteOneWord(Configuration.SYS_CLEAR_ERROR, 0x01, PCan.currentID);
            Thread.Sleep(10);
            pc.WriteOneWord(Configuration.SYS_ENABLE_DRIVER, 0x01, PCan.currentID);
            Thread.Sleep(10);
            MessageBox.Show("清错并使能成功。");
        }

        //单击设置零位按钮
        private void btnSetZeroPosition_Click(object sender, EventArgs e)
        {
            //如果当前是位置控制模式，则向内存控制表SYS_SET_ZERO_POS写入1
            if ("3" == Configuration.MemoryControlTable[Convert.ToByte("30", 16)].ToString())
            {
                pc.WriteOneWord(Configuration.SYS_SET_ZERO_POS, 0x01, PCan.currentID);
                Thread.Sleep(10);
                //更新分类1
                pc.ReadWords(16, 16, PCan.currentID);
                Thread.Sleep(10);
                //更新分类3，不更新出现了问题
                pc.ReadWords(48, 16, PCan.currentID);
                Thread.Sleep(10);
                //给出下一步提示，可以直接点击烧写
                MessageBox.Show("设置成功，请烧写Flash！");
            }
            else
            {
                MessageBox.Show("当前非位置控制模式！");
            }
        }

        #region 标题栏的事件

        private void pBExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private Point mousePoint = Point.Empty;

        private void Title_MouseDown(object sender, MouseEventArgs e)
        {
            BringToFront();
            if (e.Button == MouseButtons.Left)
            {
                mousePoint = MousePosition;
            }
        }

        private void Title_MouseUp(object sender, MouseEventArgs e)
        {
            mousePoint = Point.Empty;
        }

        private void Title_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && mousePoint != Point.Empty)
            {
                Top += MousePosition.Y - mousePoint.Y;
                Left += MousePosition.X - mousePoint.X;
                mousePoint = MousePosition;
            }
        }

        #endregion

        //单击刷新按钮
        private void Reload_Click(object sender, EventArgs e)
        {
            refresh();
        }

        //主要功能：隔1s自动刷新
        private void tmrCheck_Tick(object sender, EventArgs e)
        {
            refresh();
        }

        //控制自动刷新定时器的启停
        private void chkFasterReload_CheckedChanged(object sender, EventArgs e)
        {
            if (tmrCheck.Enabled == true)
            {
                tmrCheck.Enabled = false;
            }
            else
            {
                tmrCheck.Enabled = true;
            }
        }

        #region 输入ID

        //输入txtID完毕后调用
        private void txtID_InputDone()
        {
            try
            {
                byte tempID = Convert.ToByte(txtID.Text);
                //更改内存控制表
                pc.WriteOneWord(Configuration.SYS_ID, tempID, PCan.currentID);
            }
            catch (Exception ex)
            {
                txtID.Text = PCan.currentID.ToString();
                MessageBox.Show(ex.Message+"\n请输入合法的数值！");
            }
        }

        private void txtID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtID_InputDone();
            }
        }

        private void txtID_Leave(object sender, EventArgs e)
        {
            txtID_InputDone();
        }

        #endregion

        private void rdoEnable_Click(object sender, EventArgs e)
        {
            pc.WriteOneWord(Configuration.SYS_ENABLE_ON_POWER, 1, PCan.currentID);
        }

        private void rdoDisable_Click(object sender, EventArgs e)
        {
            pc.WriteOneWord(Configuration.SYS_ENABLE_ON_POWER, 0, PCan.currentID);
        }

        private void picMinimized_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }
    }
    ////主要功能：检测已连接的模块是否仍连接着
    ////其他说明：程序启动时即开始该定时检测（间隔时间为2000 ms），模块若断开，不关闭程序则程序重启
    //private void tMCheck_Tick(object sender, EventArgs e)
    //{
    //    refresh();

    //    //根据cBID.Text来判断当前连接与否，连接了哪个
    //    //if (cBID.Text != "")
    //    //{
    //    //    //如果选中了连接的模块，监测ID是否仍在线，掉线则弹出警告
    //    //    MessageProccessing.allID2.Clear();//从List中移除所有元素，初始化allID2
    //    //    pc.SearchModuleID();//返回ID号时，在MessageProccessing里会添加ID2
    //    //    Thread.Sleep(150);//必须的，不然总显示断开连接——该功能不成熟
    //    //    if (MessageProccessing.allID2.Contains(Convert.ToInt16(cBID.Text)))
    //    //    {
    //    //        //如果选中的ID仍在线，更新编码器多圈数据
    //    //        pc.ReadOneWord(Configuration.SYS_POSITION_H, PCan.currentID);
    //    //        tBMultiTurn.Text = Configuration.MemoryControlTable[Configuration.SYS_POSITION_H].ToString();
    //    //    }
    //    //    else
    //    //    {
    //    //        //该检测功能还不成熟
    //    //        ////如果选中的模块掉线，则弹出警告
    //    //        //string message = "您确定要关闭吗？";
    //    //        //string caption = string.Format("模块{0}已断开连接！", cBID.Text);
    //    //        //MessageBoxButtons buttons = MessageBoxButtons.YesNoCancel;
    //    //        //DialogResult result = MessageBox.Show(this, message, caption, buttons);
    //    //        //switch (result)
    //    //        //{
    //    //        //    case DialogResult.Yes:
    //    //        //        this.Close();
    //    //        //        break;
    //    //        //    case DialogResult.No:
    //    //        //        Application.Restart();
    //    //        //        break;
    //    //        //    default: return;
    //    //        //}
    //    //    }
    //    //}
    //    //else
    //    //{
    //    //    //如果没有选中模块
    //    //    ;
    //    //}
    //}
}
