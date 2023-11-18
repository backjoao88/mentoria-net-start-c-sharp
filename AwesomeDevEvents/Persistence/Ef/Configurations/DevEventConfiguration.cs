using AwesomeDevEvents.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace AwesomeDevEvents.Persistence.Ef.Configurations
{
    public class DevEventConfiguration : IEntityTypeConfiguration<DevEvent>
    {

        public void Configure(EntityTypeBuilder<DevEvent> builder)
        {
            builder.ToTable("tbl_DevEvent");
        }
    }
}