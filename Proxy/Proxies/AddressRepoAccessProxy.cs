using Autofac.Features.AttributeFilters;
using Proxy.Proxies.AccessControl;
using Proxy.Workers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Proxy.Proxies
{
    class AddressRepoAccessProxy : IRepo<Address, Guid>
    {
        private readonly IUserContext _userContext;
        private readonly IRepo<Address, Guid> _addressRepo;

        public AddressRepoAccessProxy(
            IUserContext userContext,
            [KeyFilter(Program.REPO_VALDIATOR_PROXY)] IRepo<Address, Guid> addressRepo)
        {
            _userContext = userContext;
            _addressRepo = addressRepo;
        }

        public bool Add(Address entity)
        {
            var currentUser = _userContext.Get();
            var hasRight = currentUser?.AccessRights.Any(ar => ar == AccessRights.WRITE) ?? false;

            if(hasRight)
            {
                return _addressRepo.Add(entity);
            }
            else
            {
                Console.WriteLine($"A user {currentUser.Name} has no WRITE access right.");
                return false;
            }
        }

        public bool Delete(Guid id)
        {
            var currentUser = _userContext.Get();
            var hasRight = currentUser?.AccessRights.Any(ar => ar == AccessRights.WRITE) ?? false;

            if (hasRight)
            {
                return _addressRepo.Delete(id);
            }
            else
            {
                Console.WriteLine($"A user {currentUser.Name} has no WRITE access right.");
                return false;
            }
        }

        public Address Get(Guid id)
        {
            var currentUser = _userContext.Get();
            var hasRight = currentUser?.AccessRights.Any(ar => ar == AccessRights.READ) ?? false;

            if (hasRight)
            {
                return _addressRepo.Get(id);
            }
            else
            {
                Console.WriteLine($"A user {currentUser.Name} has no READ access right.");
                return null;
            }
        }

        public IEnumerable<Address> GetAll()
        {
            var currentUser = _userContext.Get();
            var hasRight = currentUser?.AccessRights.Any(ar => ar == AccessRights.READ) ?? false;

            if (hasRight)
            {
                return _addressRepo.GetAll();
            }
            else
            {
                Console.WriteLine($"A user {currentUser.Name} has no READ access right.");
                return Enumerable.Empty<Address>();
            }
        }

        public bool Update(Address entity)
        {
            var currentUser = _userContext.Get();
            var hasRight = currentUser?.AccessRights.Any(ar => ar == AccessRights.WRITE) ?? false;

            if (hasRight)
            {
                return _addressRepo.Update(entity);
            }
            else
            {
                Console.WriteLine($"A user {currentUser.Name} has no WRITE access right.");
                return false;
            }
        }
    }
}