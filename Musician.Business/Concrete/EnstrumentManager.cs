using Musician.Business.Abstract;
using Musician.Data.Abstract;
using Musician.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Musician.Business.Concrete
{
    public class EnstrumentManager : IEnstrumentService
    {
        private IEnstrumentRepository _enstrumentRepository;

        public EnstrumentManager(IEnstrumentRepository enstrumentRepository)
        {
            _enstrumentRepository = enstrumentRepository;
        }

        public async Task CreateAsync(Enstrument enstrument)
        {
            await _enstrumentRepository.CreateAsync(enstrument);
        }

        public async Task DeleteAsync(Enstrument enstrument)
        {
           await _enstrumentRepository.DeleteAsync(enstrument);
        }

        public async Task<List<Enstrument>> GetAllAsync()
        {
           return await _enstrumentRepository.GetAllAsync();
        }

        public async Task<Enstrument> GetByIdAsync(int id)
        {
          return await _enstrumentRepository.GetByIdAsync(id);
        }

        public void Update(Enstrument enstrument)
        {
            _enstrumentRepository.Update(enstrument);
        }
    }
}
