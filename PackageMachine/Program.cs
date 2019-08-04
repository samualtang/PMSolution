using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PackageMachine
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。'\
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Process[] localNmae = Process.GetProcessesByName("PackageMachine");
            if (localNmae.Length > 1)
            {
                MessageBox.Show("包装上位系统已经打开,请勿重复开启!");

            }
            else
            {
                Application.Run(new FmMain ());
            }

        }
    }
}
