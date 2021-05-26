using System;
using System.Collections.Generic;

namespace QuipVid.Core.Models
{
    public class Media
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public IList<Quip> Quips { get; set; } = new List<Quip>();
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset UpdatedAt { get; set; }
    }
}
