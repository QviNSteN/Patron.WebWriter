using Autofac;
using AutoMapper;
using AutoMapper.EquivalencyExpression;
using Patron.WebWriter.API.Configurations.Autofac;
using Patron.WebWriter.BI.Options;
using Patron.WebWriter.EF;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Text.Json.Serialization;
using App.Metrics;
using App.Metrics.Scheduling;
using System;
using System.Threading.Tasks;
using App.Metrics.Extensions.Configuration;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Patron.WebWriter.API
{
    public class Startup
    {
        public Startup(IWebHostEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            this.Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }
        public ILifetimeScope AutofacContainer { get; private set; }


        public void ConfigureServices(IServiceCollection services)
        {
            services.AddOptions();

            services.AddCors(o => o.AddPolicy("AllowAll", builder =>
            {
                builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader();
            }));

            services.AddDbContext<ServiceDbContext>(options =>
                options.UseNpgsql(Configuration.GetConnectionString("DataBase")));
        
            services.AddAutoMapper((serviceProvider, automapper) =>
            {
                automapper.AddCollectionMappers();
                automapper.UseEntityFrameworkCoreModel<ServiceDbContext>(serviceProvider);
            }, typeof(ServiceDbContext).Assembly);

            services.AddMetricsTrackingMiddleware();
            services.AddMvcCore().AddMetricsCore();

            services.AddControllers()
                    .AddNewtonsoftJson(options =>
                        options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore).AddJsonOptions(opt =>
                        {
                            opt.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
                        });

            services.AddSwaggerGen(c =>
                    c.AddServer(new Microsoft.OpenApi.Models.OpenApiServer()
                    {
                        Url = Configuration.GetValue<string>("SwaggerUrl")
                    }));
        }

        public void ConfigureContainer(ContainerBuilder builder)
        {
            builder.RegisterModule(new ServiceModules());
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseMetricsApdexTrackingMiddleware();
            app.UseMetricsRequestTrackingMiddleware();
            app.UseMetricsErrorTrackingMiddleware();
            app.UseMetricsActiveRequestMiddleware();
            app.UseMetricsPostAndPutSizeTrackingMiddleware();
            app.UseMetricsOAuth2TrackingMiddleware();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            } 

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });

//            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
