using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace RssReader.rss
{
    public class RssChannel
    {
        private string title;
        private string link;
        private string description;

        private List<RssItem> items;
        private List<string> itemtitles;

        public RssChannel(XmlNode node)
        {
            this.title = node.SelectSingleNode("title").InnerText;
            this.link = node.SelectSingleNode("link").InnerText;
            this.description = node.SelectSingleNode("description").InnerText;

            items = new List<RssItem>();
            itemtitles = new List<string>();

            XmlNodeList itemNodes = node.SelectNodes("item");//XmlElement使用GetElementByTagName

            foreach(XmlNode itemNode in itemNodes)
            {
                RssItem item = new RssItem(itemNode);
                items.Add(item);
                itemtitles.Add(item.Title);
            }
        }

        public string Title
        {
            get
            {
                return this.title;
            }
            set
            {
                this.title = value;
            }
        }
        public string Link
        {
            get
            {
                return this.link;
            }
            set
            {
                this.link = value;
            }
        }
        public string Description
        {
            get
            {
                return this.description;
            }
            set
            {
                this.description = value;
            }
        }

        public IList<RssItem> Items
        {
            get
            {
                return  this.items.AsReadOnly();
            }
        }

        public IList<string> ItemTitles
        {
            get
            {
                return this.itemtitles.AsReadOnly();
            }
        }

    }
}
