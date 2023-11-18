using AwesomeDevEvents.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace AwesomeDevEvents.Persistence.Ef.Configurations
{
    public class DevEventSpeakerConfiguration : IEntityTypeConfiguration<DevEventSpeaker>
    {

        public void Configure(EntityTypeBuilder<DevEventSpeaker> builder)
        {
            builder.ToTable("tbl_DevEventSpeaker");
        }
    }
}