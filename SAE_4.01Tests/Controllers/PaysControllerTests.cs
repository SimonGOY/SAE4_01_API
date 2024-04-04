using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SAE_4._01.Controllers;
using SAE_4._01.Models.DataManager;
using SAE_4._01.Models.EntityFramework;
using SAE_4._01.Models.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace SAE_4._01.Controllers.Tests
{
    [TestClass()]
    public class PaysControllerTests
    {
        private PaysController controller;
        private BMWDBContext context;
        private IDataRepository<Pays> dataRepository;
        private Pays pays;

        [TestInitialize]
        public void PaysControllerTest()
        {
            var builder = new DbContextOptionsBuilder<BMWDBContext>().UseNpgsql("Server=51.83.36.122; port=5432; Database=sa11; uid=sa11; password=BMW-S4; SearchPath=bmw;");
            context = new BMWDBContext(builder.Options);
            dataRepository = new PaysManager(context);
            controller = new PaysController(dataRepository);

            pays = new Pays() {
                NomPays = "Bombardia",
            };
        }

        /*[TestMethod()]
        public void GetLesPaysTest_RecuperationsOK()
        {
            //Arrange
            List<Pays> lesPays = context.LesPays.ToList();
            // Act
            var res = controller.GetLesPays().Result;
            // Assert
            Assert.IsNotNull(res);
            CollectionAssert.AreEqual(lesPays, res.Value.ToList(), "Les listes de pays ne sont pas identiques");
        }

        [TestMethod()]
        public void GetPaysTest_RecuperationOK()
        {
            // Arrange
            Pays? pay = context.LesPays.Find("France");
            // Act
            var res = controller.GetPays("France").Result;
            // Assert
            Assert.IsNotNull(res.Value);
            Assert.AreEqual(pay, res.Value, "Le pays n'est pas le même");
        }

        [TestMethod()]
        public void GetPaysTest_RecuperationFailed()
        {
            // Arrange
            Pays? par = context.LesPays.Find("Autriche");
            // Act
            var res = controller.GetPays("France").Result;
            // Assert
            Assert.IsNotNull(res.Value);
            Assert.AreNotEqual(par, res.Value, "Le pays est le même");
        }

        [TestMethod()]
        public void GetPaysTest_EquipementNExistePas()
        {
            var res = controller.GetPays("pays").Result;
            // Assert
            Assert.IsNull(res.Result, "Le pays existe");
            Assert.IsNull(res.Value, "Le pays existe");
        }

        [TestMethod()]
        public void PostPaysTest_CreationOK()
        {
            // Act
            var result = controller.PostPays(pays).Result;
            // Assert
            var payRecup = controller.GetPays(pays.NomPays).Result;
            pays.NomPays = payRecup.Value.NomPays;
            Assert.AreEqual(pays, payRecup.Value, "pays pas identiques");
        }

        [TestMethod()]
        public void PutPaysTest_ModificationOK()
        {
            // Arrange
            var payIni = controller.GetPays(pays.NomPays).Result;
            payIni.Value.AdressePays = null;

            // Act
            var res = controller.PutPays(pays.NomPays, payIni.Value).Result;

            // Assert
            var payMaj = controller.GetPays(pays.NomPays).Result;
            Assert.IsNotNull(payMaj.Value);
            Assert.AreEqual(payIni.Value, payMaj.Value, "pays pas identiques");
        }

        [TestMethod()]
        public void DeletePaysTest_SuppressionOK()
        {
            // Act
            var parSuppr = controller.GetPays(pays.NomPays).Result;
            _ = controller.DeletePays(pays.NomPays).Result;

            // Assert
            var res = controller.GetPays(pays.NomPays).Result;
            Assert.IsNull(res.Value, "pays non supprimé");
        }*/
    }
}