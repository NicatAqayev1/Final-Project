using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProjectBackend.Models
{
    public class Address : BaseEntity
    {
        public string Name { get; set; }
        public string AppUserId { get; set; }
        public AppUser AppUser { get; set; }
    }
}
