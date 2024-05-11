using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BusinessLayer;

namespace DataLayer
{
    public class CardsDbContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DANI\\SQLEXPRESS;Database=YuGiOh_Database;Trusted_Connection=True;TrustServerCertificate=True;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public CardsDbContext() { }
        public CardsDbContext(DbContextOptions options)
            : base(options) { }

        public DbSet<Monster> Monsters { get; set; }
        public DbSet<Spell> Spells { get; set; }
        public DbSet<Trap> Traps { get; set; }
        public DbSet<Deck> Decks { get; set; }
    }
}
