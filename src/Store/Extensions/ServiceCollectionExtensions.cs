

using FluentValidation;
using LiteBus.Commands;
using LiteBus.Extensions.Microsoft.DependencyInjection;
using LiteBus.Messaging;
using LiteBus.Queries;
using Microsoft.EntityFrameworkCore;
using Store.Infrastructure.Persistence;

namespace Store.Extensions
{
    public static class ServiceCollectionExtensions
    {

        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddScoped<IDbConnectionFactory, PostgreSqlConnectionFactory>();
            services.AddDbContext<AppDbContext>(options =>
                        {
                            options.UseNpgsql(configuration.GetConnectionString("Default"));
                        });
            return services;
        }

        public static IServiceCollection AddCommonFeaturesServices(this IServiceCollection services)
        {
            var applicationLayerAssembly = typeof(Program).Assembly;

            services.AddLiteBus(liteBus =>
            {
                liteBus.AddCommands(module =>
                {
                    module.RegisterFromAssembly(applicationLayerAssembly);
                });

                liteBus.AddQueries(module => module.RegisterFromAssembly(applicationLayerAssembly));

                liteBus.AddMessaging(module => { });

            });

            services.AddValidatorsFromAssembly(applicationLayerAssembly);

            return services;
        }
    }
}