using Autofac;
using Autofac.Integration.Mvc;
using System;
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
            //mvc
            builder.RegisterControllers(Assembly.GetExecutingAssembly());
            builder.RegisterAssemblyModules(Assembly.GetExecutingAssembly());
            builder.RegisterModelBinders(Assembly.GetExecutingAssembly());
            builder.RegisterModelBinderProvider();

            //others
            builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly())
                .PropertiesAutowired();

            builder.RegisterType<UserService>().As<IUserService>();

            builder.Register(ctx => new HttpClient()
            {
                BaseAddress = new Uri("http://localhost:50000/api/")
            }).As<HttpClient>().SingleInstance();

            builder.RegisterModule(new AutoMapperInstaller());
            return builder.Build();
        }
    }
}