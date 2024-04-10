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
    public class OptionsControllerTests
    {
        private OptionsController controller;
        private BMWDBContext context;
        private IDataRepository<Option> dataRepository;
        private Option option;
        private Mock<IDataRepository<Option>> mockRepository;
        private OptionsController controller_mock;

        [TestInitialize]
        public void InitTest()
        {
            var builder = new DbContextOptionsBuilder<BMWDBContext>().UseNpgsql("Server=51.83.36.122; port=5432; Database=sa11; uid=sa11; password=BMW-S4; SearchPath=bmw;");
            context = new BMWDBContext(builder.Options);
            dataRepository = new OptionManager(context);
            controller = new OptionsController(dataRepository);
            mockRepository = new Mock<IDataRepository<Option>>();
            controller_mock = new OptionsController(mockRepository.Object);

            option = new Option
            {
                IdOption = 666666666,
                NomOption = "Vidangeage",
                PrixOption = new decimal (2.00),
                DetailOption = "Sucaaaaaaaaaaaaage........... d'huile",
                PhotoOption = "google.com"
            };
        }

        [TestMethod()]
        public void GetOptionsTest_RecuperationsOK()
        {
            //Arrange
            List<Option> lesMots = context.Options.ToList();
            // Act
            var res = controller.GetOptions().Result;
            // Assert
            Assert.IsNotNull(res);
            CollectionAssert.AreEqual(lesMots, res.Value.ToList(), "Les listes de moto dispo ne sont pas identiques");
        }

        [TestMethod()]
        public void GetOptionTest_RecuperationOK()
        {
            // Arrange
            Option? mot = context.Options.Find(1);
            // Act
            var res = controller.GetOption(1).Result;
            // Assert
            Assert.IsNotNull(res.Value);
            Assert.AreEqual(mot, res.Value, "La moto dispo n'est pas la même");
        }

        [TestMethod()]
        public void GetOptionTest_RecuperationFailed()
        {
            // Arrange
            Option? opt = context.Options.Find(1);
            // Act
            var res = controller.GetOption(2).Result;
            // Assert
            Assert.IsNotNull(res.Value);
            Assert.AreNotEqual(opt, res.Value, "La moto est la même");
        }

        [TestMethod()]
        public void GetOptionTest_OptionNExistePas()
        {
            var res = controller.GetOption(777777777).Result;
            // Assert
            Assert.IsNull(res.Result, "La moto existe");
            Assert.IsNull(res.Value, "La moto existe");
        }

        [TestMethod()]
        public void PostPutDeleteTest()
        {
            PostOptionTest_CreationOK();
            PutOptionTest_ModificationOK();
            DeleteOptionTest_SuppressionOK();
        }


        public void PostOptionTest_CreationOK()
        {
            // Act
            var result = controller.PostOption(option).Result;
            // Assert
            var optRecup = controller.GetOption(option.IdOption).Result;
            option.IdOption = optRecup.Value.IdOption;
            Assert.AreEqual(option, optRecup.Value, "option pas identiques");
        }


        public void PutOptionTest_ModificationOK()
        {
            // Arrange
            var optIni = controller.GetOption(option.IdOption).Result;
            optIni.Value.PrixOption= 10000;

            // Act
            var res = controller.PutOption(option.IdOption, optIni.Value).Result;

            // Assert
            var optMaj = controller.GetOption(option.IdOption).Result;
            Assert.IsNotNull(optMaj.Value);
            Assert.AreEqual(optIni.Value, optMaj.Value, "moto pas identiques");
        }

        public void DeleteOptionTest_SuppressionOK()
        {
            // Act
            var optSuppr = controller.GetOption(option.IdOption).Result;
            _ = controller.DeleteOption(option.IdOption).Result;

            // Assert
            var res = controller.GetOption(option.IdOption).Result;
            Assert.IsNull(res.Value, "moto non supprimé");
        }

        // ---------------------------------------- Tests Moq ----------------------------------------

        [TestMethod()]
        public void Moq_GetOptionsTest_RecuperationOK()
        {
            // Arrange
            var options = new List<Option>
                {
                    option
                };
            mockRepository.Setup(x => x.GetAllAsync()).ReturnsAsync(options);
            // Act
            var res = controller_mock.GetOptions().Result;
            // Assert
            Assert.IsNotNull(res);
            Assert.IsNotNull(res.Value);
            Assert.AreEqual(options, res.Value as IEnumerable<Option>, "La liste n'est pas le même");
        }

        [TestMethod()]
        public void Moq_GetOptionTest_RecuperationOK()
        {
            // Arrange
            mockRepository.Setup(x => x.GetByIdAsync(1)).ReturnsAsync(option);

            // Act
            var res = controller_mock.GetOption(1).Result;

            // Assert
            Assert.IsNotNull(res);
            Assert.IsNotNull(res.Value);

            Assert.AreEqual(option, res.Value, "Les objets ne sont pas égaux");
        }


        [TestMethod()]
        public void Moq_GetOptionTest_RecuperationFailed()
        {
            // Act
            var res = controller_mock.GetOption(0).Result;
            // Assert
            Assert.IsInstanceOfType(res.Result, typeof(NotFoundResult));
        }

        [TestMethod()]
        public void Moq_PostOptionTest()
        {
            // Act
            var actionResult = controller_mock.PostOption(option).Result;
            // Assert
            Assert.IsInstanceOfType(actionResult, typeof(ActionResult<Option>), "Pas un ActionResult<Option>");
            Assert.IsInstanceOfType(actionResult.Result, typeof(CreatedAtActionResult), "Pas un CreatedAtActionResult");
            var result = actionResult.Result as CreatedAtActionResult;
            Assert.IsInstanceOfType(result.Value, typeof(Option), "Pas une Option");
            option.IdOption = ((Option)result.Value).IdOption;
            Assert.AreEqual(option, (Option)result.Value, "Option pas identiques");
        }

        [TestMethod]
        public void Moq_DeleteOptionTest()
        {
            // Arrange
            mockRepository.Setup(x => x.GetByIdAsync(1).Result).Returns(option);

            // Act
            var actionResult = controller_mock.DeleteOption(1).Result;
            // Assert
            Assert.IsInstanceOfType(actionResult, typeof(NoContentResult), "Pas un NoContentResult"); // Test du type de retour
        }

        [TestMethod]
        public void Moq_PutPackTest()
        {
            // Arrange
            mockRepository.Setup(x => x.GetByIdAsync(1).Result).Returns(option);
            var init = controller_mock.GetOption(1).Result;
            init.Value.PrixOption = 100;


            // Act
            var res = controller_mock.PutOption(option.IdOption, init.Value).Result;
            var maj = controller_mock.GetOption(1).Result;

            // Assert

            Assert.IsNotNull(maj.Value);
            Assert.AreEqual(init.Value, maj.Value, "Valeurs pas identiques");
        }
    }
}