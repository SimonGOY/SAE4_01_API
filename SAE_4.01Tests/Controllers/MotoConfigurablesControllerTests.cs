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
    public class MotoConfigurablesControllerTests
    {
        private MotoConfigurablesController controller;
        private BMWDBContext context;
        private IDataRepository<MotoConfigurable> dataRepository;
        private MotoConfigurable motoConf;
        private Mock<IDataRepository<MotoConfigurable>> mockRepository;
        private MotoConfigurablesController controller_mock;

        [TestInitialize]
        public void InitTest()
        {
            var builder = new DbContextOptionsBuilder<BMWDBContext>().UseNpgsql("Server=51.83.36.122; port=5432; Database=sa11; uid=sa11; password=BMW-S4; SearchPath=bmw;");
            context = new BMWDBContext(builder.Options);
            dataRepository = new MotoConfigurableManager(context);
            controller = new MotoConfigurablesController(dataRepository);
            mockRepository = new Mock<IDataRepository<MotoConfigurable>>();
            controller_mock = new MotoConfigurablesController(mockRepository.Object);

            motoConf = new MotoConfigurable
            {
                IdMotoConfigurable = 666666666,
                IdMoto = 1,
            };
        }

        [TestMethod()]
        public void GetMotoConfigurablesTest()
        {
            //Arrange
            List<MotoConfigurable> lesMots = context.MotoConfigurables.ToList();
            // Act
            var res = controller.GetMotoConfigurables().Result;
            // Assert
            Assert.IsNotNull(res);
            CollectionAssert.AreEqual(lesMots, res.Value.ToList(), "Les listes de moto conf ne sont pas identiques");
        }

        [TestMethod()]
        public void GetMotoConfigurableTest_RecuperationOK()
        {
            // Arrange
            MotoConfigurable? mot = context.MotoConfigurables.Find(1);
            // Act
            var res = controller.GetMotoConfigurable(1).Result;
            // Assert
            Assert.IsNotNull(res.Value);
            Assert.AreEqual(mot, res.Value, "La moto n'est pas la même");
        }

        [TestMethod()]
        public void GetMotoConfigurableTest_RecuperationFailed()
        {
            // Arrange
            MotoConfigurable? med = context.MotoConfigurables.Find(1);
            // Act
            var res = controller.GetMotoConfigurable(2).Result;
            // Assert
            Assert.IsNotNull(res.Value);
            Assert.AreNotEqual(med, res.Value, "La moto est la même");
        }

        [TestMethod()]
        public void GetMotoConfigurableTest_EquipementNExistePas()
        {
            var res = controller.GetMotoConfigurable(777777777).Result;
            // Assert
            Assert.IsNull(res.Result, "La moto existe");
            Assert.IsNull(res.Value, "La moto existe");
        }

        [TestMethod()]
        public void PostDeleteTest()
        {
            PostMotoConfigurableTest_CreationOK();
            DeleteMotoConfigurableTest_SuppressionOK();
        }

        public void PostMotoConfigurableTest_CreationOK()
        {
            // Act
            var result = controller.PostMotoConfigurable(motoConf).Result;
            // Assert
            var motRecup = controller.GetMotoConfigurable(motoConf.IdMotoConfigurable).Result;
            motoConf.IdMotoConfigurable = motRecup.Value.IdMotoConfigurable;
            Assert.AreEqual(motoConf, motRecup.Value, "moto pas identiques");
        }

        public void DeleteMotoConfigurableTest_SuppressionOK()
        {
            // Act
            var motSuppr = controller.GetMotoConfigurable(motoConf.IdMotoConfigurable).Result;
            _ = controller.DeleteMotoConfigurable(motoConf.IdMotoConfigurable).Result;

            // Assert
            var res = controller.GetMotoConfigurable(motoConf.IdMotoConfigurable).Result;
            Assert.IsNull(res.Value, "moto non supprimé");
        }

        // ---------------------------------------- Tests Moq ----------------------------------------

        [TestMethod()]
        public void Moq_GetMotoConfigurablesTest_RecuperationOK()
        {
            // Arrange
            var motos = new List<MotoConfigurable>
                {
                    motoConf
                };
            mockRepository.Setup(x => x.GetAllAsync()).ReturnsAsync(motos);
            // Act
            var res = controller_mock.GetMotoConfigurables().Result;
            // Assert
            Assert.IsNotNull(res);
            Assert.IsNotNull(res.Value);
            Assert.AreEqual(motos, res.Value as IEnumerable<MotoConfigurable>, "La liste n'est pas le même");
        }

        [TestMethod()]
        public void Moq_GetMotoConfigurableTest_RecuperationOK()
        {
            // Arrange
            mockRepository.Setup(x => x.GetByIdAsync(1)).ReturnsAsync(motoConf);

            // Act
            var result = controller_mock.GetMotoConfigurable(1).Result;
            var objectResult = result.Result as ObjectResult;
            var value = objectResult.Value.GetType().GetProperty("Value").GetValue(objectResult.Value, null) as MotoConfigurable;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(objectResult);
            Assert.IsNotNull(value);

            Assert.AreEqual(motoConf, value, "Les objets ne sont pas égaux");
        }


        [TestMethod()]
        public void Moq_GetMotoConfigurableTest_RecuperationFailed()
        {
            // Act
            var res = controller_mock.GetMotoConfigurable(0).Result;
            // Assert
            Assert.IsInstanceOfType(res.Result, typeof(NotFoundResult));
        }

        [TestMethod()]
        public void Moq_PostMediaTest()
        {
            // Act
            var actionResult = controller_mock.PostMotoConfigurable(motoConf).Result;
            // Assert
            Assert.IsInstanceOfType(actionResult, typeof(ActionResult<MotoConfigurable>), "Pas un ActionResult<MotoConfigurable>");
            Assert.IsInstanceOfType(actionResult.Result, typeof(CreatedAtActionResult), "Pas un CreatedAtActionResult");
            var result = actionResult.Result as CreatedAtActionResult;
            Assert.IsInstanceOfType(result.Value, typeof(MotoConfigurable), "Pas une MotoConfigurable");
            motoConf.IdMotoConfigurable = ((MotoConfigurable)result.Value).IdMotoConfigurable;
            Assert.AreEqual(motoConf, (MotoConfigurable)result.Value, "MotoConfigurable pas identiques");
        }

        [TestMethod]
        public void Moq_DeleteMediaTest()
        {
            // Arrange
            mockRepository.Setup(x => x.GetByIdAsync(1).Result).Returns(motoConf);

            // Act
            var actionResult = controller_mock.DeleteMotoConfigurable(1).Result;
            // Assert
            Assert.IsInstanceOfType(actionResult, typeof(NoContentResult), "Pas un NoContentResult"); // Test du type de retour
        }
    }
}