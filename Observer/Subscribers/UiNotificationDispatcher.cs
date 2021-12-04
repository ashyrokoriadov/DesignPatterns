using Observer.Events;
using Observer.Models;
using Observer.Repos;
using System;

namespace Observer.Subscribers
{
    public class UiNotificationDispatcher : NotificationDispatcherBase
    {
        public UiNotificationDispatcher(IRepo<User> users) : base(users)
        {
            UserHasToBeLoggedIn = true;
        }

        protected override void ProcessEvent(MessageSent @event)
        {
            Console.WriteLine("Отправляю уведомление о новом сообщении " +
                $"для пользователя {@event.Message.To} на панель уведомлений GUI.");

            // логика отправки сообщений на панель уведомлений GUI
        }
    }
}
