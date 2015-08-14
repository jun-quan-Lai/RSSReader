using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RssReader.rss;

namespace RSSReader
{
    public partial class LinksManager : Form
    {
        private DataSet linkSet;

        public LinksManager()
        {
            InitializeComponent();
            LoadLinks();
        }

        private void LoadLinks()
        {
            RssLinkXML rsssLinkXml = new RssLinkXML();
            linkSet = rsssLinkXml.GetLinkSet();

            this.rssbindingSource.DataSource = linkSet;
            this.rssbindingSource.DataMember = linkSet.Tables[0].TableName;
            this.linksGridView.DataSource = rssbindingSource;

            linksGridView.AllowUserToAddRows = false;
            linksGridView.Columns["title"].HeaderText = "标题";
            linksGridView.Columns["title"].Width = 220;
            linksGridView.Columns["uri"].HeaderText = "URI";
            linksGridView.Columns["uri"].Width = 280;
            linksGridView.Columns["defaultshow"].HeaderText = "缺省显示";
            linksGridView.Columns["defaultshow"].Width = 80;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            rssbindingSource.AddNew();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("删除选中的链接，确定吗？", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                rssbindingSource.RemoveCurrent();
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            RssLinkXML rssLinkXml = new RssLinkXML();
            rssLinkXml.SaveLinkSet(linkSet);
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
