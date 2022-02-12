using Autofac;
using Autofac.Features.AttributeFilters;
using FluentValidation;
using Proxy.Proxies;
using Proxy.Proxies.AccessControl;
using Proxy.Proxies.Validators;
using Proxy.Workers;
using System;

namespace Proxy
{
    class Program
    {
        public const string BASE_REPO = "BaseRepo";
        public const string REPO_VALDIATOR_PROXY= "RepoValidatorProxy";
        public const string REPO_ACCESS_CONTROLL = "RepoAccessControlPrxoy";

        private static IRepo<Address, Guid> _addressRepo;
        private static IUserContext _userContext;

        static void Main(string[] args)
        {
            RegisterDependencies();
            ResolveDependencies();

            _userContext.Set(new User("Andrew", new[] { AccessRights.READ, AccessRights.WRITE }));

            var address = new Address()
            {
                Id = Guid.Parse("556bf2e8-b025-489b-b8f2-f33ba2d3d320"),
                ZipCode = "127000",
                Country = "Russia",
                City = "Moscow",
                AddressLine1 = "Akademika Korolyova 12",
                AddressLine2 = "some test value"
            };

            var addressToUpdate = new Address()
            {
                Id = Guid.Parse("556bf2e8-b025-489b-b8f2-f33ba2d3d320"),
                ZipCode = "127000",
                Country = "Russia",
                City = "Moscow",
                AddressLine1 = "",
                AddressLine2 = "some test value"
            };

            PerformAllRepoOperations(address, addressToUpdate);

            _userContext.Set(new User("Aleksandr", new[] { AccessRights.READ }));

            PerformAllRepoOperations(address, addressToUpdate);

            _userContext.Set(new User("Alexei", new[] { AccessRights.WRITE }));

            PerformAllRepoOperations(address, addressToUpdate);

            Console.ReadKey();
        }

        private static void PerformAllRepoOperations(Address address, Address addressToUpdate)
        {
            var addResult = _addressRepo.Add(address);
            Console.WriteLine($"Add result: {addResult}");

            var updatedResult = _addressRepo.Add(addressToUpdate);
            Console.WriteLine($"Update result: {updatedResult}");

            var getResult = _addressRepo.Get(address.Id);
            if (getResult != null)
            {
                Console.WriteLine($"Get result: {getResult}");
            }

            var getAllResult = _addressRepo.GetAll();
            foreach(var get in getAllResult)
                Console.WriteLine($"GetAll result: {get}");

            var deleteResult = _addressRepo.Delete(address.Id);
            Console.WriteLine($"Delete result: {deleteResult}");
        }

        private static void RegisterDependencies()
        {
            Console.WriteLine("Registrering dependencies...");

            Builder.RegisterType<AddressRepo>().Named<IRepo<Address, Guid>>(BASE_REPO).SingleInstance();
            Builder.RegisterType<AddressValidator>().As<IValidator<Address>>();
            Builder.RegisterType<UserContext>().As<IUserContext>().SingleInstance();

            Builder.RegisterType<AddressRepoValidatorProxy>()
                .Named<IRepo<Address, Guid>>(REPO_VALDIATOR_PROXY)
                .WithAttributeFiltering()
                .SingleInstance();

            Builder.RegisterType<AddressRepoAccessProxy>()
                .Named<IRepo<Address, Guid>>(REPO_ACCESS_CONTROLL)
                .WithAttributeFiltering()
                .SingleInstance();

            Console.WriteLine("Dependencies were registred.");
        }

        private static void ResolveDependencies()
        {
            Console.WriteLine("Registrering dependencies...");

            using (var scope = Container.BeginLifetimeScope())
            {
                _addressRepo = scope.ResolveNamed <IRepo<Address, Guid>>(REPO_ACCESS_CONTROLL);
                _userContext = scope.Resolve<IUserContext>();
            }

            Console.WriteLine("Dependencies were registred.");
        }

        private static IContainer _container;
        public static IContainer Container => _container ?? (_container = Builder.Build());

        private static ContainerBuilder _builder;
        public static ContainerBuilder Builder => _builder ?? (_builder = new ContainerBuilder());
    }
}
