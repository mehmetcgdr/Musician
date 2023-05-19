using Microsoft.EntityFrameworkCore;
using Musician.Data.Abstract;
using Musician.Data.Concrete.EfCore.Context;
using Musician.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Musician.Data.Concrete.EfCore
{
    public class EfCoreCardRepository : EfCoreGenericRepository<Card>, ICardRepository
    {
        public EfCoreCardRepository(MusicianContext _appContext) : base(_appContext)
        {
        }
        MusicianContext AppContext
        {
            get { return _dbContext as MusicianContext; }
        }

        public async Task<List<Card>> GetAllCardsAsync()
        {
            var cards = await AppContext.Cards.Include(x => x.Image).ToListAsync();
            return cards;
        }

       

        public async Task<List<Card>> GetFilterCardsAsync(string name,string city)
        {
            var cards =  AppContext.Cards.Include(x => x.Image).Where(c => c.EnstrumentName == name).Where(a => a.City == city).AsQueryable();

            if (city == "Hepsi" || cards.Count() == 0)
            {
                return await AppContext.Cards.Include(x => x.Image).Where(c => c.EnstrumentName == name).ToListAsync();
            }
            else
            {
                return await cards.ToListAsync();
            }    
        }
        public async Task<Card> GetCardWithImageAsync(int id)
        {
            var card = await AppContext.Cards.Include(x=>x.Image).Where(x=>x.Id== id).FirstOrDefaultAsync();
            return card;
        }

        public async Task<List<Card>> GetCardsInAdminAsync(string id)
        {
            if (id=="name")
            {
                List<Card> cards = await AppContext.Cards.Include(x => x.Image).ToListAsync();
                return cards;
            }
            else
            {
                List<Card> cards = await AppContext.Cards.Where(x => x.EnstrumentName == id).Include(x => x.Image).ToListAsync();
                return cards;
            }
        }
        public async Task<List<Card>> GetCardsByTeacherAsync(int id)
        {
            var cards = await AppContext.Cards.Where(x=>x.Teacher.Id==id).ToListAsync();
            return cards;
        }
    }
}
