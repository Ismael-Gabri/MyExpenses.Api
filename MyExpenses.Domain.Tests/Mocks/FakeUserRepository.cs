using MyExpenses.Domain.Entities;
using MyExpenses.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyExpenses.Domain.Tests.Fakes
{
    public class FakeUserRepository : IUserRepository
    {
        public bool CheckEmail(string email)
        {
            return false;
        }

        public void Save(User user)
        {
            
        }
    }
}
