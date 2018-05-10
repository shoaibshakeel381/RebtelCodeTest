using Rebtel.Business.DAL.Infrastructure;
using Rebtel.Business.DAL.Repositories;
using Rebtel.Business.Services;
using Rebtel.Business.Services.ServiceContracts;
using SimpleInjector;
using SimpleInjector.Integration.Wcf;

namespace Rebtel.Business.WCFHost
{
    public static class DIConfig
    {

        public static void Install()
        {
            //
            // Create a new Simple Injector container
            var container = new Container();

            //
            // Register 
            container.Register<IDbContextScopeFactory, DbContextScopeFactory>();
            container.Register<IAmbientDbContextLocator, AmbientDbContextLocator>();
            container.Register<IRepositoryFactory, RepositoryFactory<AppDbContext>>();
            container.Register<IUserService, UserService>();
            container.Register<ISubscriptionService, SubscriptionService>();

            //
            // 4. Register container as default DependencyResolver
            // Register the container to the SimpleInjectorServiceHostFactory.
            SimpleInjectorServiceHostFactory.SetContainer(container);
        }
    }
}