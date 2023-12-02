using DevFreela.Core;
using DevFreela.Core.Repositories;

namespace DevFreela.Infrastructure.Persistence;

public class EfUnitOfWork : IUnitOfWork
{
    private readonly EfDbContext _dbContext;
    public ICustomerRepository CustomerRepository { get; }
    public IFreelancerRepository FreelancerRepository { get; }
    public IProjectRepository ProjectRepository { get; }

    public EfUnitOfWork(EfDbContext dbContext, ICustomerRepository customerRepository, IFreelancerRepository freelancerRepository, IProjectRepository projectRepository)
    {
        _dbContext = dbContext;
        CustomerRepository = customerRepository;
        FreelancerRepository = freelancerRepository;
        ProjectRepository = projectRepository;
    }

    public int Complete()
    {
        throw new NotImplementedException();
    }
}