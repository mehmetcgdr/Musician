using Musician.Business.Abstract;
using Musician.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Musician.Business.Concrete
{
    public class CardManager : ICardService
    {
       private ICardService _cardService;

        public CardManager(ICardService cardService)
        {
            _cardService = cardService;
        }

        public async Task CreateAsync(Card card)
        {
            await _cardService.CreateAsync(card);
        }

        public void Delete(Card card)
        {
            _cardService.Delete(card);
        }

        public async Task<List<Card>> GetAllAsync()
        {
            return await _cardService.GetAllAsync();
        }

        public async Task<Card> GetByIdAsync(int id)
        {
            return await _cardService.GetByIdAsync(id);
        }

        public void Update(Card card)
        {
            _cardService.Update(card);
        }
    }
}
