using Observer.Models;

namespace Observer.Events
{
    public class MessageSent
    {
        public MessageSent(Message message)
        {
            Message = message;
        }

        public Message Message { get; init; }
    }
}
