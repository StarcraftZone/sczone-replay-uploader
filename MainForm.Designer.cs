namespace sczone_replay_uploader
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            lblStatus = new Label();
            btnToggle = new Button();
            btnUpload = new Button();
            progressBar = new ProgressBar();
            lblProgress = new Label();
            lstLog = new RichTextBox();
            lnkReplay = new LinkLabel();
            chkAutoStart = new CheckBox();
            trayMenu = new ContextMenuStrip(components);
            trayMenuShow = new ToolStripMenuItem();
            trayMenuExit = new ToolStripMenuItem();
            notifyIcon = new NotifyIcon(components);
            SuspendLayout();
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Location = new Point(22, 26);
            lblStatus.Margin = new Padding(6, 0, 6, 0);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(138, 28);
            lblStatus.TabIndex = 0;
            lblStatus.Text = "状态：未启动";
            // 
            // btnToggle
            // 
            btnToggle.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnToggle.Location = new Point(1077, 17);
            btnToggle.Margin = new Padding(6);
            btnToggle.Name = "btnToggle";
            btnToggle.Size = new Size(178, 50);
            btnToggle.TabIndex = 1;
            btnToggle.Text = "开始监听";
            btnToggle.Click += BtnToggle_Click;
            // 
            // btnUpload
            // 
            btnUpload.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnUpload.Location = new Point(1285, 17);
            btnUpload.Margin = new Padding(6);
            btnUpload.Name = "btnUpload";
            btnUpload.Size = new Size(178, 50);
            btnUpload.TabIndex = 2;
            btnUpload.Text = "手动上传";
            btnUpload.Click += BtnUpload_Click;
            // 
            // progressBar
            // 
            progressBar.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            progressBar.Location = new Point(22, 93);
            progressBar.Margin = new Padding(6);
            progressBar.Name = "progressBar";
            progressBar.Size = new Size(1441, 37);
            progressBar.TabIndex = 3;
            // 
            // lblProgress
            // 
            lblProgress.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblProgress.BackColor = Color.Transparent;
            lblProgress.Location = new Point(1263, 93);
            lblProgress.Margin = new Padding(6, 0, 6, 0);
            lblProgress.Name = "lblProgress";
            lblProgress.Size = new Size(201, 37);
            lblProgress.TabIndex = 4;
            lblProgress.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lstLog
            // 
            lstLog.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lstLog.BackColor = SystemColors.Window;
            lstLog.Font = new Font("Consolas", 9F);
            lstLog.Location = new Point(22, 149);
            lstLog.Margin = new Padding(6);
            lstLog.Name = "lstLog";
            lstLog.ReadOnly = true;
            lstLog.Size = new Size(1438, 616);
            lstLog.TabIndex = 5;
            lstLog.Text = "";
            lstLog.WordWrap = false;
            // 
            // lnkReplay
            // 
            lnkReplay.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            lnkReplay.AutoSize = true;
            lnkReplay.LinkArea = new LinkArea(7, 25);
            lnkReplay.Location = new Point(22, 788);
            lnkReplay.Margin = new Padding(6, 0, 6, 0);
            lnkReplay.Name = "lnkReplay";
            lnkReplay.Size = new Size(428, 33);
            lnkReplay.TabIndex = 6;
            lnkReplay.TabStop = true;
            lnkReplay.Text = "录像在线分析：https://haoest.com/replay";
            lnkReplay.UseCompatibleTextRendering = true;
            lnkReplay.LinkClicked += LnkReplay_LinkClicked;
            // 
            // chkAutoStart
            // 
            chkAutoStart.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            chkAutoStart.AutoSize = true;
            chkAutoStart.Location = new Point(1296, 787);
            chkAutoStart.Name = "chkAutoStart";
            chkAutoStart.Size = new Size(164, 32);
            chkAutoStart.TabIndex = 7;
            chkAutoStart.Text = "开机自动启动";
            chkAutoStart.CheckedChanged += ChkAutoStart_CheckedChanged;
            //
            // trayMenu
            //
            trayMenu.Items.AddRange(new ToolStripItem[] { trayMenuShow, trayMenuExit });
            trayMenu.Name = "trayMenu";
            //
            // trayMenuShow
            //
            trayMenuShow.Name = "trayMenuShow";
            trayMenuShow.Text = "显示窗口";
            trayMenuShow.Click += TrayMenuShow_Click;
            //
            // trayMenuExit
            //
            trayMenuExit.Name = "trayMenuExit";
            trayMenuExit.Text = "退出程序";
            trayMenuExit.Click += TrayMenuExit_Click;
            //
            // notifyIcon
            //
            notifyIcon.ContextMenuStrip = trayMenu;
            notifyIcon.Icon = (Icon)resources.GetObject("$this.Icon");
            notifyIcon.Text = "星际2录像自动上传器";
            notifyIcon.Visible = false;
            notifyIcon.DoubleClick += NotifyIcon_DoubleClick;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(13F, 28F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1486, 840);
            Controls.Add(lblStatus);
            Controls.Add(btnToggle);
            Controls.Add(btnUpload);
            Controls.Add(progressBar);
            Controls.Add(lblProgress);
            Controls.Add(lstLog);
            Controls.Add(lnkReplay);
            Controls.Add(chkAutoStart);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(6);
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "星际2录像自动上传器 - haoest.com";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblStatus;
        private Button btnToggle;
        private Button btnUpload;
        private ProgressBar progressBar;
        private Label lblProgress;
        private RichTextBox lstLog;
        private LinkLabel lnkReplay;
        private CheckBox chkAutoStart;
        private NotifyIcon notifyIcon;
        private ContextMenuStrip trayMenu;
        private ToolStripMenuItem trayMenuShow;
        private ToolStripMenuItem trayMenuExit;
    }
}
