
namespace AlarmService.Core.Events
{
    public class AlarmRaisedEvent : IEvent
    {
        public string AlarmId { get; set; }
        public string Status { get; set; }
        public string EventType => "AlarmRaised";
    }
}
