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
    public class EnstrumentConfig : IEntityTypeConfiguration<Enstrument>
    {
        public void Configure(EntityTypeBuilder<Enstrument> builder)
        {
            builder.Property(x=>x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.Name).IsRequired().HasMaxLength(100);
            builder.HasData(
                new Enstrument { Id = 1, Name = "Gitar", IsApproved = true,Url="gitar" },
                new Enstrument { Id = 2, Name = "Keman", IsApproved = true,Url="keman" },
                new Enstrument { Id = 3, Name = "Piyano", IsApproved = true,Url="piyano" },
                new Enstrument { Id = 4, Name = "Bateri", IsApproved = true,Url="bateri" },
                new Enstrument { Id = 5, Name = "Flüt", IsApproved = true,Url="flut" },
                new Enstrument { Id = 6, Name = "Klarnet", IsApproved = true,Url="klarnet" },
                new Enstrument { Id = 7, Name = "Çello", IsApproved = true,Url="cello" },
                new Enstrument { Id = 8, Name = "Bağlama", IsApproved = true,Url="baglama" },
                new Enstrument { Id = 9, Name = "Ud", IsApproved = true,Url="ud" },
                new Enstrument { Id = 10, Name = "Kalimba", IsApproved = true,Url="kalimba", }
                );
        }
    }
}
