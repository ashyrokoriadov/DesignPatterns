using System;

namespace Proxy.Workers
{
    class Address
    {
        public Guid Id { get; set; }
        public string ZipCode { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }

        public override string ToString()
        {
            return $"{nameof(Id)}: {Id}; {nameof(ZipCode)}: {ZipCode}; {nameof(Country)}: {Country}; " +
                $"{nameof(City)}: {City}; {nameof(AddressLine1)}: {AddressLine1}; " +
                $"{nameof(AddressLine2)}: {AddressLine2}.";
        }
    }
}
