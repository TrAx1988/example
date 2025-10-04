using FullProject.Domain.Repository;
using FullProject.Infrastructure.Data;
using FullProject.Infrastructure.Database.Commerce;
using FullProject.Infrastructure.Database.Ef;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FullProject.Infrastructure.Database
{
    public static class DependencyInjection
    {
        public static void AddEf(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<IUnitOfWorkFactory, UnitOfWorkFactory>();
        }

        public static void AddCommerce(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<CommerceContext>(options => options.UseNpgsql("Host=localhost;Port=5432;Database=sit;Username=sit;Password=sit;"));

            services.AddScoped<ICommerceRepository, CommerceContext>();
        }
    }
}
