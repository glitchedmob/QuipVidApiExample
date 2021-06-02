using System.ComponentModel.DataAnnotations;

namespace QuipVidApiEndpoints.Features.Media
{
    public class CreateMediaRequest
    {
        [Required]
        public string Title { get; set; }
    }
}
