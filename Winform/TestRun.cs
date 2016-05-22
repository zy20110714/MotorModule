using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ICDIBasic
{
    public partial class TestRun : Form
    {
        public static int m_iWaveMode = 0;
        public static int m_iWaveChannel = 0;

        public static bool Enablewave = false;
     
        public static float m_fFrequency = 0.5f;
        public static float m_fAmplitude = 0.0f;
        public static float m_fBias = 0.0f;        
        public static float m_fStepLength = 0.01f;

       float m_fFrequency2 = 0.5f;
       float m_fAmplitude2 = 0.0f;
       float m_fBias2 = 0.0f;


        PCan pc;


        public static TestRun pCurrentWin = null;//句柄
        public TestRun()
        {
            InitializeComponent();
            pc = new PCan();
        }

        public static TestRun GetInstance()
        {
            if (pCurrentWin == null)
            {
                pCurrentWin = new TestRun();
            }
            return pCurrentWin;
        }

        private void TestRun_FormClosed(object sender, FormClosedEventArgs e)
        {
            pCurrentWin = null;
        }

        private void cBWaveform_SelectedIndexChanged(object sender, EventArgs e)
        {
            setInitalValue();
            switch (cBWaveform.Text)
            {
                case "衡值": m_iWaveMode = MotionControl.WAVE_MODE_DC; tBFrequency.Enabled = false; tBAmplitude.Enabled = false; break;
                case "方波": m_iWaveMode = MotionControl.WAVE_MODE_SQUARE; tBFrequency.Enabled = true; tBAmplitude.Enabled = true; break;
                case "三角波": m_iWaveMode = MotionControl.WAVE_MODE_TRIANGLE; tBFrequency.Enabled = true; tBAmplitude.Enabled = true; break;
                case "正弦波": m_iWaveMode = MotionControl.WAVE_MODE_SINE; tBFrequency.Enabled = true; tBAmplitude.Enabled = true; break;
            }
        }

        void setInitalValue()
        {
            m_fFrequency = 0.5f;
            m_fAmplitude = 0.0f;
            m_fBias = 0.0f;
            tBFrequency.Text = "0.5";
            tBAmplitude.Text = "0";
            tBBias.Text = "0";
        }

        private void cBControlMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            setInitalValue();
            switch (cBControlMode.Text)
            {
                case "无": m_iWaveChannel = MotionControl.WAVE_CONNECT_NON; break;
                case "开环占空比":m_iWaveChannel = MotionControl.WAVE_CONNECT_PWM; pc.WriteOneWord(Configuration.TAG_WORK_MODE, Configuration.MODE_OPEN, PCan.currentID); break;
                case "电流控制": m_iWaveChannel = MotionControl.WAVE_CONNECT_CUR; pc.WriteOneWord(Configuration.TAG_WORK_MODE, Configuration.MODE_CURRENT, PCan.currentID); break;
                case "速度控制": m_iWaveChannel = MotionControl.WAVE_CONNECT_SPD; pc.WriteOneWord(Configuration.TAG_WORK_MODE, Configuration.MODE_SPEED, PCan.currentID); break;
                case "位置控制": m_iWaveChannel = MotionControl.WAVE_CONNECT_POS; pc.WriteOneWord(Configuration.TAG_WORK_MODE, Configuration.MODE_POSITION,PCan.currentID); break;
            }
        }

        private void tBFrequency_TextChanged(object sender, EventArgs e)
        {
            try
            {
                m_fFrequency2 = Convert.ToSingle(tBFrequency.Text);
            }
            catch (System.Exception ex)
            {
                MainForm.GetInstance().sBFeedbackShow(ex.Message, 1);
                tBFrequency.Text = "0.5";
                MessageBox.Show("请输入合法的数值！");
            }
          
        }

        private void tBAmplitude_TextChanged(object sender, EventArgs e)
        {
            try
            {
                m_fAmplitude2 = Convert.ToSingle(tBAmplitude.Text);
            }
            catch (System.Exception ex)
            {
                MainForm.GetInstance().sBFeedbackShow(ex.Message, 1);
                tBAmplitude.Text = "0";
                MessageBox.Show("请输入合法的数值！");
            }
        }

        private void tBBias_TextChanged(object sender, EventArgs e)
        {
            try
            {
                m_fBias2 = Convert.ToSingle(tBBias.Text);
            }
            catch (System.Exception ex)
            {
                tBBias.Text = "0";
                MessageBox.Show("请输入合法的数值！");
                MainForm.GetInstance().sBFeedbackShow(ex.Message, 1);
            }
        }

        private void tBSteps_TextChanged(object sender, EventArgs e)
        {
            try
            {
                m_fStepLength = Convert.ToSingle(tBSteps.Text);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("请输入合法的数值！");
                MainForm.GetInstance().sBFeedbackShow(ex.Message, 1);
            }
        }

        private void btnEnable_Click(object sender, EventArgs e)
        {
            if (btnEnable.Text == "使能开启")
            {
                Enablewave = true;
                btnEnable.Text = "使能关闭";
                btnEnable.BackColor = Color.Red;
                pLEnable.Enabled = true;
                //默认选择项
                cBWaveform.SelectedIndex = 0;
                cBControlMode.SelectedIndex = 4;
            }
            else
            {
                //将运动控制变量清零
                Enablewave = false;
                pc.WriteOneWord(Configuration.TAG_OPEN_PWM, 0, PCan.currentID);
                pc.WriteTwoWords(Configuration.TAG_CURRENT_L, 0, PCan.currentID);
                pc.WriteTwoWords(Configuration.TAG_SPEED_L, 0, PCan.currentID);
                pc.WriteTwoWords(Configuration.TAG_POSITION_L, 0, PCan.currentID);

                btnEnable.Text = "使能开启";
                btnEnable.BackColor = Color.Green;
                pLEnable.Enabled = false;
                cBWaveform.SelectedIndex = -1;
                cBControlMode.SelectedIndex = -1;
            }
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            //更新控制变量
            m_fFrequency = m_fFrequency2;
            m_fAmplitude = m_fAmplitude2;
            m_fBias = m_fBias2;     
        }

        private void tBFrequency_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                m_fFrequency = m_fFrequency2;
        }

        private void tBAmplitude_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                m_fAmplitude = m_fAmplitude2;
        }

        private void tBBias_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                m_fBias = m_fBias2; 
        }

        private void btnClearAll_Click(object sender, EventArgs e)
        {
            setInitalValue(); 
        }
















    }
}
