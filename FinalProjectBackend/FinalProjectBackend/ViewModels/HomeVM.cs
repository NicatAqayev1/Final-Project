using FinalProjectBackend.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProjectBackend.ViewModels
{
    public class HomeVM
    {
        public IEnumerable<IntroSlider> IntroSliders { get; set; }
        public Home Home { get; set; }
        public IEnumerable<FinalProjectBackend.Models.Product> Products { get; set; }
        public IEnumerable<HomeOurClientsSlider> HomeOurClientsSliders { get; set; }
        public IEnumerable<HomeCounts> HomeCounts { get; set; }
        public IEnumerable<HomeGallery> HomeGalleries { get; set; }
        public IEnumerable<HomeSpecialCards> HomeSpecialCards { get; set; }
        public Subscriber Subscriber { get; set; }
    }
}
