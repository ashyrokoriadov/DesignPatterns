namespace Observer.Interfaces
{
    public interface IMessageSender<TMessage>
    {
        void Send(TMessage message);
    }
}
