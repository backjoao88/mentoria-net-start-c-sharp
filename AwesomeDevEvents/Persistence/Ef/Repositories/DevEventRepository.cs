using System.Collections.Generic;
using System.Linq;
using AwesomeDevEvents.Core.Models;
using AwesomeDevEvents.Core.Repositories;
namespace AwesomeDevEvents.Persistence.Ef.Repositories
{
    public class DevEventRepository : IDevEventRepository
    {
        readonly DevEventsDbContext _dbContext;

        public DevEventRepository(DevEventsDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Save(DevEvent devEvent)
        {
            _dbContext.DevEvents.Add(devEvent);
        }

        public void Remove(DevEvent devEvent)
        {
            _dbContext.DevEvents.Remove(devEvent);
        }

        public List<DevEvent> FindAll()
        {
            return _dbContext.DevEvents.ToList();
        }

        public DevEvent FindById(int id)
        {
            return _dbContext.DevEvents.SingleOrDefault(d => d.Id == id);
        }

        public void SaveSpeaker(DevEventSpeaker devEventSpeaker)
        {
            _dbContext.Speakers.Add(devEventSpeaker);
        }
    }
}