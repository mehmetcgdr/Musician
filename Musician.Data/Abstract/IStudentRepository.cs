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

    }
}
