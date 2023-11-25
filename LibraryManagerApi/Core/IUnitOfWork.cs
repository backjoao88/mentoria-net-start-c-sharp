using LibraryManagerApi.Core.Repositories;

namespace LibraryManagerApi.Core;

public interface IUnitOfWork
{
    public IBookRepository BookRepository { get; }
    public IUserRepository UserRepository { get; }
    public ILoanRepository LoanRepository { get; }
    public int Complete();
}