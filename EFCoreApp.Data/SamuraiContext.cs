using EFCoreApp.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreApp.Data
{
    public class SamuraiContext : DbContext
    {
        public DbSet<Samurai> Samurais { get; set; }
        public DbSet<Quote> Quotes { get; set; }
        public DbSet<Battle> Battles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                 "Server = (localdb)\\mssqllocaldb; Database = EFCoreApp; Trusted_Connection = True; ");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SamuraiBattle>().HasKey(x => new { x.SamuraiId, x.BattleId });
        }
    }
}
