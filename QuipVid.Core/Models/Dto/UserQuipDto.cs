using System;

namespace QuipVid.Core.Models.Dto
{
    public class UserQuipDto
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
