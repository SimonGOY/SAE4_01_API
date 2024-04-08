using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SAE_4._01.Controllers;
using SAE_4._01.Models.DataManager;
using SAE_4._01.Models.EntityFramework;
using SAE_4._01.Models.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAE_4._01.Controllers.Tests
{
    [TestClass()]
    public class ParametresControllerTests
    {
        private ParametresController controller;
        private BMWDBContext context;
        private IDataRepository<Parametre> dataRepository;
        private Parametre parametre;
        private String swag;
        private Mock<IDataRepository<Parametre>> mockRepository;
        private ParametresController controller_mock;

        [TestInitialize]
        public void InitTest()
        {
            var builder = new DbContextOptionsBuilder<BMWDBContext>().UseNpgsql("Server=51.83.36.122; port=5432; Database=sa11; uid=sa11; password=BMW-S4; SearchPath=bmw;");
            context = new BMWDBContext(builder.Options);
            dataRepository = new ParametreManager(context);
            controller = new ParametresController(dataRepository);
            mockRepository = new Mock<IDataRepository<Parametre>>();
            controller_mock = new ParametresController(mockRepository.Object);

            parametre = new Parametre
            {
                NomParametre = "parametreTest",
                Description = "My name is Yoshikage Kira. I’m 33 years old.",
            };
        }

        [TestMethod()]
        public void GetParametresTest_RecuperationsOK()
        {
            //Arrange
            List<Parametre> lesPars = context.Parametres.ToList();
            // Act
            var res = controller.GetParametres().Result;
            // Assert
            Assert.IsNotNull(res);
            CollectionAssert.AreEqual(lesPars, res.Value.ToList(), "Les listes de pack ne sont pas identiques");
        }

        [TestMethod()]
        public void GetParametreTest_RecuperationOK()
        {
            // Arrange
            Parametre? par = context.Parametres.Find("montantfraislivraison");
            // Act
            var res = controller.GetParametre("montantfraislivraison").Result;
            // Assert
            Assert.IsNotNull(res.Value);
            Assert.AreEqual(par, res.Value, "Le parametre n'est pas le même");
        }

        [TestMethod()]
        public void GetParametreTest_RecuperationFailed()
        {
            // Arrange
            Parametre? par = context.Parametres.Find("montantfraislivraison");
            // Act
            var res = controller.GetParametre("fraislivraison").Result;
            // Assert
            Assert.IsNotNull(res.Value);
            Assert.AreNotEqual(par, res.Value, "Le parametre est le même");
        }

        [TestMethod()]
        public void GetParametreTest_EquipementNExistePas()
        {
            var res = controller.GetParametre("parametre").Result;
            // Assert
            Assert.IsNull(res.Result, "Le parametre existe");
            Assert.IsNull(res.Value, "Le parametre existe");
        }

        [TestMethod()]
        public void PostPutDelete()
        {
            PostParametreTest_CreationOK();
            PutParametreTest_ModificationOK();
            DeleteParametreTest_SuppressionOK();
        }

        public void PostParametreTest_CreationOK()
        {
            // Act
            var result = controller.PostParametre(parametre).Result;
            // Assert
            var parRecup = controller.GetParametre(parametre.NomParametre).Result;
            parametre.NomParametre = parRecup.Value.NomParametre;
            Assert.AreEqual(parametre, parRecup.Value, "parametre pas identiques");
        }

        public void PutParametreTest_ModificationOK()
        {
            // Arrange
            var parIni = controller.GetParametre(parametre.NomParametre).Result;
            parIni.Value.Description = "non";

            // Act
            var res = controller.PutParametre(parametre.NomParametre, parIni.Value).Result;

            // Assert
            var parMaj = controller.GetParametre(parametre.NomParametre).Result;
            Assert.IsNotNull(parMaj.Value);
            Assert.AreEqual(parIni.Value, parMaj.Value, "parametre pas identiques");
        }

        public void DeleteParametreTest_SuppressionOK()
        {
            // Act
            var parSuppr = controller.GetParametre(parametre.NomParametre).Result;
            _ = controller.DeleteParametre(parametre.NomParametre).Result;

            swag = "lol";

            // Assert
            var res = controller.GetParametre(parametre.NomParametre).Result;
            Assert.IsNull(res.Value, "parametre non supprimé");
        }
    }
}