using BloodManager.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BloodManager.Infrastructure.Persistence.EfCore.Configurations;

public class DonationConfiguration : IEntityTypeConfiguration<Donation>
{
    public void Configure(EntityTypeBuilder<Donation> builder)
    {
        builder.ToTable("tbl_Donation");
        builder.HasKey(o => o.Id);
        builder.HasOne<Donor>().WithMany(o => o.Donations).HasForeignKey(o => o.IdDonor);
        builder.Property(o => o.DonationDate).HasColumnType("datetime");
        builder.Property(o => o.IdDonor).IsRequired(false);
        builder.Property(o => o.QuantityMl).IsRequired();
    }
}