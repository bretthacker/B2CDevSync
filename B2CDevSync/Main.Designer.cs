namespace B2CDevSync
{
    partial class Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.btnLogin = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnAppSettings = new System.Windows.Forms.Button();
            this.PolicyWatcher = new System.IO.FileSystemWatcher();
            this.txtOperations = new System.Windows.Forms.TextBox();
            this.btnQuit = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.btnAbout = new System.Windows.Forms.Button();
            this.UIWatcher = new System.IO.FileSystemWatcher();
            this.btnClearLog = new System.Windows.Forms.Button();
            this.aniRunning = new System.Windows.Forms.PictureBox();
            this.txtLoginInfo = new System.Windows.Forms.TextBox();
            this.lblSyncProfile = new System.Windows.Forms.Label();
            this.cmbSyncProfiles = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPolicyFolder = new System.Windows.Forms.TextBox();
            this.txtUIFolder = new System.Windows.Forms.TextBox();
            this.btnTenantInit = new System.Windows.Forms.Button();
            this.txtTenantName = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.PolicyWatcher)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UIWatcher)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.aniRunning)).BeginInit();
            this.SuspendLayout();
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.BalloonTipText = "B2C Dev Sync";
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "B2C Dev Sync";
            this.notifyIcon1.Click += new System.EventHandler(this.notifyIcon1_Click);
            this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
            // 
            // btnLogin
            // 
            this.btnLogin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLogin.Location = new System.Drawing.Point(551, 9);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(126, 35);
            this.btnLogin.TabIndex = 4;
            this.btnLogin.Text = "Login";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_ClickAsync);
            // 
            // btnStart
            // 
            this.btnStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnStart.Enabled = false;
            this.btnStart.Location = new System.Drawing.Point(14, 697);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(117, 43);
            this.btnStart.TabIndex = 8;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnAppSettings
            // 
            this.btnAppSettings.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAppSettings.Location = new System.Drawing.Point(551, 54);
            this.btnAppSettings.Name = "btnAppSettings";
            this.btnAppSettings.Size = new System.Drawing.Size(126, 39);
            this.btnAppSettings.TabIndex = 5;
            this.btnAppSettings.Text = "Settings...";
            this.btnAppSettings.UseVisualStyleBackColor = true;
            this.btnAppSettings.Click += new System.EventHandler(this.btnAppSettings_Click);
            // 
            // PolicyWatcher
            // 
            this.PolicyWatcher.EnableRaisingEvents = true;
            this.PolicyWatcher.SynchronizingObject = this;
            // 
            // txtOperations
            // 
            this.txtOperations.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtOperations.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtOperations.Location = new System.Drawing.Point(15, 288);
            this.txtOperations.Multiline = true;
            this.txtOperations.Name = "txtOperations";
            this.txtOperations.ReadOnly = true;
            this.txtOperations.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtOperations.Size = new System.Drawing.Size(664, 594);
            this.txtOperations.TabIndex = 7;
            // 
            // btnQuit
            // 
            this.btnQuit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnQuit.Location = new System.Drawing.Point(564, 697);
            this.btnQuit.Name = "btnQuit";
            this.btnQuit.Size = new System.Drawing.Size(117, 43);
            this.btnQuit.TabIndex = 10;
            this.btnQuit.Text = "Quit";
            this.btnQuit.UseVisualStyleBackColor = true;
            this.btnQuit.Click += new System.EventHandler(this.btnQuit_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 262);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(104, 25);
            this.label3.TabIndex = 13;
            this.label3.Text = "Operations:";
            // 
            // btnAbout
            // 
            this.btnAbout.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAbout.Location = new System.Drawing.Point(551, 154);
            this.btnAbout.Name = "btnAbout";
            this.btnAbout.Size = new System.Drawing.Size(126, 39);
            this.btnAbout.TabIndex = 6;
            this.btnAbout.Text = "About";
            this.btnAbout.UseVisualStyleBackColor = true;
            this.btnAbout.Click += new System.EventHandler(this.btnAbout_Click);
            // 
            // UIWatcher
            // 
            this.UIWatcher.EnableRaisingEvents = true;
            this.UIWatcher.SynchronizingObject = this;
            // 
            // btnClearLog
            // 
            this.btnClearLog.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClearLog.Location = new System.Drawing.Point(411, 697);
            this.btnClearLog.Name = "btnClearLog";
            this.btnClearLog.Size = new System.Drawing.Size(117, 43);
            this.btnClearLog.TabIndex = 9;
            this.btnClearLog.Text = "Clear Log";
            this.btnClearLog.UseVisualStyleBackColor = true;
            this.btnClearLog.Click += new System.EventHandler(this.btnClearLog_Click);
            // 
            // aniRunning
            // 
            this.aniRunning.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.aniRunning.Image = ((System.Drawing.Image)(resources.GetObject("aniRunning.Image")));
            this.aniRunning.Location = new System.Drawing.Point(143, 705);
            this.aniRunning.Name = "aniRunning";
            this.aniRunning.Size = new System.Drawing.Size(33, 33);
            this.aniRunning.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.aniRunning.TabIndex = 14;
            this.aniRunning.TabStop = false;
            this.aniRunning.Visible = false;
            // 
            // txtLoginInfo
            // 
            this.txtLoginInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLoginInfo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtLoginInfo.Cursor = System.Windows.Forms.Cursors.Default;
            this.txtLoginInfo.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLoginInfo.Location = new System.Drawing.Point(213, 225);
            this.txtLoginInfo.Name = "txtLoginInfo";
            this.txtLoginInfo.ReadOnly = true;
            this.txtLoginInfo.Size = new System.Drawing.Size(448, 22);
            this.txtLoginInfo.TabIndex = 15;
            this.txtLoginInfo.Text = "Not logged in";
            this.txtLoginInfo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblSyncProfile
            // 
            this.lblSyncProfile.AutoSize = true;
            this.lblSyncProfile.Location = new System.Drawing.Point(9, 6);
            this.lblSyncProfile.Name = "lblSyncProfile";
            this.lblSyncProfile.Size = new System.Drawing.Size(158, 25);
            this.lblSyncProfile.TabIndex = 37;
            this.lblSyncProfile.Text = "Select Sync Profile:";
            // 
            // cmbSyncProfiles
            // 
            this.cmbSyncProfiles.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbSyncProfiles.FormattingEnabled = true;
            this.cmbSyncProfiles.Location = new System.Drawing.Point(10, 38);
            this.cmbSyncProfiles.MaximumSize = new System.Drawing.Size(769, 0);
            this.cmbSyncProfiles.Name = "cmbSyncProfiles";
            this.cmbSyncProfiles.Size = new System.Drawing.Size(530, 33);
            this.cmbSyncProfiles.TabIndex = 36;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 80);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(195, 25);
            this.label1.TabIndex = 38;
            this.label1.Text = "Watching Policy Folder:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 150);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(167, 25);
            this.label2.TabIndex = 39;
            this.label2.Text = "Watching UI Folder:";
            // 
            // txtPolicyFolder
            // 
            this.txtPolicyFolder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPolicyFolder.BackColor = System.Drawing.Color.PapayaWhip;
            this.txtPolicyFolder.Location = new System.Drawing.Point(10, 111);
            this.txtPolicyFolder.MaximumSize = new System.Drawing.Size(1537, 20);
            this.txtPolicyFolder.MinimumSize = new System.Drawing.Size(526, 20);
            this.txtPolicyFolder.Name = "txtPolicyFolder";
            this.txtPolicyFolder.ReadOnly = true;
            this.txtPolicyFolder.Size = new System.Drawing.Size(526, 31);
            this.txtPolicyFolder.TabIndex = 40;
            // 
            // txtUIFolder
            // 
            this.txtUIFolder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtUIFolder.BackColor = System.Drawing.Color.PapayaWhip;
            this.txtUIFolder.Location = new System.Drawing.Point(10, 183);
            this.txtUIFolder.MaximumSize = new System.Drawing.Size(1537, 20);
            this.txtUIFolder.MinimumSize = new System.Drawing.Size(526, 20);
            this.txtUIFolder.Name = "txtUIFolder";
            this.txtUIFolder.Size = new System.Drawing.Size(526, 31);
            this.txtUIFolder.TabIndex = 41;
            // 
            // btnTenantInit
            // 
            this.btnTenantInit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTenantInit.Enabled = false;
            this.btnTenantInit.Location = new System.Drawing.Point(551, 104);
            this.btnTenantInit.Name = "btnTenantInit";
            this.btnTenantInit.Size = new System.Drawing.Size(126, 39);
            this.btnTenantInit.TabIndex = 5;
            this.btnTenantInit.Text = "Init Tenant...";
            this.btnTenantInit.UseVisualStyleBackColor = true;
            this.btnTenantInit.Click += new System.EventHandler(this.btnTenantInit_Click);
            // 
            // txtTenantName
            // 
            this.txtTenantName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtTenantName.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTenantName.Location = new System.Drawing.Point(213, 250);
            this.txtTenantName.Name = "txtTenantName";
            this.txtTenantName.ReadOnly = true;
            this.txtTenantName.Size = new System.Drawing.Size(448, 22);
            this.txtTenantName.TabIndex = 42;
            this.txtTenantName.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(144F, 144F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(693, 756);
            this.Controls.Add(this.txtTenantName);
            this.Controls.Add(this.btnTenantInit);
            this.Controls.Add(this.txtUIFolder);
            this.Controls.Add(this.txtPolicyFolder);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblSyncProfile);
            this.Controls.Add(this.cmbSyncProfiles);
            this.Controls.Add(this.txtLoginInfo);
            this.Controls.Add(this.aniRunning);
            this.Controls.Add(this.btnClearLog);
            this.Controls.Add(this.btnAbout);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnQuit);
            this.Controls.Add(this.btnAppSettings);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.txtOperations);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(715, 727);
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Azure B2C Dev Sync";
            this.Load += new System.EventHandler(this.Main_Load);
            this.Resize += new System.EventHandler(this.Main_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.PolicyWatcher)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UIWatcher)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.aniRunning)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnAppSettings;
        private System.IO.FileSystemWatcher PolicyWatcher;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnQuit;
        private System.Windows.Forms.TextBox txtOperations;
        private System.Windows.Forms.Button btnAbout;
        private System.IO.FileSystemWatcher UIWatcher;
        private System.Windows.Forms.Button btnClearLog;
        private System.Windows.Forms.PictureBox aniRunning;
        private System.Windows.Forms.TextBox txtLoginInfo;
        private System.Windows.Forms.Label lblSyncProfile;
        private System.Windows.Forms.ComboBox cmbSyncProfiles;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPolicyFolder;
        private System.Windows.Forms.TextBox txtUIFolder;
        private System.Windows.Forms.Button btnTenantInit;
        private System.Windows.Forms.TextBox txtTenantName;
    }
}

