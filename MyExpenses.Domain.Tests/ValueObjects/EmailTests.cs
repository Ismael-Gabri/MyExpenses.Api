using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyExpenses.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyExpenses.Domain.Tests.VOs
{
    [TestClass]
    public class EmailTests
    {
        [TestMethod]
        public void Deve_Retornar_1_Quando_Email_Não_Contem_Arroba()
        {
            var email = new Email("ismaelgabri03hotmail.com");
            Assert.AreEqual(email.Notifications.Count(), 1);
        }

        [TestMethod]
        public void Deve_Retornar_0_Quando_Email_Contem_Arroba()
        {
            var email = new Email("ismaelgabri03@hotmail.com");
            Assert.AreEqual(email.Notifications.Count(), 0);
        }
    }
}
