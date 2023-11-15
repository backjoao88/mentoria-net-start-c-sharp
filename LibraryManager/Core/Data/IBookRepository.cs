using System.Linq.Expressions;
using LibraryManager.Core.Models;
namespace LibraryManager.Core.Data
{
    public interface IBookRepository
    {
        public void Save(Book book);
        public void Remove(Book book);
        public List<Book> FindAll();
        public List<Book> Find(Expression<Func<Book, bool>> predicate);
    }
}