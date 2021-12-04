using Observer.Events;
using Observer.Models;
using Observer.Repos;
using System;
using System.Linq;

namespace Observer.Subscribers
{
    public abstract class NotificationDispatcherBase : ISubscriber<MessageSent>
    {
        private readonly IRepo<User> _users;

        public NotificationDispatcherBase(IRepo<User> users)
        {
            _users = users;
            Id = Guid.NewGuid();
        }

        public bool UserHasToBeLoggedIn { get; init; }

        public Guid Id { get; init; }

        public void Publish(MessageSent @event)
        {
            var isLoggedIn = true;
            if(UserHasToBeLoggedIn)
            {
                isLoggedIn = IsUserLoggedIn(@event.Message.To);
            }

            if(isLoggedIn)
            {
                ProcessEvent(@event);
            }
        }

        protected virtual bool IsUserLoggedIn(string userName)
        {
            var loggedInUser = _users.SingleOrDefault(u => u.IsLoggedIn && u.Name == userName);
            return loggedInUser != null;
        }

        protected virtual void ProcessEvent(MessageSent @event)
        {
            Console.WriteLine("Отправляю уведомление о новом сообщении " +
                $"для пользователя {@event.Message.To}.");
        }
    }
}
