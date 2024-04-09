using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SAE_4._01.Models.DataManager;
using SAE_4._01.Models.EntityFramework;
using SAE_4._01.Models.Repository;

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
        public void PostPutDeleteTest()
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

        // ---------------------------------------- Tests Moq ----------------------------------------

        [TestMethod()]
        public void Moq_GetMotoDisponibles_RecuperationOK()
        {
            // Arrange
            var motos = new List<MotoDisponible>
                {
                    motoDispo
                };
            mockRepository.Setup(x => x.GetAllAsync()).ReturnsAsync(motos);
            // Act
            var res = controller_mock.GetMotoDisponibles().Result;
            // Assert
            Assert.IsNotNull(res);
            Assert.IsNotNull(res.Value);
            Assert.AreEqual(motos, res.Value as IEnumerable<MotoDisponible>, "La liste n'est pas le même");
        }

        [TestMethod()]
        public void Moq_GetMotoDisponible_RecuperationOK()
        {
            // Arrange
            mockRepository.Setup(x => x.GetByIdAsync(1)).ReturnsAsync(motoDispo);

            // Act
            var res = controller_mock.GetMotoDisponible(1).Result;

            // Assert
            Assert.IsNotNull(res);
            Assert.IsNotNull(res.Value);

            Assert.AreEqual(motoDispo, res.Value, "Les objets ne sont pas égaux");
        }


        [TestMethod()]
        public void Moq_GetMotoDisponible_RecuperationFailed()
        {
            // Act
            var res = controller_mock.GetMotoDisponible(0).Result;
            // Assert
            Assert.IsInstanceOfType(res.Result, typeof(NotFoundResult));
        }

        [TestMethod()]
        public void Moq_PostMotoDisponibleTest()
        {
            // Act
            var actionResult = controller_mock.PostMotoDisponible(motoDispo).Result;
            // Assert
            Assert.IsInstanceOfType(actionResult, typeof(ActionResult<MotoDisponible>), "Pas un ActionResult<MotoDisponible>");
            Assert.IsInstanceOfType(actionResult.Result, typeof(CreatedAtActionResult), "Pas un CreatedAtActionResult");
            var result = actionResult.Result as CreatedAtActionResult;
            Assert.IsInstanceOfType(result.Value, typeof(MotoDisponible), "Pas une MotoDisponible");
            motoDispo.IdMotoDisponible = ((MotoDisponible)result.Value).IdMotoDisponible;
            Assert.AreEqual(motoDispo, (MotoDisponible)result.Value, "MotoDisponible pas identiques");
        }

        [TestMethod]
        public void Moq_DeleteMotoDisponibleTest()
        {
            // Arrange
            mockRepository.Setup(x => x.GetByIdAsync(1).Result).Returns(motoDispo);

            // Act
            var actionResult = controller_mock.DeleteMotoDisponible(1).Result;
            // Assert
            Assert.IsInstanceOfType(actionResult, typeof(NoContentResult), "Pas un NoContentResult"); // Test du type de retour
        }

        [TestMethod]
        public void Moq_PutPackTest()
        {
            // Arrange
            mockRepository.Setup(x => x.GetByIdAsync(1).Result).Returns(motoDispo);
            var init = controller_mock.GetMotoDisponible(1).Result;
            init.Value.PrixMotoDisponible = 4.50f;


            // Act
            var res = controller_mock.PutMotoDisponible(motoDispo.IdMotoDisponible, init.Value).Result;
            var maj = controller_mock.GetMotoDisponible(1).Result;

            // Assert

            Assert.IsNotNull(maj.Value);
            Assert.AreEqual(init.Value, maj.Value, "Valeurs pas identiques");
        }
    }
}