using DevFreela.Core.Repositories;

namespace DevFreela.Core;

public interface IUnitOfWork
{
    public ICustomerRepository CustomerRepository { get; }
    public IFreelancerRepository FreelancerRepository { get; }
    public IProjectRepository ProjectRepository { get; }
    public int Complete();
}