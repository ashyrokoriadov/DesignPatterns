using System.Collections.Generic;

namespace Facade.Payments
{
    public interface IPaymentGatewayClient
    {
        IEnumerable<string> GetAvailablePaymentsTypes();

        double GetPaymentCommision(double amount);

        bool MakePayment(double amount);

        bool RefundPayment(double amount, string refundAccount);
    }
}
