using Dapper;
using MyExpenses.Domain.Commands.UserCommands.Input;
using MyExpenses.Domain.Entities;
using MyExpenses.Domain.Infra.Contexts;
using MyExpenses.Domain.Queries;
using MyExpenses.Domain.Repositories;
using MyExpenses.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyExpenses.Domain.Infra.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _context;
        public UserRepository(DataContext context)
        {
            _context = context;
        }
        public bool CheckEmail(string email)
        {
            return _context.Connection.Query<bool>("spCheckEmail", new { Email = email }, commandType: System.Data.CommandType.StoredProcedure).FirstOrDefault();
        }

        public IEnumerable<ListUserQueryResult> Get() //Criar store procedure para melhorar visualmente o código
        {
            return _context.Connection.Query<ListUserQueryResult>("SELECT [Id], CONCAT([FirstName],'', [LastName]) AS [Name], [Email] FROM [User]", new {});
        }

        public GetUserQueryResult Get(Guid id)
        {
            return _context.Connection.Query<GetUserQueryResult>("SELECT [Id], CONCAT([FirstName],'', [LastName]) AS [Name], [Email] FROM [User] WHERE [Id] = @id", new { id = id }).FirstOrDefault();
        }

        public IEnumerable<ListExpensesQueryResult> GetExpenses(Guid userId)
        {
            return _context.Connection.Query<ListExpensesQueryResult>("SELECT [Id], [Title], [Price], [IsSubscription] FROM [Expense] WHERE [UserId] = @userId", new { userId = userId });
        }

        public IEnumerable<ListIncomeQueryResult> GetIncomes(Guid userId) //Criar procedure
        {
            return _context.Connection.Query<ListIncomeQueryResult>("SELECT [Id], [Title], [Income] FROM [Income] WHERE [UserId] = @userId", new { userId = userId });
        }

        public void Save(User user) //Resolvido usando StoreProcedure
        {
            _context.Connection.Execute("spCreateUser", new
            {
                Id = user.Id,
                FirstName = user.Name.FirstName,
                LastName = user.Name.LastName,
                Email = user.Email.Address,
                Password = user.Password,
                Image = user.Image,
                IsPremium = user.IsPremium,
                EntryDate = user.EntryDate
            },  commandType: CommandType.StoredProcedure);
        }

        public void Save(IncomeSource incomeSource)
        {
            _context.Connection.Execute("spCreateIncome", new //Criar essa procedure para salvar a Income no Banco
            {
                Id = incomeSource.Id,
                UserId = incomeSource.UserId,
                Title = incomeSource.Title,
                Income = incomeSource.Income
            },  commandType: CommandType.StoredProcedure);
        }

        public void Save(Expense expense)
        {
            _context.Connection.Execute("spCreateExpense", new
            {
                Id = expense.Id,
                UserId = expense.UserId,
                Title = expense.Title,
                Price = expense.Price,
                IsSubscription = expense.IsSubscription
            },  commandType: CommandType.StoredProcedure);
        }
        public IncomeSourceUpdateQueryResult Update(UpdateIncomeSourceCommand incomeUpdate)
        {
            return _context.Connection.Query<IncomeSourceUpdateQueryResult>("UPDATE [Income] SET [Title] = @title, [Income] = @income WHERE [Id] = @id", new {title = incomeUpdate.Title, income = incomeUpdate.Income ,id = incomeUpdate.Id }).FirstOrDefault();
        }
        public void DeleteIncome(Guid id)
        {
            _context.Connection.Query<DeleteIncomeQueryResult>("DELETE FROM [Income] WHERE [Id] = @id", new { id = id }).FirstOrDefault();
        }
        public void DeleteExpense(Guid id)
        {
            _context.Connection.Query<DeleteExpenseQueryResult>("DELETE FROM [Expense] WHERE [Id] = @id", new { id = id }).FirstOrDefault();
        }

        public ExpenseUpdateQueryResult Update(UpdateExpenseCommand expense)
        {
            return _context.Connection.Query<ExpenseUpdateQueryResult>("UPDATE [Expense] SET [Title] = @title, [Price] = @price WHERE [Id] = @id", new { title = expense.Title, price = expense.Price, id = expense.Id }).FirstOrDefault();
        }

        public GetUserByEmailQueryResult GetByEmail(string email)
        {
            return _context.Connection.Query<GetUserByEmailQueryResult>("SELECT [Id], CONCAT([FirstName],'', [LastName]) AS [Name], [Email], [Password] FROM [User] WHERE [Email] = @email", new { email = email }).FirstOrDefault();
        }
    }
}
