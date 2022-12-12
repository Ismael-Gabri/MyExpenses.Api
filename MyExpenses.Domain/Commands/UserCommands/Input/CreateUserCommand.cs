using MyExpenses.Domain.Commands.UserCommands.Contracts;
using MyExpenses.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MyExpenses.Domain.Commands.UserCommands.Input
{
    public class CreateUserCommand : ICommand
    {
        public CreateUserCommand() { }
        public CreateUserCommand(string firstName, string lastName, string email)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Notifications = new Dictionary<string, string>();
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public IDictionary<string, string> Notifications { get; set; }

        public bool Valid()
        {
            if (FirstName.Length < 3)
            {
                Notifications.Add("FirstName", "O nome deve conter mais que 3 characteres");
            }
            if (FirstName.Length > 20)
            {
                Notifications.Add("FirstName", "O nome deve conter menos que 20 characteres");
            }
            if (LastName.Length < 3)
            {
                Notifications.Add("LastName", "O sobrenome deve conter mais que 3 characteres");
            }
            if (LastName.Length > 20)
            {
                Notifications.Add("LastName", "O sobrenome deve conter menos que 20 characteres");
            }
            if (FirstName.Any(char.IsDigit))
            {
                Notifications.Add("FirstName", "O nome não deve conter números");
            }
            if (LastName.Any(char.IsDigit))
            {
                Notifications.Add("LastName", "O sobrenome não deve conter números");
            }
            if(!IsValidEmail(Email))
            {
                Notifications.Add("Email", "E-mail inválido");
            }
            if(Notifications.Count > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public static bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            try
            {
                // Normalize the domain
                email = Regex.Replace(email, @"(@)(.+)$", DomainMapper,
                                      RegexOptions.None, TimeSpan.FromMilliseconds(200));

                // Examines the domain part of the email and normalizes it.
                string DomainMapper(Match match)
                {
                    // Use IdnMapping class to convert Unicode domain names.
                    var idn = new IdnMapping();

                    // Pull out and process domain name (throws ArgumentException on invalid)
                    string domainName = idn.GetAscii(match.Groups[2].Value);

                    return match.Groups[1].Value + domainName;
                }
            }
            catch (RegexMatchTimeoutException e)
            {
                return false;
            }
            catch (ArgumentException e)
            {
                return false;
            }

            try
            {
                return Regex.IsMatch(email,
                    @"^[^@\s]+@[^@\s]+\.[^@\s]+$",
                    RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
            }
            catch (RegexMatchTimeoutException)
            {
                return false;
            }
        }
    }
}
