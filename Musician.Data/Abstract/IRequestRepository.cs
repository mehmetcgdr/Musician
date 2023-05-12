using Musician.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Musician.Data.Abstract
{
    public interface IRequestRepository :  IGenericRepository<Request>
    {
        Task<List<Request>> GetRequestsByTeacherAsync(int id);
        Task<List<Request>> GetRequestsByStudentAsync(string id);
        Task<List<Request>> GetRequestsInAdminAsync();
    }
}
