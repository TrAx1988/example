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

        public static void AddMediator(this IServiceCollection services, IConfiguration configuration, Assembly[]? assembliesToScan = null)
        {
            List<Assembly> assemblies = [Assembly.GetAssembly(typeof(DependencyInjection))];

            if (assembliesToScan is not null && assembliesToScan.Length > 0)
            {
                assemblies.AddRange(assembliesToScan);
            }

            services.AddCortexMediator(configuration, assemblies.Select(i => i.ExportedTypes.FirstOrDefault()).Where(i => i is not null).ToArray(), options =>
            {
                options.AddDefaultBehaviors();

                options.OnlyPublicClasses = false;
            });
        }
    }
}
