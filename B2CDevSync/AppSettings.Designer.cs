namespace B2CDevSync
{
    partial class AppSettings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AppSettings));
            this.btnCancel = new System.Windows.Forms.Button();
            this.txtTenantID = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtSyncAppID = new System.Windows.Forms.TextBox();
            this.txtAuthority = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtB2BApi = new System.Windows.Forms.TextBox();
            this.txtRedirectUri = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.cmdPopupDuration = new System.Windows.Forms.ComboBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.btnAddProfile = new System.Windows.Forms.Button();
            this.pnlProfile = new System.Windows.Forms.Panel();
            this.btnProfileCancel = new System.Windows.Forms.Button();
            this.btnProfileDelete = new System.Windows.Forms.Button();
            this.btnProfileSave = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.chkUIRecursive = new System.Windows.Forms.CheckBox();
            this.chkSyncAzureStorage = new System.Windows.Forms.CheckBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtUIFolderPath = new System.Windows.Forms.TextBox();
            this.btnUIFolder = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtStorageConnectionString = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtStorageContainer = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtPolicyFolderPath = new System.Windows.Forms.TextBox();
            this.btnPolicyFolder = new System.Windows.Forms.Button();
            this.chkSyncB2CPolicies = new System.Windows.Forms.CheckBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.txtSyncProfileName = new System.Windows.Forms.TextBox();
            this.lblSyncProfile = new System.Windows.Forms.Label();
            this.cmbSyncProfiles = new System.Windows.Forms.ComboBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.chkShowAlerts = new System.Windows.Forms.CheckBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.lblSaved = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.pnlProfile.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Location = new System.Drawing.Point(351, 421);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(1);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(130, 27);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Close";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // txtTenantID
            // 
            this.txtTenantID.Location = new System.Drawing.Point(11, 71);
            this.txtTenantID.Margin = new System.Windows.Forms.Padding(1);
            this.txtTenantID.Name = "txtTenantID";
            this.txtTenantID.Size = new System.Drawing.Size(411, 23);
            this.txtTenantID.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 54);
            this.label1.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(235, 15);
            this.label1.TabIndex = 3;
            this.label1.Text = "B2C tenant (like contoso.onmicrosoft.com)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 96);
            this.label2.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 15);
            this.label2.TabIndex = 4;
            this.label2.Text = "Sync app ID";
            // 
            // txtSyncAppID
            // 
            this.txtSyncAppID.Location = new System.Drawing.Point(11, 113);
            this.txtSyncAppID.Margin = new System.Windows.Forms.Padding(1);
            this.txtSyncAppID.Name = "txtSyncAppID";
            this.txtSyncAppID.Size = new System.Drawing.Size(232, 23);
            this.txtSyncAppID.TabIndex = 5;
            // 
            // txtAuthority
            // 
            this.txtAuthority.Location = new System.Drawing.Point(11, 25);
            this.txtAuthority.Margin = new System.Windows.Forms.Padding(1);
            this.txtAuthority.Name = "txtAuthority";
            this.txtAuthority.Size = new System.Drawing.Size(411, 23);
            this.txtAuthority.TabIndex = 9;
            this.txtAuthority.Text = "https://login.microsoftonline.com/{0}";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 8);
            this.label4.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(107, 15);
            this.label4.TabIndex = 10;
            this.label4.Text = "Azure AD authority";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(7, 144);
            this.label6.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(150, 15);
            this.label6.TabIndex = 15;
            this.label6.Text = "B2C Management Base URI";
            // 
            // txtB2BApi
            // 
            this.txtB2BApi.Location = new System.Drawing.Point(10, 161);
            this.txtB2BApi.Margin = new System.Windows.Forms.Padding(1);
            this.txtB2BApi.Name = "txtB2BApi";
            this.txtB2BApi.Size = new System.Drawing.Size(411, 23);
            this.txtB2BApi.TabIndex = 14;
            this.txtB2BApi.Text = "https://graph.microsoft.com/beta/trustFramework/policies/{0}";
            // 
            // txtRedirectUri
            // 
            this.txtRedirectUri.Location = new System.Drawing.Point(249, 113);
            this.txtRedirectUri.Margin = new System.Windows.Forms.Padding(1);
            this.txtRedirectUri.Name = "txtRedirectUri";
            this.txtRedirectUri.Size = new System.Drawing.Size(172, 23);
            this.txtRedirectUri.TabIndex = 17;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(247, 97);
            this.label7.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(68, 15);
            this.label7.TabIndex = 16;
            this.label7.Text = "Redirect Uri";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(9, 193);
            this.label8.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(174, 15);
            this.label8.TabIndex = 19;
            this.label8.Text = "Popup Duration (0 is no popup)";
            // 
            // cmdPopupDuration
            // 
            this.cmdPopupDuration.FormattingEnabled = true;
            this.cmdPopupDuration.Items.AddRange(new object[] {
            "2 seconds",
            "3 seconds",
            "4 seconds",
            "5 seconds",
            "0 (no popup)"});
            this.cmdPopupDuration.Location = new System.Drawing.Point(9, 210);
            this.cmdPopupDuration.Margin = new System.Windows.Forms.Padding(1);
            this.cmdPopupDuration.Name = "cmdPopupDuration";
            this.cmdPopupDuration.Size = new System.Drawing.Size(93, 23);
            this.cmdPopupDuration.TabIndex = 20;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(7, 6);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(1);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(477, 407);
            this.tabControl1.TabIndex = 33;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.btnAddProfile);
            this.tabPage1.Controls.Add(this.pnlProfile);
            this.tabPage1.Controls.Add(this.lblSyncProfile);
            this.tabPage1.Controls.Add(this.cmbSyncProfiles);
            this.tabPage1.Location = new System.Drawing.Point(4, 24);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(1);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(1);
            this.tabPage1.Size = new System.Drawing.Size(469, 379);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Policies";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // btnAddProfile
            // 
            this.btnAddProfile.Location = new System.Drawing.Point(334, 27);
            this.btnAddProfile.Margin = new System.Windows.Forms.Padding(1);
            this.btnAddProfile.Name = "btnAddProfile";
            this.btnAddProfile.Size = new System.Drawing.Size(79, 25);
            this.btnAddProfile.TabIndex = 37;
            this.btnAddProfile.Text = "Add Profile";
            this.btnAddProfile.UseVisualStyleBackColor = true;
            this.btnAddProfile.Click += new System.EventHandler(this.btnAddProfile_Click);
            // 
            // pnlProfile
            // 
            this.pnlProfile.BackColor = System.Drawing.Color.PapayaWhip;
            this.pnlProfile.Controls.Add(this.btnProfileCancel);
            this.pnlProfile.Controls.Add(this.btnProfileDelete);
            this.pnlProfile.Controls.Add(this.btnProfileSave);
            this.pnlProfile.Controls.Add(this.groupBox2);
            this.pnlProfile.Controls.Add(this.groupBox1);
            this.pnlProfile.Controls.Add(this.label11);
            this.pnlProfile.Controls.Add(this.txtSyncProfileName);
            this.pnlProfile.Location = new System.Drawing.Point(7, 55);
            this.pnlProfile.Margin = new System.Windows.Forms.Padding(1);
            this.pnlProfile.Name = "pnlProfile";
            this.pnlProfile.Size = new System.Drawing.Size(451, 317);
            this.pnlProfile.TabIndex = 36;
            // 
            // btnProfileCancel
            // 
            this.btnProfileCancel.Location = new System.Drawing.Point(288, 283);
            this.btnProfileCancel.Margin = new System.Windows.Forms.Padding(1);
            this.btnProfileCancel.Name = "btnProfileCancel";
            this.btnProfileCancel.Size = new System.Drawing.Size(108, 25);
            this.btnProfileCancel.TabIndex = 40;
            this.btnProfileCancel.Text = "Cancel";
            this.btnProfileCancel.UseVisualStyleBackColor = true;
            this.btnProfileCancel.Click += new System.EventHandler(this.btnProfileCancel_Click);
            // 
            // btnProfileDelete
            // 
            this.btnProfileDelete.Location = new System.Drawing.Point(170, 283);
            this.btnProfileDelete.Margin = new System.Windows.Forms.Padding(1);
            this.btnProfileDelete.Name = "btnProfileDelete";
            this.btnProfileDelete.Size = new System.Drawing.Size(108, 25);
            this.btnProfileDelete.TabIndex = 39;
            this.btnProfileDelete.Text = "Delete";
            this.btnProfileDelete.UseVisualStyleBackColor = true;
            this.btnProfileDelete.Click += new System.EventHandler(this.btnProfileDelete_Click);
            // 
            // btnProfileSave
            // 
            this.btnProfileSave.Location = new System.Drawing.Point(52, 283);
            this.btnProfileSave.Margin = new System.Windows.Forms.Padding(1);
            this.btnProfileSave.Name = "btnProfileSave";
            this.btnProfileSave.Size = new System.Drawing.Size(108, 25);
            this.btnProfileSave.TabIndex = 38;
            this.btnProfileSave.Text = "Save";
            this.btnProfileSave.UseVisualStyleBackColor = true;
            this.btnProfileSave.Click += new System.EventHandler(this.btnProfileSave_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Controls.Add(this.chkUIRecursive);
            this.groupBox2.Controls.Add(this.chkSyncAzureStorage);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.txtUIFolderPath);
            this.groupBox2.Controls.Add(this.btnUIFolder);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.txtStorageConnectionString);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.txtStorageContainer);
            this.groupBox2.Location = new System.Drawing.Point(9, 137);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(1);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(1);
            this.groupBox2.Size = new System.Drawing.Size(433, 137);
            this.groupBox2.TabIndex = 37;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Storage/UI";
            // 
            // chkUIRecursive
            // 
            this.chkUIRecursive.AutoSize = true;
            this.chkUIRecursive.Checked = true;
            this.chkUIRecursive.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkUIRecursive.Location = new System.Drawing.Point(345, 39);
            this.chkUIRecursive.Margin = new System.Windows.Forms.Padding(1);
            this.chkUIRecursive.Name = "chkUIRecursive";
            this.chkUIRecursive.Size = new System.Drawing.Size(81, 19);
            this.chkUIRecursive.TabIndex = 28;
            this.chkUIRecursive.Text = "Recursive?";
            this.chkUIRecursive.UseVisualStyleBackColor = true;
            // 
            // chkSyncAzureStorage
            // 
            this.chkSyncAzureStorage.AutoSize = true;
            this.chkSyncAzureStorage.Checked = true;
            this.chkSyncAzureStorage.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkSyncAzureStorage.Location = new System.Drawing.Point(15, 19);
            this.chkSyncAzureStorage.Margin = new System.Windows.Forms.Padding(1);
            this.chkSyncAzureStorage.Name = "chkSyncAzureStorage";
            this.chkSyncAzureStorage.Size = new System.Drawing.Size(132, 19);
            this.chkSyncAzureStorage.TabIndex = 27;
            this.chkSyncAzureStorage.Text = "Sync Azure Storage?";
            this.chkSyncAzureStorage.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(13, 43);
            this.label9.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(149, 15);
            this.label9.TabIndex = 24;
            this.label9.Text = "Custom UI folder to watch:";
            // 
            // txtUIFolderPath
            // 
            this.txtUIFolderPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtUIFolderPath.Location = new System.Drawing.Point(15, 61);
            this.txtUIFolderPath.Margin = new System.Windows.Forms.Padding(1);
            this.txtUIFolderPath.Name = "txtUIFolderPath";
            this.txtUIFolderPath.Size = new System.Drawing.Size(373, 23);
            this.txtUIFolderPath.TabIndex = 22;
            // 
            // btnUIFolder
            // 
            this.btnUIFolder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUIFolder.Location = new System.Drawing.Point(389, 61);
            this.btnUIFolder.Margin = new System.Windows.Forms.Padding(1);
            this.btnUIFolder.Name = "btnUIFolder";
            this.btnUIFolder.Size = new System.Drawing.Size(25, 25);
            this.btnUIFolder.TabIndex = 26;
            this.btnUIFolder.Text = "...";
            this.btnUIFolder.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnUIFolder.UseVisualStyleBackColor = true;
            this.btnUIFolder.Click += new System.EventHandler(this.btnUIFolder_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 89);
            this.label3.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(143, 15);
            this.label3.TabIndex = 8;
            this.label3.Text = "Storage connection string";
            // 
            // txtStorageConnectionString
            // 
            this.txtStorageConnectionString.Location = new System.Drawing.Point(15, 107);
            this.txtStorageConnectionString.Margin = new System.Windows.Forms.Padding(1);
            this.txtStorageConnectionString.Name = "txtStorageConnectionString";
            this.txtStorageConnectionString.Size = new System.Drawing.Size(298, 23);
            this.txtStorageConnectionString.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(314, 89);
            this.label5.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(92, 15);
            this.label5.TabIndex = 12;
            this.label5.Text = "Container name";
            // 
            // txtStorageContainer
            // 
            this.txtStorageContainer.Location = new System.Drawing.Point(317, 107);
            this.txtStorageContainer.Margin = new System.Windows.Forms.Padding(1);
            this.txtStorageContainer.Name = "txtStorageContainer";
            this.txtStorageContainer.Size = new System.Drawing.Size(109, 23);
            this.txtStorageContainer.TabIndex = 11;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.txtPolicyFolderPath);
            this.groupBox1.Controls.Add(this.btnPolicyFolder);
            this.groupBox1.Controls.Add(this.chkSyncB2CPolicies);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Location = new System.Drawing.Point(9, 45);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(1);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(1);
            this.groupBox1.Size = new System.Drawing.Size(432, 88);
            this.groupBox1.TabIndex = 34;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Policies";
            // 
            // txtPolicyFolderPath
            // 
            this.txtPolicyFolderPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPolicyFolderPath.Location = new System.Drawing.Point(15, 57);
            this.txtPolicyFolderPath.Margin = new System.Windows.Forms.Padding(1);
            this.txtPolicyFolderPath.Name = "txtPolicyFolderPath";
            this.txtPolicyFolderPath.Size = new System.Drawing.Size(371, 23);
            this.txtPolicyFolderPath.TabIndex = 21;
            // 
            // btnPolicyFolder
            // 
            this.btnPolicyFolder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPolicyFolder.Location = new System.Drawing.Point(388, 57);
            this.btnPolicyFolder.Margin = new System.Windows.Forms.Padding(1);
            this.btnPolicyFolder.Name = "btnPolicyFolder";
            this.btnPolicyFolder.Size = new System.Drawing.Size(25, 25);
            this.btnPolicyFolder.TabIndex = 25;
            this.btnPolicyFolder.Text = "...";
            this.btnPolicyFolder.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnPolicyFolder.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnPolicyFolder.UseVisualStyleBackColor = true;
            this.btnPolicyFolder.Click += new System.EventHandler(this.btnPolicyFolder_Click);
            // 
            // chkSyncB2CPolicies
            // 
            this.chkSyncB2CPolicies.AutoSize = true;
            this.chkSyncB2CPolicies.Checked = true;
            this.chkSyncB2CPolicies.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkSyncB2CPolicies.Location = new System.Drawing.Point(15, 19);
            this.chkSyncB2CPolicies.Margin = new System.Windows.Forms.Padding(1);
            this.chkSyncB2CPolicies.Name = "chkSyncB2CPolicies";
            this.chkSyncB2CPolicies.Size = new System.Drawing.Size(123, 19);
            this.chkSyncB2CPolicies.TabIndex = 28;
            this.chkSyncB2CPolicies.Text = "Sync B2C Policies?";
            this.chkSyncB2CPolicies.UseVisualStyleBackColor = true;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(13, 39);
            this.label10.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(125, 15);
            this.label10.TabIndex = 23;
            this.label10.Text = "Policy folder to watch:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(7, 3);
            this.label11.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(104, 15);
            this.label11.TabIndex = 36;
            this.label11.Text = "Sync Profile Name";
            // 
            // txtSyncProfileName
            // 
            this.txtSyncProfileName.Location = new System.Drawing.Point(9, 21);
            this.txtSyncProfileName.Margin = new System.Windows.Forms.Padding(1);
            this.txtSyncProfileName.Name = "txtSyncProfileName";
            this.txtSyncProfileName.Size = new System.Drawing.Size(317, 23);
            this.txtSyncProfileName.TabIndex = 35;
            // 
            // lblSyncProfile
            // 
            this.lblSyncProfile.AutoSize = true;
            this.lblSyncProfile.Location = new System.Drawing.Point(5, 7);
            this.lblSyncProfile.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.lblSyncProfile.Name = "lblSyncProfile";
            this.lblSyncProfile.Size = new System.Drawing.Size(106, 15);
            this.lblSyncProfile.TabIndex = 35;
            this.lblSyncProfile.Text = "Select Sync Profile:";
            // 
            // cmbSyncProfiles
            // 
            this.cmbSyncProfiles.FormattingEnabled = true;
            this.cmbSyncProfiles.Location = new System.Drawing.Point(5, 27);
            this.cmbSyncProfiles.Margin = new System.Windows.Forms.Padding(1);
            this.cmbSyncProfiles.Name = "cmbSyncProfiles";
            this.cmbSyncProfiles.Size = new System.Drawing.Size(320, 23);
            this.cmbSyncProfiles.TabIndex = 34;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.chkShowAlerts);
            this.tabPage2.Controls.Add(this.btnSave);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.txtAuthority);
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Controls.Add(this.cmdPopupDuration);
            this.tabPage2.Controls.Add(this.txtTenantID);
            this.tabPage2.Controls.Add(this.label8);
            this.tabPage2.Controls.Add(this.txtRedirectUri);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Controls.Add(this.label7);
            this.tabPage2.Controls.Add(this.txtSyncAppID);
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Controls.Add(this.txtB2BApi);
            this.tabPage2.Location = new System.Drawing.Point(4, 24);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(1);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(1);
            this.tabPage2.Size = new System.Drawing.Size(469, 379);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Application";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // chkShowAlerts
            // 
            this.chkShowAlerts.AutoSize = true;
            this.chkShowAlerts.Checked = true;
            this.chkShowAlerts.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkShowAlerts.Location = new System.Drawing.Point(249, 212);
            this.chkShowAlerts.Name = "chkShowAlerts";
            this.chkShowAlerts.Size = new System.Drawing.Size(148, 19);
            this.chkShowAlerts.TabIndex = 22;
            this.chkShowAlerts.Text = "Show popups on error?";
            this.chkShowAlerts.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Location = new System.Drawing.Point(9, 254);
            this.btnSave.Margin = new System.Windows.Forms.Padding(1);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(130, 27);
            this.btnSave.TabIndex = 21;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lblSaved
            // 
            this.lblSaved.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblSaved.Location = new System.Drawing.Point(9, 421);
            this.lblSaved.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.lblSaved.Name = "lblSaved";
            this.lblSaved.Size = new System.Drawing.Size(323, 25);
            this.lblSaved.TabIndex = 34;
            // 
            // AppSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(491, 454);
            this.Controls.Add(this.lblSaved);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.btnCancel);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AppSettings";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "B2C Dev Sync Settings";
            this.Load += new System.EventHandler(this.Settings_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.pnlProfile.ResumeLayout(false);
            this.pnlProfile.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TextBox txtTenantID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtSyncAppID;
        private System.Windows.Forms.TextBox txtAuthority;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtB2BApi;
        private System.Windows.Forms.TextBox txtRedirectUri;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cmdPopupDuration;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label lblSyncProfile;
        private System.Windows.Forms.ComboBox cmbSyncProfiles;
        private System.Windows.Forms.Panel pnlProfile;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox chkSyncAzureStorage;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtUIFolderPath;
        private System.Windows.Forms.Button btnUIFolder;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtStorageConnectionString;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtStorageContainer;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtPolicyFolderPath;
        private System.Windows.Forms.Button btnPolicyFolder;
        private System.Windows.Forms.CheckBox chkSyncB2CPolicies;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtSyncProfileName;
        private System.Windows.Forms.Button btnAddProfile;
        private System.Windows.Forms.Button btnProfileDelete;
        private System.Windows.Forms.Button btnProfileSave;
        private System.Windows.Forms.Button btnProfileCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.CheckBox chkUIRecursive;
        private System.Windows.Forms.Label lblSaved;
        private System.Windows.Forms.CheckBox chkShowAlerts;
    }
}