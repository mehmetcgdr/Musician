using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Musician.Entity.Abstract
{
    public interface IBaseEntity
    {
        public string Description { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public string City { get; set; }
<<<<<<< HEAD
=======
        public string District { get; set; }
>>>>>>> 5e78a95da77671fc536ce3dbf0d7cbdcd5348791
        public DateTime? DateOfBirth { get; set; }
        public string Url { get; set; }

    }
}
