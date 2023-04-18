using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Musician.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Musician.Data.Concrete.EfCore.Config
{
    public class CardConfig : IEntityTypeConfiguration<Card>
    {
        public void Configure(EntityTypeBuilder<Card> builder)
        {
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.FirstName).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Price).IsRequired();
            builder.Property(x => x.City).IsRequired();
            builder.Property(x => x.EnstrumentName).IsRequired();
            
            builder.HasData(
                new Card { FirstName = "Ahmet", City = "İstanbul", Description = "Kaval dersi veriyorum", Id = 1, Price = 250,  EnstrumentName = "Kaval" },

                new Card { FirstName = "Mehmet", City = "İstanbul", Description = "Gitar dersi veriyorum", Id = 2,Price = 270,  EnstrumentName = "Gitar" },

                new Card { FirstName = "Ezgi", City = "İstanbul", Description = "Kalimba dersi veriyorum", Id = 3,Price = 240,  EnstrumentName = "Kalimba" },

                new Card { FirstName = "Arda", City = "İstanbul", Description = "Kaval dersi veriyorum", Id = 4,  Price = 250,  EnstrumentName = "Kaval" },

                new Card { FirstName = "Erdi", City = "İstanbul", Description = "Kaval dersi veriyorum", Id = 5,  Price = 350,  EnstrumentName = "Kaval" },

                new Card { FirstName = "Ulaş", City = "İstanbul", Description = "Kaval dersi veriyorum", Id = 6,  Price = 150,  EnstrumentName = "Kaval" },


                new Card { FirstName = "Canan", City = "İstanbul", Description = "Kaval dersi veriyorum", Id = 7, Price = 200,  EnstrumentName = "Kaval" },

                new Card { FirstName = "İlknur", City = "İstanbul", Description = "Kaval dersi veriyorum", Id = 8,Price = 400,  EnstrumentName = "Kaval" },

                new Card { FirstName = "Hakan", City = "İstanbul", Description = "Kaval dersi veriyorum", Id = 9, Price = 180,  EnstrumentName = "Kaval" }

                );
        }
    }
}
