using System;

namespace QuipVidControllers.Requests
{
    public class CreateQuipRequest
    {
        public string Title { get; set; }
        public string VideoUrl { get; set; }
        public string ThumbnailUrl { get; set; }
        public Guid MediaId { get; set; }
        public Guid UploaderId { get; set; }
    }
}
