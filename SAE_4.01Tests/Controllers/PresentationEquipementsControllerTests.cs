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
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace SAE_4._01.Controllers.Tests
{
    [TestClass()]
    public class PresentationEquipementsControllerTests
    {
        private PresentationEquipementsController controller;
        private BMWDBContext context;
        private IDataRepository<PresentationEquipement> dataRepository;
        private PresentationEquipement presentation;
        private Mock<IDataRepository<PresentationEquipement>> mockRepository;
        private PresentationEquipementsController controller_mock;


        [TestInitialize]
        public void InitTest()
        {
            var builder = new DbContextOptionsBuilder<BMWDBContext>().UseNpgsql("Server=51.83.36.122; port=5432; Database=sa11; uid=sa11; password=BMW-S4; SearchPath=bmw;");
            context = new BMWDBContext(builder.Options);
            dataRepository = new PresentationEquipementManager(context);
            controller = new PresentationEquipementsController(dataRepository);
            mockRepository = new Mock<IDataRepository<PresentationEquipement>>();
            controller_mock = new PresentationEquipementsController(mockRepository.Object);

            presentation = new PresentationEquipement()
            {
                IdPresentation = 666666666,
                IdEquipement = 1,
                IdColoris = 1,
            };
        }

        [TestMethod()]
        public void GetPresentationEquipementsTest_RecuperationsOK()
        {
            //Arrange
            List<PresentationEquipement> lesPres = context.PresentationEquipements.ToList();
            // Act
            var res = controller.GetPresentationEquipements().Result;
            // Assert
            Assert.IsNotNull(res);
            CollectionAssert.AreEqual(lesPres, res.Value.ToList(), "Les listes de presentation ne sont pas identiques");
        }

        [TestMethod()]
        public void GetPresentationEquipementTest_RecuperationOK()
        {
            // Arrange
            PresentationEquipement? pre = context.PresentationEquipements.Find(1);
            // Act
            var res = controller.GetPresentationEquipement(1).Result;
            // Assert
            Assert.IsNotNull(res.Value);
            Assert.AreEqual(pre, res.Value, "La presentation n'est pas le même");
        }

        [TestMethod()]
        public void GetPresentationEquipementTest_RecuperationFailed()
        {
            // Arrange
            PresentationEquipement? par = context.PresentationEquipements.Find(2);
            // Act
            var res = controller.GetPresentationEquipement(1).Result;
            // Assert
            Assert.IsNotNull(res.Value);
            Assert.AreNotEqual(par, res.Value, "La presentation est la même");
        }

        [TestMethod()]
        public void GetPresentationEquipementTest_PresentationEquipementNExistePas()
        {
            var res = controller.GetPresentationEquipement(777777777).Result;
            // Assert
            Assert.IsNull(res.Result, "La presentation existe");
            Assert.IsNull(res.Value, "La presentation existe");
        }

        [TestMethod()]
        public void PostDelete()
        {
            PostPresentationEquipementTest_CreationOK();
            DeletePresentationEquipementTest_SuppressionOK();
        }

        public void PostPresentationEquipementTest_CreationOK()
        {
            // Act
            var result = controller.PostPresentationEquipement(presentation).Result;
            // Assert
            var preRecup = controller.GetPresentationEquipement(presentation.IdPresentation).Result;
            presentation.IdPresentation = preRecup.Value.IdPresentation;
            Assert.AreEqual(presentation, preRecup.Value, "presentation pas identiques");
        }

        public void DeletePresentationEquipementTest_SuppressionOK()
        {
            // Act
            var preSuppr = controller.GetPresentationEquipement(presentation.IdPresentation).Result;
            _ = controller.DeletePresentationEquipement(presentation.IdPresentation).Result;

            // Assert
            var res = controller.GetPresentationEquipement(presentation.IdPresentation).Result;
            Assert.IsNull(res.Value, "presentation non supprimé");
        }

        // ---------------------------------------- Tests Moq ----------------------------------------

        [TestMethod()]
        public void Moq_GetPresentationEquipementsTest_RecuperationOK()
        {
            // Arrange
            var preferes = new List<PresentationEquipement>
                {
                    presentation
                };
            mockRepository.Setup(x => x.GetAllAsync()).ReturnsAsync(preferes);
            // Act
            var res = controller_mock.GetPresentationEquipements().Result;
            // Assert
            Assert.IsNotNull(res);
            Assert.IsNotNull(res.Value);
            Assert.AreEqual(preferes, res.Value as IEnumerable<PresentationEquipement>, "La liste n'est pas le même");
        }

        [TestMethod()]
        public void Moq_GetPresentationEquipementTest_RecuperationOK()
        {
            // Arrange
            mockRepository.Setup(x => x.GetByIdAsync(1)).ReturnsAsync(presentation);

            // Act
            var res = controller_mock.GetPresentationEquipement(1).Result;

            // Assert
            Assert.IsNotNull(res);
            Assert.IsNotNull(res.Value);

            Assert.AreEqual(presentation, res.Value, "Les objets ne sont pas égaux");
        }


        [TestMethod()]
        public void Moq_GetPresentationEquipementTest_RecuperationFailed()
        {
            // Act
            var res = controller_mock.GetPresentationEquipement(0).Result;
            // Assert
            Assert.IsInstanceOfType(res.Result, typeof(NotFoundResult));
        }


        [TestMethod()]
        public void Moq_PostPresentationEquipementTest()
        {
            // Act
            var actionResult = controller_mock.PostPresentationEquipement(presentation).Result;
            // Assert
            Assert.IsInstanceOfType(actionResult, typeof(ActionResult<PresentationEquipement>), "Pas un ActionResult<PresentationEquipement>");
            Assert.IsInstanceOfType(actionResult.Result, typeof(CreatedAtActionResult), "Pas un CreatedAtActionResult");
            var result = actionResult.Result as CreatedAtActionResult;
            Assert.IsInstanceOfType(result.Value, typeof(PresentationEquipement), "Pas une PresentationEquipement");
            presentation.IdPresentation = ((PresentationEquipement)result.Value).IdPresentation;
            Assert.AreEqual(presentation, (PresentationEquipement)result.Value, "PresentationEquipement pas identiques");
        }

        [TestMethod]
        public void Moq_DeletePresentationEquipementTest()
        {
            // Arrange
            mockRepository.Setup(x => x.GetByIdAsync(1).Result).Returns(presentation);

            // Act
            var actionResult = controller_mock.DeletePresentationEquipement(1).Result;
            // Assert
            Assert.IsInstanceOfType(actionResult, typeof(NoContentResult), "Pas un NoContentResult");
        }
    }
}