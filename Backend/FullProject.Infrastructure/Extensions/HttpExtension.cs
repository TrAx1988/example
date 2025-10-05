using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Primitives;
using System.Net.Http.Headers;

namespace FullProject.Infrastructure.Extensions
{
    public static class HttpExtension
    {
        public static void ConfigureHttpClient(this HttpClient httpClient, IServiceProvider serviceProvider, string address, bool useExistingToken = true)
        {
            if (string.IsNullOrWhiteSpace(address))
            {
                return;
            }

            httpClient.BaseAddress = new Uri(address);

            if (useExistingToken)
            {
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", serviceProvider.GetService<IHttpContextAccessor>()?.GetCurrentAccessToken() ?? string.Empty);
            }
        }

        public static string? GetCurrentAccessToken(this IHttpContextAccessor httpContextAccessor)
        {
            StringValues authorizationHeader = new StringValues();

            httpContextAccessor?.HttpContext?.Request?.Headers?.TryGetValue("Authorization", out authorizationHeader);

            if (authorizationHeader.Count > 0)
            {
                var bearerToken = authorizationHeader.SingleOrDefault()?.Replace("Bearer ", string.Empty, StringComparison.InvariantCultureIgnoreCase);

                return bearerToken ?? null;
            }

            return null;
        }
    }
}
