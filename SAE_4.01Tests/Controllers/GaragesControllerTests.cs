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
    public class GaragesControllerTests
    {
        private GaragesController controller;
        private BMWDBContext context;
        private IDataRepository<Garage> dataRepository;
        private Garage garage;
        private Mock<IDataRepository<Garage>> mockRepository;
        private GaragesController controller_mock;

        [TestInitialize]
        public void InitTest()
        {
            var builder = new DbContextOptionsBuilder<BMWDBContext>().UseNpgsql("Server=51.83.36.122; port=5432; Database=sa11; uid=sa11; password=BMW-S4; SearchPath=bmw;");
            context = new BMWDBContext(builder.Options);
            dataRepository = new GarageManager(context);
            controller = new GaragesController(dataRepository);
            mockRepository = new Mock<IDataRepository<Garage>>();
            controller_mock = new GaragesController(mockRepository.Object);

            garage = new Garage
            {
                IdMotoConfigurable = 1,
                IdClient = 2,
            };
        }

        [TestMethod()]
        public void GetGaragesTest_RecuperationsOK()
        {
            //Arrange
            List<Garage> lesGars = context.Garages.ToList();
            // Act
            var res = controller.GetGarages().Result;
            // Assert
            Assert.IsNotNull(res);
            CollectionAssert.AreEqual(lesGars, res.Value.ToList(), "Les listes de garages ne sont pas identiques");
        }

        [TestMethod()]
        public void GetByIds_RecuperationOK()
        {
            // Arrange
            var gar = context.Garages.Find(1, 1);
            // Act
            var res = controller.GetByIds(1, 1).Result;
            // Assert
            Assert.IsNotNull(res.Value);
            Assert.AreEqual(gar, res.Value, "Le garage n'est pas le même");
        }

        [TestMethod()]
        public void GetGarageTest_RecuperationFailed()
        {
            // Arrange
            var gar = controller.GetByIds(1, 1).Result;
            // Act
            var res = controller.GetByIds(15, 23).Result;
            // Assert
            Assert.IsNotNull(res.Value);
            Assert.AreNotEqual(gar, res.Value, "Le garage est le même");
        }

        [TestMethod()]
        public void GetGarageTest_GarageNExistePas()
        {
            var res = controller.GetByIds(777777777, 1).Result;
            // Assert
            Assert.IsNull(res.Result, "Le garage existe");
            Assert.IsNull(res.Value, "Le garage existe");
        }

        [TestMethod()]
        public void PostDeleteTest()
        {
            PostGarageTest_CreationOK();
            DeleteGarageTest_SuppressionOK();
        }

        public void PostGarageTest_CreationOK()
        {
            // Act
            var result = controller.PostGarage(garage).Result;
            // Assert
            var garRecup = controller.GetByIds(garage.IdMotoConfigurable, garage.IdClient).Result;
            garage.IdMotoConfigurable = garRecup.Value.IdMotoConfigurable;
            garage.IdClient = garRecup.Value.IdClient;
            Assert.AreEqual(garage, garRecup.Value, "garage pas identiques");
        }

        public void DeleteGarageTest_SuppressionOK()
        {
            // Act
            var garSuppr = controller.GetByIds(garage.IdMotoConfigurable, garage.IdClient).Result;
            _ = controller.DeleteGarage(garage.IdMotoConfigurable, garage.IdClient).Result;

            // Assert
            var res = controller.GetByIds(garage.IdMotoConfigurable, garage.IdClient).Result;
            Assert.IsNull(res.Value, "garage non supprimé");
        }

        // ---------------------------------------- Tests Moq ----------------------------------------

        [TestMethod()]
        public void Moq_GetGaragesTest_RecuperationOK()
        {
            // Arrange
            var garages = new List<Garage>
                {
                    garage
                };
            mockRepository.Setup(x => x.GetAllAsync()).ReturnsAsync(garages);
            // Act
            var res = controller_mock.GetGarages().Result;
            // Assert
            Assert.IsNotNull(res);
            Assert.IsNotNull(res.Value);
            Assert.AreEqual(garages, res.Value as IEnumerable<Garage>, "La liste n'est pas le même");
        }

        [TestMethod()]
        public void Moq_GetByIdClientTest_RecuperationOK()
        {
            // Arrange
            var garages = new List<Garage>
                {
                    garage
                };
            mockRepository.Setup(x => x.GetByIdClientAsync(1)).ReturnsAsync(garages);
            // Act
            var res = controller_mock.GetByIdClient(1).Result;
            var res_cast = ((Microsoft.AspNetCore.Mvc.ActionResult<System.Collections.Generic.IEnumerable<SAE_4._01.Models.EntityFramework.Garage>>)((Microsoft.AspNetCore.Mvc.ObjectResult)res.Result).Value).Value;
            // Assert
            Assert.IsNotNull(res);
            Assert.IsNotNull(res.Result);
            Assert.AreEqual(garages, res_cast as IEnumerable<Garage>, "La liste n'est pas le même");
        }

        [TestMethod()]
        public void Moq_GetByIdClientTest_RecuperationNonOK()
        {
            // Act
            var res = controller_mock.GetByIdClient(0).Result;
            // Assert
            Assert.IsInstanceOfType(res.Result, typeof(NotFoundResult));
        }

        [TestMethod()]
        public void Moq_GetByIdMotoConfigurableTest_RecuperationOK()
        {
            // Arrange
            var garages = new List<Garage>
                {
                    garage
                };
            mockRepository.Setup(x => x.GetByIdMotoConfigurableAsync(1)).ReturnsAsync(garages);
            // Act
            var res = controller_mock.GetByIdMotoConfigurable(1).Result;
            var res_cast = ((Microsoft.AspNetCore.Mvc.ActionResult<System.Collections.Generic.IEnumerable<SAE_4._01.Models.EntityFramework.Garage>>)((Microsoft.AspNetCore.Mvc.ObjectResult)res.Result).Value).Value;
            // Assert
            Assert.IsNotNull(res);
            Assert.IsNotNull(res.Result);
            Assert.AreEqual(garages, res_cast as IEnumerable<Garage>, "La liste n'est pas le même");
        }

        [TestMethod()]
        public void Moq_GetByIdMotoConfigurableTest_RecuperationFailed()
        {
            // Act
            var res = controller_mock.GetByIdMotoConfigurable(0).Result;
            // Assert
            Assert.IsInstanceOfType(res.Result, typeof(NotFoundResult));
        }

        [TestMethod()]
        public void Moq_PostGarageTest()
        {
            // Act
            var actionResult = controller_mock.PostGarage(garage).Result;
            // Assert
            Assert.IsInstanceOfType(actionResult, typeof(ActionResult<Garage>), "Pas un ActionResult<Garage>");
            Assert.IsInstanceOfType(actionResult.Result, typeof(CreatedAtActionResult), "Pas un CreatedAtActionResult");
            var result = actionResult.Result as CreatedAtActionResult;
            Assert.IsInstanceOfType(result.Value, typeof(Garage), "Pas une Garage");
            garage.IdClient = ((Garage)result.Value).IdClient;
            garage.IdMotoConfigurable = ((Garage)result.Value).IdMotoConfigurable;
            Assert.AreEqual(garage, (Garage)result.Value, "Garage pas identiques");
        }

        [TestMethod]
        public void Moq_DeleteGarageTest()
        {
            // Arrange
            mockRepository.Setup(x => x.GetBy2CompositeKeysAsync(1,1).Result).Returns(garage);

            // Act
            var actionResult = controller_mock.DeleteGarage(1,1).Result;
            // Assert
            Assert.IsInstanceOfType(actionResult, typeof(NoContentResult), "Pas un NoContentResult"); // Test du type de retour
        }
    }
}