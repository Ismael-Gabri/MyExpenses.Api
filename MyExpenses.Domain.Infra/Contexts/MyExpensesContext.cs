using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using MyExpenses.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyExpenses.Domain.Infra.Contexts
{
    public class DataContext : IDisposable
    {
        public SqlConnection Connection { get; set; }

        public DataContext()
        {
            Connection = new SqlConnection(Settings.ConnectionString);
            Connection.Open();
        }

        public void Dispose()
        {
            if(Connection.State != System.Data.ConnectionState.Closed)
                Connection.Close();
        }
    }
}
