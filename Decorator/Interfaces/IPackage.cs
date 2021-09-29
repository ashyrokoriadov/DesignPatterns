namespace Decorator.Interfaces
{
    public interface IPackage
    {
        decimal CalculateValue();

        decimal CalculateWeight();

        decimal CalculateShippingCosts();

        decimal CalculatePaymentCommision();

        string DisplayPackageInfo();
    }
}
