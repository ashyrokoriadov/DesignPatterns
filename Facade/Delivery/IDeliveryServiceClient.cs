using System.Collections.Generic;

namespace Facade.Delivery
{
    public interface IDeliveryServiceClient
    {
        IEnumerable<string> GetAvailablePackageTypes();

        double GetPackagePrice(string packageType);

        bool SendPackage(string packageType, string address);

        bool CancelSending(string packageType, string address);
    }
}
