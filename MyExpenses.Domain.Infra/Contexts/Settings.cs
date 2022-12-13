using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyExpenses.Domain.Infra.Contexts
{
    public static class Settings
    {
        public static string ConnectionString { get; set; } = "Server=localhost,1433\\SQLEXPRESS;Database=MyExpenses;User ID=sa;Encrypt=False;Password=1q2w3e4r@#$";
    }
}
