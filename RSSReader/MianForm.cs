using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RssReader.rss;

namespace RSSReader
{
    public partial class MianForm : Form
    {
        private List<RssLink> rssLinks;
        private RssFeed feed;
        private IList<RssItem> items;
        public MianForm()
        {
            InitializeComponent();
            ShowDefaultItems();
        }

        private void ShowDefaultItems()
        {
            RssTreeView.Nodes.Clear();

            RssLinkXML rssLinkXml = new RssLinkXML();
            rssLinks = rssLinkXml.GetLinkList();

            foreach (RssLink link in rssLinks)
            {
                if (link.Defaultshow)
                {
                    AddNode(link.Title, link.Uri);
                }
            }
        }

        private void AddNode(string title, string url)
        {
            TreeNode tn = new TreeNode();
            tn.Text = title;
            tn.Tag = url;

            RssTreeView.Nodes.Add(tn);
        }

        private void RssTreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            string url = (string)RssTreeView.SelectedNode.Tag;

            feed = new RssFeed(url);
            items = feed.MainChannel.Items;

            RssListView.Items.Clear();

            foreach (RssItem item in items)
            {
                string[] subItems = new string[3];
                subItems[0] = item.Title;
                subItems[1] = item.Description;
                subItems[2] = item.Link;

                ListViewItem lvi = new ListViewItem(subItems);
                RssListView.Items.Add(lvi);
            }
        }

        private void RssListView_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int index = RssListView.SelectedIndices[0];

            TabPage tabPage = new TabPage();
            tabPage.Text = feed.MainChannel.Items[index].Title;

            //Browser browser = new Browser();
           // browser.Url = feed.MainChannel.Items[index].Link;
           // browser.Show();
            WebBrowser webBrowser = new WebBrowser();
            webBrowser.Dock = DockStyle.Fill;
            webBrowser.Url = new Uri(feed.MainChannel.Items[index].Link);

            tabPage.Controls.Add(webBrowser);
            linkTabControl.TabPages.Add(tabPage);
            linkTabControl.SelectedTab = tabPage;

            if (splitContainer2.Panel2Collapsed)
            {
                splitContainer2.Panel2Collapsed = false;
            }
        }

        private void MianForm_Load(object sender, EventArgs e)
        {

        }

        private void tsbPrevious_Click(object sender, EventArgs e)
        {
            if (RssTreeView.SelectedNode.PrevNode != null)
            {
                RssTreeView.SelectedNode = RssTreeView.SelectedNode.PrevNode;
            }
        }

        private void tsbNext_Click(object sender, EventArgs e)
        {
            if (RssTreeView.SelectedNode.NextNode != null)
            {
                RssTreeView.SelectedNode = RssTreeView.SelectedNode.NextNode;
            }
        }

        private void tsbRefresh_Click(object sender, EventArgs e)
        {
            ShowDefaultItems();
        }

        private void tsbAdd_Click(object sender, EventArgs e)
        {
            AddFeed addFeed = new AddFeed();
            addFeed.ShowDialog();
            string url = addFeed.Url;

            if (url != string.Empty)
            {
                RssFeed newFeed = new RssFeed(url);

                RssLinkXML rssLinkXml = new RssLinkXML();
                rssLinkXml.AddLink(newFeed.MainChannel.Title, url);
                ShowDefaultItems();
            }
        }

        private void tsbLink_Click(object sender, EventArgs e)
        {
            LinksManager linksmng = new LinksManager();
            linksmng.ShowDialog();
        }

        private void tsbRssList_Click(object sender, EventArgs e)
        {
            if (splitContainer1.Panel1Collapsed == false)
                splitContainer1.Panel1Collapsed = true;
            else
                splitContainer1.Panel1Collapsed = false;

        }

        private void linkTabControl_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            linkTabControl.TabPages.Remove(linkTabControl.SelectedTab);

            if (linkTabControl.TabCount == 0)
            {
                splitContainer2.Panel2Collapsed = true;
            }
        }

        private void 链接管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LinksManager linksmng = new LinksManager();
            linksmng.ShowDialog();
        }

        private void 关闭ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void 新增频道ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddFeed addFeed = new AddFeed();
            addFeed.ShowDialog();
            string url = addFeed.Url;

            if (url != string.Empty)
            {
                RssFeed newFeed = new RssFeed(url);
                RssLinkXML rssLinkXML = new RssLinkXML();
                rssLinkXML.AddLink(newFeed.MainChannel.Title, url);
                ShowDefaultItems();
            }
        }

        private void 刷新ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            splitContainer1.Panel1Collapsed = false;
            ShowDefaultItems();
        }

        private void RssTreeView_MouseMove(object sender, MouseEventArgs e)
        {
            string url;
            TreeNode tn = RssTreeView.GetNodeAt(e.Location);
        }

        private void 刷新ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ShowDefaultItems();
        }

        private void 新增频道ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            AddFeed addFeed = new AddFeed();
            addFeed.ShowDialog();
            string url = addFeed.Url;

            if (url != string.Empty)
            {
                RssFeed newFeed = new RssFeed(url);

                RssLinkXML rssLinkXml = new RssLinkXML();
                rssLinkXml.AddLink(newFeed.MainChannel.Title, url);
                ShowDefaultItems();
            }
        }

        
    }
}
