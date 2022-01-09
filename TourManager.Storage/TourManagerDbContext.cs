using Microsoft.EntityFrameworkCore;
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
        public DbSet<Column> Column { get; set; }
        public DbSet<Cell> Cell { get; set; }
        public DbSet<StandardColumn> StandardColumn { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Tourist>().Property(t => t.Id).HasColumnName("TouristId");
            modelBuilder.Entity<Tourist>().Property(t => t.TourId);
            modelBuilder.Entity<Tourist>().HasOne<Tour>().WithMany().HasForeignKey(t => t.TourId);

            modelBuilder.Entity<Tour>().Property(t => t.Id).HasColumnName("TourId");

            modelBuilder.Entity<Column>().Property(c => c.Id).HasColumnName("ColumnId");
            modelBuilder.Entity<Column>().HasOne<Tour>().WithMany().HasForeignKey(t => t.TourId);

            modelBuilder.Entity<Cell>().HasOne<Column>().WithMany().HasForeignKey(c => c.ColumnId);
            modelBuilder.Entity<Cell>().HasOne<Tourist>().WithMany().HasForeignKey(c => c.TouristId).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Cell>().HasKey(c => new { c.ColumnId, c.TouristId });
            modelBuilder.Entity<Cell>().Property(t => t.DecimalValue).HasColumnType("decimal(18,4)");

            modelBuilder.Entity<StandardColumn>().Property(sc => sc.Id).HasColumnName("StandardColumnId");

            modelBuilder.Seed();
        }

    }
}
