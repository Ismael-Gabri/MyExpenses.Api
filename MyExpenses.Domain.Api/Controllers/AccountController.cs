using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyExpenses.Domain.Commands.UserCommands.Input;
using MyExpenses.Domain.Commands.UserCommands.Output;
using MyExpenses.Domain.Handlers;
using MyExpenses.Domain.Repositories;
using MyExpenses.Domain.Services;
using MyExpenses.Domain.View;
using SecureIdentity.Password;

namespace MyExpenses.Domain.Api.Controllers
{
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IUserRepository _repository;
        private readonly UserHandler _handler;
        public AccountController(IUserRepository repository, UserHandler handler)
        {
            _repository = repository;
            _handler = handler;
        }

        [HttpPost("v1/accounts/login")]
        public object Login([FromBody] UserLoginViewModel model, [FromServices] TokenService tokenService)
        {
            var user = _repository.GetByEmail(model.Email);

            if (user == null)
                return BadRequest("Usuário ou senha inválido(s)");

            if (!PasswordHasher.Verify(user.Password, model.Password))
                return StatusCode(401, "Usuário ou senha inválidos");

            if(model.Email == Configuration.AdminEmail)
            {
                var tokenAdmin = tokenService.GenerateAdminToken(user);
                return Ok(tokenAdmin);
            }

            var token = tokenService.GenerateToken(user);

            return Ok(token);
        }
    }
}
