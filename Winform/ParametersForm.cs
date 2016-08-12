using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace ICDIBasic
{
    public partial class ParametersForm : Form
    {
        public static ParametersForm pCurrentWin = null;//句柄
        TextBox tb;//用于动态生成TextBox以供编辑变量的数值
        PCan pc;
        WriteParameters wp;
        int selectedItemIndex = -1;
        public static int tVIndex;//标记当前选中的分类号，需要在主界面更改ID时更新参数表
        public static Dictionary<byte, ParameterStruct> paraRelection = new Dictionary<byte, ParameterStruct>();

        public ParametersForm()
        {
            InitializeComponent();
            InitialParameters();
            InitialControls();
            pc = new PCan();
            timerUpdate.Start();
        }

        public static ParametersForm GetInstance()
        {
            if (pCurrentWin == null)
            {
                pCurrentWin = new ParametersForm();
            }
            return pCurrentWin;
        }

        private void InitialControls()
        {
            this.KeyPreview = true;
            tVParam.SelectedNode = tVParam.Nodes[0];
            tVIndex = 0;
            tVParam.Nodes[0].Checked = true;
            RefreshlVParam(tVParam.SelectedNode.Index);     
        }

        private void InitialParameters()
        {
            paraRelection.Clear();

            paraRelection.Add(0x01, new ParameterStruct("SYS_ID",               "1-254",  "-",      "R/W",  "驱动器ID"));
            paraRelection.Add(0x02, new ParameterStruct("SYS_MODEL_TYPE",       "-",      "-",      "R",    "驱动器型号: 10, 11, 20, 21, 30, 40"));
            paraRelection.Add(0x03, new ParameterStruct("SYS_FW_VERSION",       "-",      "-",      "R",    "固件版本"));
            paraRelection.Add(0x04, new ParameterStruct("SYS_ERROR",            "0-256",  "-",      "R",    "错误代码: 1-过流，2-过压，4-欠压，8-过温，32-码盘错误，128-电流检测错误"));
            paraRelection.Add(0x05, new ParameterStruct("SYS_VOLTAGE",          "≈2400",  "0.01V",  "R",    "系统电压"));
            paraRelection.Add(0x06, new ParameterStruct("SYS_TEMP",             "0-800",  "0.1℃",  "R",    "系统温度"));
            paraRelection.Add(0x07, new ParameterStruct("SYS_REDU_RATIO",       "0-120",  "-",      "R",    "模块减速比"));
            paraRelection.Add(0x08, new ParameterStruct("SYS_BAUDRATE_232",     "-",      "-",      "R/W",  "232端口波特率"));
            paraRelection.Add(0x09, new ParameterStruct("SYS_BAUDRATE_CAN",     "-",      "-",      "R/W",  "CAN总线波特率"));
            paraRelection.Add(0x0a, new ParameterStruct("SYS_ENABLE_DRIVER",    "0-1",    "-",      "R/W",  "驱动器使能标志"));
            paraRelection.Add(0x0b, new ParameterStruct("SYS_ENABLE_ON_POWER",  "0-1",    "-",      "R/W",  "上电使能驱动器标志"));
            paraRelection.Add(0x0c, new ParameterStruct("SYS_SAVE_TO_FLASH",    "0-1",    "-",      "R/W",  "保存数据到Flash标志"));
            paraRelection.Add(0x0d, new ParameterStruct("SYS_DEMA_ABSPOS",      "0-1",    "-",      "R/W",  "自动标定绝对位置标志"));
            paraRelection.Add(0x0e, new ParameterStruct("SYS_SET_ZERO_POS",     "0-1",    "-",      "R/W",  "将当前位置设置为零点标志"));
            paraRelection.Add(0x0f, new ParameterStruct("SYS_CLEAR_ERROR",      "0-1",    "-",      "R/W",  "清除错误标志"));

            paraRelection.Add(0x10, new ParameterStruct("SYS_CURRENT_L",          "0-65535",  "-", "R",   "当前电流低16位"));
            paraRelection.Add(0x11, new ParameterStruct("SYS_CURRENT_H",          "0-65535",  "-", "R",   "当前电流高16位"));
            paraRelection.Add(0x12, new ParameterStruct("SYS_SPEED_L",            "0-65535",  "-", "R",   "当前速度低16位"));
            paraRelection.Add(0x13, new ParameterStruct("SYS_SPEED_H",            "0-65535",  "-", "R",   "当前速度高16位"));
            paraRelection.Add(0x14, new ParameterStruct("SYS_POSITION_L",         "0-65535",  "-", "R",   "当前位置低16位"));
            paraRelection.Add(0x15, new ParameterStruct("SYS_POSITION_H",         "0-65535",  "-", "R",   "当前位置高16位"));
            paraRelection.Add(0x16, new ParameterStruct("SYS_POTEN_VALUE",        "-",        "-", "R",   "数字电位器值"));
            paraRelection.Add(0x17, new ParameterStruct("SYS_ZERO_POS_OFFSET_L",  "0-65535",  "-", "R/W", "零点位置偏移量低16位"));
            paraRelection.Add(0x18, new ParameterStruct("SYS_ZERO_POS_OFFSET_H",  "0-65535",  "-", "R/W", "零点位置偏移量高16位"));

            paraRelection.Add(0x20, new ParameterStruct("MOT_RES",          "-",        "mΩ",  "R", "电机内阻"));
            paraRelection.Add(0x21, new ParameterStruct("MOT_INDUC",        "-",        "mH",   "R", "电机电感"));
            paraRelection.Add(0x22, new ParameterStruct("MOT_RATED_VOL",    "-",        "0.1V", "R", "电机额定电压"));
            paraRelection.Add(0x23, new ParameterStruct("MOT_RATED_CUR",    "-",        "mA",   "R", "电机额定电流"));
            paraRelection.Add(0x24, new ParameterStruct("MOT_ENC_LINES",    "-",        "-",    "R", "码盘线数"));
            paraRelection.Add(0x25, new ParameterStruct("MOT_HALL_VALUE",   "-",        "-",    "R", "当前霍尔状态"));
            paraRelection.Add(0x26, new ParameterStruct("MOT_ST_DAT",       "0-65535",  "-",    "R", "绝对编码器单圈数据"));
            paraRelection.Add(0x27, new ParameterStruct("MOT_MT_DAT",       "0-65535",  "-",    "R", "绝对编码器多圈数据"));
            paraRelection.Add(0x28, new ParameterStruct("MOT_ENC_STA",      "-",        "-",    "R", "绝对编码器多圈状态"));

            paraRelection.Add(0x30, new ParameterStruct("TAG_WORK_MODE",    "0-3",      "-",        "R/W", "工作模式：0-开环，1-电流模式，2-速度模式，3-位置模式"));
            paraRelection.Add(0x31, new ParameterStruct("TAG_OPEN_PWM",     "0-100",    "-",        "R/W", "开环模式下占空比"));
            paraRelection.Add(0x32, new ParameterStruct("TAG_CURRENT_L",    "0-65535",  "mA",       "R/W", "目标电流低16位"));
            paraRelection.Add(0x33, new ParameterStruct("TAG_CURRENT_H",    "0-65535",  "mA",       "R/W", "目标电流高16位"));
            paraRelection.Add(0x34, new ParameterStruct("TAG_SPEED_L",      "0-65535",  "units/s",  "R/W", "目标速度低16位"));
            paraRelection.Add(0x35, new ParameterStruct("TAG_SPEED_H",      "0-65535",  "units/s",  "R/W", "目标速度高16位"));
            paraRelection.Add(0x36, new ParameterStruct("TAG_POSITION_L",   "0-65535",  "units",    "R/W", "目标位置低16位"));
            paraRelection.Add(0x37, new ParameterStruct("TAG_POSITION_H",   "0-65535",  "units",    "R/W", "目标位置高16位"));

            paraRelection.Add(0x40, new ParameterStruct("LIT_MAX_CURRENT",      "0-65535", "mA",      "R/W", "最大电流"));
            paraRelection.Add(0x41, new ParameterStruct("LIT_MAX_SPEED",        "0-65535", "rpm",     "R/W", "最大速度"));
            paraRelection.Add(0x42, new ParameterStruct("LIT_MAX_ACC",          "0-65535", "rpm/s",   "R/W", "最大加/减速度"));
            paraRelection.Add(0x43, new ParameterStruct("LIT_MIN_POSITION_L",   "0-65535", "units",   "R/W", "最小位置低16位"));
            paraRelection.Add(0x44, new ParameterStruct("LIT_MIN_POSITION_H",   "0-65535", "units",   "R/W", "最小位置高16位"));
            paraRelection.Add(0x45, new ParameterStruct("LIT_MAX_POSITION_L",   "0-65535", "units",   "R/W", "最大位置低16位"));
            paraRelection.Add(0x46, new ParameterStruct("LIT_MAX_POSITION_H",   "0-65535", "units",   "R/W", "最大位置高16位"));

            paraRelection.Add(0x50, new ParameterStruct("SEV_PARAME_LOCKED",  "0-3",      "-", "R/W", "三闭环参数锁定标志：0-自动切换，1-低载PID参数，2-中载PID参数，3-重载PID参数"));
            paraRelection.Add(0x51, new ParameterStruct("S_CURRENT_P",        "0-65535",  "-", "R/W", "S电流环P参数"));
            paraRelection.Add(0x52, new ParameterStruct("S_CURRENT_I",        "0-65535",  "-", "R/W", "S电流环I参数"));
            paraRelection.Add(0x53, new ParameterStruct("S_CURRENT_D",        "0-65535",  "-", "R/W", "S电流环D参数"));
            paraRelection.Add(0x54, new ParameterStruct("S_SPEED_P",          "0-65535",  "-", "R/W", "S速度环P参数"));
            paraRelection.Add(0x55, new ParameterStruct("S_SPEED_I",          "0-65535",  "-", "R/W", "S速度环I参数"));
            paraRelection.Add(0x56, new ParameterStruct("S_SPEED_D",          "0-65535",  "-", "R/W", "S速度环D参数"));
            paraRelection.Add(0x57, new ParameterStruct("S_SPEED_DS",         "0-65535",  "-", "R/W", "S速度P死区"));
            paraRelection.Add(0x58, new ParameterStruct("S_POSITION_P",       "0-65535",  "-", "R/W", "S位置环P参数"));
            paraRelection.Add(0x59, new ParameterStruct("S_POSITION_I",       "0-65535",  "-", "R/W", "S位置环I参数"));
            paraRelection.Add(0x5a, new ParameterStruct("S_POSITION_D",       "0-65535",  "-", "R/W", "S位置环D参数"));
            paraRelection.Add(0x5b, new ParameterStruct("S_POSITION_DS",      "0-65535",  "-", "R/W", "S位置P死区"));
            paraRelection.Add(0x5c, new ParameterStruct("S_CURRENT_FD",       "0-65535",  "-", "R/W", "前馈参数1"));
            paraRelection.Add(0x5d, new ParameterStruct("M_CURRENT_FD",       "0-65535",  "-", "R/W", "前馈参数2"));
            paraRelection.Add(0x5e, new ParameterStruct("L_CURRENT_FD",       "0-65535",  "-", "R/W", "前馈参数3"));


            paraRelection.Add(0x61, new ParameterStruct("M_CURRENT_P",    "0-65535", "-", "R/W", "M电流环P参数"));
            paraRelection.Add(0x62, new ParameterStruct("M_CURRENT_I",    "0-65535", "-", "R/W", "M电流环I参数"));
            paraRelection.Add(0x63, new ParameterStruct("M_CURRENT_D",    "0-65535", "-", "R/W", "M电流环D参数"));
            paraRelection.Add(0x64, new ParameterStruct("M_SPEED_P",      "0-65535", "-", "R/W", "M速度环P参数"));
            paraRelection.Add(0x65, new ParameterStruct("M_SPEED_I",      "0-65535", "-", "R/W", "M速度环I参数"));
            paraRelection.Add(0x66, new ParameterStruct("M_SPEED_D",      "0-65535", "-", "R/W", "M速度环D参数"));
            paraRelection.Add(0x67, new ParameterStruct("M_SPEED_DS",     "0-65535", "-", "R/W", "M速度P死区"));
            paraRelection.Add(0x68, new ParameterStruct("M_POSITION_P",   "0-65535", "-", "R/W", "M位置环P参数"));
            paraRelection.Add(0x69, new ParameterStruct("M_POSITION_I",   "0-65535", "-", "R/W", "M位置环I参数"));
            paraRelection.Add(0x6a, new ParameterStruct("M_POSITION_D",   "0-65535", "-", "R/W", "M位置环D参数"));
            paraRelection.Add(0x6b, new ParameterStruct("M_POSITION_DS",  "0-65535", "-", "R/W", "M位置P死区"));

            paraRelection.Add(0x71, new ParameterStruct("L_CURRENT_P",    "0-65535", "-", "R/W", "L电流环P参数"));
            paraRelection.Add(0x72, new ParameterStruct("L_CURRENT_I",    "0-65535", "-", "R/W", "L电流环I参数"));
            paraRelection.Add(0x73, new ParameterStruct("L_CURRENT_D",    "0-65535", "-", "R/W", "L电流环D参数"));
            paraRelection.Add(0x74, new ParameterStruct("L_SPEED_P",      "0-65535", "-", "R/W", "L速度环P参数"));
            paraRelection.Add(0x75, new ParameterStruct("L_SPEED_I",      "0-65535", "-", "R/W", "L速度环I参数"));
            paraRelection.Add(0x76, new ParameterStruct("L_SPEED_D",      "0-65535", "-", "R/W", "L速度环D参数"));
            paraRelection.Add(0x77, new ParameterStruct("L_SPEED_DS",     "0-65535", "-", "R/W", "L速度P死区"));
            paraRelection.Add(0x78, new ParameterStruct("L_POSITION_P",   "0-65535", "-", "R/W", "L位置环P参数"));
            paraRelection.Add(0x79, new ParameterStruct("L_POSITION_I",   "0-65535", "-", "R/W", "L位置环I参数"));
            paraRelection.Add(0x7a, new ParameterStruct("L_POSITION_D",   "0-65535", "-", "R/W", "L位置环D参数"));
            paraRelection.Add(0x7b, new ParameterStruct("L_POSITION_DS",  "0-65535", "-", "R/W", "L位置P死区"));

            paraRelection.Add(0x80, new ParameterStruct("BRAKE_RELEASE_CMD",  "0-1", "-", "R/W",  "刹车释放命令，0-保持制动，1-释放刹车"));
            paraRelection.Add(0x81, new ParameterStruct("BRAKE_STATE",        "0-1", "-", "R",    "刹车状态，0-保持制动，1-释放刹车"));

            paraRelection.Add(0x90, new ParameterStruct("SCP_MASK",     "0-63",     "-", "R/W", "记录对象标志MASK"));
            paraRelection.Add(0x91, new ParameterStruct("SCP_REC_TIM",  "0-65535",  "-", "R/W", "记录时间间隔（对10kHZ的分频值）"));
            paraRelection.Add(0x92, new ParameterStruct("SCP_TAGCUR_L", "-",        "-", "R",   "目标电流数据集"));
            paraRelection.Add(0x93, new ParameterStruct("SCP_TAGCUR_H", "-",        "-", "R",   "目标电流数据集"));
            paraRelection.Add(0x94, new ParameterStruct("SCP_MEACUR_L", "-",        "-", "R",   "实际电流数据集"));
            paraRelection.Add(0x95, new ParameterStruct("SCP_MEACUR_H", "-",        "-", "R",   "实际电流数据集"));
            paraRelection.Add(0x96, new ParameterStruct("SCP_TAGSPD_L", "-",        "-", "R",   "目标速度数据集"));
            paraRelection.Add(0x97, new ParameterStruct("SCP_TAGSPD_H", "-",        "-", "R",   "目标速度数据集"));
            paraRelection.Add(0x98, new ParameterStruct("SCP_MEASPD_L", "-",        "-", "R",   "实际速度数据集"));
            paraRelection.Add(0x99, new ParameterStruct("SCP_MEASPD_H", "-",        "-", "R",   "实际速度数据集"));
            paraRelection.Add(0x9a, new ParameterStruct("SCP_TAGPOS_L", "-",        "-", "R",   "目标位置数据集"));
            paraRelection.Add(0x9b, new ParameterStruct("SCP_TAGPOS_H", "-",        "-", "R",   "目标位置数据集"));
            paraRelection.Add(0x9c, new ParameterStruct("SCP_MEAPOS_L", "-",        "-", "R",   "实际位置数据集"));
            paraRelection.Add(0x9d, new ParameterStruct("SCP_MEAPOS_H", "-",        "-", "R",   "实际位置数据集"));
        }

        //刷新相应分类号的参数表
        public void RefreshlVParam(int index)
        {      
            lVParam.Items.Clear();
            for (int i = 0; i < 16;i++ )
            {
                string str = index.ToString();
                lVParam.Items.Add(str);
                str += i.ToString("x1");
                byte addr = Convert.ToByte(str, 16);
                try
                {
                    lVParam.Items[i].SubItems.AddRange(
                        new string[] {
                            str,
                            paraRelection[addr].Name,
                            paraRelection[addr].Range,
                            cBHexDisplay.Checked ? Configuration.MemoryControlTable[Convert.ToByte(str, 16)].ToString("x4") : Configuration.MemoryControlTable[Convert.ToByte(str, 16)].ToString(),
                            paraRelection[addr].Unit });
                    if (paraRelection[addr].Competence == "R")
                    {
                        lVParam.Items[i].BackColor = tBReadOnly.BackColor;
                    }
                }
                catch (Exception ex)
                {
                    MainForm.GetInstance().sBFeedbackShow(ex.Message, 1);
                    lVParam.Items[i].SubItems.AddRange(new string[] { str, "reserved", "--",  "--", "--" });
                    lVParam.Items[i].BackColor = tBUnused.BackColor;
                }
            }
        }

        //关闭窗口后
        private void ParametersForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            pCurrentWin = null;
            timerUpdate.Stop();
        }

        //选择分类号
        private void tVParam_AfterSelect(object sender, TreeViewEventArgs e)
        {
            tVIndex = e.Node.Index;

            //刷新显示
            byte index = Convert.ToByte(Convert.ToByte(tVParam.Nodes[tVIndex].Text.Substring(2, 1)) << 4);
            pc.ReadWords(index, 16, PCan.currentID);
            Thread.Sleep(16);

            for (int i = 0; i < tVParam.Nodes.Count; i++)
            {
                if (i == tVIndex)
                {
                    tVParam.Nodes[i].ForeColor = Color.BlueViolet;
                }
                else
                {
                    tVParam.Nodes[i].ForeColor = Color.Black;
                }
            }

            RefreshlVParam(tVIndex);
        }

        #region 修改参数表中的一项

        private void lVParam_DoubleClick(object sender, EventArgs e)
        {
            //动态生成TextBox以供编辑变量的数值
            if (lVParam.SelectedItems.Count <= 0)
            {
                return;
            }
            
            selectedItemIndex = lVParam.SelectedItems[0].Index; // 记录上一次选择的索引位置

            try
            {
                if (paraRelection[Convert.ToByte(lVParam.SelectedItems[0].SubItems[1].Text, 16)].Competence != "R/W")
                {
                    return;
                }
            }
            catch (Exception ex)
            {
                MainForm.GetInstance().sBFeedbackShow(ex.Message, 1);
                return;
            }

            tb = new TextBox();
            tb.Font = new Font("宋体", 13, FontStyle.Bold);
            tb.TextAlign = HorizontalAlignment.Center;
            tb.BackColor = Color.White;
            Rectangle tt = lVParam.SelectedItems[0].SubItems[4].Bounds;//SubItems[4]是第5列：设定值
            tb.Text = lVParam.SelectedItems[0].SubItems[4].Text;

            tb.Size = new Size(tt.Width, 18);
            tb.Location = tt.Location;
            lVParam.Controls.Add(tb);

            tb.KeyDown += new KeyEventHandler(tb_KeyDown);
            tb.Leave += new EventHandler(tb_Leave);
            tb.Select(0, tb.Text.Length);
            tb.Focus();
        }

        //有了Leave方法，SelectedIndexChanged不需要了，但该方法中的错误提示值得再参考
        //private void lVParam_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    if (lVParam.SelectedItems.Count > 0)
        //    {
        //        if (tb != null)
        //        {
        //            //删除动态生成的TextBox
        //            lVParam.Controls.Remove(tb);
        //            tb = null;
        //        }

        //        selectedItemIndex = lVParam.SelectedItems[0].Index; // 记录上一次选择的索引位置

        //        int nIndex = lVParam.SelectedItems[0].Index;
        //        try
        //        {
        //            tBExplain.Text = paraRelection[Convert.ToByte(lVParam.SelectedItems[0].SubItems[1].Text, 16)].Description;
        //        }
        //        catch (System.Exception ex)
        //        {
        //            tBExplain.Text = "保留字段";
        //            MainForm.GetInstance().sBFeedbackShow(ex.Message, 1);
        //        }
        //    }
        //    else
        //    {
        //        tBExplain.Text = "";
        //    }
        //}

        private void tb_InputDone()
        {
            Int16 value = 0;
            try
            {
                if (cBHexDisplay.Checked)
                {
                    value = Convert.ToInt16(tb.Text, 16);
                }
                else
                {
                    value = Convert.ToInt16(tb.Text);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("请输入合法的字符串！");
                MainForm.GetInstance().sBFeedbackShow(ex.Message, 1);
                lVParam.Controls.Remove(tb);
                tb = null;

                return;
            }

            lVParam.SelectedItems[0].SubItems[4].Text = tb.Text;
            //更改内存控制表
            pc.WriteOneWord(Convert.ToByte(lVParam.Items[selectedItemIndex].SubItems[1].Text, 16), value, PCan.currentID);
            //移除临时用的文本框tb
            lVParam.Controls.Remove(tb);
            tb = null;
        }

        private void tb_Leave(object sender, EventArgs e)
        {
            tb_InputDone();
        }

        private void tb_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                tb_InputDone();
            }
        }

        #endregion

        //16进制显示方式更改
        private void cBHexDisplay_CheckedChanged(object sender, EventArgs e)
        {
            RefreshlVParam(tVParam.SelectedNode.Index);
        }

        //定时刷新参数表
        private void timerUpdate_Tick(object sender, EventArgs e)
        {
            //以1000ms的间隔更新变量
            lVParam.BeginUpdate();
            byte index = Convert.ToByte(Convert.ToByte(tVParam.Nodes[tVIndex].Text.Substring(2, 1)) << 4);
            pc.ReadWords(index, 16, PCan.currentID);
            Thread.Sleep(16);
            //只刷新数据部分
            for (int i = 0; i < 16; i++)
            {
                string str = lVParam.Items[i].SubItems[1].Text;
                lVParam.Items[i].SubItems[4].Text = cBHexDisplay.Checked ? Configuration.MemoryControlTable[Convert.ToByte(str, 16)].ToString("x4") : Configuration.MemoryControlTable[Convert.ToByte(str, 16)].ToString();
            }
            lVParam.EndUpdate();
            ////刷新当前页面
            //cBParametersSource.Text = "从驱动器读取";
            //byte index = Convert.ToByte(Convert.ToByte(tVParam.Nodes[tVIndex].Text.Substring(2, 1)) << 4);
            //pc.ReadWords(index, 16, PCan.currentID);
            //Thread.Sleep(150);
            //RefreshlVParam(tVIndex);
        }

        //单击烧写flash
        private void btnFlash_Click(object sender, EventArgs e)
        {
            //lVParam.Visible = false;
            wp = WriteParameters.GetInstance();
            //wp.MdiParent = this;
            //wp.Parent = ParametersForm.GetInstance();
            wp.Location = new Point(205,125);
            wp.BringToFront();
            wp.Show();            
        }

        //关闭参数设置页面
        private void pBExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        //单击计算器图标
        private void btnCalculator_Click(object sender, EventArgs e)
        {
            System.Diagnostics.ProcessStartInfo Info = new System.Diagnostics.ProcessStartInfo();
            Info.FileName = "calc.exe ";   //"calc.exe"为计算器，"notepad.exe"为记事本
            System.Diagnostics.Process Proc = System.Diagnostics.Process.Start(Info);
        }

        //单击保存图标
        private void btnSave_Click(object sender, EventArgs e)
        {
            saveFileDialogParaPath.InitialDirectory = Application.StartupPath;
            saveFileDialogParaPath.Filter = "参数文件(*.ouj)|*.ouj";
            saveFileDialogParaPath.ShowDialog();
            string path = saveFileDialogParaPath.FileName;
            for (int i = 0; i < Configuration.CMDMAP_LEN; i++)
            {
                string strName = i.ToString("x2");
                string type = "Para " + strName.Substring(0, 1);
                //是写入flash中的数据？ OR 写入内存控制表中的数据
                IniFile.WritePrivateProfileString(type, strName, Configuration.MemoryControlTable[i].ToString(), path);
            }
            MainForm.GetInstance().sBFeedbackShow("参数保存成功！",1);
        }

        private void cBParametersSource_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cBParametersSource.Text == "从驱动器读取")
            {
               if (PCan.currentID == 0)
               {
                   MessageBox.Show("请先连接模块！");
                   return;
               }
               else
               {
                   pc.WriteOneWord(Configuration.SYS_ID, PCan.currentID, PCan.currentID);
                   MainForm.GetInstance().InitialMemoryControlTable();
                   if (pCurrentWin != null)
                   {
                       pCurrentWin.RefreshlVParam(0);
                   }
               }
            }
            else if (cBParametersSource.Text == "从文件读取")
            {

            }
            else if (cBParametersSource.Text == "读取标准出厂设置")
            {

            }
            btnFlash.Focus();
        }

        private void pLName_Click(object sender, EventArgs e)
        {
            this.BringToFront();
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

        private void pLName_MouseUp(object sender, MouseEventArgs e)
        {
            mousePoint = Point.Empty;
        }

        private void pLName_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && mousePoint != Point.Empty)
            {
                this.Top += MousePosition.Y - mousePoint.Y;
                this.Left += MousePosition.X - mousePoint.X;
                mousePoint = MousePosition;
            }
        }

        #endregion

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

        //单击清除错误按钮
        private void btnClearError_Click(object sender, EventArgs e)
        {
            pc.WriteOneWord(Configuration.SYS_CLEAR_ERROR, 0x01, PCan.currentID);
            Thread.Sleep(10);
            pc.WriteOneWord(Configuration.SYS_ENABLE_DRIVER, 0x01, PCan.currentID);
            Thread.Sleep(10);
            MessageBox.Show("清错并使能成功。");
        }
    }


    public class ParameterStruct
    {
        public string Name;
        public string Range;
        public string Unit;
        public string Description;
        public string Competence;

        public ParameterStruct(string name, string range, string unit, string competence, string description)
        {
            Name = name;
            Range = range;
            Unit = unit;
            Competence = competence;
            Description = description;
        }
    }

}
