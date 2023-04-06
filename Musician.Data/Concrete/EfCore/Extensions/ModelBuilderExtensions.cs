using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Musician.Entity.Concrete;
using Musician.Entity.Concrete.Identity;

namespace Musician.Data.Concrete.EfCore.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static void SeedData(this ModelBuilder modelBuilder)
        {
            #region Rol
            List<Role> roles = new List<Role>
            {
                new Role{Name="Admin",Description="Admin",NormalizedName="ADMIN"},
                new Role{Name="Teacher",Description="Öğretmen",NormalizedName="TEACHER"},
                new Role{Name="Student",Description="Öğrenci",NormalizedName="STUDENT"},
            };
            modelBuilder.Entity<Role>().HasData(roles);
            #endregion
            #region User
            List<User> users = new List<User> {
            new User{
                FirstName="Ege",LastName="ilk",UserName="ege",NormalizedUserName="EGE",Email="ege@gmail.com",NormalizedEmail="EGE@GMAIL.COM",Gender="Erkek",Age=16,City="İstanbul",Description="asd",District="Beşiktaş"
            },
            new User{
                FirstName="Ece",LastName="Orta",UserName="ece",NormalizedUserName="ECE",Email="ece@gmail.com",NormalizedEmail="ECE@GMAIL.COM",Gender="Kadın",Age=32,City="İstanbul",Description="asd",District="Kadıköy"
            },
            new User{
                FirstName="Efe",LastName="Son",UserName="efe",NormalizedUserName="EFE",Email="efe@gmail.com",NormalizedEmail="EFE@GMAIL.COM",Gender="Erkek",Age=27,City="İstanbul",Description="asd",District="Bahçelievler"
            }
        };
            modelBuilder.Entity<User>().HasData(users);
            #endregion
            #region Parola

            #endregion
            #region Rol Atama

            #endregion
            #region Cart?

            #endregion
        }
    }
}