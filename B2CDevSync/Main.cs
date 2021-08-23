using B2CDevSync.Utils;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Threading;
using System.Collections;
using B2CDevSync.Models;

namespace B2CDevSync
{
    public partial class Main : Form
    {
        private SyncStorage _storage;
        public Logger _logger;
        internal Properties.Settings _settings;
        private PopupStatus _status;
        internal B2CPolicies _policy;
        internal B2CApps _apps;
        private Float _float;
        internal Auth _auth;
        private Hashtable _inQueue;
        private SyncProfile _currProfile;

        public Main()
        {
            InitializeComponent();
            _settings = Properties.Settings.Default;
            if (_settings.SyncProfiles == null)
            {
                _settings.SyncProfiles = new SyncProfiles();
            }

            _status = new PopupStatus(this);
            _float = new Float(this);
            _status.LostFocus += _status_LostFocus;
            _inQueue = new Hashtable();
            notifyIcon1.Icon = Properties.Resources.B2CLogo;
        }

        private void Main_Load(object sender, EventArgs e)
        {
            _logger = new Logger();
            _logger.LoggerMessage += _logger_LoggerMessage;
            PolicyWatcher.Changed += PolicyWatcher_Changed;
            PolicyWatcher.Created += PolicyWatcher_Changed;
            UIWatcher.Changed += UIWatcher_Changed;
            UIWatcher.Created += UIWatcher_Changed;
            UIWatcher.Deleted += UIWatcher_Deleted;

            PolicyWatcher.Renamed += PolicyWatcher_Renamed;
            UIWatcher.Renamed += UIWatcher_Renamed;
            Application.ApplicationExit += Application_ApplicationExit;
            cmbSyncProfiles.SelectedIndexChanged += CmbSyncProfiles_SelectedIndexChanged;

            if (!_settings.Configured || _settings.SyncProfiles.Profiles.Count == 0)
            {
                ShowSettings();
                return;
            }
            txtTenantName.Text = _settings.B2CTenant;
            Init();
        }

        public void loadProfile(string profileName)
        {
            try
            {
                _currProfile = _settings.SyncProfiles.Profiles.Single(p => p.SyncProfileName == profileName);

                _storage = new SyncStorage(_currProfile.StorageConnectionString, _currProfile.StorageContainerName, _currProfile.UIPath);
                if (_storage.ErrorMessage != null)
                {
                    MessageBox.Show("The selected profile wasn't loaded due to an error initializing storage. Please check the profile and confirm your connection string.\n\rDetails: " + _storage.ErrorMessage, "Storage Profile Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                _storage.FileActivityMessage += FileActivityMessageAsync;

                txtUIFolder.Text = (_currProfile.SyncStorageBool) ? _currProfile.UIPath : "N/A";
                txtPolicyFolder.Text = (_currProfile.SyncPolicyBool) ? _currProfile.PolicyPath : "N/A";
                btnStart.Enabled = true;
            }
            catch (Exception ex)
            {
                btnStart.Enabled = false;
                Logging.WriteToAppLog(ex.Message, EventLogEntryType.Error, ex);
                MessageBox.Show("An error occured trying to initialize the storage profile. Please check the connection string for the storage account of the selected profile.", "Error Connecting", MessageBoxButtons.OK);
            }

        }
        public void Init()
        {
            try
            {
                _policy = new B2CPolicies(_settings.B2BApi);
                _policy.FileActivityMessage += FileActivityMessageAsync;
                _policy.PolicyErrorMessage += PolicyErrorMessageAsync;

                _apps = new B2CApps();
                LoadSyncProfileList();

            }
            catch (Exception ex)
            {
                Logging.WriteToAppLog(ex.Message, EventLogEntryType.Error, ex);
                throw;
            }
        }

        public void LoadSyncProfileList()
        {
            txtTenantName.Text = _settings.B2CTenant;

            cmbSyncProfiles.Items.Clear();
            cmbSyncProfiles.Items.AddRange(_settings.SyncProfiles.Profiles.Select(p => p.SyncProfileName).ToArray<object>());

            if (cmbSyncProfiles.Items.Count > 0)
                cmbSyncProfiles.SelectedIndex = 0;
        }

        private void CmbSyncProfiles_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadProfile(cmbSyncProfiles.SelectedItem.ToString());
        }

        private void Application_ApplicationExit(object sender, EventArgs e)
        {
            try
            {
                _storage = null;
                _logger.Dispose();
                _logger = null;
            }
            catch { }
        }

        private async void FileActivityMessageAsync(object sender, FileCopyEventArgs e)
        {
            _logger.Write(e);
            await _float.ShowPopupAsync(e);
        }
        private void PolicyErrorMessageAsync(object sender, PolicyErrorArgs e)
        {
            _logger.Write(e);
            if (_settings.ShowMessageBoxOnError)
            {
                MessageBox.Show(e.Error.Error.Message, e.Error.Error.Code + " Policy Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAppSettings_Click(object sender, EventArgs e)
        {
            ShowSettings();
        }

        private void ShowSettings()
        {
            AppSettings frmSettings = new AppSettings(this);
            frmSettings.ShowDialog(this);
        }

        private void btnAbout_Click(object sender, EventArgs e)
        {
            Process.Start("https://github.com/bretthacker/B2CDevSync");
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            try
            {
                if (_currProfile.SyncPolicyBool)
                {
                    PolicyWatcher.EnableRaisingEvents = false;
                }
                if (_currProfile.SyncStorageBool)
                {
                    UIWatcher.EnableRaisingEvents = false;
                }
            }
            catch { }

            Application.Exit();
        }

        private void btnLogin_ClickAsync(object sender, EventArgs e)
        {
            try
            {
                if (btnLogin.Text == "Login")
                {
                    _auth = new Auth(_settings);
                    UserInfo res = null;
                    var task = Task.Run(async () =>
                    {
                        res = await _auth.Login();
                    });
                    task.Wait();

                    if (res == null)
                    {
                        MessageBox.Show(this, String.Format("Sorry, there was a problem authenticating. Please try again. ({0})", _auth.ErrorMessage), "Login Failed");
                        return;
                    }
                    txtLoginInfo.Text = String.Format("{0} {1} ({2})", res.GivenName, res.FamilyName, res.DisplayableId);
                    txtLoginInfo.Refresh();
                    btnLogin.Text = "Logout";
                    btnTenantInit.Enabled = true;
                }
                else
                {
                    _auth.Logout();
                    txtLoginInfo.Text = "Not logged in";
                    btnLogin.Text = "Login";
                    btnTenantInit.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                Logging.WriteToAppLog(ex.Message, EventLogEntryType.Error, ex);

                throw;
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            try
            {
                if (btnStart.Text == "Start")
                {
                    if (_currProfile.SyncPolicyBool)
                    {
                        if (_auth == null || _auth.Token == null)
                        {
                            MessageBox.Show("Please login to your B2C tenant before starting dev sync.", "Not Logged In", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                            btnLogin.Focus();
                            return;
                        }
                        PolicyWatcher.Path = _currProfile.PolicyPath;
                        PolicyWatcher.IncludeSubdirectories = true;
                        PolicyWatcher.NotifyFilter = NotifyFilters.LastWrite | NotifyFilters.CreationTime;
                        PolicyWatcher.EnableRaisingEvents = true;
                    }

                    if (_currProfile.SyncStorageBool)
                    {
                        UIWatcher.Path = _currProfile.UIPath;
                        UIWatcher.IncludeSubdirectories = _currProfile.SyncRecursive;
                        UIWatcher.NotifyFilter = NotifyFilters.LastWrite | NotifyFilters.FileName;
                        UIWatcher.Filter = "*.*";
                        UIWatcher.EnableRaisingEvents = true;
                    }
                    btnStart.Text = "Stop";
                    aniRunning.Show();
                    notifyIcon1.Text = "B2C Dev Sync (running)";
                    WindowState = FormWindowState.Minimized;
                }
                else
                {
                    if (_currProfile.SyncPolicyBool)
                    {
                        PolicyWatcher.EnableRaisingEvents = false;
                    }
                    if (_currProfile.SyncStorageBool)
                    {
                        UIWatcher.EnableRaisingEvents = false;
                    }
                    aniRunning.Hide();
                    notifyIcon1.Text = "B2C Dev Sync (paused)";
                    btnStart.Text = "Start";
                }
            }
            catch (Exception ex)
            {
                Logging.WriteToAppLog(ex.Message, EventLogEntryType.Error, ex);
                throw;
            }
        }

        private async void PolicyWatcher_Changed(object sender, FileSystemEventArgs e)
        {
            if (_inQueue.Contains(e.FullPath))
                return;

            _inQueue.Add(e.FullPath, null);

            FileAttributes file = File.GetAttributes(e.FullPath);
            if (file.HasFlag(FileAttributes.Directory))
            {
                _inQueue.Remove(e.FullPath);
                return;
            }

            await Task.Factory.StartNew(async () =>
            {
                try
                {
                    var fileStream = SyncStorage.OpenShared(e.FullPath);
                    string content;
                    using (StreamReader reader = new StreamReader(fileStream))
                    {
                        content = reader.ReadToEnd();
                    }

                    var doc = new XmlDocument();

                    doc.LoadXml(content);
                    var id = doc.SelectSingleNode("/*/@PolicyId").Value;
                    _policy.RefreshToken(_auth.Token);
                    string res = null;
                    res = await _policy.UpsertAsync(id, content);
                    File.SetAttributes(e.FullPath, FileAttributes.Normal);
                }
                catch (XmlException ex)
                {
                    Logging.WriteToAppLog("Error parsing XML while uploading policy", EventLogEntryType.Error, ex);
                    var msg = String.Format("An error occured parsing your XML policy update: {0}. Additional details may be availabe in the Windows event log for details.", ex.Message);
                    if (_settings.ShowMessageBoxOnError)
                    {
                        MessageBox.Show(msg, "Error Parsing XML", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    Logging.WriteToAppLog("Error uploading policy", EventLogEntryType.Error, ex);
                    if (_settings.ShowMessageBoxOnError)
                    {
                        MessageBox.Show("Something went wrong while uploading your policy update. Please check the Windows event log for details.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                finally
                {
                    _inQueue.Remove(e.FullPath);
                }
            }, TaskCreationOptions.LongRunning);
        }

        private void PolicyWatcher_Renamed(object sender, RenamedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void UIWatcher_Deleted(object sender, FileSystemEventArgs e)
        {
            _storage.DeleteBlob(e.FullPath);

        }
        private async void UIWatcher_Changed(object sender, FileSystemEventArgs e)
        {
            try
            {
                FileAttributes file = File.GetAttributes(e.FullPath);
                if (file.HasFlag(FileAttributes.Directory))
                    return;
                if (_inQueue.Contains(e.FullPath))
                    return;

                _inQueue.Add(e.FullPath, null);

                await _storage.AddBlobAsync(e.FullPath);
            }
            catch (Exception ex)
            {
                Logging.WriteToAppLog(ex.Message, EventLogEntryType.Error, ex);
                throw;
            }
            finally
            {
                _inQueue.Remove(e.FullPath);
            }
        }

        private void UIWatcher_Renamed(object sender, RenamedEventArgs e)
        {
            //put the new one
            _storage.AddBlobAsync(e.FullPath);
            //drop the old one
            var blobPath = e.OldFullPath.Replace(_currProfile.UIPath, "");
            _storage.DeleteBlob(blobPath);
        }

        private void _logger_LoggerMessage(object sender, LoggerEventArgs e)
        {
            if (InvokeRequired)
            {
                BeginInvoke((MethodInvoker)delegate
                {
                    _logger_LoggerMessage(sender, e);
                });
                return;
            }
            txtOperations.Text += e.Message;
        }

        private void btnClearLog_Click(object sender, EventArgs e)
        {
            txtOperations.Text = "";
            _logger.Clear();
        }

        private void Main_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                Hide();
                notifyIcon1.Visible = true;
            }
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            _status.Hide();
            Show();
            this.WindowState = FormWindowState.Normal;
            notifyIcon1.Visible = false;
            txtOperations.Text = _logger.Read();
        }

        private void notifyIcon1_Click(object sender, EventArgs e)
        {
            if (_status.Visible)
            {
                _status.Hide();
            }
            else
            {
                var scr = Screen.PrimaryScreen.WorkingArea;
                Point p = new Point((scr.Right - _status.Width - 100), (scr.Bottom - _status.Height));
                _status.Location = p;
                _status.Show();
                _status.Activate();
            }
        }
        private void _status_LostFocus(object sender, EventArgs e)
        {
            _status.Hide();
        }

        private void btnTenantInit_Click(object sender, EventArgs e)
        {
            ShowTenantInit();
        }
        private void ShowTenantInit()
        {
            InitTenant frmInit = new InitTenant(this);
            frmInit.ShowDialog(this);
        }
    }
}
