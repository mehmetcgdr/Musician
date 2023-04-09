using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Musician.Entity.Concrete
{
    public class TeacherCard
    {
        public int TeacherId { get; set; }
        public int CardId { get; set; }
        public Teacher Teacher { get; set; }
        public Card Card { get; set; }
    }
}
