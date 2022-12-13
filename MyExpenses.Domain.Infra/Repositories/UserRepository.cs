using Dapper;
using MyExpenses.Domain.Entities;
using MyExpenses.Domain.Infra.Contexts;
using MyExpenses.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyExpenses.Domain.Infra.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _context;
        public UserRepository(DataContext context)
        {
            _context = context;
        }
        public bool CheckEmail(string email)
        {
            return _context.Connection.Query<bool>("spCheckEmail", new { Email = email }, commandType: System.Data.CommandType.StoredProcedure).FirstOrDefault();
        }

        public void Save(User user)
        {
            _context.Connection.Execute("spCreateUser", new
            {
                Id = user.Id,
                FirstName = user.Name.FirstName,
                LastName = user.Name.LastName,
                Email = user.Email,
                Password = user.Password,
                Image = user.Image,
                IsPremium = user.IsPremium,
                EntryDate = user.EntryDate
            },  commandType: CommandType.StoredProcedure);
        }
    }
}
