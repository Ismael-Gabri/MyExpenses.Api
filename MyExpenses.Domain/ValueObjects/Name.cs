using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyExpenses.Domain.ValueObjects
{
    public class Name
    {
        public Name(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
            Notifications = new Dictionary<string, string>();

            if (firstName.Length < 3)
            {
                Notifications.Add("FirstName", "O nome deve conter mais que 3 characteres");
            }
            if (firstName.Length > 20)
            {
                Notifications.Add("FirstName", "O nome deve conter menos que 20 characteres");
            }
            if (lastName.Length < 3)
            {
                Notifications.Add("LastName", "O sobrenome deve conter mais que 3 characteres");
            }
            if (lastName.Length > 20)
            {
                Notifications.Add("LastName", "O sobrenome deve conter menos que 20 characteres");
            }
            if (firstName.Any(char.IsDigit))
            {
                Notifications.Add("FirstName", "O nome não deve conter números");
            }
            if (lastName.Any(char.IsDigit))
            {
                Notifications.Add("LastName", "O sobrenome não deve conter números");
            }
        }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public IDictionary<string, string> Notifications { get; private set; }
    }
}
