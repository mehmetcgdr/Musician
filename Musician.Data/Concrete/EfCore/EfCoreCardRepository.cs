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
            var cards = await AppContext.Cards.ToListAsync();
            return cards;
        }

       

<<<<<<< HEAD
        public async Task<List<Card>> GetFilterCardsAsync(string name)
        {
            var cards = await AppContext.Cards.Include(x=>x.Image).Where(c=>c.NormalizedEnstrumentName.Contains(name)).ToListAsync();
=======
        public async Task<List<Card>> GetFilterCardsAsync(int id)
        {
            var cards = await AppContext.Cards.Include(x=>x.Image).Where(c=>c.Enstrument.Id==id).ToListAsync();
>>>>>>> 5e78a95da77671fc536ce3dbf0d7cbdcd5348791
                return cards;
        }
        public async Task<Card> GetCardWithImageAsync(int id)
        {
            var card = await AppContext.Cards.Include(x=>x.Image).Where(x=>x.Id== id).FirstOrDefaultAsync();
            return card;
        }
<<<<<<< HEAD

        public async Task<List<Card>> GetCardsInAdminAsync(string id)
        {
            if (String.IsNullOrEmpty( id))
            {
                List<Card> cards = await AppContext.Cards.Include(x => x.Image).ToListAsync();
                return cards;
            }
            else
            {
                List<Card> cards = await AppContext.Cards.Where(x => x.NormalizedEnstrumentName == id).Include(x => x.Image).ToListAsync();
                return cards;
            }
            

        }
=======
>>>>>>> 5e78a95da77671fc536ce3dbf0d7cbdcd5348791
    }
}
