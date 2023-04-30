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
        Task CreateAsync(Student student);
        Task<Student> GetByIdAsync(int id);
        Task<List<Student>> GetAllAsync();
        void Update(Student student);
        Task DeleteAsync(Student student);
        Task<List<Student>> GetAllStudentsAsync();
        Task<Student> GetStudentByIdAsync(string id);
        
    }
}
