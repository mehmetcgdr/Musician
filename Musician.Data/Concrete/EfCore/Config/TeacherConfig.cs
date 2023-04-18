using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Musician.Entity.Concrete;

namespace Musician.Data.Concrete.EfCore.Config
{
    public class TeacherConfig : IEntityTypeConfiguration<Teacher>
    {
        public void Configure(EntityTypeBuilder<Teacher> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.FirstName).IsRequired().HasMaxLength(50);
            builder.Property(x => x.LastName).IsRequired().HasMaxLength(50);
            builder.Property(x => x.DateOfBirth).IsRequired();
            builder.Property(x => x.CreatedDate).IsRequired();
            builder.Property(x => x.City).IsRequired();
            builder.Property(x => x.District).IsRequired();
            builder.Property(x => x.Description).IsRequired();
      
            builder.Property(x => x.Status).IsRequired();
            builder.Property(x => x.Gender).IsRequired();
            builder.HasData(
                new Teacher { Id = 1, FirstName = "Mehmet", LastName = "Öçgüder", DateOfBirth = new DateTime(1985, 5, 18), Description = "Kalimba çalýyorum", Gender = "Erkek", IsApproved = true, Url = "mehmetocguder", City = "Ýstanbul", District = "Beþiktaþ", CreatedDate = DateTime.Now, Status = "Home",UserName="mehmetocguder",},

                new Teacher { Id = 2, FirstName = "Canan", LastName = "asd", DateOfBirth = new DateTime(1985, 5, 18), Description = "Kalimba çalýyorum", Gender = "Kadýn", IsApproved = true, Url = "canan", City = "Ýstanbul", District = "Beþiktaþ", CreatedDate = DateTime.Now, Status = "Home", UserName = "canan" },

                new Teacher { Id = 3, FirstName = "Ezgi", LastName = "sdf", DateOfBirth = new DateTime(1985, 5, 18), Description = "Kalimba çalýyorum", Gender = "Kadýn", IsApproved = true, Url = "ezgi", City = "Ýstanbul", District = "Beþiktaþ", CreatedDate = DateTime.Now, Status = "Home", UserName = "ezzgi" },

                new Teacher { Id = 4, FirstName = "Arda", LastName = "sss", DateOfBirth = new DateTime(1985, 5, 18), Description = "Kalimba çalýyorum", Gender = "Erkek", IsApproved = true, Url = "arda", City = "Ýstanbul", District = "Beþiktaþ", CreatedDate = DateTime.Now, Status = "Home", UserName = "arda" },

                new Teacher { Id = 5, FirstName = "Erdi", LastName = "asdf", DateOfBirth = new DateTime(1985, 5, 18), Description = "Kalimba çalýyorum", Gender = "Erkek", IsApproved = true, Url = "erdi", City = "Ýstanbul", District = "Beþiktaþ", CreatedDate = DateTime.Now, Status = "Home", UserName = "erdi" },

                new Teacher { Id = 6, FirstName = "Ahmet", LastName = "fgd", DateOfBirth = new DateTime(1985, 5, 18), Description = "Kalimba çalýyorum", Gender = "Erkek", IsApproved = true, Url = "ahmet", City = "Ýstanbul", District = "Beþiktaþ", CreatedDate = DateTime.Now, Status = "Home", UserName = "ahmet", }
            );
        }
    }
}
