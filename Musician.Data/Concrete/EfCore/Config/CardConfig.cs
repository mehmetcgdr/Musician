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

            //builder.HasData(
            //   new Card
            //   {
            //       FirstName = "Mehmet",
            //       City = "istanbul",
            //       EnstrumentName = "Gitar",
            //       OwnDescription = "Gitar çalmak için eğitimler vereceğim.",
            //       Status = "Yüz yüze",
            //       Description = "Güzel bir ders olacak",
            //       Price = 450,
            //       Id = 1,
            //       Image = new Image
            //       {
            //           Id = 1,
            //           UserId = "1",
            //           Url="genel.png"
            //       }
            //   }


            //  );
        }
    }
}
