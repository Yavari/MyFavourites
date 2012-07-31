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

            Startup.Init<SolrDocument>(solrUlr);
            var solr = ServiceLocator.Current.
                GetInstance<ISolrOperations<SolrDocument>>();
            solr.Delete(SolrQuery.All);
            solr.Commit();

            var payload = new List<SolrDocument>();
            var i = 0;
            foreach (var file in Directory.GetFiles(fixtures))
            {
                Console.WriteLine(file);
                payload.Add(new SolrDocument
                {
                    Id = ++i,
                    Title = Path.GetFileName(file)
                });
            }
            solr.AddRange(payload);
            solr.Commit();
        }
    }
}
