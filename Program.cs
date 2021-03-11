using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace TFS_Helper
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        { // 只能启动一个应用程序实例
            bool createNew;
            using (System.Threading.Mutex mutexObj = new System.Threading.Mutex(true, Application.ProductName, out createNew))
            {
                if (createNew)
                {
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    Application.Run(new MainForm());
                }
                else
                {
                    MainForm.WarningMessage("应用程序已经启动！");
                }
            } 
        }
    }
}
