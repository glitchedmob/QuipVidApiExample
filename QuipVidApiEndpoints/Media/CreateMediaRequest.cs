using System.ComponentModel.DataAnnotations;

namespace QuipVidApiEndpoints.Media
{
    public class CreateMediaRequest
    {
        [Required]
        public string Title { get; set; }
    }
}
