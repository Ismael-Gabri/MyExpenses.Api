using Microsoft.AspNetCore.Mvc;
using MyExpenses.Domain.Commands.UserCommands.Input;
using MyExpenses.Domain.Commands.UserCommands.Output;
using MyExpenses.Domain.Entities;
using MyExpenses.Domain.Handlers;
using MyExpenses.Domain.Queries;
using MyExpenses.Domain.Repositories;
using MyExpenses.Domain.ValueObjects;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace MyExpenses.Domain.Api.Controllers
{
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _repository;
        private readonly UserHandler _handler;
        public UserController(IUserRepository repository, UserHandler handler)
        {
            _repository = repository;
        }
        //GET

        [HttpGet("users")]
        public IEnumerable<ListUserQueryResult> Get()
        {
            return _repository.Get();
        }

        [HttpGet("users/{id:Guid}")]
        public GetUserQueryResult GetById([FromRoute] Guid id)
        {
            return _repository.Get(id);
        }

        [HttpGet("users/expenses")]
        public IEnumerable<ListExpensesQueryResult> GetExpenses([FromRoute] Guid id)
        {
            return _repository.GetExpenses(id);
        }

        [HttpGet("users/incomes")]
        public IEnumerable<ListIncomeQueryResult> GetIncomes([FromRoute] Guid id)
        {
            return _repository.GetIncomes(id);
        }

        //POST

        [HttpPost("users")]
        public object Post([FromBody] CreateUserCommand command) //Create user command result, não object
        {
            var result = (CreateUserCommandResult)_handler.Handle(command);
            if (_handler.Notifications.Count > 0)
                return BadRequest(_handler.Notifications);
            return result;
        }

        [HttpPost("user/incomes")]
        public object Post([FromBody] AddIncomeSourceCommand command)
        {
            var result = (CreateIncomeCommandResult)_handler.Handle(command);
            if(_handler.Notifications.Count > 0) //Testar if _handler = null
                return BadRequest(_handler.Notifications);
            return result;
        }

        [HttpPost("user/expenses")]
        public object Post([FromBody] AddExpenseCommand command)
        {
            var result = _handler.Handle(command);
            if(_handler.Notifications.Count > 0)
                return BadRequest(_handler.Notifications);
            return result;
        }

        //PUT

        [HttpPut("users/{id:Guid}")]
        public User Post([FromRoute] Guid id, [FromBody] CreateUserCommand command) 
        {
            var name = new Name(command.FirstName, command.LastName);
            var email = new Email(command.Email);
            var user = new User(name, email);
            return user;
        }

        //DELETE

        [HttpDelete("users/{id:Guid}")]
        public object Delete([FromRoute] Guid id)
        {
            return new { message = "Cliente removido com sucesso"};
        }
    }
}
