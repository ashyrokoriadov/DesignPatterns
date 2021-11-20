using Autofac;
using Facade.Delivery;
using Facade.Facade;
using Facade.Payments;
using Facade.Storage;
using System;
using System.Linq;

namespace Facade
{
    class Program
    {
        static void Main(string[] args)
        {
            RegisterDependencies();

            var itemName = "PS 5";
            var quantity = 1;
            var amount = 300.0;
            var address = "127000 Москва ул. Академика Королева, 12";
            var refundAccount = "Bank Account 123456789";

            Order(itemName, quantity, amount, address);
            WriteStarLine();
            CancelOrder(itemName, quantity, amount, address, refundAccount);
            WriteStarLine();
            ShowExampleWithFacade(itemName, quantity, amount, address, refundAccount);

            Console.ReadKey();
        }

        private static void Order(string itemName, int quantity, double amount, string address)
        {
            using(var scope = Container.BeginLifetimeScope())
            {
                var storage = scope.Resolve<IStorage>();
                var deliveryService = scope.Resolve<IDeliveryServiceClient>();
                var paymentService = scope.Resolve<IPaymentGatewayClient>();                

                storage.ItemExist(itemName);
                storage.TakeItem(itemName, quantity);

                var packageType = deliveryService.GetAvailablePackageTypes().First();
                deliveryService.GetPackagePrice(packageType);

                paymentService.GetAvailablePaymentsTypes();
                var commission = paymentService.GetPaymentCommision(amount);
                paymentService.MakePayment(amount + commission);

                deliveryService.SendPackage(packageType, address);    
            }
        }

        private static void CancelOrder(
            string itemName, 
            int quantity,
            double amount, 
            string address,
            string refundAccount)
        {
            using (var scope = Container.BeginLifetimeScope())
            {
                var storage = scope.Resolve<IStorage>();
                var deliveryService = scope.Resolve<IDeliveryServiceClient>();
                var paymentService = scope.Resolve<IPaymentGatewayClient>();

                var packageType = deliveryService.GetAvailablePackageTypes().First();
                deliveryService.CancelSending(packageType, address);

                paymentService.GetAvailablePaymentsTypes();
                var commission = paymentService.GetPaymentCommision(amount);
                paymentService.RefundPayment(amount + commission, refundAccount);

                storage.AddItem(itemName, quantity);
            }
        }

        private static void ShowExampleWithFacade(
            string itemName,
            int quantity,
            double amount,
            string address,
            string refundAccount
            )
        {
            using (var scope = Container.BeginLifetimeScope())
            {
                var orderFacade = scope.Resolve<IOrderFacade>();
                if(orderFacade is IOrder order)
                {
                    order.ItemName = itemName;
                    order.Quantity = quantity;
                    order.Amount = amount;
                    order.Address = address;
                    order.RefundAccount = refundAccount;

                    orderFacade.Order();
                    WriteStarLine();
                    orderFacade.CancelOrder();
                }                
            }
        }

        private static void WriteStarLine() => Console.WriteLine("*************************");

        private static void RegisterDependencies()
        {
            Builder.RegisterType<DhlServiceClient>().As<IDeliveryServiceClient>();
            Builder.RegisterType<QiwiPaymentSystemClient>().As<IPaymentGatewayClient>();
            Builder.RegisterType<GoodsStorage>().As<IStorage>();

            Builder.RegisterType<DefaultOrderFacade>()
                .As<IOrderFacade>()
                .As<IOrder>();
        }

        private static IContainer _container;
        public static IContainer Container => _container ?? (_container = Builder.Build());

        private static ContainerBuilder _builder;
        public static ContainerBuilder Builder => _builder ?? (_builder = new ContainerBuilder());
    }
}
