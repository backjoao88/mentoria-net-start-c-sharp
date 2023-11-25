using System.Linq.Expressions;
using LibraryManagerConsole.Core.Models;
namespace LibraryManagerConsole.Core.Data
{
    public interface IBookRepository
    {
        public void Save(Book book);
        public void Remove(Book book);
        public List<Book> FindAll();
        public List<Book> Find(Expression<Func<Book, bool>> predicate);
    }
}