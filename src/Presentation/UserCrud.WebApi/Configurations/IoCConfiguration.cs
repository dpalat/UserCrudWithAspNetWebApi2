using Autofac;
using Autofac.Integration.WebApi;
using System.Reflection;
using System.Web.Http;
using UserCrud.Domain;
using UserCrud.Domain.Cryptography;
using UserCrud.Domain.DefaultData;
using UsersCrud.Repository;

namespace UserCrud.WebApi.Configurations
{
    public static class IoCConfiguration
    {
        public static void ConfigureIoC(HttpConfiguration configuration)
        {
            var builder = new ContainerBuilder();
            var container = builder.Build();
            var webApiResolver = new AutofacWebApiDependencyResolver(container);
            GlobalConfiguration.Configuration.DependencyResolver = webApiResolver;

            configuration.DependencyResolver = new AutofacWebApiDependencyResolver(
                RegisterServices(new ContainerBuilder())
            );
        }

        private static IContainer RegisterServices(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly()).PropertiesAutowired();

            builder
                .RegisterGeneric(typeof(InMemoryRepository<>))
                .As(typeof(IRepository<>))
                .SingleInstance();

            builder.RegisterType<UsersDomain>().As<IUsersDomain>().SingleInstance().AutoActivate();
            builder.RegisterType<SeedUser>().As<ISeedUser>();
            builder.RegisterType<AuthenticationDomain>().As<IAuthenticationDomain>();
            builder.RegisterType<Hasher>().As<IHasher>();

            builder.RegisterModule(new AutoMapperInstaller());
            return builder.Build();
        }
    }
}