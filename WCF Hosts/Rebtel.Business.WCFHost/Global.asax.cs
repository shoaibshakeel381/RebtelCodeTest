using System;
using Rebtel.Business.DTOs;

namespace Rebtel.Business.WCFHost
{
    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            // Configure Dependency Injection
            DIConfig.Install();

            // Configure Property Mappings from DTOs to Domain Entities
            PropertyMappingConfigurator.Configure();
        }
    }
}