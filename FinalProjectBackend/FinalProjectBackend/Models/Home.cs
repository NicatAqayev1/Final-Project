using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProjectBackend.Models
{
    public class Home : BaseEntity
    {
        public string UpgradeLatestImage { get; set; }
        public string UpgradeLatestHeader { get; set; }
        public string UpgradeLatestText { get; set; }
        public string UpgradeLatestSignImage { get; set; }

        public string SpecialImage { get; set; }
        public string SpecialHeader { get; set; }

        public string HurryImage { get; set; }
        public string HurryHeader { get; set; }
        public string HurrySaleText { get; set; }

        public string ArrivalHeader { get; set; }
        public string ArrivalText { get; set; }
        public string ArrivalFeatureBtnText { get; set; }
        public string ArrivalNewBtnText { get; set; }
        public string ArrivalBestBtnText { get; set; }

        public string GalleryHeader { get; set; }
        public string GalleryText { get; set; }

        public string featuredProdsImage { get; set; }
        public string featuredProdsHeader { get; set; }
        public string featuredProdsText { get; set; }

        public string OurClientsHeader { get; set; }
        public string OurClientsText { get; set; }


        [NotMapped]
        public IFormFile UpgradeLatestImageFile { get; set; }
        [NotMapped]
        public IFormFile SpecialImageFile { get; set; }
        [NotMapped]
        public IFormFile HurryImageFile { get; set; }
        [NotMapped]
        public IFormFile featuredProdsImageFile { get; set; }
        [NotMapped]
        public IFormFile UpgradeLatestSignImageFile { get; set; }

    }
}
