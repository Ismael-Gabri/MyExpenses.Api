using MyExpenses.Domain.Commands.Contracts;
using MyExpenses.Domain.Commands.UserCommands.Input;
using MyExpenses.Domain.Commands.UserCommands.Output;
using MyExpenses.Domain.Entities;
using MyExpenses.Domain.Handlers.Contracts;
using MyExpenses.Domain.Repositories;
using MyExpenses.Domain.Services.Contracts;
using MyExpenses.Domain.ValueObjects;
using SecureIdentity.Password;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyExpenses.Domain.Handlers
{
    public class UserHandler : IHandler<CreateUserCommand>
    {
        private readonly IUserRepository _repository;

        private readonly IEmailService _emailService;

        public UserHandler(IUserRepository repository, IEmailService emailService)
        {
            Notifications = new Dictionary<string, string>();

            _repository = repository;
            _emailService = emailService;
        }

        public Dictionary<string, string> Notifications { get; set; }
        public ICommandResult Handle(CreateUserCommand command)
        {
            //Verificar se o E-mail já existe na base
            if (_repository.CheckEmail(command.Email))
                Notifications.Add("Email", "Email já registrado no banco");

            //Criar VOs
            var name = new Name(command.FirstName, command.LastName);
            var email = new Email(command.Email);

            //Criar entidade
            var user = new User(name, email);

            if (name.Notifications.Count > 0 && email.Notifications.Count > 0)
                return null;

            //Persistir no banco
            _repository.Save(user);

            //Enviar Email
            _emailService.Send(email.Address, "hello@myexpenses.io", "Bem-vindo", "Seja bem vindo ao My Expenses");

            //Retornar resultado para a tela
            return new CreateUserCommandResult(user.Id, name.FirstName, name.LastName, email.Address);
        }

        public ICommandResult Handle(AddIncomeSourceCommand command)
        {
            var income = new IncomeSource(command.Title, command.Income, command.UserId);

            if(income.Notifications.Count > 0)
            {
                //Retornar income notifications
                return null;
            }

            //Persistir no banco
            _repository.Save(income);

            return new CreateIncomeCommandResult(income.Id, income.Title, income.Income);
        }

        public ICommandResult Handle(AddExpenseCommand command)
        {
            var expense = new Expense(command.Title, command.Price, command.UserId);

            if(expense.Notifications.Count > 0)
            {
                //Retornar Expenses Notifications
                return null;
            }

            //Persistir no banco
            _repository.Save(expense);

            return new CreateExpenseCommandResult(expense.Id, expense.Title, expense.Price, expense.IsSubscription);
        }
    }
}
