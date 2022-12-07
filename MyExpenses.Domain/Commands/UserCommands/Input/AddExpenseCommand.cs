using MyExpenses.Domain.Commands.UserCommands.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyExpenses.Domain.Commands.UserCommands.Input
{
    public class AddExpenseCommand : ICommand
    {
        public Guid UserId { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
        public bool IsSubscription { get; set; }

        public bool Validate()
        {
            throw new NotImplementedException();
        }
    }
}
