using Microsoft.AspNetCore.Mvc;

namespace FullProject.Api.Controllers
{
    [Route("api/test")]
    [ApiController]
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
