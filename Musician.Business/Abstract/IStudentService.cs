using Musician.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Musician.Business.Abstract
{
    public interface IStudentService
    {
        Task CreateAsync();
        Task<Student> GetByIdAsync(int id);
        Task<List<Student>> GetAllAsync();
        void Update(Student student);
        void Delete(Student student);
    }
}
