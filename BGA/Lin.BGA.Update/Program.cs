using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lin.BGA.Update
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            var formUpdate = new FormUpdate();
            //formUpdate.Hide();
            //formUpdate.Visible = false;
            Application.Run(formUpdate);
        }
    }
}
