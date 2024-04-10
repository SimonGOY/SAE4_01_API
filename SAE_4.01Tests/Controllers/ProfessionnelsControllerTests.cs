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
    public class ProfessionnelsControllerTests
    {
        private ProfessionnelsController controller;
        private BMWDBContext context;
        private IDataRepository<Professionnel> dataRepository;
        private Professionnel professionnel;
        private Mock<IDataRepository<Professionnel>> mockRepository;
        private ProfessionnelsController controller_mock;

        [TestInitialize]
        public void InitTest()
        {
            var builder = new DbContextOptionsBuilder<BMWDBContext>().UseNpgsql("Server=51.83.36.122; port=5432; Database=sa11; uid=sa11; password=BMW-S4; SearchPath=bmw;");
            context = new BMWDBContext(builder.Options);
            dataRepository = new ProfessionnelManager(context);
            controller = new ProfessionnelsController(dataRepository);
            mockRepository = new Mock<IDataRepository<Professionnel>>();
            controller_mock = new ProfessionnelsController(mockRepository.Object);

            professionnel = new Professionnel()
            {
                IdPro = 666666666,
                IdClient = 1,
                NomCompagnie = "Pro Inc.",
            };
        }

        [TestMethod()]
        public void GetProfessionnelsTest_RecuperationsOK()
        {
            //Arrange
            List<Professionnel> lesPros = context.Professionnels.ToList();
            // Act
            var res = controller.GetProfessionnels().Result;
            // Assert
            Assert.IsNotNull(res);
            CollectionAssert.AreEqual(lesPros, res.Value.ToList(), "Les listes de professionnel ne sont pas identiques");
        }

        [TestMethod()]
        public void GetProfessionnelTest_RecuperationOK()
        {
            // Arrange
            Professionnel? pro = context.Professionnels.Find(17);
            // Act
            var res = controller.GetProfessionnel(17).Result;
            // Assert
            Assert.IsNotNull(res.Value);
            Assert.AreEqual(pro, res.Value, "Le professionnel n'est pas le même");
        }

        [TestMethod()]
        public void GetProfessionnelTest_RecuperationFailed()
        {
            // Arrange
            Professionnel? pri = context.Professionnels.Find(17);
            // Act
            var res = controller.GetProfessionnel(18).Result;
            // Assert
            Assert.IsNotNull(res.Value);
            Assert.AreNotEqual(pri, res.Value, "Le professionnel est le même");
        }

        [TestMethod()]
        public void GetProfessionnelTest_ProfessionnelNExistePas()
        {
            var res = controller.GetProfessionnel(777777777).Result;
            // Assert
            Assert.IsNull(res.Result, "Le professionnel existe");
            Assert.IsNull(res.Value, "Le professionnel existe");
        }

        [TestMethod()]
        public void PostPutDelete()
        {
            PostProfessionnelTest_CreationOK();
            PutProfessionnelTest_ModificationOK();
            DeleteProfessionnelTest_SuppressionOK();
        }

        public void PostProfessionnelTest_CreationOK()
        {
            // Act
            var result = controller.PostProfessionnel(professionnel).Result;
            // Assert
            var proRecup = controller.GetProfessionnel(professionnel.IdPro).Result;
            professionnel.IdPro = proRecup.Value.IdPro;
            Assert.AreEqual(professionnel, proRecup.Value, "professionnel pas identiques");
        }

        public void PutProfessionnelTest_ModificationOK()
        {
            // Arrange
            var proIni = controller.GetProfessionnel(professionnel.IdPro).Result;
            proIni.Value.NomCompagnie = "non";

            // Act
            var res = controller.PutProfessionnel(professionnel.IdPro, proIni.Value).Result;

            // Assert
            var proMaj = controller.GetProfessionnel(professionnel.IdPro).Result;
            Assert.IsNotNull(proMaj.Value);
            Assert.AreEqual(proIni.Value, proMaj.Value, "professionel pas identiques");
        }

        public void DeleteProfessionnelTest_SuppressionOK()
        {
            // Act
            var proSuppr = controller.GetProfessionnel(professionnel.IdPro).Result;
            _ = controller.DeleteProfessionnel(professionnel.IdPro).Result;

            // Assert
            var res = controller.GetProfessionnel(professionnel.IdPro).Result;
            Assert.IsNull(res.Value, "professionnel non supprimé");
        }

        // ---------------------------------------- Tests Moq ----------------------------------------

        [TestMethod()]
        public void Moq_GetProfessionnelsTest_RecuperationOK()
        {
            // Arrange
            var professionnels = new List<Professionnel>
                {
                    professionnel
                };
            mockRepository.Setup(x => x.GetAllAsync()).ReturnsAsync(professionnels);
            // Act
            var res = controller_mock.GetProfessionnels().Result;
            // Assert
            Assert.IsNotNull(res);
            Assert.IsNotNull(res.Value);
            Assert.AreEqual(professionnels, res.Value as IEnumerable<Professionnel>, "La liste n'est pas le même");
        }

        [TestMethod()]
        public void Moq_GetProfessionnelTest_RecuperationOK()
        {
            // Arrange
            mockRepository.Setup(x => x.GetByIdAsync(1)).ReturnsAsync(professionnel);

            // Act
            var res = controller_mock.GetProfessionnel(1).Result;

            // Assert
            Assert.IsNotNull(res);
            Assert.IsNotNull(res.Value);

            Assert.AreEqual(professionnel, res.Value, "Les objets ne sont pas égaux");
        }


        [TestMethod()]
        public void Moq_GetProfessionnelTest_RecuperationFailed()
        {
            // Act
            var res = controller_mock.GetProfessionnel(0).Result;
            // Assert
            Assert.IsInstanceOfType(res.Result, typeof(NotFoundResult));
        }


        [TestMethod()]
        public void Moq_PostProfessionnelTest()
        {
            // Act
            var actionResult = controller_mock.PostProfessionnel(professionnel).Result;
            // Assert
            Assert.IsInstanceOfType(actionResult, typeof(ActionResult<Professionnel>), "Pas un ActionResult<Professionnel>");
            Assert.IsInstanceOfType(actionResult.Result, typeof(CreatedAtActionResult), "Pas un CreatedAtActionResult");
            var result = actionResult.Result as CreatedAtActionResult;
            Assert.IsInstanceOfType(result.Value, typeof(Professionnel), "Pas une Professionnel");
            professionnel.IdPro = ((Professionnel)result.Value).IdPro;
            Assert.AreEqual(professionnel, (Professionnel)result.Value, "Professionnel pas identiques");
        }

        [TestMethod]
        public void Moq_DeleteProfessionnelTest()
        {
            // Arrange
            mockRepository.Setup(x => x.GetByIdAsync(1).Result).Returns(professionnel);

            // Act
            var actionResult = controller_mock.DeleteProfessionnel(1).Result;
            // Assert
            Assert.IsInstanceOfType(actionResult, typeof(NoContentResult), "Pas un NoContentResult");
        }
    }
}