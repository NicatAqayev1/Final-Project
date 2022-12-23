using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProjectBackend.Models
{
    public class Product : BaseEntity
    {
        [StringLength(255), Required]
        public string Name { get; set; }
        public string MainImage { get; set; }
        public string HoverImage { get; set; }
        [Column(TypeName = "money")]
        public double ExTax { get; set; }
        public int Count { get; set; }
        [Required]
        public string Description { get; set; }
        public bool Availability { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public int SpecialityId { get; set; }
        public Speciality Speciality { get; set; }

        public int VendorId { get; set; }
        public Vendor Vendor { get; set; }

        public bool IsNewArrival { get; set; }
        public bool IsBestseller { get; set; }
        public bool IsFeatured { get; set; }

        public List<ProductColorSize> ProductColorSizes { get; set; }
        public List<Review> Reviews { get; set; }


        [NotMapped]
        public List<int> TagIds { get; set; } = new List<int>();
        [NotMapped]
        public List<int> ColorIds { get; set; } = new List<int>();
        [NotMapped]
        public List<int> SizeIds { get; set; } = new List<int>();
        [NotMapped]
        public List<int> Counts { get; set; } = new List<int>();
        [NotMapped]
        public List<double> Prices { get; set; } = new List<double>();
        [NotMapped]
        public List<double> DiscountPrices { get; set; } = new List<double>();


        [NotMapped]
        public IFormFile HoverImageFile { get; set; }
        [NotMapped]
        public List<IFormFile> ImageFiles { get; set; } = new List<IFormFile>();
    }
}
