using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Castle.ActiveRecord;

namespace MyFavourites.Models
{
    [ActiveRecord]
    public class Favourite : ActiveRecordValidationBase<Favourite>
    {
        [PrimaryKey]
        public int Id { get; set; }

        [Property]
        public DateTime CreatedAt { get; set; }

        [BelongsTo]
        public Researcher User { get; set; }

        [BelongsTo]
        public Document Document { get; set; }
    }
}