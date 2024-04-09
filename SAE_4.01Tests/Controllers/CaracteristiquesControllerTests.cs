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
    public class CaracteristiquesControllerTests
    {
        private CaracteristiquesController controller;
        private BMWDBContext context;
        private IDataRepository<Caracteristique> dataRepository;
        private Caracteristique caracteristique;
        private Mock<IDataRepository<Caracteristique>> mockRepository;
        private CaracteristiquesController controller_mock;


        [TestInitialize]
        public void InitTest()
        {
            var builder = new DbContextOptionsBuilder<BMWDBContext>().UseNpgsql("Server=51.83.36.122; port=5432; Database=sa11; uid=sa11; password=BMW-S4; SearchPath=bmw;");
            context = new BMWDBContext(builder.Options);
            dataRepository = new CaracteristiqueManager(context);
            controller = new CaracteristiquesController(dataRepository);
            mockRepository = new Mock<IDataRepository<Caracteristique>>();
            controller_mock = new CaracteristiquesController(mockRepository.Object);

            caracteristique = new Caracteristique
            {
                IdCaracteristique = 666666666,
                IdMoto = 1,
                IdCatCaracteristique = 1,
                NomCaracteristique = "Pare-Choc",
                ValeurCaracteristique = "Pare-choc rembouré en plumes, coton et botox"
            };
        }

        [TestMethod()]
        public void GetCaracteristiquesTest_RecuperationsOK()
        {
            //Arrange
            List<Caracteristique> lesCars = context.Caracteristiques.ToList();
            // Act
            var res = controller.GetCaracteristiques().Result;
            // Assert
            Assert.IsNotNull(res);
            CollectionAssert.AreEqual(lesCars, res.Value.ToList(), "Les listes de caracteristiques ne sont pas identiques");
        }

        [TestMethod()]
        public void GetCaracteristiqueTest_RecuperationOK()
        {
            // Arrange
            Caracteristique? car = context.Caracteristiques.Find(1);
            // Act
            var res = controller.GetCaracteristique(1).Result;
            // Assert
            Assert.IsNotNull(res.Value);
            Assert.AreEqual(car, res.Value, "La caractéristique n'est pas le même");
        }


        [TestMethod()]
        public void GetCracteristiqueTest_RecuperationFailed()
        {
            // Arrange
            Caracteristique? car = context.Caracteristiques.Find(1);
            // Act
            var res = controller.GetCaracteristique(2).Result;
            // Assert
            Assert.IsNotNull(res.Value);
            Assert.AreNotEqual(car, res.Value, "L'caracteristique est la même");
        }

        [TestMethod()]
        public void GetAdresseTest_CaracteristiqueNExistePas()
        {
            var res = controller.GetCaracteristique(777777777).Result;
            // Assert
            Assert.IsNull(res.Result, "L'caracteristique existe");
            Assert.IsNull(res.Value, "L'caracteristique existe");
        }

        [TestMethod()]
        public void PostPutDeleteTest()
        {
            PostCaracteristiqueTest_CreationOK();
            PutCaracteristiqueTest_ModificationOK();
            DeleteCaracteristiqueTest_SuppressionOK();
        }

        public void PostCaracteristiqueTest_CreationOK()
        {
            // Act
            var result = controller.PostCaracteristique(caracteristique).Result;
            // Assert
            var carRecup = controller.GetCaracteristique(caracteristique.IdCaracteristique).Result;
            caracteristique.IdCaracteristique = carRecup.Value.IdCaracteristique;
            Assert.AreEqual(caracteristique, carRecup.Value, "Caractéristiques pas identiques"); ;
        }

        public void PutCaracteristiqueTest_ModificationOK()
        {
            // Arrange
            var carIni = controller.GetCaracteristique(caracteristique.IdCaracteristique).Result;
            carIni.Value.NomCaracteristique = "CAR CLONE N°" + 2;

            // Act
            var res = controller.PutCaracteristique(caracteristique.IdCaracteristique, carIni.Value).Result;

            // Assert
            var carMaj = controller.GetCaracteristique(caracteristique.IdCaracteristique).Result;
            Assert.IsNotNull(carMaj.Value);
            Assert.AreEqual(carIni.Value, carMaj.Value, "Caractéristiques pas identiques");
        }

        public void DeleteCaracteristiqueTest_SuppressionOK()
        {
            // Act
            var carSuppr = controller.GetCaracteristique(caracteristique.IdCaracteristique).Result;
            _ = controller.DeleteCaracteristique(carSuppr.Value.IdCaracteristique).Result;

            // Assert
            var res = controller.GetCaracteristique (caracteristique.IdCaracteristique).Result;
            Assert.IsNull(res.Value, "caracteristique non supprimé");
        }

        // ---------------------------------------- Tests Moq ----------------------------------------

        [TestMethod()]
        public void Moq_GetCaracteristiquesTest_RecuperationOK()
        {
            // Arrange
            var caracteristiques = new List<Caracteristique>
                {
                    caracteristique
                };
            mockRepository.Setup(x => x.GetAllAsync()).ReturnsAsync(caracteristiques);
            // Act
            var res = controller_mock.GetCaracteristiques().Result;
            // Assert
            Assert.IsNotNull(res);
            Assert.IsNotNull(res.Value);
            Assert.AreEqual(caracteristiques, res.Value as IEnumerable<Caracteristique>, "La liste n'est pas le même");
        }

        [TestMethod()]
        public void Moq_GetCaracteristiqueTest_RecuperationOK()
        {
            // Arrange
            mockRepository.Setup(x => x.GetByIdAsync(1).Result).Returns(caracteristique);
            // Act
            var res = controller_mock.GetCaracteristique(1).Result;
            // Assert
            Assert.IsNotNull(res);
            Assert.IsNotNull(res.Value);
            Assert.AreEqual(caracteristique, res.Value as Caracteristique, "La caracteristique n'est pas le même");
        }

        [TestMethod()]
        public void Moq_GetCaracteristiqueTest_RecuperationFailed()
        {
            // Act
            var res = controller_mock.GetCaracteristique(0).Result;
            // Assert
            Assert.IsInstanceOfType(res.Result, typeof(NotFoundResult));
        }

        [TestMethod()]
        public void Moq_PostCaracteristiqueTest()
        {
            // Act
            var actionResult = controller_mock.PostCaracteristique(caracteristique).Result;
            // Assert
            Assert.IsInstanceOfType(actionResult, typeof(ActionResult<Caracteristique>), "Pas un ActionResult<Caracteristique>");
            Assert.IsInstanceOfType(actionResult.Result, typeof(CreatedAtActionResult), "Pas un CreatedAtActionResult");
            var result = actionResult.Result as CreatedAtActionResult;
            Assert.IsInstanceOfType(result.Value, typeof(Caracteristique), "Pas une Caracteristique");
            caracteristique.IdCaracteristique = ((Caracteristique)result.Value).IdCaracteristique;
            Assert.AreEqual(caracteristique, (Caracteristique)result.Value, "Caracteristique pas identiques");
        }

        [TestMethod]
        public void Moq_DeleteCaracteristiqueTest()
        {
            // Arrange
            mockRepository.Setup(x => x.GetByIdAsync(1).Result).Returns(caracteristique);

            // Act
            var actionResult = controller_mock.DeleteCaracteristique(1).Result;
            // Assert
            Assert.IsInstanceOfType(actionResult, typeof(NoContentResult), "Pas un NoContentResult"); // Test du type de retour
        }

        [TestMethod]
        public void Moq_PutCaracteristiqueTest()
        {
            // Arrange
            mockRepository.Setup(x => x.GetByIdAsync(1).Result).Returns(caracteristique);
            var init = controller_mock.GetCaracteristique(1).Result;
            init.Value.NomCaracteristique = "CAR CLONE N°" + 2;

            // Act
            var res = controller_mock.PutCaracteristique(1, init.Value).Result;
            var maj = controller_mock.GetCaracteristique(1).Result;

            // Assert

            Assert.IsNotNull(maj.Value);
            Assert.AreEqual(init.Value, maj.Value, "Valeurs pas identiques");
        }
    }
}