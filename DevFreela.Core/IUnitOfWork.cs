using DevFreela.Core.Repositories;

namespace DevFreela.Core;

public interface IUnitOfWork
{
    public ICustomerRepository CustomerRepository { get; }
    public int Complete();
    public Task<int> CompleteAsync();
}