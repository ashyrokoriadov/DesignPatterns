using System;
using System.Collections.Generic;
using System.Linq;

namespace Proxy.Workers
{
    class AddressRepo : IRepo<Address, Guid>
    {
        private readonly List<Address> _addresses = new List<Address>();

        /// <summary>
        /// Do not create or use this class directly, use proxies instead:
        /// <seealso cref="AddressRepoAccessProxy"/>
        /// <seealso cref="AddressRepoValidatorProxy"/>
        /// </summary>
        public AddressRepo()
        { }

        public Address Get(Guid id)
        {
            var address = _addresses.SingleOrDefault(address => address.Id == id);
            return address;
        }

        public IEnumerable<Address> GetAll() => _addresses;

        public bool Add(Address address)
        {
            _addresses.Add(address);
            return true;
        }

        public bool Update(Address address)
        {
            var addressToUpdate = Get(address.Id );

            if(addressToUpdate == null)
            {
                return false;
            }

            addressToUpdate = address;
            return true;
        }

        public bool Delete(Guid id)
        {
            var addressToDelete = Get(id);

            if (addressToDelete == null)
            {
                return false;
            }

            _addresses.Remove(addressToDelete);
            return true;
        }
    }
}
