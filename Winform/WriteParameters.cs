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

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.Close();
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
