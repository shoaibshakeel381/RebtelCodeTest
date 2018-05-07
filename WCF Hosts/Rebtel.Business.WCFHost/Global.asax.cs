using System;
using Castle.Facilities.WcfIntegration;
using Castle.Windsor;
using Rebtel.Business.DTOs;

namespace Rebtel.Business.WCFHost
{
    public class Global : System.Web.HttpApplication
    {
        private static IWindsorContainer _container;

        protected void Application_Start(object sender, EventArgs e)
        {
            // Configure Dependency Injection
            _container = new WindsorContainer();
            _container.AddFacility<WcfFacility>();
            _container.Install(new DIConfig());

            // Configure Property Mappings from DTOs to Domain Entities
            PropertyMappingConfigurator.Configure();
        }
    }
}