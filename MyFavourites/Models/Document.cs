using System;
using System.Collections.Generic;
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

        [Property]
        public string Title { get; set; }

        [Property]
        public string Author { get; set; }
    }
}