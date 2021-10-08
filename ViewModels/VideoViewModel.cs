using System.ComponentModel.DataAnnotations;

namespace CSharpRestApi.ViewModels
{
    public class VideoViewModel
    {
        [Required]
        public string Description { get; set; }

        [Required]
        public string Base64 { get; set; }
    }
}
