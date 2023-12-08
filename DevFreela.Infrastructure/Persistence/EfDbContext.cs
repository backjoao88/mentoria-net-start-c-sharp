using DevFreela.Core.Entities;
using DevFreela.Infrastructure.Persistence.Configurations;
using Microsoft.EntityFrameworkCore;

namespace DevFreela.Infrastructure.Persistence;

public class EfDbContext : DbContext
{
    public required DbSet<Customer> Customers { get; set; }

    public EfDbContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new CustomerConfiguration());
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseInMemoryDatabase("freela");
    }
}