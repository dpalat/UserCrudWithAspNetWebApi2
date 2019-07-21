using Autofac;
using Autofac.Integration.Mvc;
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

            // Set the dependency resolver for MVC.
            var mvcResolver = new AutofacDependencyResolver(container);
            DependencyResolver.SetResolver(mvcResolver);

            //configuration.DependencyResolver = new AutofacWebApiDependencyResolver(
            //    RegisterServices(new ContainerBuilder())
            //);
            //return container;
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

            builder.RegisterModule(new AutoMapperInstaller());
            return builder.Build();
        }
    }
}