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
        
        public List<Card>? Cards { get; set; } =new List<Card>();
        public string Status { get; set; } = string.Empty;
    }
}
