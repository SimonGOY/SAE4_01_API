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
    public class ColorisControllerTests
    {
        private ColorisController controller;
        private BMWDBContext context;
        private IDataRepository<Coloris> dataRepository;
        private Coloris coloris;

        [TestInitialize]
        public void InitTest()
        {
            var builder = new DbContextOptionsBuilder<BMWDBContext>().UseNpgsql("Server=51.83.36.122; port=5432; Database=sa11; uid=sa11; password=BMW-S4; SearchPath=bmw;");
            context = new BMWDBContext(builder.Options);
            dataRepository = new ColorisManager(context);
            controller = new ColorisController(dataRepository);

            coloris = new Coloris
            {
                IdColoris = 666666666,
                NomColoris = "Marron Chiasse"
            };
        }

        [TestMethod()]
        public void PostDel()
        {
            PostColorisTest_CreationOk();
            DeleteColorisTest_SuppressionOK();
        }

        [TestMethod()]
        public void GetLesColorisTest_RecuperationsOK()
        {
            //Arrange
            List<Coloris> lesColos = context.LesColoris.ToList();
            // Act
            var res = controller.GetLesColoris().Result;
            // Assert
            Assert.IsNotNull(res);
            CollectionAssert.AreEqual(lesColos, res.Value.ToList(), "Les listes de coloris ne sont pas identiques");
        }

        [TestMethod()]
        public void GetColorisTest_RecuperationOK()
        {
            // Arrange
            Coloris? col = context.LesColoris.Find(1);
            // Act
            var res = controller.GetColoris(1).Result;
            // Assert
            Assert.IsNotNull(res.Value);
            Assert.AreEqual(col, res.Value, "La coloris n'est pas la même");
        }

        [TestMethod()]
        public void GetCollectionTest_RecuperationFailed()
        {
            // Arrange
            Coloris? col = context.LesColoris.Find(1);
            // Act
            var res = controller.GetColoris(2).Result;
            // Assert
            Assert.IsNotNull(res.Value);
            Assert.AreNotEqual(col, res.Value, "Le coloris est la même");
        }

        [TestMethod()]
        public void GetCollectionTest_CollecNExistePas()
        {
            var res = controller.GetColoris(777777777).Result;
            // Assert
            Assert.IsNull(res.Result, "Le coloris existe");
            Assert.IsNull(res.Value, "Le coloris existe");
        }

        public void PostColorisTest_CreationOk()
        {
            // Act
            var result = controller.PostColoris(coloris).Result;
            // Assert
            var colRecup = controller.GetColoris(coloris.IdColoris).Result;
            coloris.IdColoris = colRecup.Value.IdColoris;
            Assert.AreEqual(coloris, colRecup.Value, "Coloris pas identiques");
        }

        public void DeleteColorisTest_SuppressionOK()
        {
            // Act
            var colSuppr = controller.GetColoris(coloris.IdColoris).Result;
            _ = controller.DeleteColoris(coloris.IdColoris).Result;

            // Assert
            var res = controller.GetColoris(coloris.IdColoris).Result;
            Assert.IsNull(res.Value, "colo non supprimé");
        }

        // ---------------------------------------- Tests Moq ----------------------------------------

        [TestMethod()]
        public void Moq_GetColorisTest_RecuperationOK()
        {
            // Arrange
            var mockRepository = new Mock<IDataRepository<Coloris>>();
            mockRepository.Setup(x => x.GetByIdAsync(1).Result).Returns(coloris);

            var controller = new ColorisController(mockRepository.Object);
            // Act
            var res = controller.GetColoris(1).Result;
            // Assert
            Assert.IsNotNull(res);
            Assert.IsNotNull(res.Value);
            Assert.AreEqual(coloris, res.Value as Coloris, "La collection n'est pas le même");
        }
    }
}