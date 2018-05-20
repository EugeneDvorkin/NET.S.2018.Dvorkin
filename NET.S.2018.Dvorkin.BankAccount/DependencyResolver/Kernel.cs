using System.Data.Entity;
using Bll.Interface.Interface;
using BLL.Service;
using DAL.Fake.Repositories;
using DAL.Interface.Interfaces;
using DAL.Repositories;
using Ninject;
using ORM;

namespace DependencyResolver
{
    /// <summary>
    /// Contains implementation of dependency resolver.
    /// </summary>
    public static class Kernel
    {
        /// <summary>
        /// Configurations of the resolver.
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        public static void ConfigurateResolver(this IKernel kernel)
        {
            Configure(kernel);
        }

        /// <summary>
        /// Configures the specified kernel.
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void Configure(IKernel kernel)
        {
            kernel.Bind<DbContext>().To<BankEntities>();
            //kernel.Bind<IPersonRepository>().To<PersonRepository>();
            //kernel.Bind<IAccountRepository>().To<AccountRepository>();
            kernel.Bind<IPersonRepository>().To<PersonFakeRepository>();
            kernel.Bind<IAccountRepository>().To<AccountFakeRepository>();
            //kernel.Bind<IUnitOfWork>().To<UnitOfWork>();
            kernel.Bind<IUnitOfWork>().To<FakeUnitOfWork>();
            IGenerator generator = NumberService.Instance;
            // kernel.Bind<IGenerator>().To<NumberService>().InSingletonScope();
            //kernel.Bind<IBankService>().To<BankService>().WithConstructorArgument("UnitOfWork")
            //    .WithConstructorArgument("AccountRepository").WithConstructorArgument("PersonRepository").WithConstructorArgument(generator);
            kernel.Bind<IBankService>().To<BankService>().WithConstructorArgument("FakeUnitOfWork")
                .WithConstructorArgument("AccountFakeRepository").WithConstructorArgument("PersonFakeRepository").WithConstructorArgument(generator);
        }
    }
}
