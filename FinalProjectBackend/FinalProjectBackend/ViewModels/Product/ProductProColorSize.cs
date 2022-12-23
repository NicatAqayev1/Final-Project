using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProjectBackend.ViewModels.Product
{
    public class ProductProColorSize
    {
        public FinalProjectBackend.Models.Product Product { get; set; }
        public List<FinalProjectBackend.Models.ProductColorSize> ProductColorSize { get; set; }
    }
}
