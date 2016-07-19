﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace ICDIBasic
{
    public partial class TestRun : Form
    {
        public static int m_iWaveMode = 0;
        public static int m_iWaveChannel = 0;

        public static bool EnableRun = false;
        public static bool ChangeOK = false;

        //自动控制使用
        public static float m_fFrequency = 0.5f;
        public static float m_fAmplitude = 0.0f;
        public static float m_fBias = 0.0f;

        //手动控制使用，设置为变量使得在输入错误时能返回上一结果，设置为全局使得在定时器中可以调用
        public static float manualMin = 0.0f;
        public static float manualMax = 0.0f;

        //手动控制中回零功能使用
        public short CurrentWorkMode = 0;
        public int speedOfReturnZero = 0;
        public int currentPosition = 0;
        const short deadZone = 20;

        //手动控制中随机运动功能使用，时间毫秒数，取得随机数
        Random rad = new Random(DateTime.Now.Millisecond);

        public static TestRun pCurrentWin = null;//句柄
        PCan pc;

        public static TestRun GetInstance()
        {
            if (pCurrentWin == null)
            {
                pCurrentWin = new TestRun();
            }
            return pCurrentWin;
        }

        public TestRun()
        {
            InitializeComponent();
            pc = new PCan();
            InitialControls();
        }

        private void InitialControls()
        {
            //pLEnable.Enabled = false;//试运行控制使能关闭
            //AutomaticControl();//默认使用自动控制

            pLEnable.Enabled = true;//测试用
            MamuallyControl();//测试用

            IscBSymmetryChecked();//根据cBSymmetry的值确定tBMin
        }

        private void TestRun_Click(object sender, EventArgs e)
        {
            BringToFront();
        }

        #region 用鼠标拖拽移动窗体
        private Point mousePoint = Point.Empty;
        private void pLName_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                mousePoint = MousePosition;
            }
        }

        private void pLName_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && mousePoint != Point.Empty)
            {
                Top += MousePosition.Y - mousePoint.Y;
                Left += MousePosition.X - mousePoint.X;
                mousePoint = MousePosition;
            }
        }

        private void pLName_MouseUp(object sender, MouseEventArgs e)
        {
            mousePoint = Point.Empty;
        }
        #endregion

        private void btnEnable_Click(object sender, EventArgs e)
        {
            if (btnEnable.Text == "使能开启")
            {
                btnEnable.Text = "使能关闭";
                btnEnable.BackColor = Color.IndianRed;
                pLEnable.Enabled = true;
                EnableRun = true;
                //根据控制表当前数据初始化控制模式
                switch (Configuration.MemoryControlTable[Configuration.TAG_WORK_MODE])
                {
                    case 0: cBControlMode.SelectedIndex = 0; break;
                    case 1: cBControlMode.SelectedIndex = 1; break;
                    case 2: cBControlMode.SelectedIndex = 2; break;
                    case 3: cBControlMode.SelectedIndex = 3; break;
                }
            }
            else
            {
                //将运动控制变量清零                
                //pc.WriteOneWord(Configuration.TAG_OPEN_PWM, 0, PCan.currentID);
                //pc.WriteTwoWords(Configuration.TAG_CURRENT_L, 0, PCan.currentID);
                //pc.WriteTwoWords(Configuration.TAG_SPEED_L, 0, PCan.currentID);
                //pc.WriteTwoWords(Configuration.TAG_POSITION_L, 0, PCan.currentID);

                btnEnable.Text = "使能开启";
                btnEnable.BackColor = Color.Green;
                pLEnable.Enabled = false;
                clearValue();
            }
        }

        private void AutomaticControl()
        {
            pBMode.Tag = 1;//自定义数据，表示自动控制
            pBMode.Image = Image.FromFile(Application.StartupPath + "\\resource\\A.jpg");
            gBManually.Enabled = false;
            gBWaveFormProperty.Enabled = true;
            gBManually.BackColor = Color.White;
            gBWaveFormProperty.BackColor = Color.SlateGray;//关闭手动开自动
            setAutomaticInitalValue();
        }

        private void setAutomaticInitalValue()
        {
            cBWaveForm.SelectedIndex = Convert.ToInt32(IniFile.ContentValue("TestRun", "WaveForm", IniFile.StrProPath));//从文件读入波形生成配置
            string strWaveFrequency = IniFile.ContentValue("WaveForm" + cBWaveForm.SelectedIndex, "WaveFrequency", IniFile.StrProPath);
            string strWaveAmplitude = IniFile.ContentValue("WaveForm" + cBWaveForm.SelectedIndex, "WaveAmplitude", IniFile.StrProPath);
            string strWaveBias = IniFile.ContentValue("WaveForm" + cBWaveForm.SelectedIndex, "WaveBias", IniFile.StrProPath);

            m_fFrequency = Convert.ToSingle(strWaveFrequency);
            m_fAmplitude = Convert.ToSingle(strWaveAmplitude);
            m_fBias = Convert.ToSingle(strWaveBias);

            tBFrequency.Text = strWaveFrequency;
            tBAmplitude.Text = strWaveAmplitude;
            tBBias.Text = strWaveBias;
        }

        private void MamuallyControl()
        {
            pBMode.Tag = 2;//自定义数据，表示手动控制
            pBMode.Image = Image.FromFile(Application.StartupPath + "\\resource\\M.jpg");
            gBManually.Enabled = true;
            gBWaveFormProperty.Enabled = false;
            gBManually.BackColor = Color.SlateGray;
            gBWaveFormProperty.BackColor = Color.White;//关闭自动开手动

            pc.WriteOneWord(Configuration.SCP_MASK, OscilloScope.Mask, PCan.currentID);//向下位机请求数据
        }

        private void pBExit_Click(object sender, EventArgs e)
        {
            clearValue();
            pCurrentWin = null;
            this.Close();
        }

        public void clearValue()
        {
            //将运动控制变量恢复初始值
            EnableRun = false;
            ChangeOK = false;
            m_fFrequency = 0.0f;
            m_fAmplitude = 0.0f;
            m_fBias = 0.0f;

            //切换到速度控制模式，让当前运动停止
            pc.WriteOneWord(Configuration.TAG_WORK_MODE, Configuration.MODE_SPEED, PCan.currentID);
            pc.WriteTwoWords(Configuration.TAG_SPEED_L, 0, PCan.currentID);
            Thread.Sleep(10);
            //恢复原先选择的控制模式
            switch (cBControlMode.Text)
            {
                case "开环占空比":
                    m_iWaveChannel = MotionControl.WAVE_CONNECT_PWM;
                    pc.WriteOneWord(Configuration.TAG_WORK_MODE, Configuration.MODE_OPEN, PCan.currentID);
                    lLUnit.Text = "Unit: %";
                    break;
                case "电流控制":
                    m_iWaveChannel = MotionControl.WAVE_CONNECT_CUR;
                    pc.WriteOneWord(Configuration.TAG_WORK_MODE, Configuration.MODE_CURRENT, PCan.currentID);
                    lLUnit.Text = "Unit: mA";
                    break;
                case "速度控制":
                    m_iWaveChannel = MotionControl.WAVE_CONNECT_SPD;
                    pc.WriteOneWord(Configuration.TAG_WORK_MODE, Configuration.MODE_SPEED, PCan.currentID);
                    lLUnit.Text = "Unit: rpm";
                    break;
                case "位置控制":
                    m_iWaveChannel = MotionControl.WAVE_CONNECT_POS;
                    pc.WriteOneWord(Configuration.TAG_WORK_MODE, Configuration.MODE_POSITION, PCan.currentID);
                    lLUnit.Text = "Unit: °";
                    break;
            }
        }

        private void cBControlMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            ChangeOK = false;
            switch (cBControlMode.Text)
            {
                case "开环占空比":
                    m_iWaveChannel = MotionControl.WAVE_CONNECT_PWM;
                    pc.WriteOneWord(Configuration.TAG_WORK_MODE, Configuration.MODE_OPEN, PCan.currentID);
                    lLUnit.Text = "Unit: %";
                    break;
                case "电流控制":
                    m_iWaveChannel = MotionControl.WAVE_CONNECT_CUR;
                    pc.WriteOneWord(Configuration.TAG_WORK_MODE, Configuration.MODE_CURRENT, PCan.currentID);
                    lLUnit.Text = "Unit: mA";
                    break;
                case "速度控制":
                    m_iWaveChannel = MotionControl.WAVE_CONNECT_SPD;
                    pc.WriteOneWord(Configuration.TAG_WORK_MODE, Configuration.MODE_SPEED, PCan.currentID);
                    lLUnit.Text = "Unit: rpm";
                    break;
                case "位置控制":
                    m_iWaveChannel = MotionControl.WAVE_CONNECT_POS;
                    pc.WriteOneWord(Configuration.TAG_WORK_MODE, Configuration.MODE_POSITION, PCan.currentID);
                    lLUnit.Text = "Unit: °";
                    break;
            }
            Thread.Sleep(10);
            ////取消cBControlMode的输入焦点
            //pBMode.Focus();
            //不是自动控制的情况下改变控制模式则停止运动
            if (Convert.ToInt32(pBMode.Tag) != 1)
            {
                clearValue();
            }
            //记录到配置文件里
            IniFile.WritePrivateProfileString("TestRun", "ControlMode", cBControlMode.SelectedIndex.ToString(), IniFile.StrProPath);
        }

        private void cBWaveform_SelectedIndexChanged(object sender, EventArgs e)
        {
            clearValue();
            setAutomaticInitalValue();
            switch (cBWaveForm.Text)
            {
                case "衡值":
                    m_iWaveMode = MotionControl.WAVE_MODE_DC;
                    tBFrequency.Enabled = false;
                    tBAmplitude.Enabled = false;
                    break;
                case "方波":
                    m_iWaveMode = MotionControl.WAVE_MODE_SQUARE;
                    tBFrequency.Enabled = true;
                    tBAmplitude.Enabled = true;
                    break;
                case "三角波":
                    m_iWaveMode = MotionControl.WAVE_MODE_TRIANGLE;
                    tBFrequency.Enabled = true;
                    tBAmplitude.Enabled = true;
                    break;
                case "正弦波":
                    m_iWaveMode = MotionControl.WAVE_MODE_SINE;
                    tBFrequency.Enabled = true;
                    tBAmplitude.Enabled = true;
                    break;
            }
            IniFile.WritePrivateProfileString("TestRun", "WaveForm", cBWaveForm.SelectedIndex.ToString(), IniFile.StrProPath);
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            ChangeOK = true;
        }

        private void btnClearAll_Click(object sender, EventArgs e)
        {
            clearValue();
        }

        private void pBMode_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(pBMode.Tag) == 1)
            {
                MamuallyControl();
            }
            else
            {
                AutomaticControl();
                tMManualControl.Stop();
            }
        }

        #region 输入tBFrequency
        //输入tBFrequency完毕后调用
        private void tBFrequency_InputDone()
        {
            try
            {
                m_fFrequency = Convert.ToSingle(tBFrequency.Text);
            }
            catch (System.Exception ex)
            {
                tBFrequency.Text = m_fFrequency.ToString();
                MessageBox.Show("请输入合法的数值！");
                MainForm.GetInstance().sBFeedbackShow(ex.Message, 1);
            }
            IniFile.WritePrivateProfileString("WaveForm" + cBWaveForm.SelectedIndex, "WaveAmplitude", m_fFrequency.ToString(), IniFile.StrProPath);
        }

        private void tBFrequency_Leave(object sender, EventArgs e)
        {
            tBFrequency_InputDone();
        }

        private void tBFrequency_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                tBFrequency_InputDone();
            }
        }
        #endregion

        #region 输入tBAmplitude

        //输入tBAmplitude完毕后调用
        private void tBAmplitude_InputDone()
        {
            try
            {
                m_fAmplitude = Convert.ToSingle(tBAmplitude.Text);
            }
            catch (System.Exception ex)
            {
                tBFrequency.Text = m_fAmplitude.ToString();
                MessageBox.Show("请输入合法的数值！");
                MainForm.GetInstance().sBFeedbackShow(ex.Message, 1);
            }
            IniFile.WritePrivateProfileString("WaveForm" + cBWaveForm.SelectedIndex, "WaveAmplitude", m_fAmplitude.ToString(), IniFile.StrProPath);
        }

        private void tBAmplitude_Leave(object sender, EventArgs e)
        {
            tBAmplitude_InputDone();
        }

        private void tBAmplitude_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                tBAmplitude_InputDone();
            }
        }

        #endregion

        #region 输入tBBias

        //输入tBBias完毕后调用
        private void tBBias_InputDone()
        {
            try
            {
                m_fBias = Convert.ToSingle(tBBias.Text);
            }
            catch (System.Exception ex)
            {
                tBBias.Text = m_fBias.ToString();
                MessageBox.Show("请输入合法的数值！");
                MainForm.GetInstance().sBFeedbackShow(ex.Message, 1);
            }
            IniFile.WritePrivateProfileString("WaveForm" + cBWaveForm.SelectedIndex, "WaveBias", m_fBias.ToString(), IniFile.StrProPath);
        }

        private void tBBias_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                tBBias_InputDone();
        }

        private void tBBias_Leave(object sender, EventArgs e)
        {
            tBBias_InputDone();
        }

        #endregion

        #region 输入tBMin
        //输入tBMin完毕后调用
        private void tBMin_InputDone()
        {
            try
            {
                manualMin = Convert.ToSingle(tBMin.Text);
            }
            catch (System.Exception ex)
            {
                tBMin.Text = manualMin.ToString();
                MessageBox.Show("请输入合法的数值！");
                MainForm.GetInstance().sBFeedbackShow(ex.Message, 1);
            }
        }

        //按enter输入偏移零位的最小度数，同时进行输入检查
        private void tBMin_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                tBMin_InputDone();
            }
        }

        //没有按enter确认的情况，也可以修改
        private void tBMin_Leave(object sender, EventArgs e)
        {
            tBMin_InputDone();
        }
        #endregion

        #region 输入tBMax
        //输入tBMax完毕后调用
        private void tBMax_InputDone()
        {
            try
            {
                manualMax = Convert.ToSingle(tBMax.Text);
            }
            catch (System.Exception ex)
            {
                tBMax.Text = manualMax.ToString();
                MessageBox.Show("请输入合法的数值！");
                MainForm.GetInstance().sBFeedbackShow(ex.Message, 1);
            }
            IscBSymmetryChecked();//根据cBSymmetry的值确定tBMin
        }

        //按enter输入偏移零位的最大度数，同时进行输入检查
        private void tBMax_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                tBMax_InputDone();
            }
        }

        //没有按enter确认的情况，也可以修改
        private void tBMax_Leave(object sender, EventArgs e)
        {
            tBMax_InputDone();
        }
        #endregion

        //在定时器中控制模块
        private void tMManualControl_Tick(object sender, EventArgs e)
        {
            //根据设置的Min和Max，以及滑块位置，获得当前角度值
            float manualCur = manualMin + (manualMax - manualMin) * tBManual.Value / 100;
            Current.Text = manualCur.ToString();
            int manualValue = Convert.ToInt32(manualCur / 360.0 * 65535.0);
            pc.WriteTwoWords(Configuration.TAG_POSITION_L, manualValue, PCan.currentID);
        }

        //手动控制启停按钮，控制定时器启停
        private void btnEnManCtrl_Click(object sender, EventArgs e)
        {
            if (tMManualControl.Enabled)
            {
                Current.Visible = false;
                tMManualControl.Stop();
                btnEnManCtrl.Text = "开始";
                btnRandomMotion.Enabled = true;//允许随机运动
            }
            else
            {
                Current.Visible = true;
                tMManualControl.Start();
                btnEnManCtrl.Text = "停止";
                btnRandomMotion.Enabled = false;//禁止随机运动
            }
        }

        //滑块回中按钮
        private void btnTrackBarCenter_Click(object sender, EventArgs e)
        {
            tBManual.Value = (tBManual.Maximum + tBManual.Minimum) / 2;
        }

        //按住按钮加速回零
        private void btnReturnToZero_MouseDown(object sender, MouseEventArgs e)
        {
            //读当前工作模式CurrentWorkMode，切换工作模式为速度控制
            CurrentWorkMode = Configuration.MemoryControlTable[Convert.ToByte("30", 16)];
            pc.WriteOneWord(Configuration.TAG_WORK_MODE, Configuration.MODE_SPEED, PCan.currentID);
            //初始化控制速度，开启定时器（定时器中读当前位置，控制模块运动）
            speedOfReturnZero = 0;
            tMReturnToZero.Enabled = true;
        }

        //释放按钮回零控制结束
        private void btnReturnToZero_MouseUp(object sender, MouseEventArgs e)
        {
            //关闭定时器
            tMReturnToZero.Enabled = false;
            //速度回0，切换回之前的工作模式
            speedOfReturnZero = 0;
            pc.WriteOneWord(Configuration.TAG_SPEED_H, Convert.ToSByte(speedOfReturnZero), PCan.currentID);
            pc.WriteOneWord(Configuration.TAG_WORK_MODE, CurrentWorkMode, PCan.currentID);

            //MessageBox.Show(speedOfReturnZero.ToString()+"以及"+ currentPosition);//测试用
        }

        //回零定时器
        private void tMReturnToZero_Tick(object sender, EventArgs e)
        {
            ////预备用位置环控制使用
            //////int manualValue = Convert.ToInt32(manualCur / 360.0 * 65535.0);
            //////pc.WriteTwoWords(Configuration.TAG_POSITION_L, manualValue, PCan.currentID);

            ////根据当前位置确定速度值（正负？大小？）
            //byte[] tempL = BitConverter.GetBytes(Configuration.MemoryControlTable[Configuration.SYS_POSITION_L]);
            //byte[] tempH = BitConverter.GetBytes(Configuration.MemoryControlTable[Configuration.SYS_POSITION_H]);
            //byte[] tempResult = new byte[] { tempL[0], tempL[1], tempH[0], tempH[1] };
            //currentPosition = BitConverter.ToInt32(tempResult, 0);
            ////currentPosition = 2000;
            //MessageBox.Show(currentPosition.ToString()+"以及"+ speedOfReturnZero.ToString());//测试用
            //if ((currentPosition + deadZone) < 0)
            //{
            //    //如果当前位置为负，则需要正转
            //    speedOfReturnZero += 1;
            //}
            //else if ((currentPosition - deadZone) > 0)
            //{
            //    //否则当前位置为正，需要反转
            //    speedOfReturnZero -= 1;
            //}
            //else
            //{
            //    speedOfReturnZero = 0;
            //}
            ////校对控制速度，读到的速度限制为rpm，转换成rps，要求不大于速度限制的一半
            //if (Math.Abs(speedOfReturnZero) > Configuration.MemoryControlTable[Configuration.LIT_MAX_SPEED]/60/2)
            //{
            //    if (speedOfReturnZero > 0)
            //    {
            //        speedOfReturnZero = Configuration.MemoryControlTable[Configuration.LIT_MAX_SPEED] / 60 / 2;
            //    }
            //    else
            //    {
            //        speedOfReturnZero = -Configuration.MemoryControlTable[Configuration.LIT_MAX_SPEED] / 60 / 2;
            //    }
            //}
            ////发控制速度的指令
            //pc.WriteOneWord(Configuration.TAG_SPEED_H, Convert.ToSByte(speedOfReturnZero), PCan.currentID);
            ////发读当前位置的指令
            //pc.ReadWords(Configuration.SYS_POSITION_L, 2, PCan.currentID);
        }

        //随机运动控制用线程（并不是精确地每2秒给一个位置值）
        private delegate void FlushClient();
        Thread thread = null;

        private void ThreadRandomMotion()
        {
            while (true)
            {
                ThreadFunction();
                Thread.Sleep(2000);
            }
        }

        private void ThreadFunction()
        {
            if (Current.InvokeRequired)//等待异步
            {
                FlushClient fc = new FlushClient(ThreadFunction);
                Invoke(fc); //通过代理调用刷新方法
            }
            else
            {
                //根据设置的Min和Max，让滑块位置随机，获得当前角度值
                float manualCur = manualMin + (manualMax - manualMin) * rad.Next(101) / 100;
                Current.Text = manualCur.ToString();
                int manualValue = Convert.ToInt32(manualCur / 360.0 * 65535.0);
                pc.WriteTwoWords(Configuration.TAG_POSITION_L, manualValue, PCan.currentID);
            }
        }
        
        //随机运动启停按钮，控制定时器启停
        private void btnRandomMotion_Click(object sender, EventArgs e)
        {
            //手动控制不在进行时，才能开始
            if (thread == null)
            {
                thread = new Thread(ThreadRandomMotion);
                thread.IsBackground = true;
                thread.Start();
                Current.Visible = true;
                btnRandomMotion.Text = "停止随机";
                btnEnManCtrl.Enabled = false;//禁止手动控制
            }
            else
            {
                try
                {
                    thread.Abort();
                }
                catch (Exception)
                {
                    ;
                }
                thread = null;
                Current.Visible = false;
                btnRandomMotion.Text = "开始随机";
                btnEnManCtrl.Enabled = true;//允许手动控制
            }
        }

        //根据cBSymmetry的值确定tBMin（偏移零位的最小度数）是否关闭使能并保持和tBMax一致
        private void IscBSymmetryChecked()
        {
            if (cBSymmetry.Checked)
            {
                tBMin.Enabled = false;
                //若tBMax的值为正，tBMin为负，否则tBMin和tBMax相等
                if (Convert.ToSingle(tBMax.Text) > 0)
                {
                    tBMin.Text = (Convert.ToSingle(tBMax.Text) * -1).ToString();
                    tBMin_InputDone();//只改变Text并没有实际上的控制效果
                }
                else
                {
                    tBMin.Text = tBMax.Text;
                    tBMin_InputDone();//只改变Text并没有实际上的控制效果
                }
            }
            else
                tBMin.Enabled = true;
        }

        //改变勾选框时，直接调用
        private void cBSymmetry_CheckedChanged(object sender, EventArgs e)
        {
            IscBSymmetryChecked();
        }

        //Thread threadDirectMove;
        //public static float StepLength = 0.1f;
        private void btnReverse_MouseDown(object sender, MouseEventArgs e)
        {
            //    if (threadDirectMove != null)
            //    {
            //        if (threadDirectMove.IsAlive)
            //        {
            //            return;
            //        }
            //    }
            //    else
            //    {
            //        Button btn = sender as Button;
            //        string str = btn.Name;
            //        NormalExit = false;
            //        threadDirectMove = new Thread(new ParameterizedThreadStart(JogThread));
            //        threadDirectMove.Priority = ThreadPriority.Highest;
            //        threadDirectMove.Start(str);
            //    }
        }

        private void btnReverse_MouseUp(object sender, MouseEventArgs e)
        {
            //    NormalExit = true;
        }

        private void JogThread(object str)
        {
            //    int AcTime = Convert.ToInt32(StepLength * 10);
            //    int count = 0;
            //    bool DecExit = false;

            //    while (!DecExit)
            //    {
            //        if (!NormalExit)
            //        {
            //            count++;
            //            if (count > AcTime)
            //            {
            //                count = AcTime;
            //            }
            //        }
            //        else
            //        {
            //            count--;
            //            if (count == 0)
            //            {
            //                DecExit = true;
            //                break;
            //            }
            //        }
            //        byte bt = Configuration.TAG_OPEN_PWM;
            //        switch (m_iWaveChannel)
            //        {
            //            case MotionControl.WAVE_CONNECT_PWM: pc.ReadWords(Configuration.TAG_OPEN_PWM, 1, PCan.currentID); break;
            //            case MotionControl.WAVE_CONNECT_CUR: bt = Configuration.SCP_MEACUR_L; break;
            //            case MotionControl.WAVE_CONNECT_SPD: bt = Configuration.SCP_MEASPD_L; break;
            //            case MotionControl.WAVE_CONNECT_POS: bt = Configuration.SCP_MEAPOS_L; break;
            //        }

            //        //以固定频率控制运动 10ms
            //        threadDirectMove.Join(10);

            //        int value = 0;
            //        if (bt != Configuration.TAG_OPEN_PWM)
            //        {
            //            byte[] value1 = BitConverter.GetBytes(Configuration.MemoryControlTable[bt]);
            //            byte[] value2 = BitConverter.GetBytes(Configuration.MemoryControlTable[bt + 1]);
            //            value = BitConverter.ToInt32(new byte[] { value1[0], value1[1], value2[0], value2[1] }, 0);
            //        }
            //        else
            //        {
            //            value = Configuration.MemoryControlTable[Configuration.TAG_OPEN_PWM];
            //        }

            //        if (str.ToString() == "btnReverse")
            //        {
            //            value -= Convert.ToInt32(count * StepLength / AcTime);
            //        }
            //        else
            //        {
            //            value += Convert.ToInt32(count * StepLength / AcTime);
            //        }

            //        switch (m_iWaveChannel)
            //        {
            //            case MotionControl.WAVE_CONNECT_PWM:
            //                pc.WriteTwoWords(Configuration.TAG_OPEN_PWM, value, PCan.currentID);
            //                this.Invoke((EventHandler)(delegate { showManuallyDta(value, 1); }));
            //                break;
            //            case MotionControl.WAVE_CONNECT_CUR:
            //                pc.WriteTwoWords(Configuration.TAG_CURRENT_L, value, PCan.currentID);
            //                this.Invoke((EventHandler)(delegate { showManuallyDta(value, 2); }));
            //                break;
            //            case MotionControl.WAVE_CONNECT_SPD:
            //                pc.WriteTwoWords(Configuration.TAG_SPEED_L, value, PCan.currentID);
            //                this.Invoke((EventHandler)(delegate { showManuallyDta(value, 3); }));
            //                break;
            //            case MotionControl.WAVE_CONNECT_POS:
            //                pc.WriteTwoWords(Configuration.TAG_POSITION_L, value, PCan.currentID);
            //                this.Invoke((EventHandler)(delegate { showManuallyDta(value, 4); }));
            //                break;
            //        }
            //    }

            //    this.Invoke((EventHandler)(delegate
            //    { MainForm.GetInstance().sBFeedbackShow("手动线程退出！", 1); }));
            //    threadDirectMove.Abort();
        }

        private void showManuallyDta(int value, int type)
        {
            //    double mData = 0.0f;
            //    switch (type)
            //    {
            //        case 1: mData = value; break;
            //        case 2: mData = value; break;
            //        case 3: mData = value * 60.0 / 65536; break;
            //        case 4: mData = value * 60.0 / 65536; break;
            //    }
            //    Current.Text = value.ToString(); tBManual.Value = Convert.ToInt32(mData);
        }

        private void tBStep_TextChanged(object sender, EventArgs e)
        {
            //    try
            //    {
            //        StepLength = Convert.ToSingle(tBStep.Text);
            //    }
            //    catch (System.Exception ex)
            //    {
            //        tBStep.Text = "0";
            //        MessageBox.Show("请输入合法的数值！");
            //        MainForm.GetInstance().sBFeedbackShow(ex.Message, 1);
            //    }
        }

    }
}
