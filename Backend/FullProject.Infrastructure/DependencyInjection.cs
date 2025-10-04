using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FullProject.Infrastructure
{
    public static class DependencyInjection
    {
        public static void AddServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<ITimeService>(provider =>
            {
                var ntpServer = configuration.GetValue<string>("Endpoints:NtpService");

                if (!string.IsNullOrWhiteSpace(ntpServer))
                {
                    return new NtpTimeService(ntpServer);
                }
                else
                {
                    return new SystemTimeService();
                }
            });
        }
    }
}
