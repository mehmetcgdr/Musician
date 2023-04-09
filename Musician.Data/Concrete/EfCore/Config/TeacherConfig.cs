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
            builder.Property(x => x.Age).IsRequired();
            builder.Property(x => x.CreatedDate).IsRequired();
            builder.Property(x => x.City).IsRequired();
            builder.Property(x => x.District).IsRequired();
            builder.Property(x => x.Description).IsRequired();
      
            builder.Property(x => x.Status).IsRequired();
            builder.Property(x => x.Gender).IsRequired();
            builder.HasData(
                new Teacher { Id = 1, FirstName = "Mehmet", LastName = "��g�der", Age = 27, Description = "Kalimba �al�yorum", Gender = "Erkek", IsApproved = true, Url = "mehmetocguder", City = "�stanbul", District = "Be�ikta�", CreatedDate = DateTime.Now, Status = "Home" },
                new Teacher { Id = 2, FirstName = "Canan", LastName = "asd", Age = 25, Description = "Kalimba �al�yorum", Gender = "Kad�n", IsApproved = true, Url = "canan", City = "�stanbul", District = "Be�ikta�", CreatedDate = DateTime.Now, Status = "Home" },
                new Teacher { Id = 3, FirstName = "Ezgi", LastName = "sdf", Age = 25, Description = "Kalimba �al�yorum", Gender = "Kad�n", IsApproved = true, Url = "ezgi", City = "�stanbul", District = "Be�ikta�", CreatedDate = DateTime.Now, Status = "Home" },
                new Teacher { Id = 4, FirstName = "Arda", LastName = "sss", Age = 22, Description = "Kalimba �al�yorum", Gender = "Erkek", IsApproved = true, Url = "arda", City = "�stanbul", District = "Be�ikta�", CreatedDate = DateTime.Now, Status = "Home" },
                new Teacher { Id = 5, FirstName = "Erdi", LastName = "asdf", Age = 24, Description = "Kalimba �al�yorum", Gender = "Erkek", IsApproved = true, Url = "erdi", City = "�stanbul", District = "Be�ikta�", CreatedDate = DateTime.Now, Status = "Home" },
                new Teacher { Id = 6, FirstName = "Ahmet", LastName = "fgd", Age = 23, Description = "Kalimba �al�yorum", Gender = "Erkek", IsApproved = true, Url = "ahmet", City = "�stanbul", District = "Be�ikta�", CreatedDate = DateTime.Now,Status="Home" }
            );
        }
    }
}
