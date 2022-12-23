using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProjectBackend.Models
{
    public class HomeCounts : BaseEntity
    {
        public string CountsImage { get; set; }
        public string CountsText { get; set; }
        [NotMapped]
        public IFormFile CountsImageFile { get; set; }
    }
}
