using MyExpenses.Domain.Commands.UserCommands.Input;
using MyExpenses.Domain.Entities;
using MyExpenses.Domain.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyExpenses.Domain.Repositories
{
    public interface IUserRepository
    {
        bool CheckEmail(string email);
        void Save(User user);
        void Save(IncomeSource incomeSource);
        void Save(Expense expense);
        IncomeSourceUpdateQueryResult Update(UpdateIncomeSourceCommand incomeSource);
        ExpenseUpdateQueryResult Update(UpdateExpenseCommand expense);
        void DeleteIncome(Guid id);
        void DeleteExpense(Guid id);
        IEnumerable<ListUserQueryResult> Get();
        GetUserQueryResult Get(Guid id);
        GetUserByEmailQueryResult GetByEmail(string email);
        IEnumerable<ListIncomeQueryResult> GetIncomes(Guid userId);
        IEnumerable<ListExpensesQueryResult> GetExpenses(Guid userId);
    }
}
