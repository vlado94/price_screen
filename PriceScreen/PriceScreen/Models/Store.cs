using System.ComponentModel.DataAnnotations;

namespace PriceScreen.Models
{
    public class Store
    {
        public int Id { get; set; }
        public string StoreName { get; set; }
        public string StoreLocation { get; set; }

        [Display(Name = "Image")]
        public string ProfilePicture { get; set; }

    }
}
