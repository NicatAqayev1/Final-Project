using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProjectBackend.Models
{
    public class Subscriber : BaseEntity
    {
        [DataType(DataType.EmailAddress)]
        [Required]
        public string Email { get; set; }
    }
}
