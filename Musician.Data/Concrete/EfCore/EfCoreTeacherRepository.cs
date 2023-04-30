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
    public class EfCoreTeacherRepository : EfCoreGenericRepository<Teacher>, ITeacherRepository
    {
        public EfCoreTeacherRepository(MusicianContext _appContext) : base(_appContext)
        {
        }
        MusicianContext AppContext
        {
            get { return _dbContext as MusicianContext; }
        }

        public async Task<List<Teacher>> GetAllTeachersAsync()
        {
            List<Teacher> teachers = await AppContext.Teachers.Include(x=>x.Image).ToListAsync();
            return teachers;
        }

        public async Task<Teacher> GetTeacherByIdAsync(string id)
        {
            Teacher teacher = await AppContext.Teachers.Include(t=>t.Image).FirstOrDefaultAsync(t=>t.UserId==id);
            return teacher;
        }
        public async Task<Teacher> GetTeacherByCardId(int id)
        {
            Teacher teacher = await AppContext.Teachers.Include(x => x.Image).Include(x=>x.Cards).Where(x=>x.Id==id).FirstOrDefaultAsync();
            return teacher;
        }
    }
}
