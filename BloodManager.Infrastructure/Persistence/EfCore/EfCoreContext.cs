using BloodManager.Core.Entities;
using BloodManager.Infrastructure.Persistence.EfCore.Configurations;
using Microsoft.EntityFrameworkCore;

namespace BloodManager.Infrastructure.Persistence.EfCore;

public class EfCoreContext : DbContext
{
    public DbSet<Donor> Donors { get; set; } = null!;
    public DbSet<Donation> Donations { get; set; } = null!;
    public DbSet<Stock> Stocks { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new DonorConfiguration());
        modelBuilder.ApplyConfiguration(new DonationConfiguration());
        modelBuilder.ApplyConfiguration(new StockConfiguration());
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(
            "Server=DESKTOP-N7P7NAN\\SQLEXPRESS01;User=sa;Database=donation-db;Password=joao#123;TrustServerCertificate=true;");
    }
}