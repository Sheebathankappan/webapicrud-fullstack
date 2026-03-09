using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.UI.V4.Pages.Account.Internal;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using WebAPICRUD.Models;
using WebAPICRUD.Services.Implementations;
using WebAPICRUD.Services.Interfaces;


namespace WebAPICRUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly ITokenService _tokenService;
        public AuthController(ITokenService tokenService)
        {
            _tokenService=tokenService;
        }
        [HttpPost("login")]
        public IActionResult login(LoginRequest login)
        {
            if(login.Username=="admin" && login.Password=="123")
            {
                var token = _tokenService.GenerateToken(login.Username);
                return Ok(token);
            }
            return Unauthorized();
        }
    }
}
