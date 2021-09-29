using Decorator.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Decorator.Implementations
{
    public class Package<T> : PackageBase where T : IOrderItem
    {
        public const decimal PACKAGE_MATERIAL_WEIGHT = 0.5M;
        
        private readonly List<T> _items = new List<T>();

        public void AddItem(T item) => _items.Add(item);

        public void Remove(T item) => _items.Remove(item);

        public override decimal CalculateValue() => _items.Sum(item => item.TotalPrice);

        public override decimal CalculateWeight() => _items.Sum(item => item.TotalWeight) + PACKAGE_MATERIAL_WEIGHT;
    }
}
