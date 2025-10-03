using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FullProject.Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/test")]
    public class TestController : ControllerBase
    {
        public TestController()
        {
        }

        [HttpGet]
        [Route("test")]
        public bool Test()
        {
            return true;
        }
    }
}
