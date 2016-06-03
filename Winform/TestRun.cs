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
            InitialControls();

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

        private void InitialControls()
        {
            //初始化控制模式
            switch (Configuration.MemoryControlTable[Configuration.TAG_WORK_MODE])
            {
                case 0: cBControlMode.SelectedIndex = 0; break;
                case 1: cBControlMode.SelectedIndex = 1; break;
                case 2: cBControlMode.SelectedIndex = 2; break;
                case 3: cBControlMode.SelectedIndex = 3; break;
            }

            InitialAutomaticControl();

            pLEnable.Enabled = false;
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

        private void cBControlMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            setInitalValue();
            switch (cBControlMode.Text)
            {
                case "开环占空比":m_iWaveChannel = MotionControl.WAVE_CONNECT_PWM; pc.WriteOneWord(Configuration.TAG_WORK_MODE, Configuration.MODE_OPEN, PCan.currentID); break;
                case "电流控制": m_iWaveChannel = MotionControl.WAVE_CONNECT_CUR; pc.WriteOneWord(Configuration.TAG_WORK_MODE, Configuration.MODE_CURRENT, PCan.currentID); break;
                case "速度控制": m_iWaveChannel = MotionControl.WAVE_CONNECT_SPD; pc.WriteOneWord(Configuration.TAG_WORK_MODE, Configuration.MODE_SPEED, PCan.currentID); break;
                case "位置控制": m_iWaveChannel = MotionControl.WAVE_CONNECT_POS; pc.WriteOneWord(Configuration.TAG_WORK_MODE, Configuration.MODE_POSITION,PCan.currentID); break;
            }
            //取消cBControlMode的输入焦点
            pBMode.Focus();
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
                tBFrequency.Text = "0.2";
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

        private void btnEnable_Click(object sender, EventArgs e)
        {
            if (btnEnable.Text == "使能开启")
            {
                Enablewave = true;
                btnEnable.Text = "使能关闭";
                btnEnable.BackColor = Color.IndianRed;
                pLEnable.Enabled = true;
                //默认选择项
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
                Enablewave = false;
                pc.WriteOneWord(Configuration.TAG_OPEN_PWM, 0, PCan.currentID);
                pc.WriteTwoWords(Configuration.TAG_CURRENT_L, 0, PCan.currentID);
                pc.WriteTwoWords(Configuration.TAG_SPEED_L, 0, PCan.currentID);
                pc.WriteTwoWords(Configuration.TAG_POSITION_L, 0, PCan.currentID);

                btnEnable.Text = "使能开启";
                btnEnable.BackColor = Color.Green;
                pLEnable.Enabled = false;
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

        private void pBMode_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(pBMode.Tag) == 1)
            {
                MamuallyControl();
            } 
            else
            {
                InitialAutomaticControl();
            }
        }

        private void InitialAutomaticControl()
        {
            pBMode.Tag = 1;
            pBMode.Image = Image.FromFile(Application.StartupPath + "\\resource\\A.jpg");
            gBManually.Enabled = false;
            gBWaveFormProperty.Enabled = true;

            cBWaveform.SelectedIndex = 0;
            setInitalValue();
        }

        void setInitalValue()
        {
            m_fFrequency = 0.2f;
            m_fAmplitude = 0.0f;
            m_fBias = 0.0f;
            tBFrequency.Text = "0.2";
            tBAmplitude.Text = "0";
            tBBias.Text = "0";
        }

        private void MamuallyControl()
        {
            pBMode.Tag = 2;
            pBMode.Image = Image.FromFile(Application.StartupPath + "\\resource\\M.jpg");
            gBManually.Enabled = true;
            gBWaveFormProperty.Enabled = false;
        }

        private void pBExit_Click(object sender, EventArgs e)
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

            this.Close();
        }

        private void pLName_Click(object sender, EventArgs e)
        {
            this.BringToFront();
        }















    }
}
