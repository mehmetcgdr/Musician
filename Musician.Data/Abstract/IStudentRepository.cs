using Musician.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Musician.Data.Abstract
{
    public interface IStudentRepository :IGenericRepository<Student>
    {
        Task<List<Student>> GetAllStudentsAsync();
<<<<<<< HEAD
        Task<Student> GetStudentByIdAsync(string id);

        
=======

>>>>>>> 5e78a95da77671fc536ce3dbf0d7cbdcd5348791
    }
}
