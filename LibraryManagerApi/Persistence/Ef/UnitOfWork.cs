using LibraryManagerApi.Core;
using LibraryManagerApi.Core.Repositories;

namespace LibraryManagerApi.Persistence.Ef;

public class UnitOfWork : IUnitOfWork
{
    public DatabaseContext Context { get; }
    public IBookRepository BookRepository { get; }
    public IUserRepository UserRepository { get; }
    public ILoanRepository LoanRepository { get; }

    public UnitOfWork(DatabaseContext context, IBookRepository bookRepository, IUserRepository userRepository, ILoanRepository loanRepository)
    {
        Context = context;
        BookRepository = bookRepository;
        UserRepository = userRepository;
        LoanRepository = loanRepository;
    }

    public int Complete()
    {
        return Context.SaveChanges();
    }
}