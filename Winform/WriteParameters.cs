using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace ICDIBasic
{
    public partial class WriteParameters : Form
    {
        public static WriteParameters pCurrentWin = null;//句柄
        public static bool ProgramFinished = false;
        PCan pc;

        public WriteParameters()
        {
            InitializeComponent();
            pc = new PCan();
        }

        public static WriteParameters GetInstance()
        {
            if (pCurrentWin == null)
            {
                pCurrentWin = new WriteParameters();
                pCurrentWin.TopLevel = false;
            }
            return pCurrentWin;
        }

        private void WriteParameters_Load(object sender, EventArgs e)
        {
            InitialControls();
        }


        private void InitialControls()
        {
            lVFlash.Items.Clear();
            lVFlash.Visible = true;
            int j = 0;
            for (int i = 0; i < Configuration.CMDMAP_LEN; i++)
            {
                if (Configuration.MemoryControlTableBak[i] != Configuration.MemoryControlTable[i])
                {
                    try
                    {
                        lVFlash.Items.Add("");
                        string strName = i.ToString("x2");
                        string type = strName.Substring(0, 1);
                        lVFlash.Items[j].SubItems.AddRange(new string[] { type, strName, ParametersForm.paraRelection[(byte)i].Description, Configuration.MemoryControlTableBak[i].ToString(), Configuration.MemoryControlTable[i].ToString() });
                        lVFlash.Items[j].Checked = true;
                        j++;
                    }
                    catch (System.Exception ex)
                    {
                        MainForm.GetInstance().sBFeedbackShow(ex.Message, 1);
                        lVFlash.Items[j].Remove();   //删除添加不成功的行
                        continue;
                    }
                  
                }
            }
            if (j == 0)
            {
                lLName.Text = "无参数更改！";
                lLName.BackColor = Color.Red;
                lLName.Location = new Point(230, 160);
                lLName.BringToFront();
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (lLName.Text != "无参数更改！")
            {
                writeParametersToFlash();
            }
            this.Close();
        }

        private void writeParametersToFlash()
        {
            for (int i = 0; i < lVFlash.Items.Count;i++ )
            {
                byte index = Convert.ToByte(lVFlash.Items[i].SubItems[2].Text, 16);
                if (!lVFlash.Items[i].Checked)
                {
                  
                    pc.WriteOneWord(index, Configuration.MemoryControlTableBak[index], PCan.currentID);
                }
                else
                {
                    //更新备份的内存控制表
                    Configuration.MemoryControlTableBak[index] = Configuration.MemoryControlTable[index];
                }
            }
            //保存数据到Flash标志
            ProgramFinished = false;
            pc.WriteOneWord(Configuration.SYS_SAVE_TO_FLASH, 1, PCan.currentID);
            while(!ProgramFinished)
            {
                //等待Flash烧写完成
                pc.ReadOneWord(Configuration.SYS_SAVE_TO_FLASH, PCan.currentID);
                Thread.Sleep(3);
            }
            MessageBox.Show("Done!");
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void WriteParameters_FormClosing(object sender, FormClosingEventArgs e)
        {
            pCurrentWin = null;
        }

    
    }
}
