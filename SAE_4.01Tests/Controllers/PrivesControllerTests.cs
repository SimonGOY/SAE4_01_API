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
        private Mock<IDataRepository<Prive>> mockRepository;
        private PrivesController controller_mock;

        [TestInitialize]
        public void InitTest()
        {
            var builder = new DbContextOptionsBuilder<BMWDBContext>().UseNpgsql("Server=51.83.36.122; port=5432; Database=sa11; uid=sa11; password=BMW-S4; SearchPath=bmw;");
            context = new BMWDBContext(builder.Options);
            dataRepository = new PriveManager(context);
            controller = new PrivesController(dataRepository);
            mockRepository = new Mock<IDataRepository<Prive>>();
            controller_mock = new PrivesController(mockRepository.Object);

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
        public void GetPriveTest_RecuperationFailed()
        {
            // Arrange
            Prive? pri = context.Prives.Find(42);
            // Act
            var res = controller.GetPrive(41).Result;
            // Assert
            Assert.IsNotNull(res.Value);
            Assert.AreNotEqual(pri, res.Value, "La prive est la même");
        }

        [TestMethod()]
        public void GetPriveTest_PriveNExistePas()
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
            Assert.AreEqual(prive, priRecup.Value, "prive pas identiques");
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

        // ---------------------------------------- Tests Moq ----------------------------------------

        [TestMethod()]
        public void Moq_GetPrivesTest_RecuperationOK()
        {
            // Arrange
            var prives = new List<Prive>
                {
                    prive
                };
            mockRepository.Setup(x => x.GetAllAsync()).ReturnsAsync(prives);
            // Act
            var res = controller_mock.GetPrives().Result;
            // Assert
            Assert.IsNotNull(res);
            Assert.IsNotNull(res.Value);
            Assert.AreEqual(prives, res.Value as IEnumerable<Prive>, "La liste n'est pas le même");
        }

        [TestMethod()]
        public void Moq_GetPriveTest_RecuperationOK()
        {
            // Arrange
            mockRepository.Setup(x => x.GetByIdAsync(1)).ReturnsAsync(prive);

            // Act
            var res = controller_mock.GetPrive(1).Result;

            // Assert
            Assert.IsNotNull(res);
            Assert.IsNotNull(res.Value);

            Assert.AreEqual(prive, res.Value, "Les objets ne sont pas égaux");
        }


        [TestMethod()]
        public void Moq_GetPriveTest_RecuperationFailed()
        {
            // Act
            var res = controller_mock.GetPrive(0).Result;
            // Assert
            Assert.IsInstanceOfType(res.Result, typeof(NotFoundResult));
        }


        [TestMethod()]
        public void Moq_PostPriveTest()
        {
            // Act
            var actionResult = controller_mock.PostPrive(prive).Result;
            // Assert
            Assert.IsInstanceOfType(actionResult, typeof(ActionResult<Prive>), "Pas un ActionResult<Prive>");
            Assert.IsInstanceOfType(actionResult.Result, typeof(CreatedAtActionResult), "Pas un CreatedAtActionResult");
            var result = actionResult.Result as CreatedAtActionResult;
            Assert.IsInstanceOfType(result.Value, typeof(Prive), "Pas une Prive");
            prive.IdPrive = ((Prive)result.Value).IdPrive;
            Assert.AreEqual(prive, (Prive)result.Value, "Prive pas identiques");
        }

        [TestMethod]
        public void Moq_DeletePriveTest()
        {
            // Arrange
            mockRepository.Setup(x => x.GetByIdAsync(1).Result).Returns(prive);

            // Act
            var actionResult = controller_mock.DeletePrive(1).Result;
            // Assert
            Assert.IsInstanceOfType(actionResult, typeof(NoContentResult), "Pas un NoContentResult");
        }
    }
}