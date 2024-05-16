using HUET_JOUBERT;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest3
    {
        [TestMethod]
        public void TestModificationPosteSalarie()
        {
            // Arrange
            Salarie salarie = new Salarie("987654321", "Jane", "Smith", new DateTime(1985, 5, 5), "456 Avenue", "jane@example.com", "456", new DateTime(2010, 10, 10), "Chauffeur", 2000);
            string nouveauPoste = "Manager";

            // Act
            salarie.Poste = nouveauPoste;

            // Assert
            Assert.AreEqual(nouveauPoste, salarie.Poste);
        }

        [TestMethod]
        public void TestComparaisonSalaries()
        {
            // Arrange
            Salarie salarie1 = new Salarie("987654321", "Jane", "Smith", new DateTime(1985, 5, 5), "456 Avenue", "jane@example.com", "456", new DateTime(2010, 10, 10), "Chauffeur", 2000);
            Salarie salarie2 = new Salarie("123456789", "John", "Doe", new DateTime(1990, 1, 1), "123 Street", "john@example.com", "123", new DateTime(2015, 5, 5), "Manager", 3000);

            // Act & Assert
            Assert.IsTrue(salarie1.Salaire.CompareTo(salarie2.Salaire) < 0); // Vérifie si salarie1 est inférieur à salarie2
        }
    }
}
