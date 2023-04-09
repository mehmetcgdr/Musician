using Musician.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Musician.Business.Abstract
{
    public interface ITeacherService
    {
        Task CreateAsync(Teacher teacher);
        Task<Teacher> GetByIdAsync(int id);
        Task<List<Teacher>> GetAllAsync();
        void Update(Teacher teacher);
        void Delete(Teacher teacher);
       
    }
}
