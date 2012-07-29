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

        public void AuthorDocument()
        {
            Documents = new List<string>();
            Documents.Add("This is my first document");
        }
    }
}