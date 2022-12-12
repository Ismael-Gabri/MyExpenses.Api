using MyExpenses.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyExpenses.Domain.Tests.Fakes
{
    public class FakeEmailService : IEmailService
    {
        public void Send(string to, string from, string subject, string body)
        {
            
        }
    }
}
