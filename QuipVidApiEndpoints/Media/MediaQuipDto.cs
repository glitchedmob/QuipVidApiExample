using System;

namespace QuipVidApiEndpoints.Media
{
    public class MediaQuipDto
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
