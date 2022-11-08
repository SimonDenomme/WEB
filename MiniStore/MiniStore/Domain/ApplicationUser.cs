using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace MiniStore.Domain
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public List<Address> Address { get; set; }
    }
}
