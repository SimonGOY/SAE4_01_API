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
                NomPays = "Testanie",
                AdresseAdresse = "42 rue du Test",
            };
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
            var res = controller.GetAdresses().Result;
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
            var res = controller.GetAdresse(1).Result;
            // Assert
            Assert.IsNotNull(res);
            Assert.IsNotNull(res.Value);
            Assert.AreEqual(adresse, res.Value as Adresse, "Le concessionnaire n'est pas le même");
        }
    }
}