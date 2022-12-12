using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyExpenses.Domain.Commands.UserCommands.Contracts
{
    public interface ICommand
    {
        bool Valid();
    }
}
