using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RSSReader
{
    public partial class AddFeed : Form
    {
        private string url = string.Empty;

        public string Url
        {
            get { return url; }
        }
        public AddFeed()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            url = txtUrl.Text;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtUrl_TextChanged(object sender, EventArgs e)
        {
            if (txtUrl.Text.Length == 0)
                btnOK.Enabled = false;
            else
                btnOK.Enabled = true;
        }
    }
}
