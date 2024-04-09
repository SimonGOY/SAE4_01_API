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
    public class SpecifiesControllerTests
    {
        private SpecifiesController controller;
        private BMWDBContext context;
        private IDataRepository<Specifie> dataRepository;
        private Specifie specifie;
        private Mock<IDataRepository<Specifie>> mockRepository;
        private SpecifiesController controller_mock;

        [TestInitialize]
        public void InitTest()
        {
            var builder = new DbContextOptionsBuilder<BMWDBContext>().UseNpgsql("Server=51.83.36.122; port=5432; Database=sa11; uid=sa11; password=BMW-S4; SearchPath=bmw;");
            context = new BMWDBContext(builder.Options);
            dataRepository = new SpecifieManager(context);
            controller = new SpecifiesController(dataRepository);
            mockRepository = new Mock<IDataRepository<Specifie>>();
            controller_mock = new SpecifiesController(mockRepository.Object);

            specifie = new Specifie
            {
                IdOption = 1,
                IdMoto = 2,
            };
        }

        [TestMethod()]
        public void GetSpecifiesTest_RecuperationsOK()
        {
            //Arrange
            List<Specifie> lesSpes = context.Specifies.ToList();
            // Act
            var res = controller.GetSpecifies().Result;
            // Assert
            Assert.IsNotNull(res);
            CollectionAssert.AreEqual(lesSpes, res.Value.ToList(), "Les listes de SPECIFIE ne sont pas identiques");
        }

        [TestMethod()]
        public void GetByIdsTest_RecuperationOK()
        {
            // Arrange
            var spe = context.Specifies.Find(2, 3);
            // Act
            var res = controller.GetByIds(3, 2).Result;
            // Assert
            Assert.IsNotNull(res.Value);
            Assert.AreEqual(spe, res.Value, "Le specifie n'est pas le même");
        }

        [TestMethod()]
        public void GetByIdsTest_RecuperationFailed()
        {
            // Arrange
            var spe = controller.GetByIds(3, 2).Result;
            // Act
            var res = controller.GetByIds(5, 4).Result;
            // Assert
            Assert.IsNotNull(res.Value);
            Assert.AreNotEqual(spe, res.Value, "Le specifie est le même");
        }

        [TestMethod()]
        public void GetByIdsTest_estInclusNExistePas()
        {
            var res = controller.GetByIds(777777777, 1).Result;
            // Assert
            Assert.IsNull(res.Result, "Le specifie existe");
            Assert.IsNull(res.Value, "Le specifie existe");
        }

        [TestMethod()]
        public void PostDelete()
        {
            PostSpecifieTest_CreationOK();
            DeleteSpecifieTest_SuppressionOK();
        }

        public void PostSpecifieTest_CreationOK()
        {
            // Act
            var result = controller.PostSpecifie(specifie).Result;
            // Assert
            var speRecup = controller.GetByIds(specifie.IdOption, specifie.IdMoto).Result;
            specifie.IdOption = speRecup.Value.IdOption;
            specifie.IdMoto = speRecup.Value.IdMoto;
            Assert.AreEqual(specifie, speRecup.Value, "specifie pas identiques");
        }

        
        public void DeleteSpecifieTest_SuppressionOK()
        {
            // Act
            var speSuppr = controller.GetByIds(specifie.IdOption, specifie.IdMoto).Result;
            _ = controller.DeleteSpecifie(specifie.IdOption, specifie.IdMoto).Result;

            // Assert
            var res = controller.GetByIds(specifie.IdOption, specifie.IdMoto).Result;
            Assert.IsNull(res.Value, "specifie non supprimé");
        }

        // ---------------------------------------- Tests Moq ----------------------------------------

        [TestMethod()]
        public void Moq_GetSpecifiesTest_RecuperationOK()
        {
            // Arrange
            var specifient = new List<Specifie>
                {
                    specifie
                };
            mockRepository.Setup(x => x.GetAllAsync()).ReturnsAsync(specifient);
            // Act
            var res = controller_mock.GetSpecifies().Result;
            // Assert
            Assert.IsNotNull(res);
            Assert.IsNotNull(res.Value);
            Assert.AreEqual(specifient, res.Value as IEnumerable<Specifie>, "La liste n'est pas le même");
        }

        [TestMethod()]
        public void Moq_GetProfessionnelTest_RecuperationOK()
        {
            // Arrange
            mockRepository.Setup(x => x.GetBy2CompositeKeysAsync(1, 1)).ReturnsAsync(specifie);

            // Act
            var res = controller_mock.GetByIds(1, 1).Result;

            // Assert
            Assert.IsNotNull(res);
            Assert.IsNotNull(res.Value);

            Assert.AreEqual(specifie, res.Value, "Les objets ne sont pas égaux");
        }


        [TestMethod()]
        public void Moq_GetProfessionnelTest_RecuperationFailed()
        {
            // Act
            var res = controller_mock.GetByIds(0, 0).Result;
            // Assert
            Assert.IsInstanceOfType(res.Result, typeof(NotFoundResult));
        }


        [TestMethod()]
        public void Moq_PostSpecifieTest()
        {
            // Act
            var actionResult = controller_mock.PostSpecifie(specifie).Result;
            // Assert
            Assert.IsInstanceOfType(actionResult, typeof(ActionResult<Specifie>), "Pas un ActionResult<Specifie>");
            Assert.IsInstanceOfType(actionResult.Result, typeof(CreatedAtActionResult), "Pas un CreatedAtActionResult");
            var result = actionResult.Result as CreatedAtActionResult;
            Assert.IsInstanceOfType(result.Value, typeof(Specifie), "Pas une Specifie");
            specifie.IdMoto = ((Specifie)result.Value).IdMoto;
            Assert.AreEqual(specifie, (Specifie)result.Value, "Specifie pas identiques");
        }

        [TestMethod]
        public void Moq_DeleteSpecifieTest()
        {
            // Arrange
            mockRepository.Setup(x => x.GetBy2CompositeKeysAsync(1, 1).Result).Returns(specifie);

            // Act
            var actionResult = controller_mock.DeleteSpecifie(1, 1).Result;
            // Assert
            Assert.IsInstanceOfType(actionResult, typeof(NoContentResult), "Pas un NoContentResult");
        }
    }
}