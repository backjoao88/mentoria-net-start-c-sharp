using AwesomeDevEvents.Core.Models;
using AwesomeDevEvents.Persistence.Ef.Configurations;
using Microsoft.EntityFrameworkCore;
namespace AwesomeDevEvents.Persistence.Ef
{
    public class DevEventsDbContext : DbContext
    {
        public DevEventsDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new DevEventConfiguration());
            modelBuilder.ApplyConfiguration(new DevEventSpeakerConfiguration());
        }

        public DbSet<DevEvent> DevEvents { get; set; }
        public DbSet<DevEventSpeaker> Speakers { get; set; }
    }
}