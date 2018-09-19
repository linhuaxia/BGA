using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lin.BGA.Update
{
    public partial class FormUpdate : Form
    {

        public FormUpdate()
        {
            InitializeComponent();
        }
        AppVersionClientInfo infoAppVersionClientNew;
        private void FormUpdate_Load(object sender, EventArgs e)
        {
            //string aFilePath = Environment.SystemDirectory + "\\Notepad.exe";
            //Process.Start(aFilePath);
            //Application.Exit();
            //return;

            FileVersionInfo myFileVersionInfo = FileVersionInfo.GetVersionInfo(Environment.CurrentDirectory + "\\海底捞门店通知音乐播放器.exe");
            labelCurrent.Text = myFileVersionInfo.FileVersion;

             infoAppVersionClientNew = new UpdateHelper().GetLast();
            labelUpdate.Text ="版本号："+ infoAppVersionClientNew.Version;
            labelUpdate.Text += "新功能："+infoAppVersionClientNew.Detail;

        }



        private void timer1_Tick(object sender, EventArgs e)
        {
            //MessageBox.Show("我要出来了");
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            string SaveName = infoAppVersionClientNew.Version + ".zip";
            string SaveFullName = Environment.CurrentDirectory + "\\" + SaveName;
            if (File.Exists(SaveFullName))
            {
                File.Delete(SaveFullName);
            }
            new UpdateHelper().DownLoad(infoAppVersionClientNew.SRC, SaveFullName,
                (senderProcess, eProcess) =>
            {
                progressBar1.Value = eProcess.ProgressPercentage;
            },
                (object senderCompleted, AsyncCompletedEventArgs eCompleted) => {
                    UnZipHelper.unZipFile(SaveFullName, Environment.CurrentDirectory);
                }
            );
        }

        private void UnZip()
        {
            
        }
    }
}
