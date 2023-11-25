using Bogus;
using LibraryManagerApi.Core.Entities;
using LibraryManagerApi.Persistence.Ef.Configurations;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagerApi.Persistence.Ef;

public class DatabaseContext : DbContext
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new BookConfiguration());
        modelBuilder.ApplyConfiguration(new UserConfiguration());
        modelBuilder.ApplyConfiguration(new LoanConfiguration());
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseInMemoryDatabase("library");
    }
}