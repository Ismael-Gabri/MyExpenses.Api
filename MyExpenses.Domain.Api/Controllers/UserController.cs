using Microsoft.AspNetCore.Mvc;
using MyExpenses.Domain.Commands.UserCommands.Input;
using MyExpenses.Domain.Entities;
using MyExpenses.Domain.ValueObjects;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace MyExpenses.Domain.Api.Controllers
{
    [ApiController]
    public class UserController : ControllerBase
    {
        //GET

        [HttpGet("users")]
        public List<User> Get()
        {
            var name = new Name("Ismael", "Castro");
            var email = new Email("ismaelgabri03@hotmail.com");
            var user = new User(name, email);

            var users = new List<User>();
            users.Add(user);

            return users;
        }

        [HttpGet("users/{id:Guid}")]
        public User GetById([FromRoute] Guid id)
        {
            var name = new Name("Ismael", "Castro");
            var email = new Email("ismaelgabri03@hotmail.com");
            var user = new User(name, email);

            return user;
        }

        [HttpGet("users/expenses")]
        public IReadOnlyCollection<Expense> GetExpenses([FromRoute] Guid id)
        {
            var name = new Name("Ismael", "Castro");
            var email = new Email("ismaelgabri03@hotmail.com");
            var user = new User(name, email);

            var expense = new Expense("Luz", 65);
            user.AddExpense(expense);

            return user.Expenses;
        }

        [HttpGet("users/incomes")]
        public IReadOnlyCollection<IncomeSource> GetIncomes([FromRoute] Guid id)
        {
            var name = new Name("Ismael", "Castro");
            var email = new Email("ismaelgabri03@hotmail.com");
            var user = new User(name, email);

            var income = new IncomeSource("Trabalho", 2000);
            user.AddIncomeSource(income);

            return user.IncomeSources;
        }

        //POST

        [HttpPost("users")]
        public User Post([FromBody] CreateUserCommand command) 
        {
            var name = new Name(command.FirstName, command.LastName);
            var email = new Email(command.Email);
            var user = new User(name, email);
            return user;
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
