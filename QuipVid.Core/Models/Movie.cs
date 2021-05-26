using System;
using System.Collections.Generic;

namespace QuipVid.Core.Models
{
    public class Movie
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public ICollection<Quip> Quips { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset UpdatedAt { get; set; }
    }
}
