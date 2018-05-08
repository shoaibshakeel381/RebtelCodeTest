using System.Web.Http;
using Rebtel.Client.ServiceContracts;
using Rebtel.Client.ServiceProxies;
using SimpleInjector;
using SimpleInjector.Integration.WebApi;
using SimpleInjector.Lifestyles;


namespace Rebtel.Client.WebAPI
{
    public static class DIConfig
    {
        private static Container container;

        public static Container Install(HttpConfiguration configuration)
        {
            //
            // 1. Create a new Simple Injector container
            container = new Container();

            //
            // 2. Configure the container (register)
            container.RegisterWebApiControllers(configuration);
            //
            // Register WCF Service Clients
            container.Register<IUserService, UserServiceClient>(new AsyncScopedLifestyle());
            container.Register<ISubscriptionService, SubscriptionServiceClient>(new AsyncScopedLifestyle());

            //
            // 3. Verify Registrations {optional}
            container.Verify();

            //
            // 4. Register container as default DependencyResolver
            configuration.DependencyResolver = new SimpleInjectorWebApiDependencyResolver(container);

            return container;
        }
    }
}