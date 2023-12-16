using BloodManager.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BloodManager.Infrastructure.Persistence.EfCore.Configurations;

public class StockConfiguration : IEntityTypeConfiguration<Stock>
{
    public void Configure(EntityTypeBuilder<Stock> builder)
    {
        builder.ToTable("tbl_Stock");
        builder.HasKey(o => o.Id);
        builder.Property(o => o.RhFactorType).IsRequired();
        builder.Property(o => o.BloodType).IsRequired();
        builder.Property(o => o.Quantity).IsRequired();
    }
}