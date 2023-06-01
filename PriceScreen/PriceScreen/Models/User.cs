using System.ComponentModel.DataAnnotations;

namespace PriceScreen.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter your email")]
        [Display(Name = "Please enter your email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please enter your password")]
        [Display(Name = "Please enter your password")]
        public string Password { get; set; }

        public string Role { get; set; }
        public int isActive { get; set; }
    }
}
