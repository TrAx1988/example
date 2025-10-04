using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FullProject.Api.Proxy.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/v1/test")]
    public class TestController : ControllerBase
    {
        [HttpGet]
        [Route("test")]
        public string GetTest()
        {
            return Guid.NewGuid().ToString();
        }
    }
}
