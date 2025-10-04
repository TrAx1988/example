using Microsoft.Extensions.DependencyInjection;

namespace FullProject.Infrastructure
{
    public static class DependencyInjection
    {
        public static void AddInfrastructureServices(this IServiceCollection services)
        {
            services.AddSingleton<ITimeService, TimeService>();
        }
    }
}
