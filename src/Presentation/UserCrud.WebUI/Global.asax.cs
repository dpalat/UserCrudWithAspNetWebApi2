using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using UserCrud.WebUI.Configurations;
using System.Web.Http;

namespace UserCrud.WebUI
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            IoCConfiguration.ConfigureIoC();
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}