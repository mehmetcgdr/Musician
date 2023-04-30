using Microsoft.EntityFrameworkCore;
using Musician.Data.Abstract;
using Musician.Data.Concrete.EfCore.Context;
using Musician.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Musician.Data.Concrete.EfCore
{
    public class EfCoreStudentRepository : EfCoreGenericRepository<Student>, IStudentRepository
    {
        public EfCoreStudentRepository(MusicianContext _appContext) : base(_appContext)
        {
        }
        MusicianContext AppContext
        {
            get { return _dbContext as MusicianContext; }
        }
        public async Task<List<Student>> GetAllStudentsAsync()
        {
            var students = await AppContext.Students.Include(s=>s.Image).ToListAsync();
            return students;
        }
        
        public async Task<Student> GetStudentByIdAsync(string id)
        {
            Student student= await AppContext.Students.FirstOrDefaultAsync(s=>s.UserId==id);
            return student;
        }
        
    }
}
