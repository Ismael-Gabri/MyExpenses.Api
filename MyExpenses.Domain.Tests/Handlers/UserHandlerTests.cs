using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyExpenses.Domain.Commands.UserCommands.Input;
using MyExpenses.Domain.Handlers;
using MyExpenses.Domain.Tests.Fakes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyExpenses.Domain.Tests.Handlers
{
    [TestClass]
    public class UserHandlerTests
    {
        [TestMethod]
        public void Should_Register_Customer_When_Command_Is_Valid()
        {
            var command = new CreateUserCommand("Ismael", "Gabri", "ismaelgabri03@hotmail.com");

            var handler = new UserHandler(new FakeUserRepository(), new FakeEmailService());
            var result = handler.Handle(command);

            Assert.AreNotEqual(null, result);
            Assert.AreEqual(0, handler.Notifications.Count);
        }

        [TestMethod]
        public void Should_NOT_Register_Customer_When_Command_Is_NOT_Valid()
        {
            var command = new CreateUserCommand("I", "G", "ismaelgabri03hotmail.com");

            var handler = new UserHandler(new FakeUserRepository(), new FakeEmailService());
            var result = handler.Handle(command);

            Assert.AreEqual(null, result);
            Assert.AreEqual(2, handler.Notifications.Count);
        }
    }
}
