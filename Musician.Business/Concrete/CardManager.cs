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

        private ICardRepository _cardRepository;

        public CardManager(ICardRepository cardRepository)
        {
            _cardRepository = cardRepository;
        }

        public async Task CreateAsync(Card card)
        {
            await _cardRepository.CreateAsync(card);
        }

        public async Task DeleteAsync(Card card)
        {
           await _cardRepository.DeleteAsync(card);
        }

        public async Task<List<Card>> GetAllAsync()
        {
            return await _cardRepository.GetAllAsync();
        }

        public async Task<Card> GetByIdAsync(int id)
        {
            return await _cardRepository.GetByIdAsync(id);
        }

<<<<<<< HEAD
        public async Task<List<Card>> GetCardsInAdminAsync(string id)
        {
            return await _cardRepository.GetCardsInAdminAsync(id);
        }

=======
>>>>>>> 5e78a95da77671fc536ce3dbf0d7cbdcd5348791
        public async Task<Card> GetCardWithImageAsync(int id)
        {
            return await _cardRepository.GetCardWithImageAsync(id);
        }

<<<<<<< HEAD
        public async Task<List<Card>> GetFilterCardsAsync(string name)
        {
            return await _cardRepository.GetFilterCardsAsync(name);
=======
        public async Task<List<Card>> GetFilterCardsAsync(int id)
        {
            return await _cardRepository.GetFilterCardsAsync(id);
>>>>>>> 5e78a95da77671fc536ce3dbf0d7cbdcd5348791
        }

        public void Update(Card card)
        {
            _cardRepository.Update(card);
        }
    }
}
