using System.ComponentModel.DataAnnotations;

namespace PriceScreen.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        //[Column("Email", TypeName = "Varchar(200)")]
        public string Email { get; set; }

        //[Column("Password", TypeName = "Varchar(200)")]
        public string Password { get; set; }

        // public string Role { get; set; }
    }
}