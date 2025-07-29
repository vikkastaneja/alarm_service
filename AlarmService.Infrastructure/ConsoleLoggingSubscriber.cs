using System;
using AlarmService.Core.Events;

namespace AlarmService.Infrastructure
{
    public class ConsoleLoggingSubscriber : IEventSubscriber
    {
        public void Handle(IEvent evt)
        {
            if (evt is AlarmRaisedEvent alarmEvent)
            {
                Console.WriteLine($"[Event] Alarm Raised: ID={alarmEvent.AlarmId}, Status={alarmEvent.Status}");
            }
        }
    }
}
