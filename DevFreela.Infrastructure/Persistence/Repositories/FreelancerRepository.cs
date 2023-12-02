using DevFreela.Core.Entities;
using DevFreela.Core.Repositories;

namespace DevFreela.Infrastructure.Persistence.Repositories;

public class FreelancerRepository : EfRepository<Freelancer>, IFreelancerRepository
{
    public FreelancerRepository(EfDbContext dbContext) : base(dbContext)
    {
    }
}