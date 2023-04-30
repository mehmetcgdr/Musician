using Musician.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Musician.Data.Abstract
{
    public interface ICardRepository :IGenericRepository<Card>
    {
        Task<List<Card>> GetAllCardsAsync();
<<<<<<< HEAD
        Task<List<Card>> GetFilterCardsAsync(string name);
        Task<Card> GetCardWithImageAsync(int id);
        Task<List<Card>> GetCardsInAdminAsync(string id);
=======
        Task<List<Card>> GetFilterCardsAsync(int id);
        Task<Card> GetCardWithImageAsync(int id);
>>>>>>> 5e78a95da77671fc536ce3dbf0d7cbdcd5348791
    }   
}
