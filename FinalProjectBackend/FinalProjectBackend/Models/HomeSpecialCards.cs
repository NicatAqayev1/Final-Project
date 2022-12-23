using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProjectBackend.Models
{
    public class HomeSpecialCards : BaseEntity
    {
        public string CardImage { get; set; }
        public string CardName { get; set; }
        public string CardText { get; set; }
        [NotMapped]
        public IFormFile CardImageFile { get; set; }
    }
}
