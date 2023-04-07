using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Musician.Entity.Concrete
{
    public class StudentLessonCart
    {
        public int StudentId { get; set; }
        public int LessonCartId { get; set; }
        public Student Student { get; set; }
        public LessonCart LessonCart { get; set; }

    }
}
