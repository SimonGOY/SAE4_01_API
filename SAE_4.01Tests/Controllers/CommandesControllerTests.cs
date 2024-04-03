using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SAE_4._01.Controllers;
using SAE_4._01.Models.DataManager;
using SAE_4._01.Models.EntityFramework;
using SAE_4._01.Models.Repository;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAE_4._01.Controllers.Tests
{
    [TestClass()]
    public class CommandesControllerTests
    {
        private CommandesController controller;
        private BMWDBContext context;
        private IDataRepository<Commande> dataRepository;
        private Commande commande;

        [TestInitialize]
        public void InitTest()
        {
            var builder = new DbContextOptionsBuilder<BMWDBContext>().UseNpgsql("Server=51.83.36.122; port=5432; Database=sa11; uid=sa11; password=BMW-S4; SearchPath=bmw;");
            context = new BMWDBContext(builder.Options);
            dataRepository = new CommandeManager(context);
            controller = new CommandesController(dataRepository);

            commande = new Commande()
            {
                IdCommande = 666666666,
                IdClient = 1,
                DateCommande = DateTime.Now,
                Etat = 1
            };
        }

        [TestMethod()]
        public void GetCommandesTest_RécupérationsOK()
        {
            //Arrange
            List<Commande> lesCmd = context.Commandes.ToList();
            // Act
            var res = controller.GetCommandes().Result;
            // Assert
            Assert.IsNotNull(res);
            CollectionAssert.AreEqual(lesCmd, res.Value.ToList(), "Les listes de commandes ne sont pas identiques");
        }

        [TestMethod()]
        public void GetCommandeTest_RecuperationOK()
        {
            // Arrange
            Commande? cmd = context.Commandes.Find(1);
            // Act
            var res = controller.GetCommande(1).Result;
            // Assert
            Assert.IsNotNull(res.Value);
            Assert.AreEqual(cmd, res.Value, "La commande n'est pas la même");
        }

        [TestMethod()]
        public void GetCommandeTest_RecuperationFailed()
        {
            // Arrange
            Commande? cmd = context.Commandes.Find(1);
            // Act
            var res = controller.GetCommande(2).Result;
            // Assert
            Assert.IsNotNull(res.Value);
            Assert.AreNotEqual(cmd, res.Value, "La commande est le même");
        }

        [TestMethod()]
        public void GetCommandeTest_CollecNExistePas()
        {
            var res = controller.GetCommande(777777777).Result;
            // Assert
            Assert.IsNull(res.Result, "La commande existe");
            Assert.IsNull(res.Value, "La commande existe");
        }

        [TestMethod()]
        public void __PostCommandeTest_CreationOK()
        {
            // Act
            var result = controller.PostCommande(commande).Result;
            // Assert
            var cmdRecup = controller.GetCommande(commande.IdCommande).Result;
            commande.IdCommande = cmdRecup.Value.IdCommande;
            Assert.AreEqual(commande, cmdRecup.Value, "Commande pas identiques");
        }

        [TestMethod()]
        public void __PutCommandeTest_ModificationOK()
        {
            // Arrange
            var cmdIni = controller.GetCommande(commande.IdCommande).Result;
            cmdIni.Value.Etat = 2;

            // Act
            var res = controller.PutCommande(commande.IdCommande, cmdIni.Value).Result;

            // Assert
            var cmdMaj = controller.GetCommande(commande.IdCommande).Result;
            Assert.IsNotNull(cmdMaj.Value);
            Assert.AreEqual(cmdIni.Value, cmdMaj.Value, "color pas identiques");
        }

        [TestMethod()]
        public void DeleteCommandeTest_SuppressionOK()
        {
            // Act
            var colSuppr = controller.GetCommande(commande.IdCommande).Result;
            _ = controller.DeleteCommande(commande.IdCommande).Result;

            // Assert
            var res = controller.GetCommande(commande.IdCommande).Result;
            Assert.IsNull(res.Value, "colo non supprimé");
        }

        // ---------------------------------------- Tests Moq ----------------------------------------

        [TestMethod()]
        public void Moq_GetCommandesTest_RecuperationOK()
        {
            // Arrange
            var mockRepository = new Mock<IDataRepository<Commande>>();
            var commandes = new List<Commande>
                {
                    commande
                };
            mockRepository.Setup(x => x.GetAllAsync()).ReturnsAsync(commandes);

            var controller = new CommandesController(mockRepository.Object);

            // Act
            var res = controller.GetCommandes().Result;
            // Assert
            Assert.IsNotNull(res);
            Assert.IsNotNull(res.Value);
            Assert.AreEqual(commandes, res.Value as IEnumerable<Commande>, "La liste n'est pas le même");
        }

        [TestMethod()]
        public void Moq_GetCommandeTest_RecuperationOK()
        {
            // Arrange
            var mockRepository = new Mock<IDataRepository<Commande>>();
            mockRepository.Setup(x => x.GetByIdAsync(1).Result).Returns(commande);

            var controller = new CommandesController(mockRepository.Object);
            // Act
            var res = controller.GetCommande(1).Result;
            // Assert
            Assert.IsNotNull(res);
            Assert.IsNotNull(res.Value);
            Assert.AreEqual(commande, res.Value as Commande, "Le coloris n'est pas le même");
        }
    }
}