using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyExpenses.Domain.Commands.UserCommands.Input;
using MyExpenses.Domain.Commands.UserCommands.Output;
using MyExpenses.Domain.Entities;
using MyExpenses.Domain.Handlers;
using MyExpenses.Domain.Queries;
using MyExpenses.Domain.Repositories;
using MyExpenses.Domain.ValueObjects;
using System.Data;
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
        [Authorize(Roles = "admin")]
        public IEnumerable<ListUserQueryResult> Get()
        {
            return _repository.Get();
        }

        [HttpGet("users/{id:Guid}")]
        [Authorize(Roles = "admin")]
        public GetUserQueryResult GetById([FromRoute] Guid id)
        {
            return _repository.Get(id);
        }

        [HttpGet("v1/users/{id:Guid}/expenses")]
        [Authorize(Roles = "user")]
        public IEnumerable<ListExpensesQueryResult> GetExpenses([FromRoute] Guid id)
        {
            return _repository.GetExpenses(id);
        }

        [HttpGet("users/{id:Guid}/incomes")]
        [Authorize(Roles = "user")]
        public IEnumerable<ListIncomeQueryResult> GetIncomes([FromRoute] string id)
        {
            return _repository.GetIncomes(id);
        }

        [HttpGet("v2/users/incomes")]
        [Authorize(Roles = "user")]
        public IEnumerable<ListIncomeQueryResult> GetIncomesV2()
        {
            var user = User.Claims.FirstOrDefault(x => x.Type == "Id")?.Value;
            var result = _repository.GetIncomes(user);
            return result;
        }

        //POST

        [HttpPost("users")]
        [AllowAnonymous]
        public object Post([FromBody] CreateUserCommand command)
        {
            var result = (CreateUserCommandResult)_handler.Handle(command);
            if (_handler.Notifications.Count > 0)
                return BadRequest(_handler.Notifications);
            return result;
        }

        [HttpPost("users/incomes")]
        [Authorize(Roles = "user")]
        public object Post([FromBody] AddIncomeSourceCommand command)
        {
            var result = (CreateIncomeCommandResult)_handler.Handle(command);
            if(_handler.Notifications.Count > 0)
                return BadRequest(_handler.Notifications);
            return result;
        }

        [HttpPost("users/expenses")]
        [Authorize(Roles = "user")]
        public object Post([FromBody] AddExpenseCommand command)
        {
            var result = (CreateExpenseCommandResult)_handler.Handle(command);
            if(_handler.Notifications.Count > 0)
                return BadRequest(_handler.Notifications);
            return result;
        }

        //PUT

        [HttpPut("users/income")]
        [Authorize(Roles = "user")]
        public IncomeSourceUpdateQueryResult UpdateIncome([FromBody] UpdateIncomeSourceCommand command) 
        {
            return _repository.Update(command);
        }

        [HttpPut("users/expenses")]
        [Authorize(Roles = "user")]
        public ExpenseUpdateQueryResult UpdateExpense([FromBody] UpdateExpenseCommand command)
        {
            return _repository.Update(command);
        }

        //DELETE

        [HttpDelete("users/income/{id:Guid}")]
        [Authorize(Roles = "user")]
        public object DeleteIncome([FromRoute] Guid id)
        {
            _repository.DeleteIncome(id);
            return new { message = "Renda removida com sucesso"};
        }

        [HttpDelete("users/expenses/{id:Guid}")]
        [Authorize(Roles = "user")]
        public object DeleteExpense([FromRoute] Guid id)
        {
            _repository.DeleteExpense(id);
            return new { message = "Despesa removida com sucesso" };
        }

        //Fazer authentication e Authorization para os usuários
        //Criar o Serviço de envio de Email
        //Fazer métodos para calcular o total da expense e income. Usar os Handlers
    }
}
