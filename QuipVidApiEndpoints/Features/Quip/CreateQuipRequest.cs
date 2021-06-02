using System;
using System.ComponentModel.DataAnnotations;

namespace QuipVidApiEndpoints.Features.Quip
{
    public class CreateQuipRequest
    {
        [Required]
        public string Title { get; set; }

        [Required]
        public string VideoUrl { get; set; }

        [Required]
        public string ThumbnailUrl { get; set; }

        [Required]
        public Guid MediaId { get; set; }

        [Required]
        public Guid UploaderId { get; set; }
    }
}
