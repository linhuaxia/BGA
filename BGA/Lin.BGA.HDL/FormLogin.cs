using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Lin.BGA.APIClient;
using Lin.BGA.Model;


namespace Lin.BGA.HDL
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }

        private void BtnSubmit_Click(object sender, EventArgs e)
        {
            var info = new StoreInfo();
            info.Code = TxtCode.Text;
            info.Password = TxtPassword.Text;
            info.IP = System.Environment.MachineName;
            string Msg = string.Empty;
            info = new StoreClient().Login(info, out Msg);
            if (null == info)
            {
                MessageBox.Show(Msg);
                return;
            }
            info.Password = string.Empty;
            var JsonText = Newtonsoft.Json.JsonConvert.SerializeObject(info);
            Tool.DocHelper.Write(System.IO.Directory.GetCurrentDirectory() + "/登录信息", JsonText);
            this.Close();

        }

        private void FormLogin_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (!new StoreHelper().IsLoginFit())
            {
                Application.Exit();
            }
            
        }
    }
}
