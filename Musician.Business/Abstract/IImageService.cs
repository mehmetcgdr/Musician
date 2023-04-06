using Musician.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Musician.Business.Abstract
{
    public interface IImageService
    {
        Task CreateAsync();
        Task<Image> GetByIdAsync(int id);
        Task<List<Image>> GetAllAsync();
        void Update(Image image);
        void Delete(Image image);
    }
}
