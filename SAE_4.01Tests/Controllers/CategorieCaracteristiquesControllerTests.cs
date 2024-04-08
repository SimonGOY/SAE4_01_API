﻿using Microsoft.EntityFrameworkCore;
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
    public class CategorieCaracteristiquesControllerTests
    {
        private CategorieCaracteristiquesController controller;
        private BMWDBContext context;
        private IDataRepository<CategorieCaracteristique> dataRepository;
        private CategorieCaracteristique categorieCaracteristique;
        private Mock<IDataRepository<CategorieCaracteristique>> mockRepository;
        private CategorieCaracteristiquesController controller_mock;

        [TestInitialize()]
        public void InitTest()
        {
            var builder = new DbContextOptionsBuilder<BMWDBContext>().UseNpgsql("Server=51.83.36.122; port=5432; Database=sa11; uid=sa11; password=BMW-S4; SearchPath=bmw;");
            context = new BMWDBContext(builder.Options);
            dataRepository = new CategorieCaracteristiqueManager(context);
            controller = new CategorieCaracteristiquesController(dataRepository);
            mockRepository = new Mock<IDataRepository<CategorieCaracteristique>>();
            controller_mock = new CategorieCaracteristiquesController(mockRepository.Object);

            categorieCaracteristique = new CategorieCaracteristique
            {
                IdCatCaracteristique = 666666666,
                NomCatCaracteristique = "J'ai pas d'idée de blague",
            };
        }

        [TestMethod()]
        public void GetCategorieCaracteristiqueTest()
        {
            Assert.Fail();
        }
        // ---------------------------------------- Tests Moq ----------------------------------------

        [TestMethod()]
        public void Moq_GetCategorieCaracteristiquesTest_RecuperationOK()
        {
            // Arrange
            var categorieCaracteristiques = new List<CategorieCaracteristique>
                {
                    categorieCaracteristique
                };
            mockRepository.Setup(x => x.GetAllAsync()).ReturnsAsync(categorieCaracteristiques);

            // Act
            var res = controller_mock.GetCategorieCaracteristiques().Result;
            // Assert
            Assert.IsNotNull(res);
            Assert.IsNotNull(res.Value);
            Assert.AreEqual(categorieCaracteristiques, res.Value as IEnumerable<CategorieCaracteristique>, "La liste n'est pas le même");
        }

        [TestMethod()]
        public void Moq_GetCategorieCaracteristiqueTest_RecuperationOK()
        {
            // Arrange
            mockRepository.Setup(x => x.GetByIdAsync(1).Result).Returns(categorieCaracteristique);
            // Act
            var res = controller_mock.GetCategorieCaracteristique(1).Result;
            // Assert
            Assert.IsNotNull(res);
            Assert.IsNotNull(res.Value);
            Assert.AreEqual(categorieCaracteristique, res.Value as CategorieCaracteristique, "La CategorieCaracteristique n'est pas le même");
        }

    }
}