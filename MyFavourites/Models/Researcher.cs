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

        [Property]
        public string Username { get; set; }

        [HasMany(Cascade = ManyRelationCascadeEnum.All, Lazy = true)]
        public IList<Document> Documents { get; set; }

        [HasMany(Cascade = ManyRelationCascadeEnum.All, Lazy = true)]
        public IList<Favourite> Favourites { get; set; }

        public Researcher()
        {
            Documents = new List<Document>();
            Favourites = new List<Favourite>();
        }

        public void AuthorDocument(string title, string text)
        {
            Documents.Add(new Document{Title = title, Text = text});
        }

        public void AddFavourite(int id)
        {
            if (Favourites.Any(f => f.Document.Id == id))
                return;

            Favourites.Add(new Favourite
            {
                Document = Document.Find(id),
                CreatedAt = DateTime.Now
            });
            Save();
        }

        public void RemoveFavourite(int id)
        {
            var favourite = Favourites.First(f => f.Document.Id == id);
            Favourites.Remove(favourite);
            favourite.Delete();
        }

        public static Researcher FindByUsername(string username)
        {
            var researcher = FindFirst(Restrictions.Eq("Username", username));
            if (researcher == null)
            {
                throw new NotFoundException(String.Format("'{0}' not found", username));
            }
            return researcher;
        }

    }


}