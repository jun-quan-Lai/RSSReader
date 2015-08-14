using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RssReader.rss
{
    public class RssLink
    {
        private string title;
        private string uri;
        private bool defaultshow;

        public RssLink(string title, string uri, bool defaultshow)
        {
            this.title = title;
            this.uri = uri;
            this.defaultshow = defaultshow;

        }

        public string Title
        {
            get{
                return this.title;
            }
            set{
                this.title = value;
            }
        }
        public string Uri
        {
            get
            {
                return this.uri;
            }
            set
            {
                this.uri = value;
            }
        }
        public bool Defaultshow
        {
            get
            {
                return this.defaultshow;
            }

            set
            {
                this.defaultshow = value;
            }
        }

    }
}
