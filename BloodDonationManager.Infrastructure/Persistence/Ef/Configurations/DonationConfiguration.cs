using BloodDonationManager.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BloodDonationManager.Infrastructure.Persistence.Ef.Configurations;

public class DonationConfiguration : IEntityTypeConfiguration<Donation>
{
    public void Configure(EntityTypeBuilder<Donation> builder)
    {
        builder.HasKey(o => o.Id);
        builder.Property(o => o.IdDonor).IsRequired();
        builder.HasOne<Donor>(o => o.Donor).WithMany().HasForeignKey(o => o.IdDonor);
        
    }
}