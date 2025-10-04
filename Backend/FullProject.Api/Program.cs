
using FullProject.Api.Helper;
using FullProject.Application;
using FullProject.Infrastructure;
using FullProject.Infrastructure.Database;
using FullProject.Infrastructure.GraphQL;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Scalar.AspNetCore;

namespace FullProject.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddInfrastructureServices();

            builder.Services.AddCommerce(builder.Configuration);
            builder.Services.AddGraphQL();

            builder.Services.AddMediator(builder.Configuration, [typeof(Infrastructure.Kafka.DependencyInjection)]);

            builder.Services.AddExampleApplication(builder.Configuration);


            // Application Insights
            var applicationInsights = builder.Configuration.GetValue<string>("ApplicationInsights:ConnectionString");

            if (!string.IsNullOrWhiteSpace(applicationInsights))
            {
                builder.Services.AddApplicationInsightsTelemetry(option =>
                {
                    option.ConnectionString = applicationInsights;
                });
            }

            builder.Services.AddHttpContextAccessor();
            builder.Services.AddControllers();
            builder.Services.AddOpenApi(option =>
            {
                option.AddDocumentTransformer<BearerSecuritySchemeTransformer>();
            });


            // Authentication
            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.Authority = builder.Configuration.GetValue<string>("Authentication:Authority");
                options.Audience = builder.Configuration.GetValue<string>("Authentication:Audience");
            });



            var app = builder.Build();

            // Open Api
            app.MapOpenApi();

            if (app.Environment.IsDevelopment())
            {
                app.MapScalarApiReference(options =>
                {
                    options.Authentication = new ScalarAuthenticationOptions()
                    {
                        PreferredSecuritySchemes = ["Bearer"],
                    };
                });
            }

            app.UseHttpsRedirection();

            app.UseAuthentication();
            app.UseAuthorization();

            // Use services to the container.
            app.UseGraphQL();


            app.MapControllers();

            app.Run();
        }
    }
}
