using System;

namespace QuipVid.Core.Models
{
    public class Quip
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public int Views { get; set; }
        public string VideoUrl { get; set; }
        public string ThumbnailUrl { get; set; }
        public Guid MovieId { get; set; }
        public Movie Movie { get; set; }
        public Guid UploaderId { get; set; }
        public User Uploader { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset UpdatedAt { get; set; }
    }
}
