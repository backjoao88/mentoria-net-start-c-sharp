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
    }
}