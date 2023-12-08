using DevFreela.Core.Entities;

namespace DevFreela.Core.Repositories;

public interface ICustomerRepository : IRepository<Customer>
{
    public Customer FindById(Guid id);
    public Task<List<Customer>> FindAllAsync();
}