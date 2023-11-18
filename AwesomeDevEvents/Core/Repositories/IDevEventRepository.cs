using System.Collections.Generic;
using AwesomeDevEvents.Core.Models;
using AwesomeDevEvents.Persistence;
namespace AwesomeDevEvents.Core.Repositories
{
    public interface IDevEventRepository
    {
        public void Save(DevEvent devEvent);
        public void Remove(DevEvent devEvent);
        public List<DevEvent> FindAll();
        public DevEvent FindById(int id);
        public void SaveSpeaker(DevEventSpeaker devEventSpeaker);
    }
}