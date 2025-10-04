using Cortex.Mediator.DependencyInjection;
using Mapster;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace FullProject.Application
{
    public static class DependencyInjection
    {
        public static void AddMapping(this IServiceCollection services, Assembly[]? assembliesToScan = null)
        {
            List<Assembly> assemblies = [Assembly.GetExecutingAssembly()];

            if (assembliesToScan is not null && assembliesToScan.Length > 0)
            {
                assemblies.AddRange(assembliesToScan);
            }

            services.AddMapster();

            TypeAdapterConfig.GlobalSettings.Scan(assemblies.ToArray());
        }

        public static void AddMediator(this IServiceCollection services, IConfiguration configuration, Type[]? assembliesToScan = null)
        {
            List<Type> assemblies = [typeof(DependencyInjection), typeof(Domain.Queries.GetOrders)];

            if (assembliesToScan is not null && assembliesToScan.Length > 0)
            {
                assemblies.AddRange(assembliesToScan);
            }

            services.AddCortexMediator(configuration, assemblies.ToArray(), options =>
            {
                options.AddDefaultBehaviors();

                options.OnlyPublicClasses = false;
            });
        }
    }
}
