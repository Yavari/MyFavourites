using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyFavourites.Models
{
    public class Researcher
    {
        public string Email { get; set; }
        public string Name { get; set; }

        public List<Document> Documents { get; set; }

        public Researcher()
        {
            Documents = new List<Document>();
        }

        public void AuthorDocument(string title)
        {
            Documents.Add(new Document{Title = title, Author = Name});
        }
    }
}