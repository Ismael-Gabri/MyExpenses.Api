using MyExpenses.Domain.Commands.UserCommands.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyExpenses.Domain.Commands.UserCommands.Input
{
    public class RemoveIncomeSourceCommand : ICommand
    {
        public Guid Id { get; set; }
        public Guid IncomeId { get; set; }

        public bool Validate()
        {
            throw new NotImplementedException();
        }
    }
}
