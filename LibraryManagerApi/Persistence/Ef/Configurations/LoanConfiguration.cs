using Bogus;
using LibraryManagerApi.Core;
using LibraryManagerApi.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LibraryManagerApi.Persistence.Ef.Configurations;

public class LoanConfiguration : IEntityTypeConfiguration<Loan>
{
    public void Configure(EntityTypeBuilder<Loan> builder)
    {
        builder.HasKey(o => o.Id);
        builder.Property(o => o.IdBook).IsRequired();
        builder.Property(o => o.IdUser).IsRequired();
        builder.HasOne(o => o.Book).WithMany().HasForeignKey(o => o.IdBook);
        builder.HasOne(o => o.User).WithMany().HasForeignKey(o => o.IdUser);
    }
}