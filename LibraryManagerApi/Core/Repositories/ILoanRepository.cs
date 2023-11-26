using LibraryManagerApi.Core.Entities;

namespace LibraryManagerApi.Core.Repositories;

public interface ILoanRepository : IRepository<Loan>
{
    public Loan? FindById(Guid id);
}