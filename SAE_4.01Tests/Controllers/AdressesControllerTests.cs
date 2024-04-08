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

            adresse = new Adresse
            {
                NumAdresse = 666666666,
                NomPays = "France",
                AdresseAdresse = "42 rue du Test",
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
            var result = controller.PostAdresse(adresse).Result;
            // Assert
            var adrRecup = controller.GetAdresse(adresse.NumAdresse).Result;
            adresse.NumAdresse = adrRecup.Value.NumAdresse;
            Assert.AreEqual(adresse, adrRecup.Value, "Accessoires pas identiques");
        }

        public void PutAdresseTest_ModificationOK()
        {
            // Arrange
            var adrIni = controller.GetAdresse(adresse.NumAdresse).Result;
            adrIni.Value.AdresseAdresse = "Adresse";

            // Act
            var res = controller.PutAdresse(adresse.NumAdresse, adrIni.Value).Result;

            // Assert
            var adrMaj = controller.GetAdresse(adresse.NumAdresse).Result;
            Assert.IsNotNull(adrMaj.Value);
            Assert.AreEqual(adrIni.Value, adrMaj.Value, "Accessoire pas identiques");
        }

        public void DeleteAdresseTest_SuppressionOK()
        {

            // Act
            var adrSuppr = controller.GetAdresse(adresse.NumAdresse).Result;
            _ = controller.DeleteAdresse(adrSuppr.Value.NumAdresse).Result;

            // Assert
            var res = controller.GetAdresse(adresse.NumAdresse).Result;
            Assert.IsNull(res.Value, "adresse non supprimé");
        }

        // ---------------------------------------- Tests Moq ----------------------------------------

        [TestMethod()]
        public void Moq_GetAdressesTest_RecuperationOK()
        {
            // Arrange
            var adresses = new List<Adresse>
                {
                    adresse
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
    }
}