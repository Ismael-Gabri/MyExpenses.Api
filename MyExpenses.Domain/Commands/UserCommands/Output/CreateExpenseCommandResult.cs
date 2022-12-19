using MyExpenses.Domain.Commands.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyExpenses.Domain.Commands.UserCommands.Output
{
    public class CreateExpenseCommandResult : ICommandResult
    {
        public CreateExpenseCommandResult(Guid id, string title, decimal price, bool isSubscription)
        {
            Id = id;
            Title = title;
            Price = price;
            IsSubscription = isSubscription;
        }

        public Guid Id { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
        public bool IsSubscription { get; set; }
    }
}
