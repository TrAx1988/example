using Cortex.Mediator.DependencyInjection;
using Mapster;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace FullProject.Application
{
    public static class DependencyInjection
    {
        public static void AddExampleApplication(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddMapster();

            TypeAdapterConfig.GlobalSettings.Scan(Assembly.GetExecutingAssembly());
        }

        public static void AddMediator(this IServiceCollection services, IConfiguration configuration, Type[] assemblyToScan)
        {
            List<Type> assemblies = [typeof(DependencyInjection), typeof(Domain.Queries.GetOrders)];

            if (assemblyToScan is not null && assemblyToScan.Length > 0)
            {
                assemblies.AddRange(assemblyToScan);
            }

            services.AddCortexMediator(configuration, assemblies.ToArray(), options =>
            {
                options.AddDefaultBehaviors();

                options.OnlyPublicClasses = false;
            });
        }
    }
}
