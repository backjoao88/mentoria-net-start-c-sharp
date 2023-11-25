using System.Linq.Expressions;
using LibraryManagerConsole.Core.Models;
namespace LibraryManagerConsole.Core.Data
{
    public interface IBorrowRepository
    {
        public void Save(Borrow borrow);
        public void Remove(Borrow borrow);
        public List<Borrow> FindAll();
        public List<Borrow> Find(Expression<Func<Borrow, bool>> predicate);
    }
}