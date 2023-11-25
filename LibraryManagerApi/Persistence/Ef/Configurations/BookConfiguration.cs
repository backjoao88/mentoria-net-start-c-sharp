using Bogus;
using LibraryManagerApi.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LibraryManagerApi.Persistence.Ef.Configurations;

public class BookConfiguration : IEntityTypeConfiguration<Book>
{
    public void Configure(EntityTypeBuilder<Book> builder)
    {
        builder.HasKey(o => o.Id);
        builder.Property(o => o.Isbn).IsRequired();
        builder.Property(o => o.Title).IsRequired();
        builder.Property(o => o.Author).IsRequired();
        builder.Property(o => o.PublicationYear).IsRequired();

        var faker = new Faker<Book>("pt_BR")
            .RuleFor(o => o.Id, faker => faker.Random.Guid())
            .RuleFor(c => c.Title, f => f.Company.Random.Word())
            .RuleFor(c => c.Author, f => f.Name.FullName(Bogus.DataSets.Name.Gender.Female))
            .RuleFor(o => o.Isbn, faker => "ISBN_" + faker.Random.Guid().ToString())
            .RuleFor(o => o.PublicationYear, faker => faker.PickRandom(2020, 2021, 2022, 2023));

        builder.HasData(faker.Generate(10));
    }
}