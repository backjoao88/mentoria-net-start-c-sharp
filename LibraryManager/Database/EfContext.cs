using LibraryManager.Core.Models;
using Microsoft.EntityFrameworkCore;
namespace LibraryManager.Database
{
    public class EfContext : DbContext
    {
        public DbSet<Book> Books { get; set; } = null!;
        public DbSet<User> Users { get; set; } = null!;
        public DbSet<Borrow> Borrows { get; set; } = null!;
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase(databaseName: "library-db");
        }
    }
}