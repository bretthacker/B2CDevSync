namespace B2CDevSync
{
    partial class InitTenant
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InitTenant));
            this.btnGetStatus = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtSigningKey = new System.Windows.Forms.TextBox();
            this.btnCreateSigningKey = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtEncryptionKey = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnCreateEncKey = new System.Windows.Forms.Button();
            this.txtFacebookKey = new System.Windows.Forms.TextBox();
            this.btnCreateFBKey = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txtIEFApp = new System.Windows.Forms.TextBox();
            this.btnCreateIEFApp = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.txtIEFProxyApp = new System.Windows.Forms.TextBox();
            this.btnCreateIEFProxyApp = new System.Windows.Forms.Button();
            this.rdoLocal = new System.Windows.Forms.RadioButton();
            this.rdoSocial = new System.Windows.Forms.RadioButton();
            this.rdoSocialLocal = new System.Windows.Forms.RadioButton();
            this.rdoSocialLocalMFA = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtNewPolicyName = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.btnSetupPolicies = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.txtTestApplication = new System.Windows.Forms.TextBox();
            this.btnCreateTestApp = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lstPolicies = new System.Windows.Forms.ListBox();
            this.lstTenantApps = new System.Windows.Forms.ListBox();
            this.lstB2CApps = new System.Windows.Forms.ListBox();
            this.aniRunning = new System.Windows.Forms.PictureBox();
            this.txtTenantName = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.label13 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnOpenFolder = new System.Windows.Forms.Button();
            this.txtRepoStatus = new System.Windows.Forms.TextBox();
            this.lblDownloading = new System.Windows.Forms.Label();
            this.prgDownload = new System.Windows.Forms.ProgressBar();
            this.btnPullRepo = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.txtFacebookAppID = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.consentTestApp = new System.Windows.Forms.LinkLabel();
            this.consentIEF = new System.Windows.Forms.LinkLabel();
            this.consentIEFProxy = new System.Windows.Forms.LinkLabel();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.aniRunning)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnGetStatus
            // 
            this.btnGetStatus.Location = new System.Drawing.Point(16, 154);
            this.btnGetStatus.Name = "btnGetStatus";
            this.btnGetStatus.Size = new System.Drawing.Size(348, 45);
            this.btnGetStatus.TabIndex = 1;
            this.btnGetStatus.Text = "Reload Status";
            this.btnGetStatus.UseVisualStyleBackColor = true;
            this.btnGetStatus.Click += new System.EventHandler(this.btnGetStatus_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(388, 169);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(118, 25);
            this.label1.TabIndex = 2;
            this.label1.Text = "Signing Key";
            // 
            // txtSigningKey
            // 
            this.txtSigningKey.Location = new System.Drawing.Point(393, 198);
            this.txtSigningKey.Name = "txtSigningKey";
            this.txtSigningKey.Size = new System.Drawing.Size(612, 29);
            this.txtSigningKey.TabIndex = 3;
            // 
            // btnCreateSigningKey
            // 
            this.btnCreateSigningKey.Enabled = false;
            this.btnCreateSigningKey.Location = new System.Drawing.Point(1015, 195);
            this.btnCreateSigningKey.Name = "btnCreateSigningKey";
            this.btnCreateSigningKey.Size = new System.Drawing.Size(110, 41);
            this.btnCreateSigningKey.TabIndex = 4;
            this.btnCreateSigningKey.Text = "Create";
            this.btnCreateSigningKey.UseVisualStyleBackColor = true;
            this.btnCreateSigningKey.Click += new System.EventHandler(this.btnCreateSigningKey_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(388, 247);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(144, 25);
            this.label2.TabIndex = 5;
            this.label2.Text = "Encryption Key";
            // 
            // txtEncryptionKey
            // 
            this.txtEncryptionKey.Location = new System.Drawing.Point(393, 276);
            this.txtEncryptionKey.Name = "txtEncryptionKey";
            this.txtEncryptionKey.Size = new System.Drawing.Size(612, 29);
            this.txtEncryptionKey.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(757, 504);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(139, 25);
            this.label3.TabIndex = 7;
            this.label3.Text = "Facebook Key";
            // 
            // btnCreateEncKey
            // 
            this.btnCreateEncKey.Enabled = false;
            this.btnCreateEncKey.Location = new System.Drawing.Point(1015, 273);
            this.btnCreateEncKey.Name = "btnCreateEncKey";
            this.btnCreateEncKey.Size = new System.Drawing.Size(110, 41);
            this.btnCreateEncKey.TabIndex = 8;
            this.btnCreateEncKey.Text = "Create";
            this.btnCreateEncKey.UseVisualStyleBackColor = true;
            this.btnCreateEncKey.Click += new System.EventHandler(this.btnCreateEncKey_Click);
            // 
            // txtFacebookKey
            // 
            this.txtFacebookKey.Location = new System.Drawing.Point(761, 531);
            this.txtFacebookKey.Name = "txtFacebookKey";
            this.txtFacebookKey.Size = new System.Drawing.Size(244, 29);
            this.txtFacebookKey.TabIndex = 9;
            // 
            // btnCreateFBKey
            // 
            this.btnCreateFBKey.Enabled = false;
            this.btnCreateFBKey.Location = new System.Drawing.Point(1016, 527);
            this.btnCreateFBKey.Name = "btnCreateFBKey";
            this.btnCreateFBKey.Size = new System.Drawing.Size(110, 41);
            this.btnCreateFBKey.TabIndex = 10;
            this.btnCreateFBKey.Text = "Create";
            this.btnCreateFBKey.UseVisualStyleBackColor = true;
            this.btnCreateFBKey.Click += new System.EventHandler(this.btnCreateFBKey_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(388, 329);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(143, 25);
            this.label4.TabIndex = 11;
            this.label4.Text = "IEF Application";
            // 
            // txtIEFApp
            // 
            this.txtIEFApp.Location = new System.Drawing.Point(393, 358);
            this.txtIEFApp.Name = "txtIEFApp";
            this.txtIEFApp.Size = new System.Drawing.Size(612, 29);
            this.txtIEFApp.TabIndex = 12;
            // 
            // btnCreateIEFApp
            // 
            this.btnCreateIEFApp.Enabled = false;
            this.btnCreateIEFApp.Location = new System.Drawing.Point(1016, 353);
            this.btnCreateIEFApp.Name = "btnCreateIEFApp";
            this.btnCreateIEFApp.Size = new System.Drawing.Size(110, 41);
            this.btnCreateIEFApp.TabIndex = 13;
            this.btnCreateIEFApp.Text = "Create";
            this.btnCreateIEFApp.UseVisualStyleBackColor = true;
            this.btnCreateIEFApp.Click += new System.EventHandler(this.btnCreateIEFApp_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(388, 414);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(198, 25);
            this.label5.TabIndex = 14;
            this.label5.Text = "IEF Proxy Application";
            // 
            // txtIEFProxyApp
            // 
            this.txtIEFProxyApp.Location = new System.Drawing.Point(393, 443);
            this.txtIEFProxyApp.Name = "txtIEFProxyApp";
            this.txtIEFProxyApp.Size = new System.Drawing.Size(612, 29);
            this.txtIEFProxyApp.TabIndex = 15;
            // 
            // btnCreateIEFProxyApp
            // 
            this.btnCreateIEFProxyApp.Enabled = false;
            this.btnCreateIEFProxyApp.Location = new System.Drawing.Point(1016, 440);
            this.btnCreateIEFProxyApp.Name = "btnCreateIEFProxyApp";
            this.btnCreateIEFProxyApp.Size = new System.Drawing.Size(108, 38);
            this.btnCreateIEFProxyApp.TabIndex = 16;
            this.btnCreateIEFProxyApp.Text = "Create";
            this.btnCreateIEFProxyApp.UseVisualStyleBackColor = true;
            this.btnCreateIEFProxyApp.Click += new System.EventHandler(this.btnCreateIEFProxyApp_Click);
            // 
            // rdoLocal
            // 
            this.rdoLocal.AutoSize = true;
            this.rdoLocal.Location = new System.Drawing.Point(21, 45);
            this.rdoLocal.Name = "rdoLocal";
            this.rdoLocal.Size = new System.Drawing.Size(171, 29);
            this.rdoLocal.TabIndex = 17;
            this.rdoLocal.Text = "Local Accounts";
            this.rdoLocal.UseVisualStyleBackColor = true;
            this.rdoLocal.CheckedChanged += new System.EventHandler(this.rdoLocal_CheckedChanged);
            // 
            // rdoSocial
            // 
            this.rdoSocial.AutoSize = true;
            this.rdoSocial.Location = new System.Drawing.Point(21, 96);
            this.rdoSocial.Name = "rdoSocial";
            this.rdoSocial.Size = new System.Drawing.Size(178, 29);
            this.rdoSocial.TabIndex = 18;
            this.rdoSocial.Text = "Social Accounts";
            this.rdoSocial.UseVisualStyleBackColor = true;
            // 
            // rdoSocialLocal
            // 
            this.rdoSocialLocal.AutoSize = true;
            this.rdoSocialLocal.Checked = true;
            this.rdoSocialLocal.Location = new System.Drawing.Point(303, 45);
            this.rdoSocialLocal.Name = "rdoSocialLocal";
            this.rdoSocialLocal.Size = new System.Drawing.Size(271, 29);
            this.rdoSocialLocal.TabIndex = 19;
            this.rdoSocialLocal.TabStop = true;
            this.rdoSocialLocal.Text = "Social And Local Accounts";
            this.rdoSocialLocal.UseVisualStyleBackColor = true;
            // 
            // rdoSocialLocalMFA
            // 
            this.rdoSocialLocalMFA.AutoSize = true;
            this.rdoSocialLocalMFA.Location = new System.Drawing.Point(303, 96);
            this.rdoSocialLocalMFA.Name = "rdoSocialLocalMFA";
            this.rdoSocialLocalMFA.Size = new System.Drawing.Size(358, 29);
            this.rdoSocialLocalMFA.TabIndex = 20;
            this.rdoSocialLocalMFA.Text = "Social And Local Accounts with MFA";
            this.rdoSocialLocalMFA.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.txtNewPolicyName);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.btnSetupPolicies);
            this.groupBox1.Controls.Add(this.rdoLocal);
            this.groupBox1.Controls.Add(this.rdoSocialLocalMFA);
            this.groupBox1.Controls.Add(this.rdoSocial);
            this.groupBox1.Controls.Add(this.rdoSocialLocal);
            this.groupBox1.Location = new System.Drawing.Point(391, 733);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(717, 280);
            this.groupBox1.TabIndex = 21;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Selected Policy";
            // 
            // label11
            // 
            this.label11.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.label11.CausesValidation = false;
            this.label11.Location = new System.Drawing.Point(10, 175);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(94, 27);
            this.label11.TabIndex = 25;
            this.label11.Text = "B2C_1A_";
            // 
            // txtNewPolicyName
            // 
            this.txtNewPolicyName.Location = new System.Drawing.Point(112, 175);
            this.txtNewPolicyName.Name = "txtNewPolicyName";
            this.txtNewPolicyName.Size = new System.Drawing.Size(563, 29);
            this.txtNewPolicyName.TabIndex = 24;
            this.txtNewPolicyName.Text = "TrustFramework";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(19, 145);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(209, 25);
            this.label10.TabIndex = 23;
            this.label10.Text = "Policy Name to Upload";
            // 
            // btnSetupPolicies
            // 
            this.btnSetupPolicies.Enabled = false;
            this.btnSetupPolicies.Location = new System.Drawing.Point(16, 220);
            this.btnSetupPolicies.Name = "btnSetupPolicies";
            this.btnSetupPolicies.Size = new System.Drawing.Size(122, 40);
            this.btnSetupPolicies.TabIndex = 22;
            this.btnSetupPolicies.Text = "Create";
            this.btnSetupPolicies.UseVisualStyleBackColor = true;
            this.btnSetupPolicies.Click += new System.EventHandler(this.btnSetupPolicies_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(388, 90);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(152, 25);
            this.label6.TabIndex = 22;
            this.label6.Text = "Test Application";
            // 
            // txtTestApplication
            // 
            this.txtTestApplication.Location = new System.Drawing.Point(393, 119);
            this.txtTestApplication.Name = "txtTestApplication";
            this.txtTestApplication.Size = new System.Drawing.Size(612, 29);
            this.txtTestApplication.TabIndex = 23;
            // 
            // btnCreateTestApp
            // 
            this.btnCreateTestApp.Enabled = false;
            this.btnCreateTestApp.Location = new System.Drawing.Point(1015, 114);
            this.btnCreateTestApp.Name = "btnCreateTestApp";
            this.btnCreateTestApp.Size = new System.Drawing.Size(110, 41);
            this.btnCreateTestApp.TabIndex = 24;
            this.btnCreateTestApp.Text = "Create";
            this.btnCreateTestApp.UseVisualStyleBackColor = true;
            this.btnCreateTestApp.Click += new System.EventHandler(this.btnCreateTestApp_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(950, 1025);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(159, 45);
            this.btnClose.TabIndex = 25;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(10, 208);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(184, 25);
            this.label7.TabIndex = 27;
            this.label7.Text = "Current IEF Policies";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(10, 510);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(125, 25);
            this.label8.TabIndex = 28;
            this.label8.Text = "Tenant Apps";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(10, 790);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(102, 25);
            this.label9.TabIndex = 30;
            this.label9.Text = "B2C Apps";
            // 
            // lstPolicies
            // 
            this.lstPolicies.FormattingEnabled = true;
            this.lstPolicies.ItemHeight = 24;
            this.lstPolicies.Location = new System.Drawing.Point(16, 234);
            this.lstPolicies.Name = "lstPolicies";
            this.lstPolicies.Size = new System.Drawing.Size(349, 244);
            this.lstPolicies.TabIndex = 32;
            // 
            // lstTenantApps
            // 
            this.lstTenantApps.FormattingEnabled = true;
            this.lstTenantApps.ItemHeight = 24;
            this.lstTenantApps.Location = new System.Drawing.Point(15, 535);
            this.lstTenantApps.Name = "lstTenantApps";
            this.lstTenantApps.Size = new System.Drawing.Size(349, 220);
            this.lstTenantApps.TabIndex = 33;
            // 
            // lstB2CApps
            // 
            this.lstB2CApps.FormattingEnabled = true;
            this.lstB2CApps.ItemHeight = 24;
            this.lstB2CApps.Location = new System.Drawing.Point(16, 817);
            this.lstB2CApps.Name = "lstB2CApps";
            this.lstB2CApps.Size = new System.Drawing.Size(348, 172);
            this.lstB2CApps.TabIndex = 34;
            // 
            // aniRunning
            // 
            this.aniRunning.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.aniRunning.Image = ((System.Drawing.Image)(resources.GetObject("aniRunning.Image")));
            this.aniRunning.Location = new System.Drawing.Point(1036, 9);
            this.aniRunning.Name = "aniRunning";
            this.aniRunning.Size = new System.Drawing.Size(87, 87);
            this.aniRunning.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.aniRunning.TabIndex = 35;
            this.aniRunning.TabStop = false;
            this.aniRunning.Visible = false;
            // 
            // txtTenantName
            // 
            this.txtTenantName.Location = new System.Drawing.Point(16, 115);
            this.txtTenantName.Name = "txtTenantName";
            this.txtTenantName.ReadOnly = true;
            this.txtTenantName.Size = new System.Drawing.Size(348, 29);
            this.txtTenantName.TabIndex = 36;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(8, 87);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(131, 25);
            this.label14.TabIndex = 37;
            this.label14.Text = "Tenant Name";
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(14, 35);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(874, 25);
            this.linkLabel1.TabIndex = 38;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "https://docs.microsoft.com/en-us/azure/active-directory-b2c/active-directory-b2c-" +
    "get-started-custom";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(13, 9);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(538, 25);
            this.label13.TabIndex = 39;
            this.label13.Text = "This will initialize your B2C tenant using the documentation at";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnOpenFolder);
            this.groupBox2.Controls.Add(this.txtRepoStatus);
            this.groupBox2.Controls.Add(this.lblDownloading);
            this.groupBox2.Controls.Add(this.prgDownload);
            this.groupBox2.Controls.Add(this.btnPullRepo);
            this.groupBox2.Location = new System.Drawing.Point(392, 583);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(717, 131);
            this.groupBox2.TabIndex = 40;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Repo Status";
            // 
            // btnOpenFolder
            // 
            this.btnOpenFolder.Location = new System.Drawing.Point(547, 33);
            this.btnOpenFolder.Name = "btnOpenFolder";
            this.btnOpenFolder.Size = new System.Drawing.Size(150, 38);
            this.btnOpenFolder.TabIndex = 41;
            this.btnOpenFolder.Text = "Open Folder...";
            this.btnOpenFolder.UseVisualStyleBackColor = true;
            this.btnOpenFolder.Click += new System.EventHandler(this.btnOpenFolder_Click);
            // 
            // txtRepoStatus
            // 
            this.txtRepoStatus.Location = new System.Drawing.Point(24, 35);
            this.txtRepoStatus.Name = "txtRepoStatus";
            this.txtRepoStatus.Size = new System.Drawing.Size(517, 29);
            this.txtRepoStatus.TabIndex = 35;
            // 
            // lblDownloading
            // 
            this.lblDownloading.AutoSize = true;
            this.lblDownloading.Location = new System.Drawing.Point(182, 78);
            this.lblDownloading.Name = "lblDownloading";
            this.lblDownloading.Size = new System.Drawing.Size(140, 25);
            this.lblDownloading.TabIndex = 34;
            this.lblDownloading.Text = "Downloading...";
            this.lblDownloading.Visible = false;
            // 
            // prgDownload
            // 
            this.prgDownload.Location = new System.Drawing.Point(187, 106);
            this.prgDownload.Name = "prgDownload";
            this.prgDownload.Size = new System.Drawing.Size(353, 10);
            this.prgDownload.TabIndex = 33;
            this.prgDownload.Visible = false;
            // 
            // btnPullRepo
            // 
            this.btnPullRepo.Location = new System.Drawing.Point(24, 79);
            this.btnPullRepo.Name = "btnPullRepo";
            this.btnPullRepo.Size = new System.Drawing.Size(122, 40);
            this.btnPullRepo.TabIndex = 32;
            this.btnPullRepo.Text = "Pull Repo";
            this.btnPullRepo.UseVisualStyleBackColor = true;
            this.btnPullRepo.Click += new System.EventHandler(this.btnPullRepo_Click_1);
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(28, 28);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 1108);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.statusStrip1.Size = new System.Drawing.Size(1136, 22);
            this.statusStrip1.TabIndex = 41;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(0, 13);
            // 
            // txtFacebookAppID
            // 
            this.txtFacebookAppID.Location = new System.Drawing.Point(393, 531);
            this.txtFacebookAppID.Name = "txtFacebookAppID";
            this.txtFacebookAppID.Size = new System.Drawing.Size(336, 29);
            this.txtFacebookAppID.TabIndex = 42;
            this.txtFacebookAppID.Leave += new System.EventHandler(this.txtFacebookAppID_Leave);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(388, 502);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(159, 25);
            this.label12.TabIndex = 43;
            this.label12.Text = "Facebook AppID";
            // 
            // consentTestApp
            // 
            this.consentTestApp.AutoSize = true;
            this.consentTestApp.Location = new System.Drawing.Point(833, 88);
            this.consentTestApp.Name = "consentTestApp";
            this.consentTestApp.Size = new System.Drawing.Size(101, 25);
            this.consentTestApp.TabIndex = 44;
            this.consentTestApp.TabStop = true;
            this.consentTestApp.Text = "Consent...";
            this.consentTestApp.Visible = false;
            this.consentTestApp.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.consentTestApp_LinkClicked);
            // 
            // consentIEF
            // 
            this.consentIEF.AutoSize = true;
            this.consentIEF.Location = new System.Drawing.Point(833, 329);
            this.consentIEF.Name = "consentIEF";
            this.consentIEF.Size = new System.Drawing.Size(101, 25);
            this.consentIEF.TabIndex = 45;
            this.consentIEF.TabStop = true;
            this.consentIEF.Text = "Consent...";
            this.consentIEF.Visible = false;
            this.consentIEF.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.consentIEF_LinkClicked);
            // 
            // consentIEFProxy
            // 
            this.consentIEFProxy.AutoSize = true;
            this.consentIEFProxy.Location = new System.Drawing.Point(833, 414);
            this.consentIEFProxy.Name = "consentIEFProxy";
            this.consentIEFProxy.Size = new System.Drawing.Size(101, 25);
            this.consentIEFProxy.TabIndex = 46;
            this.consentIEFProxy.TabStop = true;
            this.consentIEFProxy.Text = "Consent...";
            this.consentIEFProxy.Visible = false;
            this.consentIEFProxy.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.consentIEFProxy_LinkClicked);
            // 
            // InitTenant
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(168F, 168F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1136, 1130);
            this.Controls.Add(this.consentIEFProxy);
            this.Controls.Add(this.consentIEF);
            this.Controls.Add(this.consentTestApp);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.txtFacebookAppID);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.txtTenantName);
            this.Controls.Add(this.aniRunning);
            this.Controls.Add(this.lstB2CApps);
            this.Controls.Add(this.lstTenantApps);
            this.Controls.Add(this.lstPolicies);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnCreateTestApp);
            this.Controls.Add(this.txtTestApplication);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnCreateIEFProxyApp);
            this.Controls.Add(this.txtIEFProxyApp);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnCreateIEFApp);
            this.Controls.Add(this.txtIEFApp);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnCreateFBKey);
            this.Controls.Add(this.txtFacebookKey);
            this.Controls.Add(this.btnCreateEncKey);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtEncryptionKey);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnCreateSigningKey);
            this.Controls.Add(this.txtSigningKey);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnGetStatus);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "InitTenant";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Initialize IEF for Tenant";
            this.Load += new System.EventHandler(this.InitTenant_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.aniRunning)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnGetStatus;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSigningKey;
        private System.Windows.Forms.Button btnCreateSigningKey;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtEncryptionKey;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnCreateEncKey;
        private System.Windows.Forms.TextBox txtFacebookKey;
        private System.Windows.Forms.Button btnCreateFBKey;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtIEFApp;
        private System.Windows.Forms.Button btnCreateIEFApp;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtIEFProxyApp;
        private System.Windows.Forms.Button btnCreateIEFProxyApp;
        private System.Windows.Forms.RadioButton rdoLocal;
        private System.Windows.Forms.RadioButton rdoSocial;
        private System.Windows.Forms.RadioButton rdoSocialLocal;
        private System.Windows.Forms.RadioButton rdoSocialLocalMFA;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnSetupPolicies;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtTestApplication;
        private System.Windows.Forms.Button btnCreateTestApp;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ListBox lstPolicies;
        private System.Windows.Forms.ListBox lstTenantApps;
        private System.Windows.Forms.ListBox lstB2CApps;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtNewPolicyName;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.PictureBox aniRunning;
        private System.Windows.Forms.TextBox txtTenantName;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtRepoStatus;
        private System.Windows.Forms.Label lblDownloading;
        private System.Windows.Forms.ProgressBar prgDownload;
        private System.Windows.Forms.Button btnPullRepo;
        private System.Windows.Forms.Button btnOpenFolder;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.TextBox txtFacebookAppID;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.LinkLabel consentTestApp;
        private System.Windows.Forms.LinkLabel consentIEF;
        private System.Windows.Forms.LinkLabel consentIEFProxy;
    }
}