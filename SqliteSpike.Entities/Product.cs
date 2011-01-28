using System.Collections.Generic;
using System;

namespace SqliteSpike.Entities
{
    public class Product
    {
        public virtual Guid ProductId { get; set; }
        public virtual string Title { get; set; }
        public virtual IEnumerable<Tag> Tags { get; set; }
        public virtual IEnumerable<Release> Releases { get; set; }
    }
}
