using System.Collections.Generic;
using System;

namespace SqliteSpike.Entities
{
    public class Tag
    {
        public virtual Guid TagId { get; set; }
        public virtual string Name { get; set; }
        public virtual IEnumerable<Product> Products { get; set; }
    }
}