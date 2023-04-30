using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
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
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public DateTime? DateOfBirth { get; set; } = new DateTime(1995, 1, 1);
        public Teacher Teacher { get; set; }
        public Student Student { get; set; }
        public EnumRoleId RoleId { get; set; }
        public Image? Image { get; set; }

    }
}

public enum EnumRoleId
{
    Teacher=0,
    Student=1,
    Admin=2

}