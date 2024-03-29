﻿using MyExpenses.Domain.Commands.Contracts;
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

            //Gerar e Codificar senha 32 characteres
            var password = PasswordGenerator.Generate(25);
            var passwordHash = PasswordHasher.Hash(password);

            //Criar entidade
            var user = new User(name, email, passwordHash);

            if (name.Notifications.Count > 0 && email.Notifications.Count > 0)
                return null;

            //Persistir no banco
            _repository.Save(user);

            //Enviar Email
            _emailService.Send(user.Name.FirstName, email.Address, "Time MyExpenses","hello@myexpenses.io");

            //Retornar resultado para a tela
            return new CreateUserCommandResult(user.Id, name.FirstName, name.LastName, email.Address, password);
        }

        public ICommandResult Handle(AddIncomeSourceCommand command, string userId)
        {
            var income = new IncomeSource(command.Title, command.Income, userId);

            if(income.Notifications.Count > 0)
            {
                //Retornar income notifications
                return null;
            }

            //Persistir no banco
            _repository.Save(income);

            return new CreateIncomeCommandResult(income.Id, income.Title, income.Income);
        }

        public ICommandResult Handle(AddExpenseCommand command, string userId)
        {
            var expense = new Expense(command.Title, command.Price, userId);

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
