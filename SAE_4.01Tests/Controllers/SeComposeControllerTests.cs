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
    public class SeComposeControllerTests
    {
        private SeComposeController controller;
        private BMWDBContext context;
        private IDataRepository<SeCompose> dataRepository;
        private SeCompose seCompose;
        private Mock<IDataRepository<SeCompose>> mockRepository;
        private SeComposeController controller_mock;


        [TestInitialize]
        public void SeComposeControllerTest()
        {
            var builder = new DbContextOptionsBuilder<BMWDBContext>().UseNpgsql("Server=51.83.36.122; port=5432; Database=sa11; uid=sa11; password=BMW-S4; SearchPath=bmw;");
            context = new BMWDBContext(builder.Options);
            dataRepository = new SeComposeManager(context);
            controller = new SeComposeController(dataRepository);
            mockRepository = new Mock<IDataRepository<SeCompose>>();
            controller_mock = new SeComposeController(mockRepository.Object);

            seCompose = new SeCompose
            {
                IdPack = 1,
                IdOption = 1,
                
            };
        }

        [TestMethod()]
        public void GetSeComposesTest_RecuperationsOK()
        {
            //Arrange
            List<SeCompose> lesComs = context.SeComposes.ToList();
            // Act
            var res = controller.GetSeComposes().Result;
            // Assert
            Assert.IsNotNull(res);
            CollectionAssert.AreEqual(lesComs, res.Value.ToList(), "Les listes de secompose ne sont pas identiques");
        }

        [TestMethod()]
        public void GetByIdsTest_RecuperationOK()
        {
            // Arrange
            var com = context.SeComposes.Find(1, 3);
            // Act
            var res = controller.GetByIds(1, 3).Result;
            // Assert
            Assert.IsNotNull(res.Value);
            Assert.AreEqual(com, res.Value, "Le secompose n'est pas le même");
        }

        [TestMethod()]
        public void GetByIdsTest_RecuperationFailed()
        {
            // Arrange
            var com = controller.GetByIds(1, 3).Result;
            // Act
            var res = controller.GetByIds(1, 5).Result;
            // Assert
            Assert.IsNotNull(res.Value);
            Assert.AreNotEqual(com, res.Value, "Le secompose est le même");
        }

        [TestMethod()]
        public void GetByIdsTest_SeComposeNExistePas()
        {
            var res = controller.GetByIds(777777777, 1).Result;
            // Assert
            Assert.IsNull(res.Result, "Le secompose existe");
            Assert.IsNull(res.Value, "Le secompose existe");
        }

        [TestMethod()]
        public void PostDeleteTest()
        {
            PostSeComposeTest_CreationOK();
            DeleteSeComposeTest_SuppressionOK();
        }

        public void PostSeComposeTest_CreationOK()
        {
            // Act
            var result = controller.PostSeCompose(seCompose).Result;
            // Assert
            var comRecup = controller.GetByIds(seCompose.IdPack, seCompose.IdOption).Result;
            seCompose.IdPack = comRecup.Value.IdPack;
            seCompose.IdOption = comRecup.Value.IdOption;
            Assert.AreEqual(seCompose, comRecup.Value, "SECOMPOSE pas identiques");
        }
        public void DeleteSeComposeTest_SuppressionOK()
        {
            // Act
            var preSuppr = controller.GetByIds(seCompose.IdPack, seCompose.IdOption).Result;
            _ = controller.DeleteSeCompose(seCompose.IdPack, seCompose.IdOption).Result;

            // Assert
            var res = controller.GetByIds(seCompose.IdPack, seCompose.IdOption).Result;
            Assert.IsNull(res.Value, "prefere non supprimé");
        }

        // ---------------------------------------- Tests Moq ----------------------------------------

        [TestMethod()]
        public void Moq_GetSeComposesTest_RecuperationOK()
        {
            // Arrange
            var seComposent = new List<SeCompose>
                {
                    seCompose
                };
            mockRepository.Setup(x => x.GetAllAsync()).ReturnsAsync(seComposent);
            // Act
            var res = controller_mock.GetSeComposes().Result;
            // Assert
            Assert.IsNotNull(res);
            Assert.IsNotNull(res.Value);
            Assert.AreEqual(seComposent, res.Value as IEnumerable<SeCompose>, "La liste n'est pas le même");
        }

        [TestMethod()]
        public void Moq_GetByIdsTest_RecuperationOK()
        {
            // Arrange
            mockRepository.Setup(x => x.GetBy2CompositeKeysAsync(1,1)).ReturnsAsync(seCompose);

            // Act
            var res = controller_mock.GetByIds(1,1).Result;

            // Assert
            Assert.IsNotNull(res);
            Assert.IsNotNull(res.Value);

            Assert.AreEqual(seCompose, res.Value, "Les objets ne sont pas égaux");
        }


        [TestMethod()]
        public void Moq_GetByIdsTest_RecuperationFailed()
        {
            // Act
            var res = controller_mock.GetByIds(0,0).Result;
            // Assert
            Assert.IsInstanceOfType(res.Result, typeof(NotFoundResult));
        }


        [TestMethod()]
        public void Moq_PostSeComposeTest()
        {
            // Act
            var actionResult = controller_mock.PostSeCompose(seCompose).Result;
            // Assert
            Assert.IsInstanceOfType(actionResult, typeof(ActionResult<SeCompose>), "Pas un ActionResult<SeCompose>");
            Assert.IsInstanceOfType(actionResult.Result, typeof(CreatedAtActionResult), "Pas un CreatedAtActionResult");
            var result = actionResult.Result as CreatedAtActionResult;
            Assert.IsInstanceOfType(result.Value, typeof(SeCompose), "Pas une SeCompose");
            seCompose.IdPack = ((SeCompose)result.Value).IdPack;
            Assert.AreEqual(seCompose, (SeCompose)result.Value, "SeCompose pas identiques");
        }

        [TestMethod]
        public void Moq_DeleteSeComposeTest()
        {
            // Arrange
            mockRepository.Setup(x => x.GetBy2CompositeKeysAsync(1,1).Result).Returns(seCompose);

            // Act
            var actionResult = controller_mock.DeleteSeCompose(1,1).Result;
            // Assert
            Assert.IsInstanceOfType(actionResult, typeof(NoContentResult), "Pas un NoContentResult");
        }
    }
}