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
    public class EfCoreRequestRepository : EfCoreGenericRepository<Request>, IRequestRepository
    {
        public EfCoreRequestRepository(MusicianContext _appContext) : base(_appContext)
        {
        }
        MusicianContext AppContext
        {
            get { return _dbContext as MusicianContext; }
        }

        public async Task<List<Request>> GetRequestsByStudentAsync(string id)
        {
            var requests = await AppContext.Requests.Where(x=>x.Student.UserId == id).ToListAsync();
            return requests;
        }
        public async Task<List<Request>> GetRequestsInAdminAsync()
        {
            var requests = await AppContext.Requests.Include(x=>x.Card).ThenInclude(x=>x.Teacher).ThenInclude(x=>x.User).Include(x=>x.Student).ThenInclude(x=>x.User).ToListAsync();
            return requests;
        }

        public async Task<List<Request>> GetRequestsByTeacherAsync(int id)
        {
            var requests =await  AppContext.Requests.Include(x=>x.Student).ThenInclude(x=>x.User).Where(c => c.TeacherId == id).ToListAsync();
            return requests;
        }
    }
}
