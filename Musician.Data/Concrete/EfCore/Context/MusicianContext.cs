using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Musician.Data.Concrete.EfCore.Config;
using Musician.Data.Concrete.EfCore.Extensions;
using Musician.Entity.Concrete;
using Musician.Entity.Concrete.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
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
<<<<<<< HEAD
        public DbSet<Request> Requests { get; set; }

=======
>>>>>>> 5e78a95da77671fc536ce3dbf0d7cbdcd5348791

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.SeedData();
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(TeacherConfig).Assembly);
            base.OnModelCreating(modelBuilder);
        }


    }
}
