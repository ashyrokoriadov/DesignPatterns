using FluentValidation;
using Proxy.Workers;
using System;

namespace Proxy.Proxies.Validators
{
    class AddressValidator : AbstractValidator<Address>
    {
        public AddressValidator()
        {
            RuleFor(a => a.Id).NotEqual(Guid.Empty).WithMessage("Please specify an id");
            RuleFor(a => a.ZipCode).NotEmpty().WithMessage("Please specify a postal code");
            RuleFor(a => a.Country).NotEmpty().WithMessage("Please specify a country name")
                .ChildRules(country =>
                    {
                        var maxLength = 128;
                        country.RuleFor(d => d)
                            .MaximumLength(maxLength)
                            .WithMessage($"The country name should not be larger than {maxLength}");
                    });
            RuleFor(a => a.City).NotEmpty().WithMessage("Please specify a city name")
               .ChildRules(country =>
               {
                   var maxLength = 64;
                   country.RuleFor(d => d)
                        .MaximumLength(maxLength)
                        .WithMessage($"The city name should not be larger than {maxLength}");
               });
            RuleFor(x => x.AddressLine1).NotEmpty().WithMessage("Please specify a street name and house number");
        }
    }
}
