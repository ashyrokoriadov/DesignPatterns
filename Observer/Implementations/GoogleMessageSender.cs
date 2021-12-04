using Observer.Interfaces;
using Observer.Models;
using System;

namespace Observer.Implementations
{
    public class GoogleMessageSender : IMessageSender<Message>
    {
        public void Send(Message message)
        {
            message.Status = MessageStatus.Sent;
            Console.WriteLine($"Сообщение {message} было отправлено.");
        }
    }
}
