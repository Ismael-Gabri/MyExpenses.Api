using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyExpenses.Domain.Services;

namespace MyExpenses.Domain.Api.Controllers
{
    [ApiController]
    public class AccountController : ControllerBase
    {
        [HttpPost("v1/login")]
        public IActionResult Login([FromServices]TokenService tokenService)
        {
            var token = tokenService.GenerateToken(null);

            return Ok(token);
        }

        [HttpGet("v1/login/admin")]
        [Authorize(Roles = "admin")]
        public IActionResult GetAdmin()
        {
            return Ok(User.Identity.Name);
        }
    }
}
