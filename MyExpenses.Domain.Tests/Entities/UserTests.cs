using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyExpenses.Domain.Entities;
using MyExpenses.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyExpenses.Domain.Tests.Entities
{
    [TestClass]
    public class UserTests
    {
        [TestMethod]
        public void Ao_Criar_Usuario_Deve()
        {
            var name = new Name("Ismael", "Castro");
            var email = new Email("ismaelgabri03@hotmail.com");
            var user = new User(name, email);
        }
    }
}
