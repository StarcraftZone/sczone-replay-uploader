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
            lblStatus = new Label();
            btnToggle = new Button();
            btnUpload = new Button();
            progressBar = new ProgressBar();
            lblProgress = new Label();
            lstLog = new RichTextBox();
            SuspendLayout();
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Location = new Point(12, 14);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(80, 15);
            lblStatus.TabIndex = 0;
            lblStatus.Text = "状态：未启动";
            // 
            // btnToggle
            // 
            btnToggle.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnToggle.Location = new Point(580, 9);
            btnToggle.Name = "btnToggle";
            btnToggle.Size = new Size(96, 27);
            btnToggle.TabIndex = 1;
            btnToggle.Text = "开始监听";
            btnToggle.Click += BtnToggle_Click;
            // 
            // btnUpload
            // 
            btnUpload.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnUpload.Location = new Point(692, 9);
            btnUpload.Name = "btnUpload";
            btnUpload.Size = new Size(96, 27);
            btnUpload.TabIndex = 2;
            btnUpload.Text = "手动上传";
            btnUpload.Click += BtnUpload_Click;
            // 
            // progressBar
            // 
            progressBar.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            progressBar.Location = new Point(12, 50);
            progressBar.Name = "progressBar";
            progressBar.Size = new Size(776, 20);
            progressBar.TabIndex = 3;
            // 
            // lblProgress
            // 
            lblProgress.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblProgress.Location = new Point(680, 50);
            lblProgress.Name = "lblProgress";
            lblProgress.Size = new Size(108, 20);
            lblProgress.TabIndex = 4;
            lblProgress.Text = "";
            lblProgress.TextAlign = ContentAlignment.MiddleRight;
            lblProgress.BackColor = Color.Transparent;
            // 
            // lstLog
            // 
            lstLog.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lstLog.BackColor = SystemColors.Window;
            lstLog.Font = new Font("Consolas", 9F);
            lstLog.Location = new Point(12, 80);
            lstLog.Name = "lstLog";
            lstLog.ReadOnly = true;
            lstLog.ScrollBars = RichTextBoxScrollBars.Both;
            lstLog.Size = new Size(776, 358);
            lstLog.TabIndex = 5;
            lstLog.WordWrap = false;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(lblStatus);
            Controls.Add(btnToggle);
            Controls.Add(btnUpload);
            Controls.Add(progressBar);
            Controls.Add(lblProgress);
            Controls.Add(lstLog);
            Name = "MainForm";
            Text = "SCZone Replay Uploader";
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
    }
}
