using FinalProjectBackend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProjectBackend.ViewModels.Product
{
    public class ProductVM
    {
        public FinalProjectBackend.Models.Product Product { get; set; }
        public Setting Setting { get; set; }
        public IEnumerable<Review> Reviews { get; set; }
        public IEnumerable<ProductColorSize> ProductColorSizes { get; set; }
    }
}
