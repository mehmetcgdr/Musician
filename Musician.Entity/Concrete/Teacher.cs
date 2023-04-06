using Musician.Entity.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Musician.Entity.Concrete
{
    public class Teacher : IBaseEntity
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
        public string Status { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsApproved { get; set; }
        public Image Image { get; set; }
        public List<Enstrument> Enstruments { get; set; }
    }
}
