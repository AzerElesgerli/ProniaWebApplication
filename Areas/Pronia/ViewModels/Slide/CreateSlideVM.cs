using System.ComponentModel.DataAnnotations;

namespace ProniaWebApplication.Areas.Pronia.ViewModels.Slide
{
    public class CreateSlideVM
    {
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string Description { get; set; }

        public int Order { get; set; }
        [Required]
        public IFormFile? Image { get; set; }
    }
}
