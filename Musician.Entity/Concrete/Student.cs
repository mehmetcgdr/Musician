using Musician.Entity.Abstract;
using Musician.Entity.Concrete.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Musician.Entity.Concrete
{
    public class Student : IBaseEntity
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }
        public string UserName { get; set; }
        public DateTime CreatedDate { get; set; }=DateTime.Now;
        public DateTime ModifiedDate { get; set; }

        public bool IsApproved { get; set; } = false;
        public List<Card> Cards { get; set; } = new List<Card>();
        public Card Card { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Description { get; set; } = "";
        public string Gender { get; set; } = "";
        public string City { get; set; } = "";
        public DateTime? DateOfBirth { get; set; } = new DateTime(1995, 1, 1);
        public string Url { get; set; }
        public Image Image { get; set; }

    }
}
