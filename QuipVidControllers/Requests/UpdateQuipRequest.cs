using System;

namespace QuipVidControllers.Requests
{
    public class UpdateQuipRequest
    {
        public string Title { get; set; }
        public int Views { get; set; }
        public string VideoUrl { get; set; }
        public string ThumbnailUrl { get; set; }
        public Guid MediaId { get; set; }
        public Guid UploaderId { get; set; }
    }
}
