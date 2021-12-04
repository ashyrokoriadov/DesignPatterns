using Observer.Events;
using Observer.Implementations;
using Observer.Interfaces;
using Observer.Models;
using Observer.Repos;
using Observer.Subscribers;
using System;
using System.Collections.Generic;

namespace Observer.ObservableEntities
{
    public class MessageBox
    {
        private IRepo<ISubscriber<MessageSent>> _subscribers;
        private IMessageSender<Message> _messageSender;
        private readonly List<Message> _message = new List<Message>();

        public MessageBox(
            IRepo<ISubscriber<MessageSent>> subscribers,
            IMessageSender<Message> messageSender)
        {
            _subscribers = subscribers;
            _messageSender = messageSender;
        }

        public void Subscribe(ISubscriber<MessageSent> subscriber)
        {
            var result = _subscribers.Add(subscriber);

            if (result)
            {
                Console.WriteLine($"{subscriber} подписался на события в классе {nameof(MessageBox)}.");
            }
            else
            {
                Console.WriteLine($"Неудачная попытка подписки пользователя {subscriber} " +
                                  $"на события в классе {nameof(MessageBox)}.");
            }
        }

        public void Unsubscribe(ISubscriber<MessageSent> subscriber)
        {
            var result = _subscribers.Remove(subscriber);

            if (result)
            {
                Console.WriteLine($"{subscriber} отписался от событий в классе {nameof(MessageBox)}.");
            }
            else
            {
                Console.WriteLine($"Неудачная попытка отписки пользователя {subscriber} " +
                                  $"от событий в классе {nameof(MessageBox)}.");
            }
        }

        public void SendMessage(Message message)
        {
            _message.Add(message);

            message.Status = MessageStatus.SendWaiting;
            _messageSender.Send(message);

            if (message.Status == MessageStatus.Sent)
            {
                foreach (var subscriber in _subscribers)
                {
                    subscriber.Publish(new MessageSent(message));
                }
            }
        }
    }
}
