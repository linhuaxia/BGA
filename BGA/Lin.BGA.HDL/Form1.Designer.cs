namespace Lin.BGA.HDL
{
    partial class FormMain
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.labelStoreName = new System.Windows.Forms.Label();
            this.labelStatus = new System.Windows.Forms.Label();
            this.groupBoxMusic = new System.Windows.Forms.GroupBox();
            this.panelMusic = new System.Windows.Forms.Panel();
            this.hScrollBar1 = new System.Windows.Forms.HScrollBar();
            this.groupBoxVolumn = new System.Windows.Forms.GroupBox();
            this.axWindowsMediaPlayer1 = new AxWMPLib.AxWindowsMediaPlayer();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.LabUpdateStatus = new System.Windows.Forms.Label();
            this.groupBoxMusic.SuspendLayout();
            this.groupBoxVolumn.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axWindowsMediaPlayer1)).BeginInit();
            this.SuspendLayout();
            // 
            // labelStoreName
            // 
            this.labelStoreName.AutoSize = true;
            this.labelStoreName.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelStoreName.Location = new System.Drawing.Point(51, 40);
            this.labelStoreName.Name = "labelStoreName";
            this.labelStoreName.Size = new System.Drawing.Size(105, 21);
            this.labelStoreName.TabIndex = 0;
            this.labelStoreName.Text = "门店名称:";
            // 
            // labelStatus
            // 
            this.labelStatus.AutoSize = true;
            this.labelStatus.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelStatus.Location = new System.Drawing.Point(383, 40);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(178, 21);
            this.labelStatus.TabIndex = 0;
            this.labelStatus.Text = "现时播放音乐：无";
            // 
            // groupBoxMusic
            // 
            this.groupBoxMusic.Controls.Add(this.panelMusic);
            this.groupBoxMusic.Location = new System.Drawing.Point(12, 92);
            this.groupBoxMusic.Name = "groupBoxMusic";
            this.groupBoxMusic.Size = new System.Drawing.Size(960, 461);
            this.groupBoxMusic.TabIndex = 1;
            this.groupBoxMusic.TabStop = false;
            this.groupBoxMusic.Text = "音乐清单";
            // 
            // panelMusic
            // 
            this.panelMusic.AutoScroll = true;
            this.panelMusic.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMusic.Location = new System.Drawing.Point(3, 17);
            this.panelMusic.Name = "panelMusic";
            this.panelMusic.Size = new System.Drawing.Size(954, 441);
            this.panelMusic.TabIndex = 0;
            // 
            // hScrollBar1
            // 
            this.hScrollBar1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.hScrollBar1.Location = new System.Drawing.Point(3, 31);
            this.hScrollBar1.Name = "hScrollBar1";
            this.hScrollBar1.Size = new System.Drawing.Size(978, 23);
            this.hScrollBar1.TabIndex = 2;
            this.hScrollBar1.Value = 50;
            this.hScrollBar1.Scroll += new System.Windows.Forms.ScrollEventHandler(this.hScrollBar1_Scroll);
            // 
            // groupBoxVolumn
            // 
            this.groupBoxVolumn.Controls.Add(this.hScrollBar1);
            this.groupBoxVolumn.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBoxVolumn.Location = new System.Drawing.Point(0, 604);
            this.groupBoxVolumn.Name = "groupBoxVolumn";
            this.groupBoxVolumn.Size = new System.Drawing.Size(984, 57);
            this.groupBoxVolumn.TabIndex = 3;
            this.groupBoxVolumn.TabStop = false;
            this.groupBoxVolumn.Text = "音量大小";
            this.groupBoxVolumn.Visible = false;
            // 
            // axWindowsMediaPlayer1
            // 
            this.axWindowsMediaPlayer1.Enabled = true;
            this.axWindowsMediaPlayer1.Location = new System.Drawing.Point(0, 587);
            this.axWindowsMediaPlayer1.Name = "axWindowsMediaPlayer1";
            this.axWindowsMediaPlayer1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axWindowsMediaPlayer1.OcxState")));
            this.axWindowsMediaPlayer1.Size = new System.Drawing.Size(984, 45);
            this.axWindowsMediaPlayer1.TabIndex = 5;
            this.axWindowsMediaPlayer1.StatusChange += new System.EventHandler(this.axWindowsMediaPlayer1_StatusChange);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 10000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // LabUpdateStatus
            // 
            this.LabUpdateStatus.AutoSize = true;
            this.LabUpdateStatus.Location = new System.Drawing.Point(3, 0);
            this.LabUpdateStatus.Name = "LabUpdateStatus";
            this.LabUpdateStatus.Size = new System.Drawing.Size(95, 12);
            this.LabUpdateStatus.TabIndex = 6;
            this.LabUpdateStatus.Text = "LabUpdateStatus";
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(984, 661);
            this.Controls.Add(this.LabUpdateStatus);
            this.Controls.Add(this.axWindowsMediaPlayer1);
            this.Controls.Add(this.groupBoxVolumn);
            this.Controls.Add(this.groupBoxMusic);
            this.Controls.Add(this.labelStatus);
            this.Controls.Add(this.labelStoreName);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormMain";
            this.Text = "海底捞门店通知音乐播放器";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.groupBoxMusic.ResumeLayout(false);
            this.groupBoxVolumn.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.axWindowsMediaPlayer1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelStoreName;
        private System.Windows.Forms.Label labelStatus;
        private System.Windows.Forms.GroupBox groupBoxMusic;
        private System.Windows.Forms.HScrollBar hScrollBar1;
        private System.Windows.Forms.GroupBox groupBoxVolumn;
        private System.Windows.Forms.Panel panelMusic;
        private AxWMPLib.AxWindowsMediaPlayer axWindowsMediaPlayer1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label LabUpdateStatus;
    }
}

