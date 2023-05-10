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

        public async Task<List<Card>> GetCardsInAdminAsync(string id)
        {
            return await _cardRepository.GetCardsInAdminAsync(id);
        }

        public async Task<Card> GetCardWithImageAsync(int id)
        {
            return await _cardRepository.GetCardWithImageAsync(id);
        }

        public async Task<List<Card>> GetFilterCardsAsync(string name,string city)
        {
            return await _cardRepository.GetFilterCardsAsync(name,city);
        }

        public void Update(Card card)
        {
            _cardRepository.Update(card);
        }
        public async Task<List<Card>> GetCardsByTeacherAsync(int id)
        {
            return await _cardRepository.GetCardsByTeacherAsync(id);
        }
    }
}
