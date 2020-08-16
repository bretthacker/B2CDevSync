using B2CDevSync.Models;
using B2CDevSync.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace B2CDevSync
{
    public partial class AppSettings : Form
    {
        private Properties.Settings _settings;
        private Main _parent;
        private bool _isDirty;

        public AppSettings(Main parent)
        {
            InitializeComponent();
            _parent = parent;
            _settings = Properties.Settings.Default;
        }
        private void Settings_Load(object sender, EventArgs e)
        {
            if (_settings.Configured && _settings.SyncProfiles.Profiles.Count == 0)
            {
                _settings.Configured = false;
                _settings.Save();
            }
            txtAuthority.Text = _settings.AADAuthority;
            txtTenantID.Text = _settings.B2CTenant;
            txtSyncAppID.Text = _settings.SyncAppId;
            txtB2BApi.Text = _settings.B2BApi;
            txtRedirectUri.Text = _settings.RedirectUri;
            cmdPopupDuration.SelectedIndex = _settings.PopupDuration=="" ? 3 : Convert.ToInt16(_settings.PopupDuration);
            cmbSyncProfiles.SelectedIndexChanged += CmbSyncProfiles_SelectedIndexChanged;
            LoadProfilePicker();
        }

        private void Notify(string msg)
        {
            lblSaved.Text = msg;

            var task = Task.Run(() =>
            {
                Thread.Sleep(3000);
                Invoke(new Action(() =>
                {
                    lblSaved.Text = "";
                }));
            });
        }

        private void LoadProfilePicker()
        {
            cmbSyncProfiles.Items.Clear();
            cmbSyncProfiles.Items.Add("Load Profile...");
            cmbSyncProfiles.Items.AddRange(_settings.SyncProfiles.Profiles.Select(p => p.SyncProfileName).ToArray<object>());
            cmbSyncProfiles.SelectedIndex = 0;
        }

        private void CmbSyncProfiles_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cmbSyncProfiles.SelectedItem.ToString())
            {
                case "Load Profile...":
                    break;
                default:
                    LoadSyncProfile(cmbSyncProfiles.SelectedItem.ToString());
                    break;
            }
        }

        private bool PromptToSave()
        {
            if (!_isDirty)
                return true;

            DialogResult res = MessageBox.Show("Save changes?", "Editing Policy", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            if (res == DialogResult.Cancel)
                return false;
            if (res == DialogResult.Yes)
            {
                SaveSyncProfile();
                Notify("Saved");
             }
            return true;
        }

        private void LoadSyncProfile(string profileName)
        {
            if (!PromptToSave())
                return;

            ClearProfileForm();
            var profile = _settings.SyncProfiles.Profiles.SingleOrDefault(p => p.SyncProfileName == profileName);
            if (profile == null)
            {
                throw new Exception("A profile wasn't found in the collection, although it was listed in the selection box.");
            }

            txtStorageConnectionString.Text = profile.StorageConnectionString;
            txtStorageContainer.Text = profile.StorageContainerName;
            txtPolicyFolderPath.Text = profile.PolicyPath;
            txtUIFolderPath.Text = profile.UIPath;
            chkUIRecursive.Checked = profile.SyncRecursive;
            chkSyncB2CPolicies.Checked = profile.SyncPolicyBool;
            chkSyncAzureStorage.Checked = profile.SyncStorageBool;
            txtSyncProfileName.Text = profile.SyncProfileName;
        }

        private void SetDirty()
        {
            _isDirty = true;
        }
        
        private void SaveSyncProfile()
        {
            if (!IsValidProfile())
            {
                MessageBox.Show("One or more settings is incomplete. Please review the profile.", "Incomplete Profile", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return;
            }
            var profile = _settings.SyncProfiles.Profiles.SingleOrDefault(p => p.SyncProfileName == txtSyncProfileName.Text);
            if (profile == null)
            {
                AddSyncProfile();
            }
            else
            {
                UpdateSyncProfile(profile);
            }
            _settings.Save();
            Notify("Saved");
            ClearProfileForm();
            LoadProfilePicker();
        }

        private void AddSyncProfile()
        {
            var profile = new SyncProfile();
            UpdateSyncProfile(profile);
            _settings.SyncProfiles.Profiles.Add(profile);
            LoadProfilePicker();
        }

        private void UpdateSyncProfile(SyncProfile profile)
        {
            profile.StorageConnectionString = txtStorageConnectionString.Text;
            profile.StorageContainerName = txtStorageContainer.Text;
            profile.PolicyPath = txtPolicyFolderPath.Text;
            profile.UIPath = txtUIFolderPath.Text;
            profile.SyncRecursive = chkUIRecursive.Checked;
            profile.SyncPolicyBool = chkSyncB2CPolicies.Checked;
            profile.SyncStorageBool = chkSyncAzureStorage.Checked;
            profile.SyncProfileName = txtSyncProfileName.Text;
        }

        private bool IsValidProfile()
        {
            var res = true;
            res &= (txtSyncProfileName.Text != "");

            if (chkSyncAzureStorage.Checked)
            {
                res &= (txtStorageConnectionString.Text != "");
                res &= (txtStorageContainer.Text != "");
                res &= (txtUIFolderPath.Text != "");
            }
            if (chkSyncB2CPolicies.Checked)
            {
                res &= (txtPolicyFolderPath.Text != "");
            }
            return res;
        }

        private void ClearProfileForm()
        {
            txtSyncProfileName.Text = "";
            txtStorageConnectionString.Text = "";
            txtStorageContainer.Text = "";
            txtPolicyFolderPath.Text = "";
            txtUIFolderPath.Text = "";
            chkSyncB2CPolicies.Checked = true;
            chkSyncAzureStorage.Checked = true;
            chkUIRecursive.Checked = true;
            _isDirty = false;
        }

        private void RemoveSyncProfile(string profileName)
        {
            var profile = _settings.SyncProfiles.Profiles.Single(p => p.SyncProfileName == profileName);
            _settings.SyncProfiles.Profiles.Remove(profile);
            _settings.Save();
            Notify("Saved");

            LoadProfilePicker();
            ClearProfileForm();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            bool firstConfig = (!_settings.Configured);
            _settings.AADAuthority = txtAuthority.Text;
            _settings.B2CTenant = txtTenantID.Text;
            _settings.SyncAppId = txtSyncAppID.Text;
            _settings.B2BApi = txtB2BApi.Text;
            _settings.RedirectUri = txtRedirectUri.Text;
            _settings.PopupDuration = cmdPopupDuration.SelectedIndex.ToString();
            _settings.Configured = (_settings.SyncProfiles.Profiles.Count > 0 && _settings.B2CTenant != "contosob2c.onmicrosoft.com");

            _settings.Save();
            Notify("Saved");

            if (firstConfig && _settings.Configured)
            {
                _parent.Init();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (!_settings.Configured)
            {
                var res = MessageBox.Show("Your configuration is incomplete. Please make sure you have at least one profile, and that you've setup the application settings (including specifying your specific B2C tenant name).\n\r\n\rAre you sure you want to exit configuration?", "Settings Incomplete", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                if (res == DialogResult.No)
                {
                    return;
                }
            }
            _parent.LoadSyncProfileList();
            Hide();
        }

        private void btnAddProfile_Click(object sender, EventArgs e)
        {
            ClearProfileForm();
        }

        private void btnProfileCancel_Click(object sender, EventArgs e)
        {
            if (!PromptToSave())
                return;
            ClearProfileForm();
        }

        private void btnProfileDelete_Click(object sender, EventArgs e)
        {
            RemoveSyncProfile(txtSyncProfileName.Text);
        }

        private void btnProfileSave_Click(object sender, EventArgs e)
        {
            SaveSyncProfile();
        }
        private void btnPolicyFolder_Click(object sender, EventArgs e)
        {
            setPath(txtPolicyFolderPath);
        }
        private void btnUIFolder_Click(object sender, EventArgs e)
        {
            setPath(txtUIFolderPath);
        }

        private void setPath(TextBox obj)
        {
            try
            {
                if (obj.Text != "")
                {
                    folderBrowserDialog1.SelectedPath = obj.Text;
                }
                else
                {
                    folderBrowserDialog1.RootFolder = Environment.SpecialFolder.MyComputer;
                }
                var res = folderBrowserDialog1.ShowDialog();
                if (res == DialogResult.OK)
                {
                    obj.Text = folderBrowserDialog1.SelectedPath;
                }
            }
            catch (Exception ex)
            {
                Logging.WriteToAppLog(ex.Message, EventLogEntryType.Error, ex);
                throw;
            }
        }
    }
}
