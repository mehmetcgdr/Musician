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
        Task<List<Card>> GetFilterCardsAsync(string name);
        Task<Card> GetCardWithImageAsync(int id);
        Task<List<Card>> GetCardsInAdminAsync(string id);
    }   
}
