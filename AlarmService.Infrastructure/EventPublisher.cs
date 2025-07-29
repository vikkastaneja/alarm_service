using System.Collections.Generic;
using AlarmService.Core.Events;

namespace AlarmService.Infrastructure
{
    public class EventPublisher
    {
        private readonly List<IEventSubscriber> _subscribers = new();

        public void Subscribe(IEventSubscriber subscriber)
        {
            _subscribers.Add(subscriber);
        }

        public void Publish(IEvent evt)
        {
            foreach (var subscriber in _subscribers)
            {
                subscriber.Handle(evt);
            }
        }
    }
}
