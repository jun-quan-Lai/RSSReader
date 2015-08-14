using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RssReader.rss
{
    class RssLink
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

        public string Title { get; set; }
        public string Uri { get; set; }
        public bool  Defaultshow { get; set; }

    }
}
