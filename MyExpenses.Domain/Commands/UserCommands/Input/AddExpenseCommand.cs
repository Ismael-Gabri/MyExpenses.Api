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
        public AddExpenseCommand() { }

        public AddExpenseCommand(Guid userId, string title, decimal price, bool isSubscription)
        {
            UserId = userId;
            Title = title;
            Price = price;
            IsSubscription = isSubscription;
        }

        public Guid UserId { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
        public bool IsSubscription { get; set; }

        public bool Valid()
        {
            throw new NotImplementedException();
        }
    }
}
