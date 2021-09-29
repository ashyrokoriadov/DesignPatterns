using Decorator.Implementations;
using Decorator.Interfaces;

namespace Decorator.ShippingCosts
{
    public class DhlShippingPackage : PackageBase
    {
        private readonly IPackage _packageToBeDecorated;

        public const decimal SHIPPING_COST = 20.0M;

        public DhlShippingPackage(IPackage packageToBeDecorated)
        {
            _packageToBeDecorated = packageToBeDecorated;
        }

        public override decimal CalculateValue() => _packageToBeDecorated.CalculateValue();

        public override decimal CalculateWeight() => _packageToBeDecorated.CalculateWeight();

        public override decimal CalculatePaymentCommision() => _packageToBeDecorated.CalculatePaymentCommision();

        public override decimal CalculateShippingCosts()
        {
            var initalShippingCosts = _packageToBeDecorated.CalculateShippingCosts();
            return initalShippingCosts + SHIPPING_COST;
        }
    }
}
