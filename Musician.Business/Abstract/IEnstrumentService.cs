using Musician.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Musician.Business.Abstract
{
    public interface IEnstrumentService
    {
        Task CreateAsync();
        Task<Enstrument> GetByIdAsync(int id);
        Task<List<Enstrument>> GetAllAsync();
        void Update(Enstrument enstrument);
        void Delete(Enstrument enstrument);
        

    }
}
