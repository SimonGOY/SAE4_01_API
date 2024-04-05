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
    public class SeComposeControllerTests
    {
        private SeComposeController controller;
        private BMWDBContext context;
        private IDataRepository<SeCompose> dataRepository;
        private SeCompose seCompose;

        [TestInitialize]
        public void SeComposeControllerTest()
        {
            var builder = new DbContextOptionsBuilder<BMWDBContext>().UseNpgsql("Server=51.83.36.122; port=5432; Database=sa11; uid=sa11; password=BMW-S4; SearchPath=bmw;");
            context = new BMWDBContext(builder.Options);
            dataRepository = new SeComposeManager(context);
            controller = new SeComposeController(dataRepository);

            seCompose = new SeCompose
            {
                IdOption = 1,
                IdPack = 1,
            };
        }

        [TestMethod()]
        public void GetSeComposesTest_RecuperationsOK()
        {
            //Arrange
            List<SeCompose> lesComs = context.SeComposes.ToList();
            // Act
            var res = controller.GetSeComposes().Result;
            // Assert
            Assert.IsNotNull(res);
            CollectionAssert.AreEqual(lesComs, res.Value.ToList(), "Les listes de secompose ne sont pas identiques");
        }

        /*[TestMethod()]
        public void GetByIdPackTest_RecuperationOK()
        {
            // Arrange
            var com = context.Preferes.Find(1, 3);
            // Act
            var res = controller.GetByIds(1, 3).Result;
            // Assert
            Assert.IsNotNull(res.Value);
            Assert.AreEqual(com, res.Value, "Le secompose n'est pas le même");
        }*/

        [TestMethod()]
        public void GetByIdsTest_RecuperationFailed()
        {
            // Arrange
            var com = controller.GetByIds(1, 3).Result;
            // Act
            var res = controller.GetByIds(1, 5).Result;
            // Assert
            Assert.IsNotNull(res.Value);
            Assert.AreNotEqual(com, res.Value, "Le secompose est le même");
        }

        [TestMethod()]
        public void GetByIdsTest_estInclusNExistePas()
        {
            var res = controller.GetByIds(777777777, 1).Result;
            // Assert
            Assert.IsNull(res.Result, "Le secompose existe");
            Assert.IsNull(res.Value, "Le secompose existe");
        }

        [TestMethod()]
        public void PutSeComposeTest()
        {

        }

        [TestMethod()]
        public void PostSeComposeTest()
        {

        }

        [TestMethod()]
        public void DeleteSeComposeTest()
        {

        }
    }
}