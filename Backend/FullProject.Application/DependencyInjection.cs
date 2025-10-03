using Cortex.Mediator.DependencyInjection;
using Mapster;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FullProject.Application
{
    public static class DependencyInjection
    {
        public static void AddExampleApplication(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddCortexMediator(configuration, [typeof(DependencyInjection)], options =>
            {
                options.AddDefaultBehaviors();

                options.OnlyPublicClasses = false;
            });

            services.AddMapster();
        }
    }
}
