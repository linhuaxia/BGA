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
using static Lin.BGA.APIClient.ProfilesClient;

namespace Lin.BGA.HDL
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }
        private static IEnumerable<CategoryInfo> listCategory = null;

        private  void  FormMain_Load(object sender, EventArgs e)
        {
            LoginCheck();
            var categoryClient = new APIClient.CategoryClient();
            listCategory = categoryClient.GetList();
            InitDataAsync();

            LoadUI();

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

        private  void LoadUI()
        {
            //var listEnableGroupBoxName = listCategory.Select(c => "GroupBox" + c.ID);
            //foreach (Control item in panelMusic.Controls)
            //{
            //    if (!listEnableGroupBoxName.Any(a => a == item.Name))
            //    {
            //        panelMusic.Controls.Remove(item);
            //    }
            //}
            while (panelMusic.Controls.Count>0)
            {
                panelMusic.Controls.RemoveAt(0);
            }
            int Flag = 0;
            foreach (var itemCategory in listCategory)
            {
                Control groupBox= panelMusic.Controls.Find("GroupBox" + itemCategory.ID, false).FirstOrDefault();
                ListBox listbox;
                if (null== groupBox)
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
           // MessageBox.Show(CurrentControl.SelectedItem.ToString()); //执行双击事件

            var infoMusic = listCategory.SelectMany(c => c.MusicInfo).FirstOrDefault(a => a.Name == CurrentControl.SelectedItem.ToString());
            if (null==infoMusic)
            {
                MessageBox.Show("音频文件已下架，请重新打开app"); //
                return;
            }
            axWindowsMediaPlayer1.URL= GetCurrentMusicDirectory() + 
                infoMusic.CategoryInfo.Name + 
                "\\" + 
                infoMusic.SRC.Substring(infoMusic.SRC.LastIndexOf("/") + 1);
            axWindowsMediaPlayer1.settings.playCount = infoMusic.PlayTime;
            axWindowsMediaPlayer1.Ctlcontrols.play();
            labelStatus.Text = "现时播放音乐：" + infoMusic.Name;
        }

        private void hScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            System.UInt32 Value = (System.UInt32)((double)0xffff * (double)hScrollBar1.Value / (double)(hScrollBar1.Maximum - hScrollBar1.Minimum));//先把trackbar的value值映射到0x0000～0xFFFF范围
            //限制value的取值范围

            if (Value < 0) Value = 0;

            if (Value > 0xffff) Value = 0xffff;


        }

        private string GetCurrentMusicDirectory()
        {
            return System.IO.Directory.GetCurrentDirectory().Replace("/", "\\") + "\\MusicOffLine\\"; ;
        }
        private void InitDataAsync()
        {
            string BaseDir = GetCurrentMusicDirectory();
            foreach (var itemCategory in listCategory)
            {
                if (!Directory.Exists(BaseDir+ itemCategory.Name))
                {
                    Directory.CreateDirectory(BaseDir + itemCategory.Name);
                }
                foreach (var itemMusic in itemCategory.MusicInfo)
                {
                    string FileFullName = BaseDir
                        + itemCategory.Name
                        + "\\"
                        + itemMusic.SRC.Substring(itemMusic.SRC.LastIndexOf("/")+1);
                    if (!File.Exists(FileFullName))
                    {
                        var HttpFileName = APIClient.APIHellper.ConstConfig.APIURL.Replace("/api", "") + itemMusic.SRC;
                        new APIHellper().DownloadFileAsync(HttpFileName,
                            FileFullName,
                            (object sender, System.Net.DownloadProgressChangedEventArgs e) => { },
                            (object sender, AsyncCompletedEventArgs e) => { });
                    }
                }
               
            }
        }
        private static int TimeTickTimes = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            TimeTickTimes++;

            DateTime nowDate = DateTime.Now;
            var listProfiles = new ProfilesClient().GetAllConfig();
            int EnableUpdateTimeBegin = Tool.Function.ConverToInt(listProfiles.FirstOrDefault(a => a.Key == "EnableUpdateTimeBegin").Value);
            int EnableUpdateTimeEnd = Tool.Function.ConverToInt(listProfiles.FirstOrDefault(a => a.Key == "EnableUpdateTimeEnd").Value);
            int EnableUpdateTimeInterval = Tool.Function.ConverToInt(listProfiles.FirstOrDefault(a => a.Key == "EnableUpdateTimeInterval").Value);
            if ((EnableUpdateTimeInterval / timer1.Interval) <= TimeTickTimes)
            {
                TimeTickTimes = 0;
                if (EnableUpdateTimeBegin >= nowDate.Hour || EnableUpdateTimeEnd <= nowDate.Hour)
                {
                    LoadUI();
                }
            }
            
        }

        private void axWindowsMediaPlayer1_StatusChange(object sender, EventArgs e)
        {
            if ("已停止"== axWindowsMediaPlayer1.status)
            {
                labelStatus.Text = "现时播放音乐：无";
            }
        }
    }
}
