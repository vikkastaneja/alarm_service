using AlarmService.Core;
using AlarmService.Core.Events;
using System;
using StackExchange.Redis;

namespace AlarmService.Infrastructure
{
    public class AlarmRepository
    {
        private readonly EventPublisher _publisher;

        private readonly IConnectionMultiplexer _redis;

        public AlarmRepository(EventPublisher publisher, IConnectionMultiplexer redis)
        {
            _publisher = publisher;
            _redis = redis;
        }

        public void SaveResult(string alarmId, bool isRaised)
        {
            var db = _redis.GetDatabase();
            var status = isRaised ? "Raised" : "Normal";

            db.StringSet($"alarm:{alarmId}", status);

            Console.WriteLine($">> Alarm {alarmId} status: {status}");

            var evt = new AlarmRaisedEvent
            {
                AlarmId = alarmId,
                Status = status
            };
            _publisher.Publish(evt);

            var pub = _redis.GetSubscriber();
            pub.Publish("alarms", $"Alarm:{evt.AlarmId} Status:{(evt.Status)}");
        }
    }
}
