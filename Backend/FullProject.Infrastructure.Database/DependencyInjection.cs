using FullProject.Domain.Repository;
using FullProject.Infrastructure.Database.Commerce;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FullProject.Infrastructure.Database
{
    public static class DependencyInjection
    {
        public static void AddCommerce(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<CommerceContext>();
            services.AddScoped<ICommerceRepository, CommerceContext>();
            services.AddScoped<ICommerceUnitOfWork>(serviceProvider => new CommerceUnitOfWork(new CommerceContext()));
        }
    }
}
