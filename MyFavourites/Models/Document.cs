using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Castle.ActiveRecord;

namespace MyFavourites.Models
{
    [ActiveRecord]
    public class Document : ActiveRecordBase<Document>
    {
        [PrimaryKey]
        public int Id { get; set; }

        [Required]
        [Property]
        public string Title { get; set; }

        [Required]
        [Property]
        public string Text { get; set; }

        [BelongsTo]
        public Researcher Author { get; set; }

        [HasMany(Cascade = ManyRelationCascadeEnum.All, Lazy = true)]
        public IList<Favourite> Favourites { get; set; }

        public string AuthorName { get { return Author.Name; } }
    }
}