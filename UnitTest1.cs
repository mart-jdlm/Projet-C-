using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace HUET_JOUBERT
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestPrixCalcul()
        {
            // Arrange
            Client client = new Client("123456789", "John", "Doe", new DateTime(1990, 1, 1), "123 Street", "john@example.com", "123", 100);
            Salarie chauffeur = new Salarie("987654321", "Jane", "Smith", new DateTime(1985, 5, 5), "456 Avenue", "jane@example.com", "456", new DateTime(2010, 10, 10), "Chauffeur", 2000);
            DateTime date = DateTime.Now;
            int prixInitial = 100;
            string vehicule = "Voiture";
            // Calcul attendu : prixInitial + 20
            int prixAttendu = prixInitial + 20;

            // Act
            Commande commande = new Commande(client, "Depart", "Arrivee", prixInitial, vehicule, chauffeur, date);

            // Assert
            Assert.AreEqual(prixAttendu, commande.Prix);
        }
        [TestMethod]
        public void TestProprietesCommande()
        {
            // Arrange
            Client client = new Client("123456789", "John", "Doe", new DateTime(1990, 1, 1), "123 Street", "john@example.com", "123", 100);
            Salarie chauffeur = new Salarie("987654321", "Jane", "Smith", new DateTime(1985, 5, 5), "456 Avenue", "jane@example.com", "456", new DateTime(2010, 10, 10), "Chauffeur", 2000);
            DateTime date = DateTime.Now;
            int prixInitial = 100;
            string vehicule = "Voiture";
            string lieuDepartAttendu = "Depart";
            string lieuArriveeAttendu = "Arrivee";

            // Act
            Commande commande = new Commande(client, lieuDepartAttendu, lieuArriveeAttendu, prixInitial, vehicule, chauffeur, date);

            // Assert
            Assert.AreEqual(client, commande.Customer);
            Assert.AreEqual(lieuDepartAttendu, commande.Lieu_depart);
            Assert.AreEqual(lieuArriveeAttendu, commande.Lieu_arrivee);
            Assert.AreEqual(prixInitial+20, commande.Prix);
            Assert.AreEqual(vehicule, commande.Vehicule);
            Assert.AreEqual(chauffeur, commande.Chauffeur);
            Assert.AreEqual(date, commande.Date);
        }

        [TestMethod]
        public void TestCreationCommande()
        {
            // Arrange
            Client client = new Client("123456789", "John", "Doe", new DateTime(1990, 1, 1), "123 Street", "john@example.com", "123", 100);
            Salarie chauffeur = new Salarie("987654321", "Jane", "Smith", new DateTime(1985, 5, 5), "456 Avenue", "jane@example.com", "456", new DateTime(2010, 10, 10), "Chauffeur", 2000);
            DateTime date = DateTime.Now;
            int prixInitial = 100;
            string vehicule = "Voiture";

            // Act
            Commande commande = new Commande(client, "Depart", "Arrivee", prixInitial, vehicule, chauffeur, date);

            // Assert
            Assert.IsNotNull(commande); // Vérifiez si une commande est créée
        }
    }
}
