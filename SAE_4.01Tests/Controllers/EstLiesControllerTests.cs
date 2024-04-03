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
    public class EstLiesControllerTests
    {
        private EstLiesController controller;
        private BMWDBContext context;
        private IDataRepository<EstLie> dataRepository;
        private EstLie estLie;

        [TestInitialize]
        public void InitTest()
        {
            var builder = new DbContextOptionsBuilder<BMWDBContext>().UseNpgsql("Server=51.83.36.122; port=5432; Database=sa11; uid=sa11; password=BMW-S4; SearchPath=bmw;");
            context = new BMWDBContext(builder.Options);
            dataRepository = new EstLieManager(context);
            controller = new EstLiesController(dataRepository);

            estLie = new EstLie
            {
                IdEquipement = 2,
                EquIdEquipement = 8,
            };
        }

        [TestMethod()]
        public void GetSontLiesTest_RecuperationsOK()
        {
            //Arrange
            List<EstLie> lesEsts = context.SontLies.ToList();
            // Act
            var res = controller.GetSontLies().Result;
            // Assert
            Assert.IsNotNull(res);
            CollectionAssert.AreEqual(lesEsts, res.Value.ToList(), "Les listes de estlie ne sont pas identiques");
        }

        [TestMethod()]
        public void GetEstLieTest_RecuperationOK()
        {
            // Arrange
            var est = context.SontLies.Find(1, 20);
            // Act
            var res = controller.GetByIds(1, 20).Result;
            // Assert
            Assert.IsNotNull(res.Value);
            Assert.AreEqual(est, res.Value, "Le estLie n'est pas le même");
        }

        [TestMethod()]
        public void GetEstLieTest_RecuperationFailed()
        {
            // Arrange
            var est = controller.GetByIds(1, 20).Result;
            // Act
            var res = controller.GetByIds(5, 19).Result;
            // Assert
            Assert.IsNotNull(res.Value);
            Assert.AreNotEqual(est, res.Value, "Le estLie est le même");
        }

        [TestMethod()]
        public void GetEstLieTest_estInclusNExistePas()
        {
            var res = controller.GetByIds(777777777, 1).Result;
            // Assert
            Assert.IsNull(res.Result, "Le estLie existe");
            Assert.IsNull(res.Value, "Le estLie existe");
        }

        [TestMethod()]
        public void PostDeleteTest()
        {
            PostEstLieTest_CreationOK();
            DeleteEstLieTest_SuppressionOK();
        }

        public void PostEstLieTest_CreationOK()
        {
            // Act
            var result = controller.PostEstLie(estLie).Result;
            // Assert
            var estRecup = controller.GetByIds(estLie.IdEquipement, estLie.EquIdEquipement).Result;
            estLie.IdEquipement = estRecup.Value.IdEquipement;
            estLie.EquIdEquipement = estRecup.Value.EquIdEquipement;
            Assert.AreEqual(estLie, estRecup.Value, "estLie pas identiques");
        }

        public void DeleteEstLieTest_SuppressionOK()
        {
            // Act
            var estSuppr = controller.GetByIds(estLie.IdEquipement, estLie.EquIdEquipement).Result;
            _ = controller.DeleteEstLie(estLie.IdEquipement, estLie.EquIdEquipement).Result;

            // Assert
            var res = controller.GetByIds(estLie.IdEquipement, estLie.EquIdEquipement).Result;
            Assert.IsNull(res.Value, "estLie non supprimé");
        }
    }
}