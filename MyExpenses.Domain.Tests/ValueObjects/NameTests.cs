using MyExpenses.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyExpenses.Domain.Tests.VOs
{
    [TestClass]
    public class NameTests
    {
        [TestMethod]
        public void Deve_Retornar_2_Notificacoes_Quando_Nome_E_Sobrenome_Sao_Menores_Que_3_Characteres()
        {
            var name = new Name("bo", "bo");
            Assert.AreEqual(name.Notifications.Count, 2);
        }

        [TestMethod]
        public void Deve_Retornar_2_Notificacoes_Quando_Nome_e_Sobrenome_Contem_Digitos()
        {
            var name = new Name("Ismael23", "Castro4");
            Assert.AreEqual(name.Notifications.Count, 2);
        }

        [TestMethod]
        public void Deve_Retornar_0_Quando_Nome_E_Sobrenome_Contem_Mais_Que_3_Characteres_E_Nao_Contem_Digitos()
        {
            var name = new Name("Ismael", "Castro");
            Assert.AreEqual(name.Notifications.Count, 0);
        }

        [TestMethod]
        public void Deve_Retornar_2_Quando_Nome_e_Sobrenome_Contem_Mais_Que_20_digitos()
        {
            var name = new Name("iiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiii", "iiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiii");
            Assert.AreEqual(name.Notifications.Count, 2);
        }
    }
}
