﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyExpenses.Domain.Services
{
    public interface IEmailService
    {
        void Send(string to, string from, string subject, string body);
    }
}
