﻿using Autofac;
using Autofac.Integration.WebApi;
using System.Reflection;
using System.Web.Http;
using UserCrud.Domain;
using UserCrud.Domain.DefaultData;
using UserCrud.WebApi.Configurations;
using UsersCrud.Repository;

namespace UserCrud.WebApi
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
                .InstancePerDependency();

            builder.RegisterType<UsersDomain>().As<IUsersDomain>().SingleInstance();
            builder.RegisterType<SeedUser>().As<ISeedUser>();

            builder.RegisterModule(new AutoMapperInstaller());
            return builder.Build();
        }
    }
}