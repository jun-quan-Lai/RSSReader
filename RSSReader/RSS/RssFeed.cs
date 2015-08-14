using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;
using System.Xml;

namespace RssReader.rss
{
    public class RssFeed
    {
        private string uri;
        private List<RssChannel> channels;

        public RssFeed(string Uri)
        {
            this.uri = Uri;
            Load(Uri);
        }

        public string URI 
        {
            get
            {
                return this.uri;
            }
        }

        public IList<RssChannel> Channels
        {
            get
            {
                return this.channels.AsReadOnly();
            }
        }

        private void Load(string Uri)
        {
            System.Net.WebClient webClient = new WebClient();
            XmlDocument rssXml = new XmlDocument();

            using (Stream rssStream = webClient.OpenRead(Uri))
            {
                rssXml.Load(rssStream);
            }

            channels = new List<RssChannel>();
            XmlNode rssNode = rssXml.SelectSingleNode("rss");

            XmlNodeList nodes = rssNode.ChildNodes;

            foreach (XmlNode node in nodes)
            {
                RssChannel channel = new RssChannel(node);
                channels.Add(channel);
            }
        }
    }
}
