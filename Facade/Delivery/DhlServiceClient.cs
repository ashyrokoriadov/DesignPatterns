using System;
using System.Collections.Generic;

namespace Facade.Delivery
{
    public class DhlServiceClient : IDeliveryServiceClient
    {        
        public bool CancelSending(string packageType, string address)
        {
            Console.WriteLine($"Отправка на адрес {address} посылки типа {packageType} была отменена.");
            return true;
        }

        public IEnumerable<string> GetAvailablePackageTypes() => new[] { "S", "M", "L", "Mega Package" };

        public double GetPackagePrice(string packageType) 
            => packageType switch
            {
                "S" => 5.00,
                "M" => 10.00,
                "L" => 15.00,
                "Mega Package" => 20.00,
                _ => 30.00,
            };        

        public bool SendPackage(string packageType, string address)
        {
            Console.WriteLine($"Отправка на адрес {address} посылки типа {packageType} была успешна.");
            return true;
        }
    }
}
