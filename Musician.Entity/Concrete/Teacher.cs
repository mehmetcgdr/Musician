using Musician.Entity.Abstract;
using Musician.Entity.Concrete.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Musician.Entity.Concrete
{
    public class Teacher : IBaseEntity
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }
        public string Url { get; set; }
        public string UserName { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsApproved { get; set; } = false;
        public List<Card> Cards { get; set; } =new List<Card>();
        public Card Card { get; set; }
        public string Status { get; set; } = string.Empty;
        public string Description { get; set; } = "";
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; } = "";
        public string City { get; set; } = "";
        public string District { get; set; } = "";
        public string PhoneNumber { get; set; } = "";
        public DateTime? DateOfBirth { get; set; } = new DateTime(1995, 1, 1);
        public Image Image { get; set; } 
        

    }
}
