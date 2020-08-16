using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace B2CDevSync
{
    public partial class PopupStatus : Form
    {
        private Main _parent;

        public PopupStatus(Main parent)
        {
            _parent = parent;
            InitializeComponent();
        }

        private void PopupStatus_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible)
            {
                txtOperationsLog.Text = _parent._logger.Read();
            } else
            {
                txtOperationsLog.Text = "";
            }
        }

        private void btnStatusClose_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
