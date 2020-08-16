using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace B2CDevSync.Utils
{
    public static class Dialog
    {
        public static string ShowDialog(string InputHeader, string FormCaption)
        {
            Form dlg = new Form
            {
                ClientSize = new Size(350, 120),
                AutoScaleMode = AutoScaleMode.Font,
                Text = FormCaption,
                ShowIcon = false,
                ShowInTaskbar = false,
                StartPosition = FormStartPosition.CenterParent
            };
            Label textHeading = new Label
            {
                AutoSize = true,
                Location = new Point(10, 15),
                Size = new Size(345,29),
                Text = InputHeader
            };
            TextBox textC = new TextBox
            {
                Location = new Point(15, 35),
                Size = new Size(320, 29)
            };
            Button grabInput = new Button
            {
                Text = "OK",
                Location = new Point(55, 70),
                Size = new Size(100, 29),
                UseVisualStyleBackColor = true
            };
            Button cancel = new Button
            {
                Text = "Cancel",
                Location = new Point(188, 70),
                Size = new Size(100, 29),
                UseVisualStyleBackColor = true
            };
            grabInput.Click += (sender, evt) =>
            {
                dlg.Close();
            };
            cancel.Click += (sender, evt) =>
            {
                textC.Text = "";
                dlg.Close();
            };
            dlg.Controls.Add(grabInput);
            dlg.Controls.Add(cancel);
            dlg.Controls.Add(textHeading);
            dlg.Controls.Add(textC);
            dlg.Shown += (sender, evt) =>
            {
                textC.Focus();
            };

            dlg.ShowDialog();
            return textC.Text;
        }
    }
}
