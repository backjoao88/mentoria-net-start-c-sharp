namespace AwesomeDevEvents.Core.Models
{
    public class DevEvent
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string TalkTitle { get; private set; }
        public string TalkDescription { get; private set; }
        public bool IsDeleted { get; set; }

        public DevEvent(int id, string name, string talkTitle, string talkDescription)
        {
            Id = id;
            Name = name;
            TalkTitle = talkTitle;
            TalkDescription = talkDescription;
            IsDeleted = false;
        }

    }
}