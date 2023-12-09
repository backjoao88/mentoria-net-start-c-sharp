using BloodDonationManager.Core.Entities;
using BloodDonationManager.Infrastructure.Persistence.Ef.Configurations;
using Microsoft.EntityFrameworkCore;

namespace BloodDonationManager.Infrastructure.Persistence.Ef;

public class EfDbContext : DbContext
{
    public DbSet<Donor> Donors { get; set;  } = null!;
    public DbSet<Donation> Donations { get; set;  } = null!;
    public DbSet<Stock> BloodStocks { get; set;  } = null!;

    public EfDbContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new DonorConfiguration());
        modelBuilder.ApplyConfiguration(new DonationConfiguration());
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseInMemoryDatabase("blood-donation");
        
    }
}