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

            var i = 0;
            foreach (var file in Directory.GetFiles(fixtures))
            {
                Console.WriteLine(file);

                using(var fileStream = File.OpenRead(file))
                {
                    solr.Extract(new ExtractParameters(fileStream, (++i).ToString())
                    {
                        ExtractFormat = ExtractFormat.Text,
                        ExtractOnly = false,
                        Fields = new List<ExtractField>()
                        {
                            new ExtractField("title", Path.GetFileName(file)),
                            new ExtractField("author", "Baha'i World Volume")
                        }
                    });
                }
            }
        }
    }
}
