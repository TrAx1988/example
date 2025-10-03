
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
            builder.Services.AddCommerce(builder.Configuration);
            builder.Services.AddGraphQL();


            builder.Services.AddControllers();
            builder.Services.AddOpenApi(option =>
            {
                option.AddDocumentTransformer<>
            });

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

            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
                app.MapScalarApiReference(options =>
                {
                    options.Authentication = new ScalarAuthenticationOptions()
                    {
                        PreferredSecuritySchemes = ["Bearer"],
                    };

                    options.AddPreferredSecuritySchemes("Bearer");
                });
            }

            app.UseHttpsRedirection();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseGraphQL();

            app.MapControllers();

            app.Run();
        }
    }
}
