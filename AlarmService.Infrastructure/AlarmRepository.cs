using AlarmService.Core;
using AlarmService.Core.Events;
using System;

namespace AlarmService.Infrastructure
{
    public class AlarmRepository
    {
        private readonly EventPublisher _publisher;

        public AlarmRepository(EventPublisher publisher)
        {
            _publisher = publisher;
        }

        public void SaveResult(string alarmId, bool isRaised)
        {
            Console.WriteLine($">> Alarm {alarmId} status: {(isRaised ? "Raised" : "Normal")}");

            var evt = new AlarmRaisedEvent
            {
                AlarmId = alarmId,
                Status = isRaised ? "Raised" : "Normal"
            };
            _publisher.Publish(evt);
        }
    }
}
