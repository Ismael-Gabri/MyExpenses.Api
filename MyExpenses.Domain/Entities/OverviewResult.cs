using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyExpenses.Domain.Entities
{
    public class Overview : Entity
    {
        public Overview(User user, List<Expense> expensesList, List<IncomeSource> incomesList)
        {
            User = user;
            ExpensesList = expensesList;
            IncomesList = incomesList;
        }

        public User User { get; private set; }
        public string Title { get; private set; }
        public List<Expense> ExpensesList { get; private set; }
        public List<IncomeSource> IncomesList { get; private set; }
        public decimal TotalExpended { get; private set; }
        public decimal Savings { get; private set; }
        public int SimulationMonths { get; private set; }
        public decimal SimulationMonthsResult { get; private set; }
        public IDictionary<string, string> Notifications { get; private set; }

        public void EditTile(string newTitle) { }
        public void CalculateSavings(List<Expense> exepensesList, List<IncomeSource> incomeList) { }
        public void CalculateTotalExpended(List<Expense> exepensesList, List<IncomeSource> incomeList) { }
        public void ExecuteSimulationMonths(int simulationMonths) { }
        public void EstimateSavingsTime(decimal savings, decimal objective) { }
        public void ListSubscriptions() { }
        public void CalculateSubscriptionsPrice() { }


        //Edit title, Calculate the savings, calculate the total expended, execute an simulation, Gerar PDF
    }
}
