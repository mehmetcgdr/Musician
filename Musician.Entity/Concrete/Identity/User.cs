using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Musician.Entity.Concrete.Identity
{
    public class User : IdentityUser
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Description { get; set; }
        public string Gender { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public int Age { get; set; }
        public string Url { get; set; }
    }
}