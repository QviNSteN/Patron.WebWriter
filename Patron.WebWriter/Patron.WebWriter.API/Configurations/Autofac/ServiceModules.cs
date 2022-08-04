using Autofac;
using AutoMapper;
using Divergic.Configuration.Autofac;
using Patron.WebWriter.API.Configurations.AutoMapper;
using Patron.WebWriter.BI.Options;
using Patron.WebWriter.BI.Interfaces;
using Patron.WebWriter.BI.Services;
using System;

namespace Patron.WebWriter.API.Configurations.Autofac
{
    public class ServiceModules : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            builder.RegisterType<Backend>()
                .As<IBackend>()
                .SingleInstance();

            builder.RegisterType<FileService>()
                .As<IFile>();

            builder.Register(context => new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<AutoMapperProfile>();
            }
            )).AsSelf().SingleInstance();

            builder.Register(c =>
            {
                var context = c.Resolve<IComponentContext>();
                var config = context.Resolve<MapperConfiguration>();
                return config.CreateMapper(context.Resolve);
            })
            .As<IMapper>()
            .InstancePerLifetimeScope();

            var env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

            var resolver = new EnvironmentJsonResolver<Config>("appsettings.json", $"appsettings.{env}.json");
            var module = new ConfigurationModule(resolver);

            builder.RegisterModule(module);
        }
    }
}
