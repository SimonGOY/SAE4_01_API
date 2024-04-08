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
    public class AccessoiresControllerTests
    {
        private AccessoiresController controller;
        private BMWDBContext context;
        private IDataRepository<Accessoire> dataRepository;
        private Accessoire accessoire;
        private Accessoire accessoire_bis;
        private Mock<IDataRepository<Accessoire>> mockRepository;
        private AccessoiresController controller_mock;

        [TestInitialize]
        public void InitTest()
        {
            var builder = new DbContextOptionsBuilder<BMWDBContext>().UseNpgsql("Server=51.83.36.122; port=5432; Database=sa11; uid=sa11; password=BMW-S4; SearchPath=bmw;");
            context = new BMWDBContext(builder.Options);
            dataRepository = new AccessoireManager(context);
            controller = new AccessoiresController(dataRepository);
            mockRepository = new Mock<IDataRepository<Accessoire>>();
            controller_mock= new AccessoiresController(mockRepository.Object);

            accessoire = new Accessoire
            {
                IdAccessoire = 666666666,
                IdMoto = 1,
                IdCatAcc = 1,
                NomAccessoire = "Piece Test",
                PrixAccessoire = 200,
                DetailAccessoire ="C'est une pièce de test quoi",
                PhotoAccessoire = "latavernedutesteur.files.wordpress.com/2017/11/testss.png"
            };
        }

        [TestMethod()]
        public void GetAccessoires_RecuperationOK()
        {
            //Arrange
            List<Accessoire> lesAccessoires = context.Accessoires.ToList();
            // Act
            var res = controller.GetAccessoires().Result;
            // Assert
            Assert.IsNotNull(res);
            CollectionAssert.AreEqual(lesAccessoires, res.Value.ToList(), "Les listes de clients ne sont pas identiques");
        }

        // ---------------------------------------- Tests Moq ----------------------------------------

        [TestMethod()]
        public void Moq_GetByIdClientTest_RecuperationOK()
        {
            // Arrange
            var accessoires = new List<Accessoire>
                {
                    accessoire
                };
            mockRepository.Setup(x => x.GetAllAsync()).ReturnsAsync(accessoires);

            // Act
            var res = controller_mock.GetAccessoires().Result;
            // Assert
            Assert.IsNotNull(res);
            Assert.IsNotNull(res.Value);
            Assert.AreEqual(accessoires, res.Value as IEnumerable<Accessoire>, "La liste n'est pas le même");
        }

        [TestMethod()]
        public void Moq_GetAccessoireTest_RecuperationOK()
        {
            // Arrange
            mockRepository.Setup(x => x.GetByIdAsync(1).Result).Returns(accessoire);
            // Act
            var res = controller_mock.GetAccessoire(1).Result;
            // Assert
            Assert.IsNotNull(res);
            Assert.IsNotNull(res.Value);
            Assert.AreEqual(accessoire, res.Value as Accessoire, "Le concessionnaire n'est pas le même");
        }

        [TestMethod()]
        public void Moq_GetAccessoireTest_RecuperationNonOK()
        {
            // Act
            var res = controller_mock.GetAccessoire(0).Result;
            // Assert
            Assert.IsInstanceOfType(res.Result, typeof(NotFoundResult));
        }

        


        [TestMethod()]
        public void Moq_GetByIdMotoTest_RecuperationOK()
        {
            // Arrange
            var accessoires = new List<Accessoire>
                {
                    accessoire
                };
            mockRepository.Setup(x => x.GetByIdMotoAsync(1)).ReturnsAsync(accessoires);
            // Act
            var res = controller_mock.GetByIdMoto(1).Result;
            // Assert
            Assert.IsNotNull(res);
            Assert.IsNotNull(res.Value);
            Assert.AreEqual(accessoires, res.Value as IEnumerable<Accessoire>, "La liste n'est pas le même");
        }
    }
}