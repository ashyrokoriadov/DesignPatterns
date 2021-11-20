namespace Facade.Facade
{
    public interface IOrder
    {
        string ItemName { get; set; }
        int Quantity { get; set; }
        double Amount { get; set; }
        string Address { get; set; }
        string RefundAccount { get; set; }
    }
}
