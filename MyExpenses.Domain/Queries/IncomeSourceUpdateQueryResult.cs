using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyExpenses.Domain.Queries
{
    public class IncomeSourceUpdateQueryResult
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public decimal Income { get; set; }
    }
}
