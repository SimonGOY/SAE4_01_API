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
    public class GammeMotoesControllerTests
    {
        private GammeMotoesController controller;
        private BMWDBContext context;
        private IDataRepository<GammeMoto> dataRepository;
        private GammeMoto gammeMoto;
        private Mock<IDataRepository<GammeMoto>> mockRepository;
        private GammeMotoesController controller_mock;



        [TestInitialize]
        public void InitTest()
        {
            var builder = new DbContextOptionsBuilder<BMWDBContext>().UseNpgsql("Server=51.83.36.122; port=5432; Database=sa11; uid=sa11; password=BMW-S4; SearchPath=bmw;");
            context = new BMWDBContext(builder.Options);
            dataRepository = new GammeMotoManager(context);
            controller = new GammeMotoesController(dataRepository);
            mockRepository = new Mock<IDataRepository<GammeMoto>>();
            controller_mock = new GammeMotoesController(mockRepository.Object);


            gammeMoto = new GammeMoto
            {
                IdGamme = 666666666,
                LibelleGamme = "Tout Terrain"
            };
        }

        [TestMethod()]
        public void GetGammeMotosTest_RecuperationsOK()
        {
            //Arrange
            List<GammeMoto> lesGams = context.GammeMotos.ToList();
            // Act
            var res = controller.GetGammeMotos().Result;
            // Assert
            Assert.IsNotNull(res);
            CollectionAssert.AreEqual(lesGams, res.Value.ToList(), "Les listes de gammes ne sont pas identiques");
        }

        [TestMethod()]
        public void GetGammeMotoTest_RecuperationOK()
        {
            // Arrange
            GammeMoto? gam = context.GammeMotos.Find(1);
            // Act
            var res = controller.GetGammeMoto(1).Result;
            // Assert
            Assert.IsNotNull(res.Value);
            Assert.AreEqual(gam, res.Value, "La gamme n'est pas la même");
        }

        [TestMethod()]
        public void GetGammeMotoTest_RecuperationFailed()
        {
            // Arrange
            GammeMoto? dem = context.GammeMotos.Find(2);
            // Act
            var res = controller.GetGammeMoto(1).Result;
            // Assert
            Assert.IsNotNull(res.Value);
            Assert.AreNotEqual(dem, res.Value, "La gamme est le même");
        }

        [TestMethod()]
        public void GetGammeMotoTest_GammeMotoNExistePas()
        {
            var res = controller.GetGammeMoto(777777777).Result;
            // Assert
            Assert.IsNull(res.Result, "La gamme existe");
            Assert.IsNull(res.Value, "La gamme existe");
        }


        [TestMethod()]
        public void PostDelete()
        {
            PostGammeMotoTest_CreationOK();
            DeleteGammeMotoTest_SuppressionOK();
        }

        public void PostGammeMotoTest_CreationOK()
        {
            // Act
            var result = controller.PostGammeMoto(gammeMoto).Result;
            // Assert
            var gamRecup = controller.GetGammeMoto(gammeMoto.IdGamme).Result;
            gammeMoto.IdGamme = gamRecup.Value.IdGamme;
            Assert.AreEqual(gammeMoto, gamRecup.Value, "Gammes pas identiques");
        }

        public void DeleteGammeMotoTest_SuppressionOK()
        {
            // Act
            var gamSuppr = controller.GetGammeMoto(gammeMoto.IdGamme).Result;
            _ = controller.DeleteGammeMoto(gammeMoto.IdGamme).Result;

            // Assert
            var res = controller.GetGammeMoto(gammeMoto.IdGamme).Result;
            Assert.IsNull(res.Value, "gammes non supprimé");
        }

        // ---------------------------------------- Tests Moq ----------------------------------------

        [TestMethod()]
        public void Moq_GetGammeMotosTest_RecuperationOK()
        {
            // Arrange
            var gammes = new List<GammeMoto>
                {
                    gammeMoto
                };
            mockRepository.Setup(x => x.GetAllAsync()).ReturnsAsync(gammes);
            // Act
            var res = controller_mock.GetGammeMotos().Result;
            // Assert
            Assert.IsNotNull(res);
            Assert.IsNotNull(res.Value);
            Assert.AreEqual(gammes, res.Value as IEnumerable<GammeMoto>, "La liste n'est pas le même");
        }

        [TestMethod()]
        public void Moq_GetEquipementTest_RecuperationOK()
        {
            // Arrange
            mockRepository.Setup(x => x.GetByIdAsync(1).Result).Returns(gammeMoto);
            // Act
            var res = controller_mock.GetGammeMoto(1).Result;
            // Assert
            Assert.IsNotNull(res);
            Assert.IsNotNull(res.Value);
            Assert.AreEqual(gammeMoto, res.Value as GammeMoto, "La gammeMoto n'est pas la même");
        }

        [TestMethod()]
        public void Moq_GetEquipementTest_RecuperationFailed()
        {
            // Act
            var res = controller_mock.GetGammeMoto(0).Result;
            // Assert
            Assert.IsInstanceOfType(res.Result, typeof(NotFoundResult));
        }

        [TestMethod()]
        public void Moq_PostGammeMotoTest()
        {
            // Act
            var actionResult = controller_mock.PostGammeMoto(gammeMoto).Result;
            // Assert
            Assert.IsInstanceOfType(actionResult, typeof(ActionResult<GammeMoto>), "Pas un ActionResult<GammeMoto>");
            Assert.IsInstanceOfType(actionResult.Result, typeof(CreatedAtActionResult), "Pas un CreatedAtActionResult");
            var result = actionResult.Result as CreatedAtActionResult;
            Assert.IsInstanceOfType(result.Value, typeof(GammeMoto), "Pas une GammeMoto");
            gammeMoto.IdGamme = ((GammeMoto)result.Value).IdGamme;
            Assert.AreEqual(gammeMoto, (GammeMoto)result.Value, "GammeMoto pas identiques");
        }

        [TestMethod]
        public void Moq_DeleteGammeMotoTest()
        {
            // Arrange
            mockRepository.Setup(x => x.GetByIdAsync(1).Result).Returns(gammeMoto);

            // Act
            var actionResult = controller_mock.DeleteGammeMoto(1).Result;
            // Assert
            Assert.IsInstanceOfType(actionResult, typeof(NoContentResult), "Pas un NoContentResult"); // Test du type de retour
        }
    }
}