using LibraryManagerConsole.Core;
using LibraryManagerConsole.Core.Data;
using LibraryManagerConsole.Database.Data;
namespace LibraryManagerConsole.Database
{
    public class EfUnitOfWork : IUnitOfWork, IDisposable
    {
        readonly EfContext _efContext;
        public IBookRepository BookRepository { get; }
        
        public IUserRepository UserRepository { get; }
        
        public IBorrowRepository BorrowRepository { get; }

        public EfUnitOfWork(EfContext efContext)
        {
            _efContext = efContext;
            BookRepository = new BookRepository(efContext);
            UserRepository = new UserRepository(efContext);
            BorrowRepository = new BorrowRepository(efContext);
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