using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using TourManager.Storage.Models;

namespace TourManager.Storage
{
    public class TourManagerDbContext : DbContext
    {
        public TourManagerDbContext(DbContextOptions<TourManagerDbContext> options)
            : base(options)
        {
        }

        public DbSet<Tourist> Tourist { get; set; }
        public DbSet<Tour> Tour { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Tourist>().Property(t => t.Id).HasColumnName("TouristId");
            modelBuilder.Entity<Tourist>().Property(t => t.ClosePrice).HasColumnType("decimal(18,4)");
            modelBuilder.Entity<Tourist>().Property(t => t.TourId);
            modelBuilder.Entity<Tourist>().HasOne<Tour>().WithMany().HasForeignKey(t => t.TourId);

            modelBuilder.Entity<Tour>().Property(t => t.Id).HasColumnName("TourId");
        }

    }
}
