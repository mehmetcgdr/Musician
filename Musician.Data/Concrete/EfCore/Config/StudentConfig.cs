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
    internal class StudentConfig : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.FirstName).IsRequired().HasMaxLength(50);
            builder.Property(x => x.LastName).IsRequired().HasMaxLength(50);
            builder.Property(x => x.DateOfBirth).IsRequired();
            builder.Property(x => x.CreatedDate).IsRequired();
            builder.Property(x => x.City).IsRequired();
            builder.Property(x => x.Description).IsRequired();
            builder.Property(x => x.Gender).IsRequired();
            //builder.HasData(
            //     new Student { Id = 1, FirstName = "Şeyma", LastName = "Cankuş", DateOfBirth = new DateTime(1985, 5, 18), Description = "gitar öğrenmek istiyorum", Gender = "Kadın", Url = "seyma-cankus", City = "İstanbul",  CreatedDate = DateTime.Now, },
            //     new Student { Id = 2, FirstName = "Sema", LastName = "asd", DateOfBirth = new DateTime(1985, 5, 18), Description = "keman öğrenmek istiyorum", Gender = "Kadın", Url = "sema-asd", City = "İstanbul",  CreatedDate = DateTime.Now, }, 
            //     new Student { Id = 3, FirstName = "Uğurcan", LastName = "Emare", DateOfBirth = new DateTime(1985, 5, 18), Description = "kalimba öğrenmek istiyorum", Gender = "Erkek", Url = "ugurcan-emare", City = "İstanbul", CreatedDate = DateTime.Now, }
            //    );
        }
    }
}
