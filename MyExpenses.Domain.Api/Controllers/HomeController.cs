using Microsoft.AspNetCore.Mvc;

namespace MyExpenses.Domain.Api.Controllers
{
    [ApiController]
    public class HomeController : ControllerBase
    {
        [HttpGet("")]
        public object Get()
        {
            return new { version = "Version 0.0.1" };
        }
    }
}
