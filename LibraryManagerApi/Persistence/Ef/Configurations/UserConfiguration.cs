using Bogus;
using LibraryManagerApi.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LibraryManagerApi.Persistence.Ef.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(o => o.Id);
        builder.Property(o => o.Name).IsRequired();
        builder.Property(o => o.Email).IsRequired();
    }
}