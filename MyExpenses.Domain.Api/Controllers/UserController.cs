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
            _handler = handler;
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

        [HttpGet("users/{id:Guid}/expenses")]
        public IEnumerable<ListExpensesQueryResult> GetExpenses([FromRoute] Guid id)
        {
            return _repository.GetExpenses(id);
        }

        [HttpGet("users/{id:Guid}/incomes")]
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

        [HttpPost("users/incomes")]
        public object Post([FromBody] AddIncomeSourceCommand command)
        {
            var result = (CreateIncomeCommandResult)_handler.Handle(command);
            if(_handler.Notifications.Count > 0) //Testar if _handler = null
                return BadRequest(_handler.Notifications);
            return result;
        }

        [HttpPost("users/expenses")]
        public object Post([FromBody] AddExpenseCommand command)
        {
            var result = (CreateExpenseCommandResult)_handler.Handle(command);
            if(_handler.Notifications.Count > 0)
                return BadRequest(_handler.Notifications);
            return result;
        }

        //PUT

        [HttpPut("users/income")] //implementar apenas para expenses e incomes
        public IncomeSourceUpdateQueryResult UpdateIncome([FromBody] UpdateIncomeSourceCommand command) 
        {
            return _repository.Update(command);
        }

        //DELETE

        [HttpDelete("users/income/{id:Guid}")]
        public object DeleteIncome([FromRoute] Guid id)
        {
            _repository.DeleteIncome(id);
            return new { message = "Renda removida com sucesso"};
        }

        [HttpDelete("users/expenses/{id:Guid}")]
        public object DeleteExpense([FromRoute] Guid id)
        {
            _repository.DeleteExpense(id);
            return new { message = "Despesa removida com sucesso" };
        }
    }
}
