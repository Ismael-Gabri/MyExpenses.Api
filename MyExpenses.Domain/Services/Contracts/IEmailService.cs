﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyExpenses.Domain.Services.Contracts
{
    public interface IEmailService
    {
        void Send(string toName, string toEmail, string fromName, string fromEmail);
    }
}
