using HUET_JOUBERT;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace HUET_JOUBERT
{
    [TestClass]
    public class UnitTest2
    {
        [TestMethod]
        public void TestCreationClientAvecSSValide()
        {
            // Arrange
            string ss = "123456789";
            string nom = "John";
            string prenom = "Doe";
            DateTime naissance = new DateTime(1990, 1, 1);
            string adresse = "123 Street";
            string mail = "john@example.com";
            string num = "123";
            int cagnotte = 100;

            // Act
            Client client = new Client(ss, nom, prenom, naissance, adresse, mail, num, cagnotte);

            // Assert
            Assert.IsNotNull(client); // Vérifie si le client est créé
            Assert.AreEqual(ss, client.SS);
        }

        [TestMethod]
        public void TestMiseAJourCagnotteClient()
        {
            // Arrange
            int cagnotteInitiale = 100;
            Client client = new Client("123456789", "John", "Doe", new DateTime(1990, 1, 1), "123 Street", "john@example.com", "123", cagnotteInitiale);
            int montantAjoute = 50;
            int cagnotteAttendue = cagnotteInitiale + montantAjoute;

            // Act
            client.Cagnotte += montantAjoute;

            // Assert
            Assert.AreEqual(cagnotteAttendue, client.Cagnotte);
        }

        [TestMethod]
        public void TestComparaisonClients()
        {
            // Arrange
            Client client1 = new Client("123456789", "John", "Doe", new DateTime(1990, 1, 1), "123 Street", "john@example.com", "123", 100);
            Client client2 = new Client("987654321", "Jane", "Smith", new DateTime(1985, 5, 5), "456 Avenue", "jane@example.com", "456", 200);

            // Act & Assert
            Assert.IsTrue(client1.Cagnotte.CompareTo(client2.Cagnotte) < 0); // Vérifie si client1 est inférieur à client2
        }
    }
}
