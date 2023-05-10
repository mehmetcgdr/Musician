using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
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
                new Role{Name="User",Description="User",NormalizedName="USER"},
            };
            modelBuilder.Entity<Role>().HasData(roles);
            #endregion


            //List<Image> images = new List<Image>
            //{
            //    new Image{Id=1,Url="genel.png",UserId="1"},
            //    new Image{Id=2,Url="genel.png",UserId="2"},
            //    new Image{Id=3,Url="genel.png",UserId="3"},
            //};
            //modelBuilder.Entity<Image>().HasData(images);


        //    #region User
        //    List<User> users = new List<User> {
        //    new User{Id="1",
        //        FirstName="Ege",LastName="ilk",UserName="admin",NormalizedUserName="ADMIN",Email="ege@gmail.com",NormalizedEmail="EGE@GMAIL.COM",Gender="Erkek",DateOfBirth = new DateTime(1985, 5, 18) ,City="İstanbul",Description="asd",ImageId=images[0].Id
        //    },
        //    new User{Id="2",
        //        FirstName="Ece",LastName="Orta",UserName="teacher",NormalizedUserName="TEACHER",Email="ece@gmail.com",NormalizedEmail="ECE@GMAIL.COM",Gender="Kadın",DateOfBirth = new DateTime(1985, 5, 18),City="İstanbul",Description="asd",ImageId=images[0].Id
        //    },
        //    new User{Id="3",
        //        FirstName="Efe",LastName="Son",UserName="student",NormalizedUserName="STUDENT",Email="efe@gmail.com",NormalizedEmail="EFE@GMAIL.COM",Gender="Erkek",DateOfBirth = new DateTime(1985, 5, 18),City="İstanbul",Description="asd",ImageId=images[0].Id
        //    }
        //};
        //    modelBuilder.Entity<User>().HasData(users);
        //    #endregion

            //    List<Teacher> teachers = new List<Teacher>
            //    {
            //        new Teacher{Id=1,UserId=users[1].Id,}
            //    };modelBuilder.Entity<Teacher>().HasData(teachers);


            //    List<Card> cards = new List<Card>
            //    {
            //        new Card
            //        {
            //            Id=1,
            //            ImageId=images[0].Id,
            //           FirstName = "Mehmet",
            //           EnstrumentName = "Gitar",
            //           OwnDescription = "Gitar çalmak için eğitimler vereceğim.",
            //           Status = "Yüz yüze",
            //           Description = "Güzel bir ders olacak",
            //           Price = 450,
            //           City="istanbul",
            //          TeacherId=teachers[0].Id
            //          }
            //    };
            //    modelBuilder.Entity<Card>().HasData(cards);






            //#region Parola
            //var passwordHasher = new PasswordHasher<User>();
            //users[0].PasswordHash = passwordHasher.HashPassword(users[0], "Qwe123.");
            //users[1].PasswordHash = passwordHasher.HashPassword(users[1], "Qwe123.");
            //users[2].PasswordHash = passwordHasher.HashPassword(users[2], "Qwe123.");


            //#endregion

            //#region Rol Atama
            //List<IdentityUserRole<string>> userRoles = new List<IdentityUserRole<string>>
            //{
            //    new IdentityUserRole<string>{UserId=users[0].Id,RoleId=roles[0].Id},
            //    new IdentityUserRole<string>{UserId=users[1].Id,RoleId=roles[1].Id},
            //    new IdentityUserRole<string>{UserId=users[2].Id,RoleId=roles[2].Id},
            //};
            //modelBuilder.Entity<IdentityUserRole<string>>().HasData(userRoles);
            //#endregion
            //#region Cart? yapılmadı

            //#endregion
        }
    }
}