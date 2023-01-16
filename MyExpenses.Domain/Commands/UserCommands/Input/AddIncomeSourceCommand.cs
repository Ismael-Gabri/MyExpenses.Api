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
        public string Title { get; set; }
        public decimal Income { get; set; }

        public bool Valid()
        {
            Dictionary<string, string> Notifications = new Dictionary<string, string>();

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
