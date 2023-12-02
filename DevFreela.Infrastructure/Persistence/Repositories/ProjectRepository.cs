using DevFreela.Core.Entities;
using DevFreela.Core.Repositories;

namespace DevFreela.Infrastructure.Persistence.Repositories;

public class ProjectRepository : EfRepository<Project>, IProjectRepository
{
    public ProjectRepository(EfDbContext dbContext) : base(dbContext)
    {
    }
}