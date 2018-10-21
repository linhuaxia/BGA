using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lin.BGA.HDL
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            System.Diagnostics.Process instance = RunningInstance();
            if (instance == null)
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                var mainForm = new FormMain();
                mainForm.StartPosition = FormStartPosition.CenterScreen;
                try
                {
                    Application.Run(mainForm);
                }
                catch (Exception ex)
                {
                    //Tool.DocHelper.Write(Environment.CurrentDirectory+ "\\ErrorLog.txt", ex.Message + "\n");
                    Console.WriteLine(ex.Message);
                    Console.ReadKey();
                }
            }
            else
            {
                HandleRunningInstance(instance);
            }

        }

        /// <summary>
        /// 获取当前正在运行的进程实例
        /// </summary>
        /// <returns></returns>
        public static Process RunningInstance()
        {
            // 获取当前活动的进程
            Process current = Process.GetCurrentProcess();
            // 获取当前本地计算机上指定的进程名称的所有进程
            Process[] processes = Process.GetProcessesByName(current.ProcessName);
            foreach (Process process in processes)
            {
                // 忽略当前进程
                if (process.Id != current.Id)
                {
                    if (Assembly.GetExecutingAssembly().Location.Replace("/", "\\") == current.MainModule.FileName)
                    {
                        return process;
                    }
                }
            }

            // 如果没有其他同名进程存在,则返回 null
            return null;
        }

        // 指示该属性化方法由非托管动态链接库 (DLL) 作为静态入口点公开
        [DllImport("User32.dll")]
        private static extern bool ShowWindowAsync(IntPtr hWnd, int cmdShow);
        [DllImport("User32.dll")]
        private static extern bool SetForegroundWindow(IntPtr hWnd);
        private const int WS_SHOWNORMAL = 1;

        /// <summary>
        /// 如果有另一个同名进程启动,则调用之前的实例
        /// </summary>
        /// <param name="instance"></param>
        private static void HandleRunningInstance(Process instance)
        {
            // 确保窗体不是最小化或者最大化
            ShowWindowAsync(instance.MainWindowHandle, WS_SHOWNORMAL);
            // 将之前启动的进程实例弄到前台窗口
            SetForegroundWindow(instance.MainWindowHandle);
        }

    }
}
