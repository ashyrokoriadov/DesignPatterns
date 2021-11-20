using Facade.Delivery;
using Facade.Payments;
using Facade.Storage;
using System.Linq;

namespace Facade.Facade
{
    public class DefaultOrderFacade : IOrderFacade, IOrder
    {
        private readonly IStorage _storage;
        private readonly IDeliveryServiceClient _deliveryService;
        private readonly IPaymentGatewayClient _paymentService;

        public DefaultOrderFacade(
            IStorage storage,
            IDeliveryServiceClient deliveryService,
            IPaymentGatewayClient paymentService
            )
        {
            _storage = storage;
            _deliveryService = deliveryService;
            _paymentService = paymentService;
        }

        public string ItemName { get; set; }
        public int Quantity { get; set; }
        public double Amount { get; set; }
        public string Address { get; set; }
        public string RefundAccount { get; set; }

        public void CancelOrder()
        {
            var packageType = _deliveryService.GetAvailablePackageTypes().First();
            _deliveryService.CancelSending(packageType, Address);

            _paymentService.GetAvailablePaymentsTypes();
            var commission = _paymentService.GetPaymentCommision(Amount);
            _paymentService.RefundPayment(Amount + commission, RefundAccount);

            _storage.AddItem(ItemName, Quantity);
        }

        public void Order()
        {
            _storage.ItemExist(ItemName);
            _storage.TakeItem(ItemName, Quantity);

            var packageType = _deliveryService.GetAvailablePackageTypes().First();
            _deliveryService.GetPackagePrice(packageType);

            _paymentService.GetAvailablePaymentsTypes();
            var commission = _paymentService.GetPaymentCommision(Amount);
            _paymentService.MakePayment(Amount + commission);

            _deliveryService.SendPackage(packageType, Address);
        }
    }
}
