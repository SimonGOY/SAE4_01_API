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
    public class TaillesControllerTests
    {
        private TaillesController controller;
        private BMWDBContext context;
        private IDataRepository<Taille> dataRepository;
        private Taille taille;
        private Mock<IDataRepository<Taille>> mockRepository;
        private TaillesController controller_mock;


        [TestInitialize]
        public void InitTest()
        {
            var builder = new DbContextOptionsBuilder<BMWDBContext>().UseNpgsql("Server=51.83.36.122; port=5432; Database=sa11; uid=sa11; password=BMW-S4; SearchPath=bmw;");
            context = new BMWDBContext(builder.Options);
            dataRepository = new TailleManager(context);
            controller = new TaillesController(dataRepository);
            mockRepository = new Mock<IDataRepository<Taille>>();
            controller_mock = new TaillesController(mockRepository.Object);

            taille = new Taille
            {
                IdTaille = 666666666,
                DescTaille = "Enorme",
                LibelleTaille = "XXXL"
            };
        }

        [TestMethod()]
        public void GetTaillesTest_RecuperationsOK()
        {
            //Arrange
            List<Taille> lesTais = context.Tailles.ToList();
            // Act
            var res = controller.GetTailles().Result;
            // Assert
            Assert.IsNotNull(res);
            CollectionAssert.AreEqual(lesTais, res.Value.ToList(), "Les listes de tailles ne sont pas identiques");
        }

        [TestMethod()]
        public void GetTailleTest_RecuperationOK()
        {
            // Arrange
            Taille? tai = context.Tailles.Find(1);
            // Act
            var res = controller.GetTaille(1).Result;
            // Assert
            Assert.IsNotNull(res.Value);
            Assert.AreEqual(tai, res.Value, "La taille n'est pas la même");
        }

        [TestMethod()]
        public void GetTailleTest_RecuperationFailed()
        {
            // Arrange
            Taille? tai = context.Tailles.Find(1);
            // Act
            var res = controller.GetTaille(2).Result;
            // Assert
            Assert.IsNotNull(res.Value);
            Assert.AreNotEqual(tai, res.Value, "La taille est la même");
        }

        [TestMethod()]
        public void GetTailleTest_EquipementNExistePas()
        {
            var res = controller.GetTaille(777777777).Result;
            // Assert
            Assert.IsNull(res.Result, "La taille existe");
            Assert.IsNull(res.Value, "La taille existe");
        }

        [TestMethod()]
        public void PostPutDelete()
        {
            PostTailleTest_CreationOK();
            PutTailleTest_ModificationOK();
            DeleteTailleTest_SuppressionOK();
        }

        
        public void PostTailleTest_CreationOK()
        {
            // Act
            var result = controller.PostTaille(taille).Result;
            // Assert
            var taiRecup = controller.GetTaille(taille.IdTaille).Result;
            taille.IdTaille = taiRecup.Value.IdTaille;
            Assert.AreEqual(taille, taiRecup.Value, "professionnel pas identiques");
        }

        
        public void PutTailleTest_ModificationOK()
        {
            // Arrange
            var taiIni = controller.GetTaille(taille.IdTaille).Result;
            taiIni.Value.DescTaille = "nom";

            // Act
            var res = controller.PutTaille(taille.IdTaille, taiIni.Value).Result;

            // Assert
            var taiMaj = controller.GetTaille(taille.IdTaille).Result;
            Assert.IsNotNull(taiMaj.Value);
            Assert.AreEqual(taiIni.Value, taiMaj.Value, "tailles pas identiques");
        }

        
        public void DeleteTailleTest_SuppressionOK()
        {
            // Act
            var taiSuppr = controller.GetTaille(taille.IdTaille).Result;
            _ = controller.DeleteTaille(taille.IdTaille).Result;

            // Assert
            var res = controller.GetTaille(taille.IdTaille).Result;
            Assert.IsNull(res.Value, "taille non supprimé");
        }

        // ---------------------------------------- Tests Moq ----------------------------------------

        [TestMethod()]
        public void Moq_GetTaillesTest_RecuperationOK()
        {
            // Arrange
            var tailles = new List<Taille>
                {
                    taille
                };
            mockRepository.Setup(x => x.GetAllAsync()).ReturnsAsync(tailles);
            // Act
            var res = controller_mock.GetTailles().Result;
            // Assert
            Assert.IsNotNull(res);
            Assert.IsNotNull(res.Value);
            Assert.AreEqual(tailles, res.Value as IEnumerable<Taille>, "La liste n'est pas le même");
        }

        [TestMethod()]
        public void Moq_GetTailleTest_RecuperationOK()
        {
            // Arrange
            mockRepository.Setup(x => x.GetByIdAsync(1)).ReturnsAsync(taille);

            // Act
            var res = controller_mock.GetTaille(1).Result;

            // Assert
            Assert.IsNotNull(res);
            Assert.IsNotNull(res.Value);

            Assert.AreEqual(taille, res.Value, "Les objets ne sont pas égaux");
        }


        [TestMethod()]
        public void Moq_GetTailleTest_RecuperationFailed()
        {
            // Act
            var res = controller_mock.GetTaille(0).Result;
            // Assert
            Assert.IsInstanceOfType(res.Result, typeof(NotFoundResult));
        }


        [TestMethod()]
        public void Moq_PostTailleTest()
        {
            // Act
            var actionResult = controller_mock.PostTaille(taille).Result;
            // Assert
            Assert.IsInstanceOfType(actionResult, typeof(ActionResult<Taille>), "Pas un ActionResult<Taille>");
            Assert.IsInstanceOfType(actionResult.Result, typeof(CreatedAtActionResult), "Pas un CreatedAtActionResult");
            var result = actionResult.Result as CreatedAtActionResult;
            Assert.IsInstanceOfType(result.Value, typeof(Taille), "Pas une Taille");
            taille.IdTaille = ((Taille)result.Value).IdTaille;
            Assert.AreEqual(taille, (Taille)result.Value, "Taille pas identiques");
        }

        [TestMethod]
        public void Moq_DeleteTailleTest()
        {
            // Arrange
            mockRepository.Setup(x => x.GetByIdAsync(1).Result).Returns(taille);

            // Act
            var actionResult = controller_mock.DeleteTaille(1).Result;
            // Assert
            Assert.IsInstanceOfType(actionResult, typeof(NoContentResult), "Pas un NoContentResult");
        }

        [TestMethod]
        public void Moq_PutTailleTest()
        {
            // Arrange
            mockRepository.Setup(x => x.GetByIdAsync(1).Result).Returns(taille);
            var init = controller_mock.GetTaille(1).Result;
            init.Value.DescTaille = "nom";


            // Act
            var res = controller_mock.PutTaille(taille.IdTaille, init.Value).Result;
            var maj = controller_mock.GetTaille(1).Result;

            // Assert
            Assert.IsNotNull(maj.Value);
            Assert.AreEqual(init.Value, maj.Value, "Valeurs pas identiques");
        }
    }
}