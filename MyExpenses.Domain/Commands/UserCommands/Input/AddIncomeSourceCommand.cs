using MyExpenses.Domain.Commands.UserCommands.Contracts;
using MyExpenses.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyExpenses.Domain.Commands.UserCommands.Input
{
    public class AddIncomeSourceCommand : ICommand
    {
        public Guid User { get; set; }
        public string Title { get; set; }
        public decimal Income { get; set; }
        public IDictionary<string, string> Notifications { get; private set; }

        public bool Validate()
        {
            if (Title == "" || Title == null)
            {
                Notifications.Add("IncomeSource Title", "Title vazio ou nulo");
                return false;
            }
            if (Title.Length > 15)
            {
                Notifications.Add("Expense Title", "Título muito grande");
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
