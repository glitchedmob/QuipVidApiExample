using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace QuipVidApiEndpoints.Quip
{
    public class UpdateQuipRequest
    {
        [FromRoute]
        public Guid Id { get; set; }

        [Required]
        public string Title { get; set; }

        public int Views { get; set; }

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
