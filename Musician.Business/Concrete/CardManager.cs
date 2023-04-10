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
    public class CardManager : ICardService
    {
       private ICardService _cardService;

        private ICardRepository _cardRepository;

        public CardManager(ICardRepository cardRepository)
        {
            _cardRepository = cardRepository;
        }

        public async Task CreateAsync(Card card)
        {
            await _cardRepository.CreateAsync(card);
        }

        public void Delete(Card card)
        {
            _cardRepository.Delete(card);
        }

        public async Task<List<Card>> GetAllAsync()
        {
            return await _cardRepository.GetAllAsync();
        }

        public async Task<Card> GetByIdAsync(int id)
        {
            return await _cardRepository.GetByIdAsync(id);
        }

        public void Update(Card card)
        {
            _cardRepository.Update(card);
        }
    }
}
