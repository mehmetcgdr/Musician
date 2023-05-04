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
            builder.Property(x => x.Status).IsRequired();
        
            //builder.HasData(
            //    new Teacher { Id = 1, FirstName = "Mehmet", LastName = "��g�der", DateOfBirth = new DateTime(1985, 5, 18), Description = "Kalimba �al�yorum", Gender = "Erkek", IsApproved = true, Url = "mehmetocguder", City = "�stanbul",  CreatedDate = DateTime.Now, Status = "Home",UserName="mehmetocguder",},

            //    new Teacher { Id = 2, FirstName = "Canan", LastName = "asd", DateOfBirth = new DateTime(1985, 5, 18), Description = "Kalimba �al�yorum", Gender = "Kad�n", IsApproved = true, Url = "canan", City = "�stanbul",  CreatedDate = DateTime.Now, Status = "Home", UserName = "canan" },

            //    new Teacher { Id = 3, FirstName = "Ezgi", LastName = "sdf", DateOfBirth = new DateTime(1985, 5, 18), Description = "Kalimba �al�yorum", Gender = "Kad�n", IsApproved = true, Url = "ezgi", City = "�stanbul",  CreatedDate = DateTime.Now, Status = "Home", UserName = "ezzgi" },

            //    new Teacher { Id = 4, FirstName = "Arda", LastName = "sss", DateOfBirth = new DateTime(1985, 5, 18), Description = "Kalimba �al�yorum", Gender = "Erkek", IsApproved = true, Url = "arda", City = "�stanbul",  CreatedDate = DateTime.Now, Status = "Home", UserName = "arda" },

            //    new Teacher { Id = 5, FirstName = "Erdi", LastName = "asdf", DateOfBirth = new DateTime(1985, 5, 18), Description = "Kalimba �al�yorum", Gender = "Erkek", IsApproved = true, Url = "erdi", City = "�stanbul",  CreatedDate = DateTime.Now, Status = "Home", UserName = "erdi" },

            //    new Teacher { Id = 6, FirstName = "Ahmet", LastName = "fgd", DateOfBirth = new DateTime(1985, 5, 18), Description = "Kalimba �al�yorum", Gender = "Erkek", IsApproved = true, Url = "ahmet", City = "�stanbul",  CreatedDate = DateTime.Now, Status = "Home", UserName = "ahmet", }
            //);
        }
    }
}
