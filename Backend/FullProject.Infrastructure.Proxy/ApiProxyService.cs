using FullProject.Domain.Services;
using Org.OpenAPITools.Api;

namespace FullProject.Infrastructure.Proxy
{
    internal class ApiProxyService : IApiProxyService
    {
        private readonly ITestApi _testApi;

        public ApiProxyService(ITestApi testApi)
        {
            _testApi = testApi;
        }

        public async ValueTask<object?> Test()
        {
            var result = await _testApi.ApiV1TestTestGetOrDefaultAsync();

            return result;
        }
    }
}
