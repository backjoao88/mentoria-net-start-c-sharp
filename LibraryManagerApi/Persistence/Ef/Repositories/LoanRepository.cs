using LibraryManagerApi.Core.Entities;
using LibraryManagerApi.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagerApi.Persistence.Ef.Repositories;

public class LoanRepository : Repository<Loan>, ILoanRepository
{
    public LoanRepository(DatabaseContext context) : base(context)
    {
    }
    
    public new IEnumerable<Loan> FindAll()
    {
        return Context.Set<Loan>()
            .Include(o => o.User)
            .Include(o => o.Book)
            .ToList();
    }

    public Loan? FindById(int id)
    {
        return Context.Set<Loan>()
            .Include(o => o.User)
            .Include(o => o.Book)
            .SingleOrDefault(o => o.Id == id);
    }
}