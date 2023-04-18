using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Musician.Entity.Concrete.Identity
{
    public class User : IdentityUser
    {
        
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Description { get; set; } = "";
        public string Gender { get; set; }="";
        public string City { get; set; } ="";
        public string District { get; set; }="";
        public DateTime? DateOfBirth { get; set; } = new DateTime(1995, 1, 1);
        public Teacher Teacher { get; set; }
        
        public EnumRoleId RoleId { get; set; }
        
    }
}

public enum EnumRoleId
{
    Teacher=0,
    Student=1

}