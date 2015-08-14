using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Data;
using System.Xml.XPath;

namespace RssReader.rss
{
    public class RssLinkXML
    {
       
        public List<RssLink> GetLinkList()
        {
            List<RssLink> links = new List<RssLink>();
            XmlDocument doc = new XmlDocument();
            doc.Load("RssLinks.xml");

            XmlNode rootNode = doc.SelectSingleNode("links");
            XmlNodeList linknodes = rootNode.ChildNodes;

            foreach (XmlNode linknode in linknodes)
            {
                string title = linknode.SelectSingleNode("title").InnerText;
                string uri = linknode.SelectSingleNode("uri").InnerText;
                bool defaultshow = bool.Parse(linknode.SelectSingleNode("defaultshow").InnerText);

                RssLink linkItem = new RssLink(title, uri, defaultshow);
                links.Add(linkItem);
                
            }
            return links;
        }

        public DataSet GetLinkSet()
        {
            DataSet linkSet;

            linkSet = new DataSet("links");
            linkSet.Tables.Add("link");

            linkSet.Tables["link"].Columns.Add("title", typeof(string));
            linkSet.Tables["link"].Columns.Add("uri", typeof(string));
            linkSet.Tables["link"].Columns.Add("defaultshow", typeof(bool));
            linkSet.Tables["link"].Columns["defaultshow"].DefaultValue = false;

            linkSet.ReadXml("RssLinks.xml", XmlReadMode.InferSchema);

            return linkSet;
        }

        public void SaveLinkSet(DataSet linkSet)
        {
            linkSet.WriteXml("RssLinks.xml");
        }

        public bool IsLinkExist(string uri)
        {
            XPathDocument doc = new XPathDocument("RssLinks.xml");
            XPathNavigator navigator = doc.CreateNavigator();
            XPathNodeIterator iterator = navigator.Select("/links/link[uri='" + uri + "']");

            if (iterator.Count == 0)
            {
                return false;
            }

            else
            {
                return true;
            }
        }

        public void AddLink(string title, string uri)
        {
            XmlDocument doc = new XmlDataDocument();
            doc.Load("RssLinks.xml");
            XmlNode rootNode = doc.SelectSingleNode("links");

            XmlNode linkNode = doc.CreateElement("link");

            XmlNode titleNode = doc.CreateElement("title");
            XmlText titleText = doc.CreateTextNode(title);
            titleNode.AppendChild(titleText);

            XmlNode uriNode = doc.CreateElement("uri");
            XmlText uriText = doc.CreateTextNode(uri);
            uriNode.AppendChild(uriText);

            XmlNode defaultshowNode = doc.CreateElement("defaultshow");
            XmlText defaultshowText = doc.CreateTextNode("false");
            defaultshowNode.AppendChild(defaultshowText);

            linkNode.AppendChild(titleNode);
            linkNode.AppendChild(uriNode);
            linkNode.AppendChild(defaultshowNode);

            rootNode.AppendChild(linkNode);

            doc.Save("RssLinks.xml");
        }
    }
}
