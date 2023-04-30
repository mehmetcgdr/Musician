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

<<<<<<< HEAD
        public async Task DeleteAsync(Enstrument enstrument)
        {
           await _enstrumentRepository.DeleteAsync(enstrument);
=======
        public void Delete(Enstrument enstrument)
        {
            _enstrumentRepository.Delete(enstrument);
>>>>>>> 5e78a95da77671fc536ce3dbf0d7cbdcd5348791
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
