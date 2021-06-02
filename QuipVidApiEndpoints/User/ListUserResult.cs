using System;
using System.Collections.Generic;

namespace QuipVidApiEndpoints.User
{
    public class ListUserResult
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public IList<Quip> Quips { get; set; } = new List<Quip>();

        public class Quip
        {
            public Guid Id { get; set; }
            public string Title { get; set; }
            public int Views { get; set; }
            public string VideoUrl { get; set; }
            public string ThumbnailUrl { get; set; }
            public Guid MediaId { get; set; }
            public string MediaTitle { get; set; }
        }
    }
}
