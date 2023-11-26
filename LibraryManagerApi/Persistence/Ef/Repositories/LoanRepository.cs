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
        return Context.Set<Loan>().Where(o => !o.IsDeleted).Include(o => o.User).Include(o => o.Book).ToList();
    }

    public Loan? FindById(Guid id)
    {
        return Context.Set<Loan>().Include(o => o.User).Include(o => o.Book).SingleOrDefault(o => !o.IsDeleted && o.Id == id);
    }
}