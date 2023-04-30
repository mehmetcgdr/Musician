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
    public class EfCoreEnstrumentRepository : EfCoreGenericRepository<Enstrument>, IEnstrumentRepository
    {
        public EfCoreEnstrumentRepository(MusicianContext _appContext) : base(_appContext)
        {
        }
        MusicianContext AppContext
        {
            get { return _dbContext as MusicianContext; }
        }
        public async Task<List<Enstrument>> GetAllEnstrumentsAsync()
        {
            var enstruments = await AppContext.Enstruments.ToListAsync();
            return enstruments;
        }
    }
}
