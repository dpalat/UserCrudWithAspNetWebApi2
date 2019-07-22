using Swashbuckle.Application;
using System.Web.Http;
using System.Web.Mvc;
using UserCrud.WebApi.Configurations;

namespace UserCrud.WebApi
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            IoCConfiguration.ConfigureIoC(GlobalConfiguration.Configuration);
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            GlobalConfiguration.Configuration
                .EnableSwagger(c => c.SingleApiVersion("v1", "SomosTechies API"))
                .EnableSwaggerUi();

            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
        }
    }
}