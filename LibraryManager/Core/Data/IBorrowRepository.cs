using System.Linq.Expressions;
using LibraryManager.Core.Models;
namespace LibraryManager.Core.Data
{
    public interface IBorrowRepository
    {
        public void Save(Borrow borrow);
        public void Remove(Borrow borrow);
        public List<Borrow> FindAll();
        public List<Borrow> Find(Expression<Func<Borrow, bool>> predicate);
    }
}