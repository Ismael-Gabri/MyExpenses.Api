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
        void Update(Guid id, IncomeSource incomeSource);
        IEnumerable<ListUserQueryResult> Get();
        GetUserQueryResult Get(Guid id);
        IEnumerable<ListIncomeQueryResult> GetIncomes(Guid userId);
        IEnumerable<ListExpensesQueryResult> GetExpenses(Guid userId);
    }
}
