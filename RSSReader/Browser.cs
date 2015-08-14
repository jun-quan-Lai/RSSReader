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
    public partial class Browser : Form
    {
        private string url;
        public string Url
        {
            get
            {
                return url;
            }
            set
            {
                url = value;
                rsswebBrowser.Url = new Uri(url);
            }
        }
        public Browser()
        {
            InitializeComponent();
        }

        
    }
}
