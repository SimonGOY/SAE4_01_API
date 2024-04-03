using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
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

        [TestInitialize]
        public void InitTest()
        {
            var builder = new DbContextOptionsBuilder<BMWDBContext>().UseNpgsql("Server=51.83.36.122; port=5432; Database=sa11; uid=sa11; password=BMW-S4; SearchPath=bmw;");
            context = new BMWDBContext(builder.Options);
            dataRepository = new GarageManager(context);
            controller = new GaragesController(dataRepository);

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
        public void GetGarageTest_estInclusNExistePas()
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
    }
}