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
    public class MotoDisponiblesControllerTests
    {
        private MotoDisponiblesController controller;
        private BMWDBContext context;
        private IDataRepository<MotoDisponible> dataRepository;
        private MotoDisponible motoDispo;
        private Mock<IDataRepository<MotoDisponible>> mockRepository;
        private MotoDisponiblesController controller_mock;

        [TestInitialize]
        public void InitTest()
        {
            var builder = new DbContextOptionsBuilder<BMWDBContext>().UseNpgsql("Server=51.83.36.122; port=5432; Database=sa11; uid=sa11; password=BMW-S4; SearchPath=bmw;");
            context = new BMWDBContext(builder.Options);
            dataRepository = new MotoDisponibleManager(context);
            controller = new MotoDisponiblesController(dataRepository);
            mockRepository = new Mock<IDataRepository<MotoDisponible>>();
            controller_mock = new MotoDisponiblesController(mockRepository.Object);

            motoDispo = new MotoDisponible
            {
                IdMotoDisponible = 666666666,
                PrixMotoDisponible = 15000.00f,
                IdMoto = 1,
            };
        }

        [TestMethod()]
        public void GetMotoDisponiblesTest_RecuperationsOK()
        {
            //Arrange
            List<MotoDisponible> lesMots = context.MotoDisponibles.ToList();
            // Act
            var res = controller.GetMotoDisponibles().Result;
            // Assert
            Assert.IsNotNull(res);
            CollectionAssert.AreEqual(lesMots, res.Value.ToList(), "Les listes de moto dispo ne sont pas identiques");
        }

        [TestMethod()]
        public void GetMotoDisponibleTest_RecuperationOK()
        {
            // Arrange
            MotoDisponible? mot = context.MotoDisponibles.Find(1);
            // Act
            var res = controller.GetMotoDisponible(1).Result;
            // Assert
            Assert.IsNotNull(res.Value);
            Assert.AreEqual(mot, res.Value, "La moto dispo n'est pas la même");
        }

        [TestMethod()]
        public void GetMotoConfigurableTest_RecuperationFailed()
        {
            // Arrange
            MotoDisponible? med = context.MotoDisponibles.Find(1);
            // Act
            var res = controller.GetMotoDisponible(2).Result;
            // Assert
            Assert.IsNotNull(res.Value);
            Assert.AreNotEqual(med, res.Value, "La moto est la même");
        }

        [TestMethod()]
        public void GetMotoConfigurableTest_EquipementNExistePas()
        {
            var res = controller.GetMotoDisponible(777777777).Result;
            // Assert
            Assert.IsNull(res.Result, "La moto existe");
            Assert.IsNull(res.Value, "La moto existe");
        }

        [TestMethod()]
        public void PostDeleteTest()
        {
            PostMotoDisponibleTest_CreationOK();
            PutMotoDisponibleTest_ModificationOK();
            DeleteMotoDisponibleTest_SuppressionOK();
        }

        public void PostMotoDisponibleTest_CreationOK()
        {
            // Act
            var result = controller.PostMotoDisponible(motoDispo).Result;
            // Assert
            var motRecup = controller.GetMotoDisponible(motoDispo.IdMotoDisponible).Result;
            motoDispo.IdMotoDisponible = motRecup.Value.IdMotoDisponible;
            Assert.AreEqual(motoDispo, motRecup.Value, "moto pas identiques");
        }

        public void PutMotoDisponibleTest_ModificationOK()
        {
            // Arrange
            var motIni = controller.GetMotoDisponible(motoDispo.IdMotoDisponible).Result;
            motIni.Value.PrixMotoDisponible = 4.50f;

            // Act
            var res = controller.PutMotoDisponible(motoDispo.IdMotoDisponible, motIni.Value).Result;

            // Assert
            var motMaj = controller.GetMotoDisponible(motoDispo.IdMotoDisponible).Result;
            Assert.IsNotNull(motMaj.Value);
            Assert.AreEqual(motIni.Value, motMaj.Value, "moto pas identiques");
        }

        public void DeleteMotoDisponibleTest_SuppressionOK()
        {
            // Act
            var motSuppr = controller.GetMotoDisponible(motoDispo.IdMotoDisponible).Result;
            _ = controller.DeleteMotoDisponible(motoDispo.IdMotoDisponible).Result;

            // Assert
            var res = controller.GetMotoDisponible(motoDispo.IdMotoDisponible).Result;
            Assert.IsNull(res.Value, "moto non supprimé");
        }
    }
}