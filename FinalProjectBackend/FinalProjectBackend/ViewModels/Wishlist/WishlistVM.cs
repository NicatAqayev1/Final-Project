using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProjectBackend.ViewModels.Wishlist
{
    public class WishlistVM
    {
        public string Name { get; set; }
        public string Image { get; set; }
        public double Price { get; set; }
        public Nullable<int> ProductId { get; set; }
        public string AppUserId { get; set; }
        public Nullable<int> ColorId { get; set; }
        public string ColorName { get; set; }
        public Nullable<int> SizeId { get; set; }
        public string SizeName { get; set; }
    }
}
