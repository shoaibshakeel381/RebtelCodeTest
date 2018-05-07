using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Rebtel.Business.DAL.Infrastructure;
using Rebtel.Business.DAL.Repositories;
using Rebtel.Business.Services;
using Rebtel.Business.Services.ServiceContracts;

namespace Rebtel.Business.WCFHost
{
    public class DIConfig : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                Component.For<IDbContextScopeFactory, DbContextScopeFactory>(),
                Component.For<IAmbientDbContextLocator, AmbientDbContextLocator>(),
                Component.For<IRepositoryFactory, RepositoryFactory>(),
                Component.For<IUserService, UserService>(),
                Component.For<ISubscriptionService, SubscriptionService>()
            );
        }
    }
}