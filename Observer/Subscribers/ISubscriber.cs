using Observer.Interfaces;

namespace Observer.Subscribers
{
    public interface ISubscriber<TEvent> : IIdentifiable
    {
        public void Publish(TEvent @event);
    }
}
