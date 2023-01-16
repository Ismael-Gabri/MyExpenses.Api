using MyExpenses.Domain.Services.Contracts;
using SendGrid.Helpers.Mail;
using SendGrid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace MyExpenses.Domain.Infra.Services
{
    public class EmailService : IEmailService
    {
        private IConfiguration _configuration;

        public EmailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async void Send(string toName, string toEmail, string fromName = "Equipe MyExpenses.API", string fromEmail = "ismaelgabrijob@hotmail.com")
        {
            var apiKey = _configuration["SendGridApiKey"];
            var client = new SendGridClient(apiKey);
            var from = new EmailAddress("ismaelgabri9@gmail.com", fromName);
            var subject = "Sending with SendGrid is Fun";
            var to = new EmailAddress(toEmail);
            var plainTextContent = "and easy to do anywhere, even with C#";
            var htmlContent = "<strong>and easy to do anywhere, even with C#</strong>";
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            var response = await client.SendEmailAsync(msg);
        }
    }
}
