using AwesomeDevEvents.Core;
using AwesomeDevEvents.Core.Repositories;
using AwesomeDevEvents.Persistence.Ef.Repositories;
namespace AwesomeDevEvents.Persistence.Ef
{
    public class UnitOfWork : IUnitOfWork
    {
        DevEventsDbContext DbContext { get; } 
        public IDevEventRepository DevEventRepository { get; }

        public UnitOfWork(DevEventsDbContext dbContext)
        {
            DbContext = dbContext;
            DevEventRepository = new DevEventRepository(dbContext);
        }

        public int Complete()
        {
            return DbContext.SaveChanges();
        }
    }
}