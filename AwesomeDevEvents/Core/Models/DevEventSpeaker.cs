namespace AwesomeDevEvents.Core.Models
{
    public class DevEventSpeaker
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        
        public int DevEventId { get; private set; }

        public DevEventSpeaker(int id, string name, int devEventId)
        {
            Id = id;
            Name = name;
            DevEventId = devEventId;
        }
    }
}