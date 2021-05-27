using System.ComponentModel.DataAnnotations;

namespace QuipVidControllers.Requests
{
    public class CreateMediaRequest
    {
        [Required]
        public string Title { get; set; }
    }
}
