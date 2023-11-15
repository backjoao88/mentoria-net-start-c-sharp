using AwesomeDevEvents.Models;
using Microsoft.EntityFrameworkCore;
namespace AwesomeDevEvents.Persistence
{
    public class DevEventsDbContext : DbContext
    {
        public DbSet<DevEvents> DevEvents { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("dev-events-db");
        }
    }
}