using Musician.Entity.Concrete;
using Musician.Entity.Concrete.Identity;
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
        Task<Teacher> GetByIdAsync(string id);
        Task<List<Teacher>> GetAllAsync();
        void Update(Teacher teacher);
        Task DeleteAsync(Teacher teacher);
        Task<List<Teacher>> GetAllTeachersAsync();
        Task<Teacher> GetTeacherByIdAsync(string id);
        Task<Teacher> GetTeacherByCardId(int id);

    }
}
