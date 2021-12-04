using Observer.Events;
using Observer.Models;
using Observer.Repos;
using System;

namespace Observer.Subscribers
{
    public class EmailNotificationDispatcher : NotificationDispatcherBase
    {
        public EmailNotificationDispatcher(IRepo<User> users) : base(users)
        {
            UserHasToBeLoggedIn = false;
        }

        protected override void ProcessEvent(MessageSent @event)
        {
            Console.WriteLine("Отправляю уведомление о новом сообщении " +
                $"для пользователя {@event.Message.To} по электронной почте.");

            // логика отправки сообщений по электронной почте
        }
    }
}
