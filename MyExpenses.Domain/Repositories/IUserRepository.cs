using MyExpenses.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyExpenses.Domain.Repositories
{
    public interface IUserRepository
    {
        bool CheckEmail(string email);
        void Save(User user);
    }
}
