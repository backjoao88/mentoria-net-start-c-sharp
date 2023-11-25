using LibraryManagerApi.Core.Entities;
using LibraryManagerApi.Core.Repositories;

namespace LibraryManagerApi.Persistence.Ef.Repositories;

public class LoanRepository : Repository<Loan>, ILoanRepository
{
    public LoanRepository(DatabaseContext context) : base(context)
    {
    }
}