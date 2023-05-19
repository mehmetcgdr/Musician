using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Musician.Data.Concrete.EfCore.Config;
using Musician.Data.Concrete.EfCore.Extensions;
using Musician.Entity.Concrete;
using Musician.Entity.Concrete.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Musician.Data.Concrete.EfCore.Context
{
    public class MusicianContext : IdentityDbContext<User, Role, string>
    {
        public MusicianContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Card> Cards { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Enstrument> Enstruments { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Request> Requests { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.SeedData();
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(TeacherConfig).Assembly);

            modelBuilder.Entity<User>()
                .HasOne(x => x.Student)
                .WithOne(x => x.User)
                .HasForeignKey<Student>(x => x.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<User>()
                .HasOne(x => x.Teacher)
                .WithOne(x => x.User)
                .HasForeignKey<Teacher>(x => x.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<User>()
                .HasOne(x => x.Image)
                .WithOne(x => x.User)
                .HasForeignKey<Image>(x => x.UserId)
                .OnDelete(DeleteBehavior.Cascade);



            base.OnModelCreating(modelBuilder);
        }


    }
}
