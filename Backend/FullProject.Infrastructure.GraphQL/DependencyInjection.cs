using FullProject.Infrastructure.GraphQL.Commerce.Query;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FullProject.Infrastructure.GraphQL
{
    public static class DependencyInjection
    {
        public static void AddGraphQL(this IServiceCollection services, IConfiguration configuration)
        {
            services
                .AddGraphQLServer()
                .AddAuthorization()
                .AddFiltering()
                .AddProjections()
                .AddSorting()
                .AddQueryType<OrderQuery>();
        }

        public static void UseGraphQL(this IApplicationBuilder app)
        {
            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGraphQL();
            });
        }
    }
}
