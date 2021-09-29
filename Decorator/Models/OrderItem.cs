using Decorator.Interfaces;

namespace Decorator.Models
{
    public class OrderItem : IOrderItem
    {
        public string Name { get; init; }

        public decimal Weight { get; init; }

        public decimal Price { get; init; }

        public int Quantity { get; init; }

        public decimal TotalWeight => Weight * Quantity;

        public decimal TotalPrice => Price * Quantity;
    }
}
