using BloodDonationManager.Core.Entities;
using BloodDonationManager.Infrastructure.Persistence.Ef.Configurations;
using Microsoft.EntityFrameworkCore;

namespace BloodDonationManager.Infrastructure.Persistence.Ef;

public class EfDbContext : DbContext
{
    public DbSet<Donor> Donors { get; } = null!;
    public DbSet<Donation> Donations { get; } = null!;
    public DbSet<Stock> BloodStocks { get; } = null!;

    public EfDbContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new DonorConfiguration());
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseInMemoryDatabase("blood-donation");
        
    }
}