using CRM.Entities;
using Microsoft.EntityFrameworkCore;

namespace CRM.Context
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Costumer> Costumers { get; set; }
        public DbSet<Sale> Sales { get; set; }
        public DbSet<Visit> Visits { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Costumer>()
                .Property(c => c.TotalSalesValue)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Sale>()
                .Property(s => s.SalesPrice)
                .HasColumnType("decimal(18,2)");

            base.OnModelCreating(modelBuilder);
        }

    }
}
