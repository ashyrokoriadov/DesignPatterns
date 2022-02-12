using Autofac.Features.AttributeFilters;
using FluentValidation;
using Proxy.Workers;
using System;
using System.Collections.Generic;

namespace Proxy.Proxies
{
    class AddressRepoValidatorProxy : IRepo<Address, Guid>
    {
        private readonly IValidator<Address> _addressValidator;
        private readonly IRepo<Address, Guid> _addressRepo;
        
        public AddressRepoValidatorProxy(
            IValidator<Address> addressValidator, 
            [KeyFilter(Program.BASE_REPO)] IRepo<Address, Guid> addressRepo)
        {
            _addressValidator = addressValidator;
            _addressRepo = addressRepo;
        }

        public bool Add(Address entity)
        {
            var validationResult = _addressValidator.Validate(entity);
            if (validationResult.IsValid)
                return _addressRepo.Add(entity);
            else
            {
                foreach (var error in validationResult.Errors)
                    Console.WriteLine(error.ErrorMessage);
                return false;
            }
        }

        public bool Delete(Guid id)
        {
            if (id == Guid.Empty)
                return false;

            return _addressRepo.Delete(id);
        }

        public Address Get(Guid id) => _addressRepo.Get(id);

        public IEnumerable<Address> GetAll() => _addressRepo.GetAll();

        public bool Update(Address entity)
        {
            var validationResult = _addressValidator.Validate(entity);
            if (validationResult.IsValid)
                return _addressRepo.Update(entity);
            else
            {
                foreach (var error in validationResult.Errors)
                    Console.WriteLine(error.ErrorMessage);
                return false;
            }
        }
    }
}
