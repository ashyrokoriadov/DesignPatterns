using Decorator.Implementations;
using Decorator.Interfaces;

namespace Decorator.PaymentComissions
{
    public class MoneyGramPaymentComissionPackage : PackageBase
    {
        private readonly IPackage _packageToBeDecorated;

        public const decimal COMISSION = 12.0M;

        public MoneyGramPaymentComissionPackage(IPackage packageToBeDecorated)
        {
            _packageToBeDecorated = packageToBeDecorated;
        }

        public override decimal CalculateValue() => _packageToBeDecorated.CalculateValue();

        public override decimal CalculateWeight() => _packageToBeDecorated.CalculateWeight();

        public override decimal CalculateShippingCosts() => _packageToBeDecorated.CalculateShippingCosts();

        public override decimal CalculatePaymentCommision()
        {
            var initalPaymentComission = _packageToBeDecorated.CalculatePaymentCommision();
            return initalPaymentComission + COMISSION;
        }
    }
}
