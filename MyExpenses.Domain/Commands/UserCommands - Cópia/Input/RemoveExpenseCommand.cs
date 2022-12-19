using MyExpenses.Domain.Commands.UserCommands.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyExpenses.Domain.Commands.UserCommands.Input
{
    public class RemoveExpenseCommand : ICommand
    {
        public Guid User { get; set; }
        public Guid ExpenseId { get; set; }

        public bool Valid()
        {
            throw new NotImplementedException();
        }
    }
}
