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
    public class PreferesControllerTests
    {
        private PreferesController controller;
        private BMWDBContext context;
        private IDataRepository<Prefere> dataRepository;
        private Prefere prefere;
        private Mock<IDataRepository<Prefere>> mockRepository;
        private PreferesController controller_mock;

        [TestInitialize]
        public void InitTest()
        {
            var builder = new DbContextOptionsBuilder<BMWDBContext>().UseNpgsql("Server=51.83.36.122; port=5432; Database=sa11; uid=sa11; password=BMW-S4; SearchPath=bmw;");
            context = new BMWDBContext(builder.Options);
            dataRepository = new PrefereManager(context);
            controller = new PreferesController(dataRepository);
            mockRepository = new Mock<IDataRepository<Prefere>>();
            controller_mock = new PreferesController(mockRepository.Object);

            prefere = new Prefere()
            {
                IdClient = 75,
                IdConcessionnaire = 2,
            };

        }

        [TestMethod()]
        public void GetPreferesTest_RecuperationsOK()
        {
            //Arrange
            List<Prefere> lesPres = context.Preferes.ToList();
            // Act
            var res = controller.GetPreferes().Result;
            // Assert
            Assert.IsNotNull(res);
            CollectionAssert.AreEqual(lesPres, res.Value.ToList(), "Les listes de prefere ne sont pas identiques");
        }

        [TestMethod()]
        public void GetByIdsTest_RecuperationOK()
        {
            // Arrange
            var pre = context.Preferes.Find(1, 1);
            // Act
            var res = controller.GetByIds(1, 1).Result;
            // Assert
            Assert.IsNotNull(res.Value);
            Assert.AreEqual(pre, res.Value, "Le prefere n'est pas le même");
        }

        [TestMethod()]
        public void GetByIdsTest_RecuperationFailed()
        {
            // Arrange
            var pre = controller.GetByIds(1, 1).Result;
            // Act
            var res = controller.GetByIds(2, 2).Result;
            // Assert
            Assert.IsNotNull(res.Value);
            Assert.AreNotEqual(pre, res.Value, "Le estLie est le même");
        }

        [TestMethod()]
        public void GetByIdsTest_PrefereNExistePas()
        {
            var res = controller.GetByIds(777777777, 1).Result;
            // Assert
            Assert.IsNull(res.Result, "Le estLie existe");
            Assert.IsNull(res.Value, "Le estLie existe");
        }

        [TestMethod()]
        public void PostDelete()
        {
            PostPrefereTest_CreationOK();
            DeletePrefereTest_SuppressionOK();
        }

        
        public void PostPrefereTest_CreationOK()
        {
            // Act
            var result = controller.PostPrefere(prefere).Result;
            // Assert
            var preRecup = controller.GetByIds(prefere.IdClient, prefere.IdConcessionnaire).Result;
            prefere.IdClient = preRecup.Value.IdClient;
            prefere.IdConcessionnaire = preRecup.Value.IdConcessionnaire;
            Assert.AreEqual(prefere, preRecup.Value, "prefere pas identiques");
        }

        public void DeletePrefereTest_SuppressionOK()
        {
            // Act
            var preSuppr = controller.GetByIds(prefere.IdClient, prefere.IdConcessionnaire).Result;
            _ = controller.DeletePrefere(prefere.IdClient, prefere.IdConcessionnaire).Result;

            // Assert
            var res = controller.GetByIds(prefere.IdClient, prefere.IdConcessionnaire).Result;
            Assert.IsNull(res.Value, "prefere non supprimé");
        }

        // ---------------------------------------- Tests Moq ----------------------------------------

        [TestMethod()]
        public void Moq_GetPreferesTest_RecuperationOK()
        {
            // Arrange
            var preferes = new List<Prefere>
                {
                    prefere
                };
            mockRepository.Setup(x => x.GetAllAsync()).ReturnsAsync(preferes);
            // Act
            var res = controller_mock.GetPreferes().Result;
            // Assert
            Assert.IsNotNull(res);
            Assert.IsNotNull(res.Value);
            Assert.AreEqual(preferes, res.Value as IEnumerable<Prefere>, "La liste n'est pas le même");
        }

        [TestMethod()]
        public void Moq_GetByIdsTest_RecuperationOK()
        {
            // Arrange
            mockRepository.Setup(x => x.GetBy2CompositeKeysAsync(1,1)).ReturnsAsync(prefere);

            // Act
            var res = controller_mock.GetByIds(1,1).Result;

            // Assert
            Assert.IsNotNull(res);
            Assert.IsNotNull(res.Value);

            Assert.AreEqual(prefere, res.Value, "Les objets ne sont pas égaux");
        }


        [TestMethod()]
        public void Moq_GetByIdsTest_RecuperationFailed()
        {
            // Act
            var res = controller_mock.GetByIds(0,0).Result;
            // Assert
            Assert.IsInstanceOfType(res.Result, typeof(NotFoundResult));
        }


        [TestMethod()]
        public void Moq_PostPrefereTest()
        {
            // Act
            var actionResult = controller_mock.PostPrefere(prefere).Result;
            // Assert
            Assert.IsInstanceOfType(actionResult, typeof(ActionResult<Prefere>), "Pas un ActionResult<Prefere>");
            Assert.IsInstanceOfType(actionResult.Result, typeof(CreatedAtActionResult), "Pas un CreatedAtActionResult");
            var result = actionResult.Result as CreatedAtActionResult;
            Assert.IsInstanceOfType(result.Value, typeof(Prefere), "Pas une Prefere");
            prefere.IdConcessionnaire = ((Prefere)result.Value).IdConcessionnaire;
            prefere.IdClient = ((Prefere)result.Value).IdClient;
            Assert.AreEqual(prefere, (Prefere)result.Value, "Prefere pas identiques");
        }

        [TestMethod]
        public void Moq_DeletePrefereTest()
        {
            // Arrange
            mockRepository.Setup(x => x.GetBy2CompositeKeysAsync(1,1).Result).Returns(prefere);

            // Act
            var actionResult = controller_mock.DeletePrefere(1,1).Result;
            // Assert
            Assert.IsInstanceOfType(actionResult, typeof(NoContentResult), "Pas un NoContentResult");
        }
    }
}