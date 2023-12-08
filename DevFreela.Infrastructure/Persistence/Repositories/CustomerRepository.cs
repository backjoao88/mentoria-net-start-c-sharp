using DevFreela.Core.Entities;
using DevFreela.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DevFreela.Infrastructure.Persistence.Repositories;

public class CustomerRepository : EfRepository<Customer>, ICustomerRepository
{
    public CustomerRepository(EfDbContext dbContext) : base(dbContext)
    {
    }

    public Customer FindById(Guid id)
    {
        return _dbContext.Customers.SingleOrDefault(c => c.Id == id);
    }

    public async Task<List<Customer>> FindAllAsync()
    {
        var customers = await _dbContext.Customers.ToListAsync();
        return customers;
    }
    
}