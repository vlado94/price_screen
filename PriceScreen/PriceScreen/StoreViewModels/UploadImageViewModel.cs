using System.ComponentModel.DataAnnotations;

namespace PriceScreen.StoreViewModels
{
    public class UploadImageViewModel
    {
        [Required]
        [Display(Name = "Image")]
        public IFormFile StorePicture { get; set; }
    }
}
