using B2CDevSync.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace B2CDevSync
{
    public partial class Float : Form
    {
        private Main _parent;

        public Float(Main parent)
        {
            _parent = parent;
            InitializeComponent();
        }

        public async Task ShowPopupAsync(FileCopyEventArgs e)
        {
            if (InvokeRequired)
            {
                BeginInvoke((MethodInvoker)async delegate {
                    await ShowPopupAsync(e);
                });
                return;
            }

            await Task.Factory.StartNew(() =>
            {
                try
                {
                    picFileIcon.Image = GetIcon(e.FilePath);
                    var fileName = Path.Combine(Path.GetDirectoryName(e.FilePath), Path.GetFileName(e.FilePath));

                    lblFileOperation.Text = String.Format("{0} {1}", e.Action, fileName);

                    var dur = _parent._settings.PopupDuration;
                    var scr = Screen.PrimaryScreen.WorkingArea;
                    Point p = new Point((scr.Right - Width - 100), scr.Bottom);
                    Location = p;
                    Show();
                    Activate();
                    for (Int32 i = 1; i < Height; i++)
                    {
                        p = new Point((scr.Right - Width - 100), (scr.Bottom - i));
                        Location = p;
                        Application.DoEvents();
                        Thread.Sleep(4);
                    }
                    Application.DoEvents();
                    Thread.Sleep(Convert.ToInt16(dur) * 1000);
                    Hide();
                }
                catch (Exception ex)
                {
                    Logging.WriteToAppLog("Error showing popup", EventLogEntryType.Error, ex);
                }
            });
        }

        private Bitmap GetIcon(string file)
        {
            var ext = Path.GetExtension(file);
            switch(ext) {
                case "gif":
                    return Properties.Resources.gif;
                case "jpg":
                case "jpeg":
                    return Properties.Resources.jpg;
                case "png":
                    return Properties.Resources.png;
                case "txt":
                    return Properties.Resources.txt;
                case "html":
                case "htm":
                    return Properties.Resources.html;
                case "xml":
                    return Properties.Resources.xml;
                default:
                    return Properties.Resources.ansi;
            }
        }
    }
}
