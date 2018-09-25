using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lin.BGA.HDL
{
    public partial class FormFinishConfirm : Form
    {
        public FormFinishConfirm()
        {
            InitializeComponent();
        }

        private void BtnOK_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void FormFinishConfirm_Load(object sender, EventArgs e)
        {
            BtnOK.Focus();
        }
    }
}
