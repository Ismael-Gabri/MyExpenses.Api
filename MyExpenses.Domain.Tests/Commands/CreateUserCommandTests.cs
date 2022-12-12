using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyExpenses.Domain.Commands.UserCommands.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyExpenses.Domain.Tests.Commands
{
    [TestClass]
    public class CreateUserCommandTests
    {
        [TestMethod]
        public void Se_Passado_Um_Command_Valido_Deve_Retornar_True()
        {
            var command = new CreateUserCommand("Ismael", "Gabri", "ismaelgabri03@hotmail.com");
            Assert.AreEqual(command.Valid(), true);
        }

        [TestMethod]
        public void Se_Passado_Um_Command_Vazio_Deve_Retornar_False()
        {
            var command = new CreateUserCommand();
            Assert.AreEqual(command.Valid(), false);
        }
    }
}
