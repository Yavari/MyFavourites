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

        public List<string> Documents { get; set; }

        public Researcher()
        {
            Documents = new List<string>();
        }

        public void AuthorDocument()
        {
            Documents.Add("This is my first document");
        }
    }
}