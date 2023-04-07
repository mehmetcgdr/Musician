using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Musician.Entity.Concrete
{
    public class Enstrument
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsApproved { get; set; }
        public string Url { get; set; }
        public List<Image> Images { get; set; }
        public List<Teacher> Teachers { get; set; }
        public Teacher Teacher { get; set; }
        public string TeacherIds { get; set; }
    }
}
