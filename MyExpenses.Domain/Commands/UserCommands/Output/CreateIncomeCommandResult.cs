using MyExpenses.Domain.Commands.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyExpenses.Domain.Commands.UserCommands.Output
{
    public class CreateIncomeCommandResult : ICommandResult
    {
        public CreateIncomeCommandResult(Guid id, string title, decimal income)
        {
            Id = id;
            Title = title;
            Income = income;
        }

        public Guid Id { get; set; }
        public string Title { get; set; }
        public decimal Income { get; set; }
    }
}
