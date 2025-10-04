using FullProject.Domain.Repository;
using FullProject.Infrastructure.Database.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FullProject.Infrastructure.Database
{
    public static class DependencyInjection
    {
        public static void AddCommerce(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<CommerceContext>(options => options.UseNpgsql("Host=localhost;Port=5432;Database=sit;Username=sit;Password=sit;"));

            services.AddSingleton<ISessionFactory, SessionFactory>();
            services.AddScoped<ICommerceRepository, CommerceContext>();
        }
    }
}
