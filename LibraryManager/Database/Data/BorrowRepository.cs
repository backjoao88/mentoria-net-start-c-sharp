using System.Linq.Expressions;
using LibraryManager.Core.Data;
using LibraryManager.Core.Models;
namespace LibraryManager.Database.Data
{
    public class BorrowRepository : IBorrowRepository
    {

        readonly EfContext _efContext;

        public BorrowRepository(EfContext efContext)
        {
            this._efContext = efContext;
        }

        public void Save(Borrow borrow)
        {
            _efContext.Borrows.Add(borrow);
        }

        public void Remove(Borrow borrow)
        {
            _efContext.Borrows.Remove(borrow);
        }

        public List<Borrow> FindAll()
        {
            return _efContext.Borrows.ToList();
        }

        public List<Borrow> Find(Expression<Func<Borrow, bool>> predicate)
        {
            return _efContext.Borrows.Where(predicate).ToList();
        }
    }
}