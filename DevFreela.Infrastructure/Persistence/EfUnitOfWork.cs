using DevFreela.Core;
using DevFreela.Core.Repositories;

namespace DevFreela.Infrastructure.Persistence;

public class EfUnitOfWork : IUnitOfWork
{
    private readonly EfDbContext _dbContext;
    public ICustomerRepository CustomerRepository { get; }

    public EfUnitOfWork(EfDbContext dbContext, ICustomerRepository customerRepository)
    {
        _dbContext = dbContext;
        CustomerRepository = customerRepository;
    }

    public int Complete()
    {
        return _dbContext.SaveChanges();
    }

    public async Task<int> CompleteAsync()
    {
        return await _dbContext.SaveChangesAsync();
    }
}