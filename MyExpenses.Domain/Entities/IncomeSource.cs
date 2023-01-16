using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyExpenses.Domain.Entities
{
    public class IncomeSource : Entity
    {
        public IncomeSource(string title, decimal income, string userId)
        {
            Title = title;
            Income = income;
            UserId = userId;
            Notifications = new Dictionary<string, string>();

            if (title == "" || title == null)
                Notifications.Add("IncomeSource Title", "Title vazio ou nulo");

            if (title.Length > 15)
                Notifications.Add("Expense Title", "Título muito grande");
        }

        public string UserId { get; set; }
        public string Title { get; private set; }
        public decimal Income { get; private set; }
        public IDictionary<string, string> Notifications { get; private set; }

        public void EditTitle(string newTitle)
        {
            Title = newTitle;

            if (newTitle == "" || newTitle == null)
                Notifications.Add("IncomeSource Title", "Title vazio ou nulo");

            if (newTitle.Length > 15)
                Notifications.Add("Expense Title", "Título muito grande");
        }
        public void EditIncome(decimal newIncome)
        {
            Income = newIncome;
        }
    }
}
