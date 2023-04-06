using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Musician.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Musician.Data.Concrete.EfCore.Context
{
    public class MusicianContext : DbContext
    {
       
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Enstrument> Enstruments { get; set; }
        public DbSet<TeacherEnstrument> TeacherEnstruments { get; set; }
        public DbSet<Image> Images { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source = Musician.db");
            base.OnConfiguring(optionsBuilder); 
        }
        

    }
}
