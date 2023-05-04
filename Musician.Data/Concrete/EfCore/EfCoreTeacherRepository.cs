using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
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
            List<Teacher> teachers = await AppContext.Teachers.ToListAsync();
            return teachers;
        }

        public async Task<Teacher> GetTeacherByIdAsync(string id)
        {
            Teacher teacher = await AppContext.Teachers.Include(x=>x.User).ThenInclude(x=>x.Image).FirstOrDefaultAsync(t=>t.UserId==id);
            return teacher;
        }
        public async Task<Teacher> GetTeacherByCardId(int id)
        {
            Teacher teacher = await AppContext.Teachers.Include(x=>x.Cards).Where(x=>x.Id==id).FirstOrDefaultAsync();
            return teacher;
        }
        public async Task<Teacher> GetTeacherByCardAsync(Card card)
        {
            Teacher teacher = await AppContext.Teachers.Include(x=>x.Cards).Where(x=>x.Id == card.Id).FirstOrDefaultAsync();
            return teacher;
        }
    }
}
