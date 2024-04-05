using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
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
    public class PrivesControllerTests
    {
        private PrivesController controller;
        private BMWDBContext context;
        private IDataRepository<Prive> dataRepository;
        private Prive prive;

        [TestInitialize]
        public void InitTest()
        {
            var builder = new DbContextOptionsBuilder<BMWDBContext>().UseNpgsql("Server=51.83.36.122; port=5432; Database=sa11; uid=sa11; password=BMW-S4; SearchPath=bmw;");
            context = new BMWDBContext(builder.Options);
            dataRepository = new PriveManager(context);
            controller = new PrivesController(dataRepository);

            prive = new Prive()
            {
                IdPrive = 666666666,
                IdClient = 1,
            };
        }

        [TestMethod()]
        public void GetPrivesTest_RecuperationsOK()
        {
            //Arrange
            List<Prive> lesPris = context.Prives.ToList();
            // Act
            var res = controller.GetPrives().Result;
            // Assert
            Assert.IsNotNull(res);
            CollectionAssert.AreEqual(lesPris, res.Value.ToList(), "Les listes de prive ne sont pas identiques");
        }

        [TestMethod()]
        public void GetPriveTest_RecuperationOK()
        {
            // Arrange
            Prive? pri = context.Prives.Find(41);
            // Act
            var res = controller.GetPrive(41).Result;
            // Assert
            Assert.IsNotNull(res.Value);
            Assert.AreEqual(pri, res.Value, "Le prive n'est pas le même");
        }

        [TestMethod()]
        public void GetParametreTest_RecuperationFailed()
        {
            // Arrange
            Prive? pri = context.Prives.Find(42);
            // Act
            var res = controller.GetPrive(41).Result;
            // Assert
            Assert.IsNotNull(res.Value);
            Assert.AreNotEqual(pri, res.Value, "La presentation est la même");
        }

        [TestMethod()]
        public void GetParametreTest_EquipementNExistePas()
        {
            var res = controller.GetPrive(777777777).Result;
            // Assert
            Assert.IsNull(res.Result, "Le prive existe");
            Assert.IsNull(res.Value, "Le prive existe");
        }

        [TestMethod()]
        public void PostDelete()
        {
            PostPriveTest_CreationOK();
            DeletePriveTest_SuppressionOK();
        }

        public void PostPriveTest_CreationOK()
        {
            // Act
            var result = controller.PostPrive(prive).Result;
            // Assert
            var priRecup = controller.GetPrive(prive.IdPrive).Result;
            prive.IdPrive = priRecup.Value.IdPrive;
            Assert.AreEqual(prive, priRecup.Value, "presentation pas identiques");
        }

        public void DeletePriveTest_SuppressionOK()
        {
            // Act
            var preSuppr = controller.GetPrive(prive.IdPrive).Result;
            _ = controller.DeletePrive(prive.IdPrive).Result;

            // Assert
            var res = controller.GetPrive(prive.IdPrive).Result;
            Assert.IsNull(res.Value, "prive non supprimé");
        }
    }
}