using MyExpenses.Domain.Commands.UserCommands.Input;
using MyExpenses.Domain.Entities;
using MyExpenses.Domain.Queries;
using MyExpenses.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyExpenses.Domain.Tests.Fakes
{
    public class FakeUserRepository : IUserRepository
    {
        public bool CheckEmail(string email)
        {
            return false;
        }

        public void DeleteExpense(Guid id)
        {
            throw new NotImplementedException();
        }

        public void DeleteIncome(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ListUserQueryResult> Get()
        {
            throw new NotImplementedException();
        }

        public GetUserQueryResult Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ListExpensesQueryResult> GetExpenses(Guid userId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ListIncomeQueryResult> GetIncomes(Guid userId)
        {
            throw new NotImplementedException();
        }

        public void Save(User user)
        {
            
        }

        public void Save(IncomeSource incomeSource)
        {
            throw new NotImplementedException();
        }

        public void Save(Expense expense)
        {
            throw new NotImplementedException();
        }

        public IncomeSourceUpdateQueryResult Update(UpdateIncomeSourceCommand incomeSource)
        {
            throw new NotImplementedException();
        }

        public ExpenseUpdateQueryResult Update(UpdateExpenseCommand expense)
        {
            throw new NotImplementedException();
        }
    }
}
