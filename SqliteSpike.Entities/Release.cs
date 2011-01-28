using System;
namespace SqliteSpike.Entities
{
    public class Release
    {
        public virtual Guid ReleaseId { get; set; }
        public virtual string Title { get; set; }
        public virtual Product Product { get; set; }
    }
}