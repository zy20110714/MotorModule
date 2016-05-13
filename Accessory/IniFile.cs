using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Text;
using System.IO;

namespace ICDIBasic
{
    /// <summary>
    /// 配置文件 类
    /// </summary>
    public class IniFile
    {
        public static string InitialPara = Application.StartupPath + "\\" + "\\initialPara.ouj";//获取INI文件路径
        public static string strProPath = Application.StartupPath + "\\" + "\\config.ouj";//获取INI文件路径
        [DllImport("kernel32")]
        public static extern long WritePrivateProfileString(string section, string key, string val, string filepath);
        [DllImport("kernel32")]
        public static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retval, int size, string filePath);
        public static string ContentValue(string Section, string key, string path)
        {
            StringBuilder temp = new StringBuilder(1024);
            GetPrivateProfileString(Section, key, "", temp, 1024, path);
            return temp.ToString();
        }
    }
}
