using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace RssReader.rss
{
    class RssItem
    {
        private string title;
        private string link;
        private string decription;

        public RssItem(XmlNode itemNode)
        {
            this.title = itemNode.SelectSingleNode("title").InnerText;
            this.link = itemNode.SelectSingleNode("link").InnerText;
            this.decription = itemNode.SelectSingleNode("decription").InnerText;
        }


        public string Titel { get; }
        public string Link { get; }
        public string Decription { get; }

    }
}
