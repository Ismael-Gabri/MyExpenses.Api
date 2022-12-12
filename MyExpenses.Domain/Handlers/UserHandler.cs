using MyExpenses.Domain.Commands.Contracts;
using MyExpenses.Domain.Commands.UserCommands.Input;
using MyExpenses.Domain.Commands.UserCommands.Output;
using MyExpenses.Domain.Entities;
using MyExpenses.Domain.Handlers.Contracts;
using MyExpenses.Domain.Repositories;
using MyExpenses.Domain.Services;
using MyExpenses.Domain.ValueObjects;
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
            Notifications = new List<IDictionary<string, string>>();

            _repository = repository;
            _emailService = emailService;
        }

        public List<IDictionary<string, string>> Notifications { get; set; }
        public ICommandResult Handle(CreateUserCommand command)
        {
            //Verificar se o E-mail já existe na base
            if (_repository.CheckEmail(command.Email))
                command.Notifications.Add("Email", "Email já registrado no banco");

            //Criar VOs
            var name = new Name(command.FirstName, command.LastName);
            var email = new Email(command.Email);

            //Criar entidade
            var user = new User(name, email);

            //Validar entidades e VOs
            if(name.Notifications.Count > 0)
            {
                Notifications.Add(name.Notifications);
            }
            if(email.Notifications.Count > 0)
            {
                Notifications.Add(email.Notifications);
            }

            if (Notifications.Count > 0)
                return null;

            //Persistir no banco
            _repository.Save(user);

            //Enviar Email
            _emailService.Send(email.Address, "hello@myexpenses.io", "Bem-vindo", "Seja bem vindo ao My Expenses");

            //Retornar resultado para a tela
            return new CreateUserCommandResult(user.Id, name.FirstName, name.LastName, email.Address);
        }
    }
}
