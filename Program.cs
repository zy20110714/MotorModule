using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ICDIBasic
{
    static class Program
    {
        /// The main entry point for the application.
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(MainForm.GetInstance());

        }
    }
}