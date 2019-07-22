using Autofac;
using Autofac.Integration.Mvc;
using System;
using System.Configuration;
using System.Net.Http;
using System.Reflection;
using System.Web.Mvc;
using UserCrud.WebUI.Services;

namespace UserCrud.WebUI.Configurations
{
    public static class IoCConfiguration
    {
        public static void ConfigureIoC()
        {
            var builder = new ContainerBuilder();
            var container = RegisterServices(builder);

            var mvcResolver = new AutofacDependencyResolver(container);
            DependencyResolver.SetResolver(mvcResolver);
        }

        private static IContainer RegisterServices(ContainerBuilder builder)
        {
            builder.RegisterControllers(Assembly.GetExecutingAssembly());
            builder.RegisterAssemblyModules(Assembly.GetExecutingAssembly());
            builder.RegisterModelBinders(Assembly.GetExecutingAssembly());
            builder.RegisterModelBinderProvider();

            builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly())
                .PropertiesAutowired();

            builder.RegisterType<UserService>().As<IUserService>();
            string urlWebAPI = ConfigurationManager.AppSettings["UrlWebAPI"];
            builder.Register(ctx => new HttpClient()
            {
                BaseAddress = new Uri(urlWebAPI)
            }).As<HttpClient>().SingleInstance();

            builder.RegisterModule(new AutoMapperInstaller());
            return builder.Build();
        }
    }
}