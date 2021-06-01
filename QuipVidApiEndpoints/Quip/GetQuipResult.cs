using System;

namespace QuipVidApiEndpoints.Quip
{
    public class GetQuipResult
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public int Views { get; set; }
        public string VideoUrl { get; set; }
        public string ThumbnailUrl { get; set; }
        public string MediaTitle { get; set; }
        public Guid MediaId { get; set; }
        public string UploaderUserName { get; set; }
        public Guid UploaderId { get; set; }
    }
}
