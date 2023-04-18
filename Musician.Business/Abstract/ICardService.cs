using Musician.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Musician.Business.Abstract
{
    public interface ICardService
    {
        Task CreateAsync(Card card);
        Task<Card> GetByIdAsync(int id);
        Task<List<Card>> GetAllAsync();
        void Update(Card card);
        void Delete(Card card);
        Task<List<Card>> GetFilterCardsAsync(int id);
        Task<Card> GetCardWithImageAsync(int id);

    }
}
