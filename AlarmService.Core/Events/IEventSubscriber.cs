
namespace AlarmService.Core.Events
{
    public interface IEventSubscriber
    {
        void Handle(IEvent evt);
    }
}
