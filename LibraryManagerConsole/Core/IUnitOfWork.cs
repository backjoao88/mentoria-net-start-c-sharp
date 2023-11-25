using LibraryManagerConsole.Core.Data;
namespace LibraryManagerConsole.Core
{
    public interface IUnitOfWork
    {
        public IBookRepository BookRepository { get; }
        public IUserRepository UserRepository { get; }
        public IBorrowRepository BorrowRepository { get; }
        public int Complete();
    }
}