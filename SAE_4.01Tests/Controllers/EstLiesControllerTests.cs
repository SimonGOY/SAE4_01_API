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
    public class EstLiesControllerTests
    {
        private EstLiesController controller;
        private BMWDBContext context;
        private IDataRepository<EstLie> dataRepository;
        private EstLie estLie;
        private Mock<IDataRepository<EstLie>> mockRepository;
        private EstLiesController controller_mock;


        [TestInitialize]
        public void InitTest()
        {
            var builder = new DbContextOptionsBuilder<BMWDBContext>().UseNpgsql("Server=51.83.36.122; port=5432; Database=sa11; uid=sa11; password=BMW-S4; SearchPath=bmw;");
            context = new BMWDBContext(builder.Options);
            dataRepository = new EstLieManager(context);
            controller = new EstLiesController(dataRepository);
            mockRepository = new Mock<IDataRepository<EstLie>>();
            controller_mock = new EstLiesController(mockRepository.Object);

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

        // ---------------------------------------- Tests Moq ----------------------------------------

        [TestMethod()]
        public void Moq_GetSontLiesTest_RecuperationOK()
        {
            // Arrange
            var sontLies = new List<EstLie>
                {
                    estLie
                };
            mockRepository.Setup(x => x.GetAllAsync()).ReturnsAsync(sontLies);
            // Act
            var res = controller_mock.GetSontLies().Result;
            // Assert
            Assert.IsNotNull(res);
            Assert.IsNotNull(res.Value);
            Assert.AreEqual(sontLies, res.Value as IEnumerable<EstLie>, "La liste n'est pas le même");
        }

        [TestMethod()]
        public void Moq_GetByEquIdEquipementTest_RecuperationOK()
        {
            // Arrange
            var liste = new List<EstLie>
                {
                    estLie
                };
            mockRepository.Setup(x => x.GetByEquIdEquipementAsync(1)).ReturnsAsync(liste);

            // Act
            var res = controller_mock.GetByEquIdEquipement(1).Result;
            var res_cast = ((Microsoft.AspNetCore.Mvc.ActionResult<System.Collections.Generic.IEnumerable<SAE_4._01.Models.EntityFramework.EstLie>>)((Microsoft.AspNetCore.Mvc.ObjectResult)res.Result).Value).Value;
            // Assert
            Assert.IsNotNull(res);
            Assert.IsNotNull(res.Result);
            Assert.AreEqual(liste, res_cast as IEnumerable<EstLie>, "La liste n'est pas le même");
        }

        [TestMethod()]
        public void Moq_GetByEquIdEquipementTest_RecuperationNonOK()
        {
            // Act
            var res = controller_mock.GetByEquIdEquipement(0).Result;
            // Assert
            Assert.IsInstanceOfType(res.Result, typeof(NotFoundResult));
        }

        [TestMethod()]
        public void Moq_GetByIdEquipementTest_RecuperationOK()
        {
            // Arrange
            var liste = new List<EstLie>
                {
                    estLie
                };
            mockRepository.Setup(x => x.GetByIdEquipementAsync(1)).ReturnsAsync(liste);
            // Act
            var res = controller_mock.GetByIdEquipement(1).Result;
            var res_cast = ((Microsoft.AspNetCore.Mvc.ActionResult<System.Collections.Generic.IEnumerable<SAE_4._01.Models.EntityFramework.EstLie>>)((Microsoft.AspNetCore.Mvc.ObjectResult)res.Result).Value).Value;
            // Assert
            Assert.IsNotNull(res);
            Assert.IsNotNull(res.Result);
            Assert.AreEqual(liste, res_cast as IEnumerable<EstLie>, "La liste n'est pas le même");
        }

        [TestMethod()]
        public void Moq_GetByIdEquipementTest_RecuperationNonOK()
        {
            // Act
            var res = controller_mock.GetByIdEquipement(0).Result;
            // Assert
            Assert.IsInstanceOfType(res.Result, typeof(NotFoundResult));
        }

        [TestMethod()]
        public void Moq_PostDemandeEssaiTest()
        {
            // Act
            var actionResult = controller_mock.PostEstLie(estLie).Result;
            // Assert
            Assert.IsInstanceOfType(actionResult, typeof(ActionResult<EstLie>), "Pas un ActionResult<EstLie>");
            Assert.IsInstanceOfType(actionResult.Result, typeof(CreatedAtActionResult), "Pas un CreatedAtActionResult");
            var result = actionResult.Result as CreatedAtActionResult;
            Assert.IsInstanceOfType(result.Value, typeof(EstLie), "Pas une EstLie");
            estLie.EquipementEstLie1 = ((EstLie)result.Value).EquipementEstLie1;
            estLie.EquipementEstLie2 = ((EstLie)result.Value).EquipementEstLie2;
            Assert.AreEqual(estLie, (EstLie)result.Value, "EstLie pas identiques");
        }

        [TestMethod]
        public void Moq_DeleteContenuCommandeTest()
        {
            // Arrange
            mockRepository.Setup(x => x.GetBy2CompositeKeysAsync(1, 1).Result).Returns(estLie);

            // Act
            var actionResult = controller_mock.DeleteEstLie(1, 1).Result;
            // Assert
            Assert.IsInstanceOfType(actionResult, typeof(NoContentResult), "Pas un NoContentResult"); // Test du type de retour
        }
    }
}