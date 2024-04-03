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
    public class EstInclusControllerTests
    {
        private EstInclusController controller;
        private BMWDBContext context;
        private IDataRepository<EstInclus> dataRepository;
        private EstInclus estInclus;

        [TestInitialize]
        public void InitTest()
        {
            var builder = new DbContextOptionsBuilder<BMWDBContext>().UseNpgsql("Server=51.83.36.122; port=5432; Database=sa11; uid=sa11; password=BMW-S4; SearchPath=bmw;");
            context = new BMWDBContext(builder.Options);
            dataRepository = new EstInclusManager(context);
            controller = new EstInclusController(dataRepository);

            estInclus = new EstInclus
            {
                IdOption = 1,
                IdStyle = 2,
            };
        }

        [TestMethod()]
        public void GetSontInclusTest_RecuperationsOK()
        {
            //Arrange
            List<EstInclus> lesEsts = context.SontInclus.ToList();
            // Act
            var res = controller.GetSontInclus().Result;
            // Assert
            Assert.IsNotNull(res);
            CollectionAssert.AreEqual(lesEsts, res.Value.ToList(), "Les listes de estInclus ne sont pas identiques");
        }

        [TestMethod()]
        public void GetByIdsTest_RecuperationOK()
        {
            // Arrange
            var est = context.SontInclus.Find(1, 1);
            // Act
            var res = controller.GetByIds(1, 1).Result;
            // Assert
            Assert.IsNotNull(res.Value);
            Assert.AreEqual(est, res.Value, "Le est inclus n'est pas le même");
        }

        [TestMethod()]
        public void GetEstInclusTest_RecuperationFailed()
        {
            // Arrange
            var est = controller.GetByIds(3, 2).Result;
            // Act
            var res = controller.GetByIds(1,1).Result;
            // Assert
            Assert.IsNotNull(res.Value);
            Assert.AreNotEqual(est, res.Value, "Le estInclus est le même");
        }

        [TestMethod()]
        public void GetEstInclusTest_estInclusNExistePas()
        {
            var res = controller.GetByIds(777777777, 1).Result;
            // Assert
            Assert.IsNull(res.Result, "Le contenu existe");
            Assert.IsNull(res.Value, "Le contenu existe");
        }

        [TestMethod()]
        public void PostDeleteTest()
        {
            PostEstInclusTest_CreationOK();
            DeleteEstInclusTest_SuppressionOK();
        }

        public void PostEstInclusTest_CreationOK()
        {
            // Act
            var result = controller.PostEstInclus(estInclus).Result;
            // Assert
            var estRecup = controller.GetByIds(estInclus.IdOption, estInclus.IdStyle).Result;
            estInclus.IdOption = estRecup.Value.IdOption;
            estInclus.IdStyle = estRecup.Value.IdStyle;
            Assert.AreEqual(estInclus, estRecup.Value, "estInclus pas identiques");
        }

        public void DeleteEstInclusTest_SuppressionOK()
        {
            // Act
            var estSuppr = controller.GetByIds(estInclus.IdOption, estInclus.IdStyle).Result;
            _ = controller.DeleteEstInclus(estInclus.IdOption, estInclus.IdStyle).Result;

            // Assert
            var res = controller.GetByIds(estInclus.IdOption, estInclus.IdStyle).Result;
            Assert.IsNull(res.Value, "estinclus non supprimé");
        }

        // ---------------------------------------- Tests Moq ----------------------------------------

        [TestMethod()]
        public void Moq_GetSontInclusTest_RecuperationOK()
        {
            // Arrange
            var mockRepository = new Mock<IDataRepository<EstInclus>>();
            var sontInclus = new List<EstInclus>
                {
                    estInclus
                };
            mockRepository.Setup(x => x.GetAllAsync()).ReturnsAsync(sontInclus);

            var controller = new EstInclusController(mockRepository.Object);

            // Act
            var res = controller.GetSontInclus().Result;
            // Assert
            Assert.IsNotNull(res);
            Assert.IsNotNull(res.Value);
            Assert.AreEqual(sontInclus, res.Value as IEnumerable<EstInclus>, "La liste n'est pas le même");
        }

        [TestMethod()]
        public void Moq_GetByIdOptionTest_RecuperationOK()
        {
            // Arrange
            var mockRepository = new Mock<IDataRepository<EstInclus>>();
            var liste = new List<EstInclus>
                {
                    estInclus
                };
            mockRepository.Setup(x => x.GetByIdOptionAsync(1)).ReturnsAsync(liste);

            var controller = new EstInclusController(mockRepository.Object);
            
            // Act
            var res = controller.GetByIdOption(1).Result;
            var res_cast = ((Microsoft.AspNetCore.Mvc.ActionResult<System.Collections.Generic.IEnumerable<SAE_4._01.Models.EntityFramework.EstInclus>>)((Microsoft.AspNetCore.Mvc.ObjectResult)res.Result).Value).Value;
            // Assert
            Assert.IsNotNull(res);
            Assert.IsNotNull(res.Result);
            Assert.AreEqual(liste, res_cast as IEnumerable<EstInclus>, "La liste n'est pas le même");
        }

        [TestMethod()]
        public void Moq_GetByIdStyleAsyncTest_RecuperationOK()
        {
            // Arrange
            var mockRepository = new Mock<IDataRepository<EstInclus>>();
            var liste = new List<EstInclus>
                {
                    estInclus
                };
            mockRepository.Setup(x => x.GetByIdStyleAsync(1)).ReturnsAsync(liste);

            var controller = new EstInclusController(mockRepository.Object);

            // Act
            var res = controller.GetByIdStyle(1).Result;
            // Assert
            Assert.IsNotNull(res);
            Assert.IsNotNull(res.Value);
            Assert.AreEqual(liste, res.Value as IEnumerable<EstInclus>, "La liste n'est pas le même");
        }
    }
}