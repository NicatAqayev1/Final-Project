using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProjectBackend.Models
{
    public class Setting : BaseEntity
    {
        [StringLength(255)]
        public string Logo { get; set; }
        [StringLength(255)]
        public string Facebook { get; set; }
        [StringLength(255)]
        public string Instagram { get; set; }
        [StringLength(255)]
        public string Pinterest { get; set; }
        [StringLength(255), Required]
        public string Address { get; set; }
        [StringLength(255), Required, EmailAddress]
        public string Email { get; set; }
        [StringLength(255), Required, EmailAddress]
        public string Email2 { get; set; }
        [StringLength(255), Required]
        public string Phone { get; set; }
        [StringLength(255), Required]
        public string Fax { get; set; }
        public string ShippingDetail { get; set; }
        [NotMapped]
        public IFormFile LogoImageFile { get; set; }
    }
}
