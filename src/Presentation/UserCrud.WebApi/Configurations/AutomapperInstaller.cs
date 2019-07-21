using Autofac;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;

namespace UserCrud.WebApi.Configurations
{
    /// <summary>
    /// AutoMapper installer is a good way to register all abaout AutoMapper in Autofac.
    /// Original Idea from http://www.protomatter.co.uk/blog/development/2017/02/modular-automapper-registrations-with-autofac/
    /// </summary>
    public class AutoMapperInstaller : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var assemblies = AppDomain.CurrentDomain.GetAssemblies();
            builder.RegisterAssemblyTypes(assemblies)
                .Where(t => typeof(Profile).IsAssignableFrom(t) && !t.IsAbstract && t.IsPublic)
                .As<Profile>();

            builder.Register(c => new MapperConfiguration(cfg =>
            {
                foreach (var profile in c.Resolve<IEnumerable<Profile>>())
                {
                    cfg.AddProfile(profile);
                }
            })).AsSelf().SingleInstance();

            builder.Register(c => c.Resolve<MapperConfiguration>()
                .CreateMapper(c.Resolve))
                .As<IMapper>()
                .InstancePerLifetimeScope();
        }
    }
}