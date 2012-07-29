using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Castle.ActiveRecord;
using NHibernate.Criterion;

namespace MyFavourites.Models
{
    [ActiveRecord]
    public class Researcher : ActiveRecordBase<Researcher>
    {
        [PrimaryKey]
        public int Id { get; set; }
        
        [Property]
        public string Email { get; set; }

        [Property]
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

        public static Researcher FindByName(string name)
        {
            return FindOne(Restrictions.Eq("Name", name));
        }
    }
}