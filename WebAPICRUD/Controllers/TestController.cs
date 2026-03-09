using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPICRUD.Services.Implementations;

namespace WebAPICRUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public TestController(IConfiguration configuration)
        {
            _configuration=configuration;
        }
        [HttpGet]
        public IActionResult Get()
        {
            TokenService tokenService = new TokenService(_configuration);
            tokenService.GenerateToken("ii");
            return Ok();
        }
    }
}
