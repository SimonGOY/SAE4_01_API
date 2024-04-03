﻿using Microsoft.AspNetCore.Mvc;
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
    public class CategorieAccessoiresControllerTests
    {
        private CategorieAccessoiresController controller;
        private BMWDBContext context;
        private IDataRepository<CategorieAccessoire> dataRepository;
        private CategorieAccessoire categorieAccessoire;

        [TestInitialize()]
        public void InitTest()
        {
            var builder = new DbContextOptionsBuilder<BMWDBContext>().UseNpgsql("Server=51.83.36.122; port=5432; Database=sa11; uid=sa11; password=BMW-S4; SearchPath=bmw;");
            context = new BMWDBContext(builder.Options);
            dataRepository = new CategorieAccessoireManager(context);
            controller = new CategorieAccessoiresController(dataRepository);

            categorieAccessoire = new CategorieAccessoire
            {
                IdCatAcc = 666666666,
                NomCatAcc = "J'ai pas d'idée de blague",
            };
        }

        [TestMethod()]
        public void PostDel()
        {
            PostCategorieAccessoireTest_CreationOK();
            //Ne peut pas etre modifier du fait de sa configuration
            //PutCategorieAccessoireTest_ModificationOK();
            DeleteCategorieAccessoireTest_SuppressionOK();
        }

        [TestMethod()]
        public void GetCategorieAccessoiresTest_RecuperationOK()
        {
            //Arrange
            List<CategorieAccessoire> lesCatAcc = context.CategorieAccessoires.ToList();
            // Act
            var res = controller.GetCategorieAccessoires().Result;
            // Assert
            Assert.IsNotNull(res);
            CollectionAssert.AreEqual(lesCatAcc, res.Value.ToList(), "Les listes de catégories accessoire ne sont pas identiques");
        }

        [TestMethod()]
        public void GetCategorieAccessoireTest_RecuperationOK()
        {
            // Arrange
            CategorieAccessoire? cta = context.CategorieAccessoires.Find(1);
            // Act
            var res = controller.GetCategorieAccessoire(1).Result;
            // Assert
            Assert.IsNotNull(res.Value);
            Assert.AreEqual(cta, res.Value, "La catégorie accessoire n'est pas la même");
        }

        public void PostCategorieAccessoireTest_CreationOK()
        {
            // Act
            var result = controller.PostCategorieAccessoire(categorieAccessoire).Result;
            // Assert
            var ctaRecup = controller.GetCategorieAccessoire(categorieAccessoire.IdCatAcc).Result;
            categorieAccessoire.IdCatAcc = ctaRecup.Value.IdCatAcc;
            Assert.AreEqual(categorieAccessoire, ctaRecup.Value, "Catégories accessoires pas identiques"); ;
        }

        /*public void PutCategorieAccessoireTest_ModificationOK()
        {
            // Arrange
            var ctaIni = controller.GetCategorieAccessoire(categorieAccessoire.IdCatAcc).Result;
            ctaIni.Value.NomCatAcc = "CATACC CLONE N°" + 2;

            // Act
            var res = controller.PutCategorieAccessoire(categorieAccessoire.IdCatAcc, ctaIni.Value).Result;

            // Assert
            var ctaMaj = controller.GetCategorieAccessoire(categorieAccessoire.IdCatAcc).Result;
            Assert.IsNotNull(ctaMaj.Value);
            Assert.AreEqual(ctaIni.Value, ctaMaj.Value, "Client pas identiques");
        }*/

        public void DeleteCategorieAccessoireTest_SuppressionOK()
        {
            // Act
            var ctaSuppr = controller.GetCategorieAccessoire(categorieAccessoire.IdCatAcc).Result;
            _ = controller.DeleteCategorieAccessoire(ctaSuppr.Value.IdCatAcc).Result;

            // Assert
            var res = controller.GetCategorieAccessoire(categorieAccessoire.IdCatAcc).Result;
            Assert.IsNull(res.Value, "client non supprimé");
        }

        // ---------------------------------------- Tests Moq ----------------------------------------

        [TestMethod()]
        public void Moq_GetCategorieAccessoireTest_RecuperationOK()
        {
            // Arrange
            var mockRepository = new Mock<IDataRepository<CategorieAccessoire>>();
            mockRepository.Setup(x => x.GetByIdAsync(1).Result).Returns(categorieAccessoire);

            var controller = new CategorieAccessoiresController(mockRepository.Object);
            // Act
            var res = controller.GetCategorieAccessoire(1).Result;
            // Assert
            Assert.IsNotNull(res);
            Assert.IsNotNull(res.Value);
            Assert.AreEqual(categorieAccessoire, res.Value as CategorieAccessoire, "La CategorieAccessoire n'est pas le même");
        }
    }
}