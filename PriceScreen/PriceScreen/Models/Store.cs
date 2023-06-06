using System.ComponentModel.DataAnnotations;

namespace PriceScreen.Models
{
    public class Store
    {
        [Key]
        public int Id { get; set; }

        public string? Name { get; set; }
        public string? Location { get; set; }

    }
}
