using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Microsoft.Practices.ServiceLocation;
using SolrNet;

namespace DocumentCrawler
{
    class Program
    {
        static void Main(string[] args)
        {
            var fixtures = args[0];
            var solrUlr = "http://localhost:8983/solr";

            Startup.Init<Dictionary<string, object>>(solrUlr);
            var solr = ServiceLocator.Current.
                GetInstance<ISolrOperations<Dictionary<string, object>>>();
            solr.Delete(SolrQuery.All);
            solr.Commit();

            foreach (var file in Directory.GetFiles(fixtures))
            {
                Console.WriteLine(file);
            }
        }
    }
}
