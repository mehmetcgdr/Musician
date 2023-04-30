﻿using Microsoft.EntityFrameworkCore;
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

       

        public async Task<List<Card>> GetFilterCardsAsync(string name)
        {
            var cards = await AppContext.Cards.Include(x=>x.Image).Where(c=>c.NormalizedEnstrumentName.Contains(name)).ToListAsync();
                return cards;
        }
        public async Task<Card> GetCardWithImageAsync(int id)
        {
            var card = await AppContext.Cards.Include(x=>x.Image).Where(x=>x.Id== id).FirstOrDefaultAsync();
            return card;
        }

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
    }
}