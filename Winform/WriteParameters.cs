using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

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
            InitialControls();
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

        private void InitialControls()
        {
            lVFlash.Items.Clear();
            lVFlash.Visible = true;
            int j = 0;
            for (int i = 0; i < Configuration.CMDMAP_LEN; i++)
            {
                if (Configuration.MemoryControlTableBak[i] != Configuration.MemoryControlTable[i])
                {
                    lVFlash.Items.Add("");
                    string strName = i.ToString("x2");
                    string type = strName.Substring(0, 1);
                    lVFlash.Items[j].SubItems.AddRange(new string[] { type, strName, ParametersForm.paraRelection[(byte)i].Description, Configuration.MemoryControlTableBak[i].ToString(),Configuration.MemoryControlTable[i].ToString()});
                    lVFlash.Items[j].Checked = true;
                    j++;
                }
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            writeParametersToFlash();
            this.Close();
        }

        private void writeParametersToFlash()
        {
            for (int i = 0; i < lVFlash.Items.Count;i++ )
            {
                if (!lVFlash.Items[i].Checked)
                {
                    byte index = Convert.ToByte(lVFlash.Items[i].SubItems[2].Text,16);
                    pc.WriteOneWord(index, Configuration.MemoryControlTableBak[index], PCan.currentID);
                }
            }
            //保存数据到Flash标志
            ProgramFinished = false;
            pc.WriteOneWord(Configuration.SYS_SAVE_TO_FLASH, 1, PCan.currentID);
            while(!ProgramFinished)
            {
                //等待Flash烧写完成
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
