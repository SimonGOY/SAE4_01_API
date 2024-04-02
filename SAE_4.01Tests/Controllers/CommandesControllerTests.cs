using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
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
        private Commande com;

        [TestInitialize]
        public void InitTest()
        {
            var builder = new DbContextOptionsBuilder<BMWDBContext>().UseNpgsql("Server=51.83.36.122; port=5432; Database=sa11; uid=sa11; password=BMW-S4; SearchPath=bmw;");
            context = new BMWDBContext(builder.Options);
            dataRepository = new CommandeManager(context);
            controller = new CommandesController(dataRepository);

            com = new Commande()
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
            Assert.IsNotNull(res);
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
            Assert.IsNotNull(res);
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
        public void PostCommandeTest_CreationOK()
        {
            // Act
            var result = controller.PostCommande(com).Result;
            // Assert
            var cmdRecup = controller.GetCommande(com.IdCommande).Result;
            com.IdCommande = cmdRecup.Value.IdCommande;
            Assert.AreEqual(com, cmdRecup.Value, "Coloris pas identiques");
        }

        /*[TestMethod()]
        public void PutCommandeTest_ModificationOK()
        {
            // Arrange
            var cmdIni = controller.GetCommande(com.IdCommande).Result;
            cmdIni.Value.Etat = 2;

            // Act
            var res = controller.PutCommande(com.IdCommande, cmdIni.Value).Result;

            // Assert
            var cmdMaj = controller.GetCommande(com.IdCommande).Result;
            Assert.IsNotNull(cmdMaj.Value);
            Assert.AreEqual(cmdIni.Value, cmdMaj.Value, "color pas identiques");
        }*/

        [TestMethod()]
        public void ZDeleteCommandeTest()
        {
            // Act
            var colSuppr = controller.GetCommande(com.IdCommande).Result;
            _ = controller.DeleteCommande(com.IdCommande).Result;

            // Assert
            var res = controller.GetCommande(com.IdCommande).Result;
            Assert.IsNull(res.Value, "colo non supprimé");
        }
    }
}