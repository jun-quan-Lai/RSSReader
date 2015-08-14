using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace RssReader.rss
{
    public class RssItem
    {
        private string title;
        private string link;
        private string description;

        public RssItem(XmlNode itemNode)
        {
            this.title = itemNode.SelectSingleNode("title").InnerText;
            this.link = itemNode.SelectSingleNode("link").InnerText;
            this.description = itemNode.SelectSingleNode("description").InnerText;
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

    }
}
