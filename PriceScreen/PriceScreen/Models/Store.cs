using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;

namespace PriceScreen.Models
{
    public class Store
    {
        [Key]
        public int StoreId { get; set; }


        [Column(TypeName="nvarchar(50)")]
        public string StoreName { get; set; }


        [Column(TypeName = "nvarchar(50)")]
        public string StoreLocation { get; set; }


        [Column(TypeName = "nvarchar(50)")]
        [DisplayName("Upload image")]
        public string? ImageName { get; set; }


        [NotMapped] // da se ne bi u ovom obliku sacuvalo u bazi
        [DisplayName("Upload image")]
        public IFormFile ImageFile { get; set; }

        //novi property koji ce sluziti za cuvanje slike u bazi
        public string ImageData { get; set; }
        
    }
}
