using Decorator.Implementations;
using Decorator.Interfaces;
using Decorator.Models;
using System.Collections.Generic;

namespace Decorator.UnitTests
{
    class PackageFactory
    {
        public IPackage Order()
        {
            var laptop = new OrderItem() { Name = "MacBook", Quantity = 1, Price = 2.999M, Weight = 3.0M };
            var iPhones = new OrderItem() { Name = "iPhone", Quantity = 2, Price = 1.499M, Weight = 0.2M };

            var package = new Package<OrderItem>();
            package.AddItem(laptop);
            package.AddItem(iPhones);

            return package;
        }

        public IPackage Order(IEnumerable<OrderItem> items)
        {
            var package = new Package<OrderItem>();

            foreach(var item in items)
            {
                package.AddItem(item);
            }

            return package;
        }
    }
}
