using System.Web.Http;


namespace Rebtel.Client.WebAPI
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        
        protected void Application_Start()
        {
            DIConfig.Install(GlobalConfiguration.Configuration);

            GlobalConfiguration.Configure(WebApiConfig.Register);
        }
    }
}
