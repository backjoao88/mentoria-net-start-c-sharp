using Bogus;
using LibraryManagerApi.Core.Entities;
using LibraryManagerApi.Persistence.Ef.Configurations;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagerApi.Persistence.Ef;

public class DatabaseContext : DbContext
{
    public DbSet<Book> Books { get; set;  } = null!;
    public DbSet<User> Users { get; set;  } = null!;
    public DbSet<Loan> Loans { get; set;  } = null!;
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new BookConfiguration());
        modelBuilder.ApplyConfiguration(new UserConfiguration());
        modelBuilder.ApplyConfiguration(new LoanConfiguration());
        
        // Fake data for books
        var fakerBook = new Faker<Book>("pt_BR")
            .RuleFor(o => o.Id, faker => faker.Random.Guid())
            .RuleFor(c => c.Title, f => f.Company.Random.Word())
            .RuleFor(c => c.Author, f => f.Name.FullName(Bogus.DataSets.Name.Gender.Female))
            .RuleFor(o => o.Isbn, faker => "ISBN_" + faker.Random.Guid().ToString())
            .RuleFor(o => o.PublicationYear, faker => faker.PickRandom(2020, 2021, 2022, 2023));
        var fakeBooks = fakerBook.Generate(10);
        var fakeBooksIds = fakeBooks.Select(o => o.Id);
        modelBuilder.Entity<Book>().HasData(fakeBooks);

        // Fake data for users
        var fakerUser = new Faker<User>("pt_BR")
            .RuleFor(o => o.Id, f => f.Random.Guid())
            .RuleFor(o => o.Name, f => f.Name.FullName(Bogus.DataSets.Name.Gender.Male))
            .RuleFor(c => c.Email, f => f.Company.Random.Word());
        var fakeUsers = fakerUser.Generate(20);
        var fakeUsersIds = fakeUsers.Select(o => o.Id);
        modelBuilder.Entity<User>().HasData(fakeUsers);
        
        // Fake data for loans
        var fakerLoan = new Faker<Loan>("pt_BR")
            .RuleFor(o => o.Id, f => f.Random.Guid())
            .RuleFor(o => o.IdBook, f => f.PickRandom(fakeBooksIds))
            .RuleFor(o => o.IdUser, f => f.PickRandom(fakeUsersIds))
            .RuleFor(o => o.Start, f => f.Date.Between(new DateTime(2023, 01, 01), new DateTime(2023, 12, 31)))
            .RuleFor(o => o.End, (_, l) => l.Start.AddDays(7));
        var fakeLoans = fakerLoan.Generate(10);
        modelBuilder.Entity<Loan>().HasData(fakeLoans);
    }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseInMemoryDatabase("library");
    }
}