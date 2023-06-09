using System.ComponentModel.DataAnnotations;

namespace PriceScreen.StoreViewModels
{
    public class StoreViewModel : EditImageViewModel
    {
        [Required]
        [Display(Name = "Name")]
        public string StoreName { get; set; }

        [Required]
        [Display(Name = "Name")]
        public string StoreLocation { get; set; }
    }
}
