using LibraryManager.Core.Data;
namespace LibraryManager.Core
{
    public interface IUnitOfWork
    {
        public IBookRepository BookRepository { get; }
        public IUserRepository UserRepository { get; }
        public IBorrowRepository BorrowRepository { get; }
        public int Complete();
    }
}