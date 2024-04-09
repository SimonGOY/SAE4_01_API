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
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAE_4._01.Controllers.Tests
{
    [TestClass()]
    public class ConcessionnairesControllerTests
    {
        private ConcessionnairesController controller;
        private BMWDBContext context;
        private IDataRepository<Concessionnaire> dataRepository;
        private Concessionnaire concessionnaire;
        private Mock<IDataRepository<Concessionnaire>> mockRepository;
        private ConcessionnairesController controller_mock;

        [TestInitialize]
        public void InitTest()
        {
            var builder = new DbContextOptionsBuilder<BMWDBContext>().UseNpgsql("Server=51.83.36.122; port=5432; Database=sa11; uid=sa11; password=BMW-S4; SearchPath=bmw;");
            context = new BMWDBContext(builder.Options);
            dataRepository = new ConcessionnaireManager(context);
            controller = new ConcessionnairesController(dataRepository);
            mockRepository = new Mock<IDataRepository<Concessionnaire>>();
            controller_mock = new ConcessionnairesController(mockRepository.Object);

            concessionnaire = new Concessionnaire
            {
                IdConcessionnaire = 666666666,
                NomConcessionnaire = "Vroum",
                EmailConcessionnaire = "vroum.motorad@gmail.com",
                TelephoneConcessionnaire = "0123456789",
                SiteConcessionnaire = "vroum.fr",
                AdresseConcessionnaire = "42 rue des petits rigolos 69420 Montcul"
            };

            
        }

        [TestMethod()]
        public void GetConcessionnairesTest_RecuperationsOK()
        {
            //Arrange
            List<Concessionnaire> lesCons = context.Concessionnaires.ToList();
            // Act
            var res = controller.GetConcessionnaires().Result;
            // Assert
            Assert.IsNotNull(res);
            CollectionAssert.AreEqual(lesCons, res.Value.ToList(), "Les listes de concessionnaire ne sont pas identiques");
        }

        [TestMethod()]
        public void GetConcessionnaireTest_RecuperationOK()
        {
            // Arrange
            Concessionnaire? concessionnaire = context.Concessionnaires.Find(1);
            // Act
            var res = controller.GetConcessionnaire(1).Result;
            // Assert
            Assert.IsNotNull(res.Value);
            Assert.AreEqual(concessionnaire, res.Value, "Le concessionnaire n'est pas la même");
        }

        [TestMethod()]
        public void GetConcessionnaireTest_RecuperationFailed()
        {
            // Arrange
            Concessionnaire? concessionnaire = context.Concessionnaires.Find(1);
            // Act
            var res = controller.GetConcessionnaire(2).Result;
            // Assert
            Assert.IsNotNull(res.Value);
            Assert.AreNotEqual(concessionnaire, res.Value, "Le concessionnaire est le même");
        }

        [TestMethod()]
        public void GetConcessionnaireTest_CollecNExistePas()
        {
            var res = controller.GetConcessionnaire(777777777).Result;
            // Assert
            Assert.IsNull(res.Result, "Le concessionnaire existe");
            Assert.IsNull(res.Value, "Le concessionnaire existe");
        }

        [TestMethod()]
        public void PostPutDeleteTest()
        {
            PostConcessionnaireTest_CreationOK();
            PutConcessionnaireTest_ModificationOK();
            DeleteConcessionnaireTest_SuppressionOK();
        }

        public void PostConcessionnaireTest_CreationOK()
        {
            // Act
            var result = controller.PostConcessionnaire(concessionnaire).Result;
            // Assert
            var conRecup = controller.GetConcessionnaire(concessionnaire.IdConcessionnaire).Result;
            concessionnaire.IdConcessionnaire = conRecup.Value.IdConcessionnaire;
            Assert.AreEqual(concessionnaire, conRecup.Value, "Concessionnaires pas identiques");
        }

        public void PutConcessionnaireTest_ModificationOK()
        {
            // Arrange
            var conIni = controller.GetConcessionnaire(concessionnaire.IdConcessionnaire).Result;
            conIni.Value.EmailConcessionnaire = "crash.motorad@gmail.gov";

            // Act
            var res = controller.PutConcessionnaire(concessionnaire.IdConcessionnaire, conIni.Value).Result;

            // Assert
            var conMaj = controller.GetConcessionnaire(concessionnaire.IdConcessionnaire).Result;
            Assert.IsNotNull(conMaj.Value);
            Assert.AreEqual(conIni.Value, conMaj.Value, "concessionnaire pas identiques");
        }

        public void DeleteConcessionnaireTest_SuppressionOK()
        {
            // Act
            var conSuppr = controller.GetConcessionnaire(concessionnaire.IdConcessionnaire).Result;
            _ = controller.DeleteConcessionnaire(concessionnaire.IdConcessionnaire).Result;

            // Assert
            var res = controller.GetConcessionnaire(concessionnaire.IdConcessionnaire).Result;
            Assert.IsNull(res.Value, "concessionnaire non supprimé");
        }

        // ---------------------------------------- Tests Moq ----------------------------------------

        [TestMethod()]
        public void Moq_GetConcessionnairesTest_RecuperationOK()
        {
            // Arrange
            var concessionnaires = new List<Concessionnaire>
                {
                    concessionnaire
                };
            mockRepository.Setup(x => x.GetAllAsync()).ReturnsAsync(concessionnaires);

            // Act
            var res = controller_mock.GetConcessionnaires().Result;
            // Assert
            Assert.IsNotNull(res);
            Assert.IsNotNull(res.Value);
            Assert.AreEqual(concessionnaires, res.Value as IEnumerable<Concessionnaire>, "La liste n'est pas le même");
        }

        [TestMethod()]
        public void Moq_GetConcessionnaireTest_RecuperationOK()
        {
            // Arrange
            mockRepository.Setup(x => x.GetByIdAsync(1).Result).Returns(concessionnaire);
            // Act
            var res = controller_mock.GetConcessionnaire(1).Result;
            // Assert
            Assert.IsNotNull(res);
            Assert.IsNotNull(res.Value);
            Assert.AreEqual(concessionnaire, res.Value as Concessionnaire, "Le concessionnaire n'est pas le même");
        }

        [TestMethod()]
        public void Moq_GetConcessionnaireTest_RecuperationFailed()
        {
            // Act
            var res = controller_mock.GetConcessionnaire(0).Result;
            // Assert
            Assert.IsInstanceOfType(res.Result, typeof(NotFoundResult));
        }

        [TestMethod()]
        public void Moq_PostConcessionnaireTest()
        {
            // Act
            var actionResult = controller_mock.PostConcessionnaire(concessionnaire).Result;
            // Assert
            Assert.IsInstanceOfType(actionResult, typeof(ActionResult<Concessionnaire>), "Pas un ActionResult<Concessionnaire>");
            Assert.IsInstanceOfType(actionResult.Result, typeof(CreatedAtActionResult), "Pas un CreatedAtActionResult");
            var result = actionResult.Result as CreatedAtActionResult;
            Assert.IsInstanceOfType(result.Value, typeof(Concessionnaire), "Pas une Concessionnaire");
            concessionnaire.IdConcessionnaire = ((Concessionnaire)result.Value).IdConcessionnaire;
            Assert.AreEqual(concessionnaire, (Concessionnaire)result.Value, "Concessionnaire pas identiques");
        }

        [TestMethod]
        public void Moq_DeleteConcessionnaireTest()
        {
            // Arrange
            mockRepository.Setup(x => x.GetByIdAsync(1).Result).Returns(concessionnaire);

            // Act
            var actionResult = controller_mock.DeleteConcessionnaire(1).Result;
            // Assert
            Assert.IsInstanceOfType(actionResult, typeof(NoContentResult), "Pas un NoContentResult"); // Test du type de retour
        }

        [TestMethod]
        public void Moq_PutConcessionnaireTest()
        {
            // Arrange
            mockRepository.Setup(x => x.GetByIdAsync(1).Result).Returns(concessionnaire);
            var init = controller.GetConcessionnaire(1).Result;
            init.Value.EmailConcessionnaire = "crash.motorad@gmail.gov";

            // Act
            var res = controller.PutConcessionnaire(1, init.Value).Result;
            var maj = controller.GetConcessionnaire(1).Result;

            // Assert

            Assert.IsNotNull(maj.Value);
            Assert.AreEqual(init.Value, maj.Value, "Valeurs pas identiques");
        }
    }
}