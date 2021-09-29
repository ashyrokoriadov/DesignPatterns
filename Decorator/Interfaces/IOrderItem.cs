namespace Decorator.Interfaces
{
    public interface IOrderItem
    {
        decimal TotalWeight { get; }

        decimal TotalPrice { get; }
    }
}
