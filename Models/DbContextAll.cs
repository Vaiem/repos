using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;


namespace BlogDesing.Models
{
    public class DbContextAll : DbContext
    {
        public DbContextAll(DbContextOptions<DbContextAll> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AutorToDesing>().HasKey(t => new { t.AutorId, t.DesingId });
        }
        public DbSet<Autor> autors { get; set; }
        public DbSet<Desing> desings { get; set; }
    }
}
