
using Carter;
using FluentValidation;
using LiteBus.Commands;
using LiteBus.Extensions.Microsoft.DependencyInjection;
using LiteBus.Messaging;
using LiteBus.Queries;
using Microsoft.EntityFrameworkCore;
using Store.Common.Persistence;

namespace Store.Common.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddCommonServices(this IServiceCollection services, IConfiguration configuration)
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

            services.AddOpenApi();

            services.AddCarter();


            services.AddScoped<IDbConnectionFactory, PostgreSqlConnectionFactory>();
            services.AddDbContext<AppDbContext>(options =>
                        {
                            options.UseNpgsql(configuration.GetConnectionString("Default"));
                        });

            return services;
        }
    }
}