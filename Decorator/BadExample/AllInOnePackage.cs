using Decorator.Implementations;
using Decorator.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Decorator.BadExample
{
    public class AllInOnePackage<T> : PackageBase where T : IOrderItem
    {
        public const decimal PACKAGE_MATERIAL_WEIGHT = 0.5M;

        private readonly List<T> _items = new List<T>();
        public AllInOnePackage(PackageType packageType, PaymentType paymentType)
        {
            PackageType = packageType;
            PaymentType = paymentType;
        }

        public PackageType PackageType { get; init; }

        public PaymentType PaymentType { get; init; }

        public void AddItem(T item) => _items.Add(item);

        public void Remove(T item) => _items.Remove(item);

        public override decimal CalculateValue() => _items.Sum(item => item.TotalPrice);

        public override decimal CalculateWeight() => _items.Sum(item => item.TotalWeight) + PACKAGE_MATERIAL_WEIGHT;

        public override decimal CalculateShippingCosts() 
        {
            return PackageType switch
            {
                PackageType.DHL => 20.0M,
                PackageType.POST => 10.0M,
                _ => 0.0M,
            };
        }

        public override decimal CalculatePaymentCommision()
        {
            switch (PaymentType)
            {
                case PaymentType.WESTERN_UNION:
                    return 17.0M;
                case PaymentType.MONEYGRAM:
                    return 12.0M;
                default:
                    return 0.0M;
            }
        }
    }
}
