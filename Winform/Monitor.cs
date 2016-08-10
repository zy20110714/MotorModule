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
                Thread.Sleep(10);
                pc.ReadOneWord(0x08, PCan.currentID);
                Thread.Sleep(10);
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
    }
}
