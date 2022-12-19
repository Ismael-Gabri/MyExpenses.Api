using MyExpenses.Domain.Commands.UserCommands.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyExpenses.Domain.Commands.UserCommands.Input
{
    public class UpdateIncomeSourceCommand : ICommand
    {
        public string Title { get; set; }
        public string Income { get; set; }

        public bool Valid()
        {
            throw new NotImplementedException();
        }
    }
}
