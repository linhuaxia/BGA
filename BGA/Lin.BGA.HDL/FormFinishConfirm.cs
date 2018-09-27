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
        private bool _TrueBeforeFalseAfter;
        public FormFinishConfirm(bool TrueBeforeFalseAfter)
        {
            _TrueBeforeFalseAfter = TrueBeforeFalseAfter;
            InitializeComponent();
            if (_TrueBeforeFalseAfter)
            {
                pictureBox1.Image = global::Lin.BGA.HDL.Properties.Resources.Before;
            }
            else
            {
                pictureBox1.Image = global::Lin.BGA.HDL.Properties.Resources.After;
            }
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
