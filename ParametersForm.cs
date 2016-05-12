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
        TextBox tb;
        PCan pc;
        int selectedItemIndex = -1;

        public ParametersForm()
        {
            InitializeComponent();
            InitialControls();
            pc = new PCan();
            //timerUpdate.Start();
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
            tVParam.Nodes[0].Checked = true;
            RefreshlVParam(tVParam.SelectedNode.Index);
     
        }

        public void RefreshlVParam(int index)
        {
            //Thread.Sleep(1000);      //等待一定时间确保已经加载完成
           
            lVParam.Items.Clear();
            for (int i = 0; i < 16;i++ )
            {
                string str = index.ToString();
                lVParam.Items.Add(str);
                str += i.ToString("x1");
                lVParam.Items[i].SubItems.AddRange(new string[] { str, "", "", cBHexDisplay.Checked ? Configuration.m_CmdMap[Convert.ToByte(str, 16)].ToString("x4") : Configuration.m_CmdMap[Convert.ToByte(str, 16)].ToString(), "" });
            }
        }

        private void ParametersForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            pCurrentWin = null;
            timerUpdate.Stop();

        }

        private void tVParam_AfterSelect(object sender, TreeViewEventArgs e)
        {
            int strName = Convert.ToInt32(e.Node.Text.Substring(2, 1));
            RefreshlVParam(strName);
        }

        private void lVParam_DoubleClick(object sender, EventArgs e)
        {
            //动态生成TextBox以供编辑变量的数值
            if (lVParam.SelectedItems.Count > 0)
            {
                Rectangle tt = lVParam.SelectedItems[0].SubItems[4].Bounds;
                tb = new TextBox();
                tb.Font = new Font("宋体", 13, FontStyle.Bold);
                tb.TextAlign = HorizontalAlignment.Center;
                tb.Size = new Size(tt.Width, 18);
                tb.Location = tt.Location;
                tb.BackColor = Color.White;
                tb.Text = lVParam.SelectedItems[0].SubItems[4].Text;
                tb.Focus();
                lVParam.Controls.Add(tb);

                tb.KeyDown += new System.Windows.Forms.KeyEventHandler(tb_KeyDown);
                tb.MouseLeave += new System.EventHandler(tb_MouseLeave);

                tb.Select(0, tb.Text.Length);
                tb.Focus();
           
                selectedItemIndex = lVParam.SelectedItems[0].Index; // 记录上一次选择的索引位置
            }
        }

        private void lVParam_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lVParam.SelectedItems.Count > 0)
            {
                if (tb != null)
                {
                    //删除动态生成的TextBox
                    lVParam.Controls.Remove(tb);
                    tb = null;
                }

                selectedItemIndex = lVParam.SelectedItems[0].Index; // 记录上一次选择的索引位置

                int nIndex = lVParam.SelectedItems[0].Index;
                for (int i = 0; i < lVParam.Items.Count; i++)
                {
                    if (i == nIndex)
                    {
                        lVParam.Items[i].BackColor = Color.DodgerBlue;
                    }
                    else
                    {
                        lVParam.Items[i].BackColor = Color.White;
                    }

                }
            }
            else
            {
                for (int i = 0; i < lVParam.Items.Count; i++)
                {
                    lVParam.Items[i].BackColor = Color.White;
                }
            }


           
          
        }
        private void tb_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter: if (tb != null)
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
                        catch (System.Exception ex)
                        {
                            MessageBox.Show("请输入合法的字符串！");
                            lVParam.Controls.Remove(tb);
                            tb = null;
                            return;
                        }

                        lVParam.SelectedItems[0].SubItems[4].Text = tb.Text;
                        //更改内存控制表
                        pc.WriteOneWord(Convert.ToByte(lVParam.Items[selectedItemIndex].SubItems[1].Text, 16), value, PCan.currentID);
                        lVParam.Controls.Remove(tb);
                        tb = null;
                    }
                    break;
            }
        }

        private void tb_MouseLeave(object sender, System.EventArgs e)
        {
            if (tb != null && !tb.Focused)
            {

                lVParam.Controls.Remove(tb);
                tb = null;
            }
        }

        private void lVParam_MouseLeave(object sender, EventArgs e)
        {
            //if (tb != null && tb.Focused)
            //{
            //    lVParam.Controls.Remove(tb);
            //    tb = null;
            //}
        }

        private void cBHexDisplay_CheckedChanged(object sender, EventArgs e)
        {
            RefreshlVParam(tVParam.SelectedNode.Index);
        }

        private void pLExplain2_MouseClick(object sender, MouseEventArgs e)
        {
            if (tb != null)
            {
                lVParam.Controls.Remove(tb);
                tb = null;
            }
        }

        private void timerUpdate_Tick(object sender, EventArgs e)
        {
            //以300ms的间隔更新变量
            for (int i = 0; i < 16; i++)
            {
                string str = lVParam.Items[i].SubItems[1].Text;
                lVParam.Items[i].SubItems[4].Text = cBHexDisplay.Checked ? Configuration.m_CmdMap[Convert.ToByte(str, 16)].ToString("x4") : Configuration.m_CmdMap[Convert.ToByte(str, 16)].ToString();
            }
        }



    }
}
