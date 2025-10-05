using FullProject.Domain.Services;
using FullProject.Infrastructure.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Org.OpenAPITools.Api;
using Org.OpenAPITools.Client;
using Org.OpenAPITools.Extensions;

namespace FullProject.Infrastructure.Proxy
{
    public static class DependencyInjection
    {
        public static void AddProxyServices(this IServiceCollection services, IConfiguration configuration)
        {
            var hosting = new HostConfiguration(services);

            var address = configuration.GetValue<string>("Endpoint:TestApi");

            services.AddHttpClient<ITestApi, TestApi>((serviceProvider, client) =>
            {
                client.ConfigureHttpClient(serviceProvider, address ?? string.Empty);
            }).AddRetryPolicy(3).AddTimeoutPolicy(TimeSpan.FromSeconds(10)).AddCircuitBreakerPolicy(2, TimeSpan.FromSeconds(10));

            services.AddTransient<IApiProxyService, ApiProxyService>();
        }
    }
}
