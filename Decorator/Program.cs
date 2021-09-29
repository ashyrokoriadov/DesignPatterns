using Decorator.BadExample;
using Decorator.Implementations;
using Decorator.Models;
using Decorator.PaymentComissions;
using Decorator.ShippingCosts;
using System;

namespace Decorator
{
    class Program
    {
        static void Main(string[] args)
        {
            //DisplayInitialExample();
            //DisplayShippingCostsExample();
            //DisplayDoubleDecoratorCostsExample();
            DisplayComissionDecoratorExample();
            //DisplayDoubleComissionDecoratorExample();
            //DisplayBadExample();
            Console.ReadLine();
        }

        static void DisplayInitialExample()
        {
            Console.WriteLine("Пример 1 - посылка без декораторов");

            var package = CreatePackage();

            Console.WriteLine(package.DisplayPackageInfo());
            Console.WriteLine();
        }

        static void DisplayShippingCostsExample()
        {
            Console.WriteLine("Пример 2 - декоратор изменяет способ расчета стоимости доставки");

            var package = CreatePackage();

            var postPackage = new PostShippingPackage(package);

            Console.WriteLine(postPackage.DisplayPackageInfo());
            Console.WriteLine();
        }

        static void DisplayDoubleDecoratorCostsExample()
        {
            Console.WriteLine("Пример 3 - 2 декоратора изменяют способ расчета стоимости доставки");

            var package = CreatePackage();

            var postPackage = new PostShippingPackage(package);
            var dhlPackage = new DhlShippingPackage(postPackage);

            Console.WriteLine(dhlPackage.DisplayPackageInfo());
            Console.WriteLine();
        }

        static void DisplayComissionDecoratorExample()
        {
            Console.WriteLine("Пример 4");
            Console.WriteLine("2 декоратора изменяют способ расчета стоимости доставки");
            Console.WriteLine("1 декоратор изменяет способ расчета комиссии платежа");

            var package = CreatePackage();

            var postPackage = new PostShippingPackage(package);
            var dhlPackage = new DhlShippingPackage(postPackage);
            var wuComissionpackage = new WesternUnionPaymentComissionPackage(dhlPackage);

            Console.WriteLine(wuComissionpackage.DisplayPackageInfo());
            Console.WriteLine();
        }

        static void DisplayDoubleComissionDecoratorExample()
        {
            Console.WriteLine("Пример 5");
            Console.WriteLine("2 декоратора изменяют способ расчета стоимости доставки");
            Console.WriteLine("2 декоратора изменяют способ расчета комиссии платежа");

            var package = CreatePackage();

            var postPackage = new PostShippingPackage(package);
            var dhlPackage = new DhlShippingPackage(postPackage);
            var wuComissionpackage = new WesternUnionPaymentComissionPackage(dhlPackage);
            var mgComissionpackage = new MoneyGramPaymentComissionPackage(wuComissionpackage);

            Console.WriteLine(mgComissionpackage.DisplayPackageInfo());
            Console.WriteLine();
        }

        static void DisplayBadExample()
        {
            Console.WriteLine("Пример 6 - плохой пример");

            var laptop = new OrderItem() { Name = "MacBook", Quantity = 1, Price = 2.999M, Weight = 3.0M };
            var iPhones = new OrderItem() { Name = "iPhone", Quantity = 2, Price = 1.499M, Weight = 0.2M };

            var package = new AllInOnePackage<OrderItem>(PackageType.POST, PaymentType.WESTERN_UNION);
            package.AddItem(laptop);
            package.AddItem(iPhones);

            Console.WriteLine(package.DisplayPackageInfo());
            Console.WriteLine();
        }

        static Package<OrderItem> CreatePackage()
        {
            var laptop = new OrderItem() { Name = "MacBook", Quantity = 1, Price = 2.999M, Weight = 3.0M };
            var iPhones = new OrderItem() { Name = "iPhone", Quantity = 2, Price = 1.499M, Weight = 0.2M };

            var package = new Package<OrderItem>();
            package.AddItem(laptop);
            package.AddItem(iPhones);

            return package;
        }
    }
}
