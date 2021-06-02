using System;
using System.Collections.Generic;

namespace QuipVidApiEndpoints.Media
{
    public class GetMediaResult
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public IList<Quip> Quips { get; set; } = new List<Quip>();

        public class Quip
        {
            public Guid Id { get; set; }
            public string Title { get; set; }
            public int Views { get; set; }
            public string VideoUrl { get; set; }
            public string ThumbnailUrl { get; set; }
            public Guid UploaderId { get; set; }
            public string UploaderUserName { get; set; }
        }
    }
}