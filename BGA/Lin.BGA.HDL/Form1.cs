using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Lin.BGA.APIClient;
using Lin.BGA.Model;

namespace Lin.BGA.HDL
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }
        private static IEnumerable<CategoryInfo> listCategory = null;

        private void FormMain_Load(object sender, EventArgs e)
        {
            toolStripStatusLabel2.Text = " Version:" + Application.ProductVersion.ToString();
            LoginCheck();

            LoadUI(true);

        }
        public void LoginCheck()
        {
            if (!new StoreHelper().IsLoginFit())
            {
                var formLogin = new FormLogin();
                formLogin.StartPosition = FormStartPosition.CenterParent;
                formLogin.Show(this);
                return;
            }
            labelStoreName.Text = "门店名称:" + new StoreHelper().GetLoginInfo().Name;
        }

        /// <summary>
        ///获取服务器最新音乐数据，并显示列表及音乐文件
        /// </summary>
        private void LoadUI(bool EnableOffLine = false)
        {
            var categoryClient = new Lin.BGA.APIClient.CategoryClient();
            listCategory = categoryClient.GetList();

            if (!DataHelper.Ping(null))
            {
                if (!EnableOffLine)
                {
                    return;
                }
            }
            else
            {
                InitDataAsync();
            }

            while (panelMusic.Controls.Count > 0)
            {
                panelMusic.Controls.RemoveAt(0);
            }
            int Flag = 0;
            foreach (var itemCategory in listCategory)
            {
                Control groupBox = panelMusic.Controls.Find("GroupBox" + itemCategory.ID, false).FirstOrDefault();
                ListBox listbox;
                if (null == groupBox)
                {
                    groupBox = new GroupBox();
                    panelMusic.Controls.Add(groupBox);
                    groupBox.Name = "GroupBox" + itemCategory.ID;
                    groupBox.Left = (250 + 30) * Flag;
                    groupBox.Width = 250;
                    groupBox.Height = 400;
                    groupBox.Text = itemCategory.Name;

                    listbox = new ListBox();
                    listbox.Name = "ListBox" + itemCategory.ID;
                    groupBox.Controls.Add(listbox);
                    listbox.Top = 20;
                    listbox.Left = 10;
                    listbox.Width = 230;
                    listbox.Height = 360;
                    listbox.Font = new Font("宋体", 12);
                    listbox.MouseDoubleClick += Listbox_MouseDoubleClick;
                }
                else
                {
                    listbox = (ListBox)groupBox.Controls.Find("ListBox" + itemCategory.ID, false).First();
                }

                foreach (var itemMusic in itemCategory.MusicInfo)
                {
                    listbox.Items.Add(itemMusic.Name);
                }
                Flag++;
            }
        }

        private void Listbox_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            var CurrentControl = (ListBox)sender;
            int index = CurrentControl.IndexFromPoint(e.Location);
            if (index == System.Windows.Forms.ListBox.NoMatches)
            {
                CurrentControl.SelectedIndex = -1;
                return;
            }

            var formFinishConfirm = new FormFinishConfirm(true);
            formFinishConfirm.StartPosition = FormStartPosition.CenterParent;
            var confirmResult = formFinishConfirm.ShowDialog();//  MessageBox.Show("是否确认已将音源输入切换至电脑？","切换提醒",MessageBoxButtons.OKCancel); //执行双击事件

            var infoMusic = listCategory.SelectMany(c => c.MusicInfo).FirstOrDefault(a => a.Name == CurrentControl.SelectedItem.ToString());
            if (null == infoMusic)
            {
                MessageBox.Show("音频文件已下架，请重新打开app"); //
                return;
            }
            axWindowsMediaPlayer1.URL = GetCurrentMusicDirectory() +
                infoMusic.CategoryInfo.Name +
                "\\" +
                infoMusic.SRC.Substring(infoMusic.SRC.LastIndexOf("/") + 1);
            axWindowsMediaPlayer1.settings.playCount = infoMusic.PlayTime;
            axWindowsMediaPlayer1.Ctlcontrols.play();
            labelStatus.Text = "现时播放音乐：" + infoMusic.Name;


            MusicLogInfo infoMusicLog = new MusicLogInfo();
            infoMusicLog.StoreID = new StoreHelper().GetLoginInfo().ID;
            infoMusicLog.MusicName = infoMusic.Name;
            infoMusicLog.CategoryName = infoMusic.CategoryInfo.Name;
            infoMusicLog.CreateDate = DateTime.Now;
            infoMusicLog.FinishConfirmTime = DicInfo.DateZone;
            if (infoMusicLog.StoreID > 0)
            {
                new MusicLogClient().CreateToClient(infoMusicLog);
            }
        }


        private string GetCurrentMusicDirectory()
        {
            return System.IO.Directory.GetCurrentDirectory().Replace("/", "\\") + "\\MusicOffLine\\"; ;
        }
        /// <summary>
        /// 离线音乐文件
        /// </summary>
        private void InitDataAsync()
        {
            string BaseDir = GetCurrentMusicDirectory();
            foreach (var itemCategory in listCategory)
            {
                if (!Directory.Exists(BaseDir + itemCategory.Name))
                {
                    Directory.CreateDirectory(BaseDir + itemCategory.Name);
                }

            }
            var listMusic = listCategory.SelectMany(a => a.MusicInfo).ToList();
           Tool.AsyncHelper.Run<bool>(() =>
            {
                DownLoadMusic(listMusic, 0);
                return true;
            });

        }

        private void DownLoadMusic(List<MusicInfo> listMusic, int Index)
        {
            if (Index == listMusic.Count())
            {
                return;
            }
            var itemMusic = listMusic[Index];
            string BaseDir = GetCurrentMusicDirectory();
            string FileFullName = BaseDir
                            + itemMusic.CategoryInfo.Name
                            + "\\"
                            + itemMusic.SRC.Substring(itemMusic.SRC.LastIndexOf("/") + 1);
            string MD5Local = Tool.Md5Helper.GetMD5HashFromFile(FileFullName);
            if (!File.Exists(FileFullName) || MD5Local != itemMusic.MD5)
            {
                if (File.Exists(FileFullName))
                {
                    File.Delete(FileFullName);
                }
                try
                {
                    var HttpFileName = APIClient.APIHellper.ConstConfig.APIURL.Replace("/api", "") + itemMusic.SRC;
                    new APIHellper().DownloadFileAsync(HttpFileName,
                        FileFullName,
                        (object sender, System.Net.DownloadProgressChangedEventArgs e) => { toolStripStatusLabel1.Text = "正在下载音乐文件:" + itemMusic.Name; },
                        (object sender, AsyncCompletedEventArgs e) =>
                        {
                            toolStripStatusLabel1.Text = string.Empty;
                            DownLoadMusic(listMusic, Index + 1);
                        });
                }
                catch (Exception ex)
                {
                    Console.WriteLine("{0}:下载文件出错，特别注意这条消息！！错误代码：{1}", DateTime.Now, ex.Message);
                    DownLoadMusic(listMusic, Index + 1);
                    //throw;
                }

            }
            else
            {
                DownLoadMusic(listMusic, Index + 1);
            }
        }

        private static int TimeTickTimes = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (!DataHelper.Ping(null))
            {
                toolStripStatusLabelNetWork.Text = "网络连接失败";
                return;
            }
            else
            {
                toolStripStatusLabelNetWork.Text = "网络正常";
            }

            TimeTickTimes++;

            DateTime nowDate = DateTime.Now;
            var listProfiles = new ProfilesClient().GetAllConfig();
            if (null == listProfiles || listProfiles.Count() == 0)
            {
                return;
            }
            int EnableUpdateTimeBegin = Tool.Function.ConverToInt(listProfiles.FirstOrDefault(a => a.Key == "EnableUpdateTimeBegin").Value);
            int EnableUpdateTimeEnd = Tool.Function.ConverToInt(listProfiles.FirstOrDefault(a => a.Key == "EnableUpdateTimeEnd").Value);
            int EnableUpdateTimeInterval = Tool.Function.ConverToInt(listProfiles.FirstOrDefault(a => a.Key == "EnableUpdateTimeInterval").Value);
            if ((EnableUpdateTimeInterval / timer1.Interval) <= TimeTickTimes)
            {
                TimeTickTimes = 0;
                if (nowDate.Hour >= EnableUpdateTimeBegin || nowDate.Hour <= EnableUpdateTimeEnd)
                {
                    toolStripStatusLabel2.Text = DateTime.Now.ToString() + ":正在通讯，检查更新中。。。";
                    LoadUI();
                    AppVerionCheck();
                    new MusicLogClient().CreateToServer();
                    toolStripStatusLabel2.Text = " Version:" + Application.ProductVersion.ToString();

                }
            }

        }
        private void AppVerionCheck()
        {
            var infoLastAppVersion = new AppVersionClient().GetLast();
            if (infoLastAppVersion.Version != Application.ProductVersion.ToString())
            {
                timer1.Stop();
                var UpdateResult = MessageBox.Show("系统发布了新版本，是否马上更新？", "重要更新，请及时处理", MessageBoxButtons.YesNo);
                if (UpdateResult == DialogResult.Yes)
                {
                    string aFilePath = Environment.CurrentDirectory + "\\Update\\Lin.BGA.Update.exe";
                    System.Diagnostics.Process.Start(aFilePath);
                    Application.Exit();
                    return;
                }
                else
                {
                    timer1.Start();
                }
            }
        }

        private void axWindowsMediaPlayer1_StatusChange(object sender, EventArgs e)
        {
            Console.WriteLine(DateTime.Now.ToString("HH时mm分ss秒 ffff") + ":" + axWindowsMediaPlayer1.status);
            if ("已停止" == axWindowsMediaPlayer1.status)
            {
                labelStatus.Text = "现时播放音乐：无";

                FormFinishConfirm formFinishConfirm = new FormFinishConfirm(false);
                formFinishConfirm.StartPosition = FormStartPosition.CenterParent;
                formFinishConfirm.ShowDialog();
                var musicLogClient = new MusicLogClient();
                musicLogClient.UpdateLastOneFinishTIme();

            }
        }

        private void BtnUpdateCheck_Click(object sender, EventArgs e)
        {
            LoadUI();
        }
    }
}
