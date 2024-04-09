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
    public class AdressesControllerTests { 
        private AdressesController controller;
        private BMWDBContext context;
        private IDataRepository<Adresse> dataRepository;
        private AdressePostRequest adressePostRequest;
        private Adresse adresse;
        private Mock<IDataRepository<Adresse>> mockRepository;
        private AdressesController controller_mock;

        [TestInitialize]
        public void InitTest()
        {
            var builder = new DbContextOptionsBuilder<BMWDBContext>().UseNpgsql("Server=51.83.36.122; port=5432; Database=sa11; uid=sa11; password=BMW-S4; SearchPath=bmw;");
            context = new BMWDBContext(builder.Options);
            dataRepository = new AdresseManager(context);
            controller = new AdressesController(dataRepository);
            mockRepository = new Mock<IDataRepository<Adresse>>();
            controller_mock = new AdressesController(mockRepository.Object);

            adressePostRequest = new AdressePostRequest
            {
                NumAdresse = 666666666,
                NomPays = "France",
                AdresseAdresse = "42 rue du Test",
            };

            adresse = new Adresse
            {
                NumAdresse = 666666666,
                NomPays = "France",
                AdresseAdresse = "42 rue du Test"
            };
        }

        [TestMethod()]
        public void GetAdressesTest_RecuperationsOK()
        {
            //Arrange
            List<Adresse> lesAdrs = context.Adresses.ToList();
            // Act
            var res = controller.GetAdresses().Result;
            // Assert
            Assert.IsNotNull(res);
            CollectionAssert.AreEqual(lesAdrs, res.Value.ToList(), "Les listes d'adresses ne sont pas identiques");
        }

        [TestMethod()]
        public void GetAdresseTest_RecuperationOK()
        {
            // Arrange
            Adresse? acc = context.Adresses.Find(1);
            // Act
            var res = controller.GetAdresse(1).Result;
            // Assert
            Assert.IsNotNull(res.Value);
            Assert.AreEqual(acc, res.Value, "L'adresse n'est pas la même");
        }

        [TestMethod()]
        public void GetAdresseTest_RecuperationFailed()
        {
            // Arrange
            Adresse? acc = context.Adresses.Find(1);
            // Act
            var res = controller.GetAdresse(2).Result;
            // Assert
            Assert.IsNotNull(res.Value);
            Assert.AreNotEqual(acc, res.Value, "L'adresse est la même");
        }

        [TestMethod()]
        public void GetAdresseTest_AdresseNExistePas()
        {
            var res = controller.GetAdresse(777777777).Result;
            // Assert
            Assert.IsNull(res.Result, "L'adresse existe");
            Assert.IsNull(res.Value, "L'adresse existe");
        }

        [TestMethod()]
        public void PostPutDeleteTest()
        {
            PostAdresseTest_CreationOK();
            PutAdresseTest_ModificationOK();
            DeleteAdresseTest_SuppressionOK();
        }

        
        public void PostAdresseTest_CreationOK()
        {

            //Act
            var result = controller.PostAdresse(adressePostRequest).Result;
            // Assert
            var adrRecup = controller.GetAdresse((int)adresse.NumAdresse).Result;
            adresse.NumAdresse = adrRecup.Value.NumAdresse;
            var var1 = adresse;
            var var2 = adrRecup.Value;
            Assert.AreEqual(adresse, adrRecup.Value, "Adresses pas identiques");
        }

        public void PutAdresseTest_ModificationOK()
        {
            // Arrange
            var adrIni = controller.GetAdresse((int)adresse.NumAdresse).Result;
            adrIni.Value.AdresseAdresse = "Adresse";

            // Act
            var res = controller.PutAdresse((int)adresse.NumAdresse, adrIni.Value).Result;

            // Assert
            var adrMaj = controller.GetAdresse((int)adresse.NumAdresse).Result;
            Assert.IsNotNull(adrMaj.Value);
            Assert.AreEqual(adrIni.Value, adrMaj.Value, "Adresses pas identiques");
        }

        public void DeleteAdresseTest_SuppressionOK()
        {

            // Act
            var adrSuppr = controller.GetAdresse((int)adresse.NumAdresse).Result;
            _ = controller.DeleteAdresse(adrSuppr.Value.NumAdresse).Result;

            // Assert
            var res = controller.GetAdresse((int)adresse.NumAdresse).Result;
            Assert.IsNull(res.Value, "adresse non supprimé");
        }

        // ---------------------------------------- Tests Moq ----------------------------------------

        [TestMethod()]
        public void Moq_GetAdressesTest_RecuperationOK()
        {
            // Arrange
            var adresses = new List<Adresse>
                {
                    controller.GetAdresse((int)adresse.NumAdresse).Result.Value
                };
            mockRepository.Setup(x => x.GetAllAsync()).ReturnsAsync(adresses);
            // Act
            var res = controller_mock.GetAdresses().Result;
            // Assert
            Assert.IsNotNull(res);
            Assert.IsNotNull(res.Value);
            Assert.AreEqual(adresses, res.Value as IEnumerable<Adresse>, "La liste n'est pas le même");
        }

        [TestMethod()]
        public void Moq_GetAdresseTest_RecuperationOK()
        {
            // Arrange
            mockRepository.Setup(x => x.GetByIdAsync(1).Result).Returns(adresse);
            // Act
            var res = controller_mock.GetAdresse(1).Result;
            // Assert
            Assert.IsNotNull(res);
            Assert.IsNotNull(res.Value);
            Assert.AreEqual(adresse, res.Value as Adresse, "Le concessionnaire n'est pas le même");
        }

        [TestMethod()]
        public void Moq_GetAdresseTest_RecuperationFailed()
        {
            // Act
            var res = controller_mock.GetAdresse(0).Result;
            // Assert
            Assert.IsInstanceOfType(res.Result, typeof(NotFoundResult));
        }

        [TestMethod()]
        public void Moq_PostAdresseTest()
        {
            // Act
            var actionResult = controller_mock.PostAdresse(adressePostRequest).Result;
            // Assert
            Assert.IsInstanceOfType(actionResult, typeof(ActionResult<Adresse>), "Pas un ActionResult<Adresse>");
            Assert.IsInstanceOfType(actionResult.Result, typeof(CreatedAtActionResult), "Pas un CreatedAtActionResult");
            var result = actionResult.Result as CreatedAtActionResult;
            Assert.IsInstanceOfType(result.Value, typeof(Adresse), "Pas une Adresse");
            adresse.NumAdresse = ((Adresse)result.Value).NumAdresse;
            Assert.AreEqual(adresse, (Adresse)result.Value, "Adresse pas identiques");
        }

        [TestMethod]
        public void Moq_DeleteAccessoireTest_RecuperationOK()
        {
            // Arrange
            mockRepository.Setup(x => x.GetByIdAsync(1).Result).Returns(adresse);

            // Act
            var actionResult = controller_mock.DeleteAdresse(1).Result;
            // Assert
            Assert.IsInstanceOfType(actionResult, typeof(NoContentResult), "Pas un NoContentResult"); // Test du type de retour
        }

        [TestMethod]
        public void Moq_PutAdresseTest()
        {
            // Arrange
            mockRepository.Setup(x => x.GetByIdAsync(1).Result).Returns(adresse);
            var init = controller.GetAdresse(1).Result;
            init.Value.AdresseAdresse = "Adresse";

            // Act
            var res = controller.PutAdresse(1, init.Value).Result;
            var maj = controller.GetAdresse(1).Result;

            // Assert

            Assert.IsNotNull(maj.Value);
            Assert.AreEqual(init.Value, maj.Value, "Valeurs pas identiques");
        }
    }
}