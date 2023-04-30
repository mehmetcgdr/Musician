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
    public class ImageManager : IImageService
    {
        private IImageRepository _imageRepository;

        public ImageManager(IImageRepository imageRepository)
        {
            _imageRepository = imageRepository;
        }

        public async Task CreateAsync(Image image)
        {
            await _imageRepository.CreateAsync(image);
        }

        public async Task DeleteAsync(Image image)
        {
           await _imageRepository.DeleteAsync(image);
        }

        public async Task<List<Image>> GetAllAsync()
        {
            return await _imageRepository.GetAllAsync();
        }

        public async Task<Image> GetByIdAsync(int id)
        {
           return await _imageRepository.GetByIdAsync(id);
        }

        public void Update(Image image)
        {
            _imageRepository.Update(image);
        }
    }
}
