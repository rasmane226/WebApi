using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class DataContext: DbContext
    {
        public DataContext() { }
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Bolumler> Bolumlers { get; set; }
        public DbSet<Urunler> Urunlers { get; set; }
        public DbSet<Markalar> Markalars { get; set; }
        public DbSet<Modeller> Modellers { get; set; }
        public DbSet<Depogirisi> Depogirisis { get; set; }
        public DbSet<Depocikisi> Depocikisis { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Urunler>()
                .HasOne(r => r.Bolumler)
                .WithMany(b => b.Urunlers)
                .HasForeignKey(r => r.BolumlerId);

            modelBuilder.Entity<Markalar>()
               .HasOne(r => r.Urunler)
               .WithMany(b => b.Markalars)
               .HasForeignKey(r => r.UrunlerId);

            modelBuilder.Entity<Modeller>()
               .HasOne(r => r.Markalar)
               .WithMany(b => b.Modellers)
               .HasForeignKey(r => r.MarkalarId);

          
        }

    }
}
