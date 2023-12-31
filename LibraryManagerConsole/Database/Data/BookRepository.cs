using System.Linq.Expressions;
using LibraryManagerConsole.Core.Data;
using LibraryManagerConsole.Core.Models;
namespace LibraryManagerConsole.Database.Data
{
    public class BookRepository : IBookRepository
    {

        readonly EfContext _context;

        public BookRepository(EfContext context)
        {
            _context = context;
        }

        public void Save(Book book)
        {
            _context.Books.Add(book);
        }

        public void Remove(Book book)
        {
            _context.Books.Remove(book);
        }

        public List<Book> FindAll()
        {
            return _context.Books.ToList();
        }

        public List<Book> Find(Expression<Func<Book, bool>> predicate)
        {
            return _context.Books.Where(predicate).ToList();
        }
    }
}