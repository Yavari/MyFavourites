using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SolrNet.Attributes;

namespace DocumentCrawler
{
    public class SolrDocument
    {
        [SolrUniqueKey("id")]
        public int Id { get; set; }

        [SolrField("title")]
        public string Title { get; set; }
    }
}
