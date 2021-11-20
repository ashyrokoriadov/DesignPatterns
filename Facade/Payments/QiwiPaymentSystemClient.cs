using System;
using System.Collections.Generic;

namespace Facade.Payments
{
    public class QiwiPaymentSystemClient : IPaymentGatewayClient
    {
        public IEnumerable<string> GetAvailablePaymentsTypes() => new[] { "Standard", "Express" };

        public double GetPaymentCommision(double amount)
            => amount switch
            {
                10 => 0.02,
                100 => 0.01,
                1000 => 0.005,
                _ => 0.05,
            };

        public bool MakePayment(double amount)
        {
            Console.WriteLine($"Платеж выполнен. Сумма: {amount} USD.");
            return true;
        }

        public bool RefundPayment(double amount, string refundAccount)
        {
            Console.WriteLine($"Платеж возвращен. Сумма: {amount} USD.");
            return true;
        }
    }
}
