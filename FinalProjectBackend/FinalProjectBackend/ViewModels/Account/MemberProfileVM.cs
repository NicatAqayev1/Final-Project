using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinalProjectBackend.ViewModels.Account;

namespace FinalProjectBackend.ViewModels.Account
{
    public class MemberProfileVM
    {
        public MemberUpdateVM Member { get; set; }
        public List<FinalProjectBackend.Models.Order> Orders { get; set; }
    }
}
