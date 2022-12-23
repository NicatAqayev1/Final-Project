using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProjectBackend.Models
{
    public class IntroSlider : BaseEntity
    {
        [StringLength(255)]
        public string Image { get; set; }
        [StringLength(255)]
        public string SmallImageLogo { get; set; }
        [StringLength(255)]
        public string Subtitle { get; set; }
        [StringLength(255)]
        public string Title { get; set; }

        [NotMapped]
        public IFormFile BackImageFile { get; set; }
        [NotMapped]
        public IFormFile SmallLogoImageFile { get; set; }
    }
}
