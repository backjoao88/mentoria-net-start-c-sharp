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
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Borrow>(o =>
            {
                o.HasKey(o => o.Id);
                o.HasOne<Book>(o => o.Book).WithMany(o => o.Borrows).HasForeignKey(o => o.IdBook);
                o.HasOne<User>(o => o.User).WithMany(o => o.Borrows).HasForeignKey(o => o.IdUser);
            });
            modelBuilder.Entity<User>(o => o.HasKey(o => o.Id));
            modelBuilder.Entity<Book>(o => o.HasKey(o => o.Id));
        }
    }
}