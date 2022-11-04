using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace MiniStore.Domain
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        //public int? CommandId { get; set; }
        //public Command Command { get; set; }
        public int? AddressId { get; set; }
        public Address Address { get; set; }
    }
}
