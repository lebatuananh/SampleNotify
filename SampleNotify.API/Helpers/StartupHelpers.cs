using System.Data;
using System.Reflection;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using SampleNotify.Infrastructure;
using SampleNotify.Infrastructure.Repositories;
using SampleNotify.Models.AggregateModels.NotifyConfigGroupAggregate;
using Shared.Behaviour;
using Shared.Behaviours;
using Shared.Constants;

namespace SampleNotify.API.Helpers
{
    public static class StartupHelpers
    {
        public static readonly string AssemblyName = typeof(Startup).GetTypeInfo().Assembly.GetName().Name;

        public static IServiceCollection AddDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DataNotifyDbContext>(opt =>
            {
                opt.UseLazyLoadingProxies()
                    .UseSqlServer(configuration.GetConnectionString(ConfigurationKeys.DefaultConnectionString));
            }).AddScoped<IDbConnection>(sp =>
            {
                var config = sp.GetRequiredService<IConfiguration>();
                var connection =
                    new SqlConnection(config.GetConnectionString(ConfigurationKeys.DefaultConnectionString));
                connection.Open();
                return connection;
            });
            return services;
        }

        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddTransient<INotifyConfigGroupRepository, NotifyConfigGroupRepository>();
            return services;
        }

        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            return services;
        }

        public static IServiceCollection AddIdentity(this IServiceCollection services, IConfiguration configuration)
        {
            return services;
        }

        public static IServiceCollection AddMediatREvent(this IServiceCollection services)
        {
            services.AddMediatR(typeof(Application.Write.Assembly).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(Application.Read.Assembly).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(Shared.Assembly).Assembly);
            return services;
        }

        public static IServiceCollection AddHealthCheck(this IServiceCollection services, IConfiguration configuration)
        {
            return services;
        }

        public static IServiceCollection AddBehaviour(this IServiceCollection services)
        {
            services.AddValidatorsFromAssembly(typeof(Application.Assembly).GetTypeInfo().Assembly);
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(PerformanceBehaviour<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(UnhandledExceptionBehaviour<,>));
            return services;
        }

        public static IServiceCollection AddAuthentication(this IServiceCollection services,
            IConfiguration configuration)
        {
            return services;
        }

        public static IServiceCollection AddAuthorization(this IServiceCollection services,
            IConfiguration configuration)
        {
            return services;
        }

        public static IServiceCollection AddApiVersioning(this IServiceCollection services,
            IConfiguration configuration)
        {
            return services;
        }

        public static void AddSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "iChiba CO private api v1",
                    Version = "v1"
                });
            });
        }

        public static void UseSwaggerUi(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "iChiba CO private api v1");
                c.DocumentTitle = "iChiba CO private api v1";
            });
        }
    }
}