using LibraryManager.Core;
using LibraryManager.Core.Data;
using LibraryManager.Database.Data;
namespace LibraryManager.Database
{
    public class EfUnitOfWork : IUnitOfWork, IDisposable
    {
        readonly EfContext _efContext;
        public IBookData BookData { get; private set; }

        public EfUnitOfWork(EfContext efContext)
        {
            _efContext = efContext;
            BookData = new BookData(efContext);
        }

        public int Complete()
        {
            return _efContext.SaveChanges();
        }

        public void Dispose()
        {
            _efContext.Dispose();
        }
        
    }
}