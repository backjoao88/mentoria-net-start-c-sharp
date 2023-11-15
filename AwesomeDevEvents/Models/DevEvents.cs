using System;
namespace AwesomeDevEvents.Models
{
    public class DevEvents
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string TalkTitle { get; private set; }
        public string TalkDescription { get; private set; }

        public DevEvents(Guid id, string name, string talkTitle, string talkDescription)
        {
            Id = id;
            Name = name;
            TalkTitle = talkTitle;
            TalkDescription = talkDescription;
        }
        
    }
}