using FinalProjectBackend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProjectBackend.ViewModels.Blog
{
    public class BlogVM
    {
        public List<Review> Reviews { get; set; }
        public FinalProjectBackend.Models.Blog Blog { get; set; }
        public List<FinalProjectBackend.Models.Blog> Blogs { get; set; }
    }
}
