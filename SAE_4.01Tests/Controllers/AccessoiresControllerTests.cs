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
    public class AccessoiresControllerTests
    {
        private AccessoiresController controller;
        private BMWDBContext context;
        private IDataRepository<Accessoire> dataRepository;
        private Accessoire accessoire;
        private Accessoire accessoire_bis;
        private Mock<IDataRepository<Accessoire>> mockRepository;
        private AccessoiresController controller_mock;

        [TestInitialize]
        public void InitTest()
        {
            var builder = new DbContextOptionsBuilder<BMWDBContext>().UseNpgsql("Server=51.83.36.122; port=5432; Database=sa11; uid=sa11; password=BMW-S4; SearchPath=bmw;");
            context = new BMWDBContext(builder.Options);
            dataRepository = new AccessoireManager(context);
            controller = new AccessoiresController(dataRepository);
            mockRepository = new Mock<IDataRepository<Accessoire>>();
            controller_mock= new AccessoiresController(mockRepository.Object);

            accessoire = new Accessoire
            {
                IdAccessoire = 666666666,
                IdMoto = 1,
                IdCatAcc = 1,
                NomAccessoire = "Piece Test",
                PrixAccessoire = 200,
                DetailAccessoire ="C'est une pièce de test quoi",
                PhotoAccessoire = "latavernedutesteur.files.wordpress.com/2017/11/testss.png"
            };
        }

        [TestMethod()]
        public void GetAccessoiresTest_RecuperationsOK()
        {
            //Arrange
            List<Accessoire> lesAccessoires = context.Accessoires.ToList();
            // Act
            var res = controller.GetAccessoires().Result;
            // Assert
            Assert.IsNotNull(res);
            CollectionAssert.AreEqual(lesAccessoires, res.Value.ToList(), "Les listes d'accessoires ne sont pas identiques");
        }

        [TestMethod()]
        public void GetAccessoireTest_RecuperationOK()
        {
            // Arrange
            Accessoire? acc = context.Accessoires.Find(1);
            // Act
            var res = controller.GetAccessoire(1).Result;
            // Assert
            Assert.IsNotNull(res.Value);
            Assert.AreEqual(acc, res.Value, "L'accessoire n'est pas le même");
        }

        [TestMethod()]
        public void GetAccessoireTest_RecuperationFailed()
        {
            // Arrange
            Accessoire? acc = context.Accessoires.Find(1);
            // Act
            var res = controller.GetAccessoire(2).Result;
            // Assert
            Assert.IsNotNull(res.Value);
            Assert.AreNotEqual(acc, res.Value, "L'accessoire est le même");
        }

        [TestMethod()]
        public void GetAccessoireTest_ClientNExistePas()
        {
            var res = controller.GetAccessoire(777777777).Result;
            // Assert
            Assert.IsNull(res.Result, "L'accessoire existe");
            Assert.IsNull(res.Value, "L'accessoire existe");
        }

        [TestMethod()]
        public void PostPutDeleteTest()
        {
            PostAccessoireTest_CreationOK();
            PutAccessoireTest_ModificationOK();
            DeleteAccessoireTest_SuppressionOK();
        }

        public void PostAccessoireTest_CreationOK()
        {

            //Act
            var result = controller.PostAccessoire(accessoire).Result;
            // Assert
            var accRecup = controller.GetAccessoire(accessoire.IdAccessoire).Result;
            accessoire.IdAccessoire = accRecup.Value.IdAccessoire;
            Assert.AreEqual(accessoire, accRecup.Value, "Accessoires pas identiques");
        }

        public void PutAccessoireTest_ModificationOK()
        {
            // Arrange
            var accIni = controller.GetAccessoire(accessoire.IdAccessoire).Result;
            accIni.Value.DetailAccessoire = "Détails";

            // Act
            var res = controller.PutAccessoire(accessoire.IdAccessoire, accIni.Value).Result;

            // Assert
            var accMaj = controller.GetAccessoire(accessoire.IdAccessoire).Result;
            Assert.IsNotNull(accMaj.Value);
            Assert.AreEqual(accIni.Value, accMaj.Value, "Accessoire pas identiques");
        }

        public void DeleteAccessoireTest_SuppressionOK()
        {

            // Act
            var accSuppr = controller.GetAccessoire(accessoire.IdAccessoire).Result;
            _ = controller.DeleteAccessoire(accSuppr.Value.IdAccessoire).Result;

            // Assert
            var res = controller.GetAccessoire(accessoire.IdAccessoire).Result;
            Assert.IsNull(res.Value, "accessoire non supprimé");
        }

        // ---------------------------------------- Tests Moq ----------------------------------------

        [TestMethod()]
        public void Moq_GetByIdClientTest_RecuperationOK()
        {
            // Arrange
            var accessoires = new List<Accessoire>
                {
                    accessoire
                };
            mockRepository.Setup(x => x.GetAllAsync()).ReturnsAsync(accessoires);

            // Act
            var res = controller_mock.GetAccessoires().Result;
            // Assert
            Assert.IsNotNull(res);
            Assert.IsNotNull(res.Value);
            Assert.AreEqual(accessoires, res.Value as IEnumerable<Accessoire>, "La liste n'est pas le même");
        }

        [TestMethod()]
        public void Moq_GetAccessoireTest_RecuperationOK()
        {
            // Arrange
            mockRepository.Setup(x => x.GetByIdAsync(1).Result).Returns(accessoire);
            // Act
            var res = controller_mock.GetAccessoire(1).Result;
            // Assert
            Assert.IsNotNull(res);
            Assert.IsNotNull(res.Value);
            Assert.AreEqual(accessoire, res.Value as Accessoire, "Le concessionnaire n'est pas le même");
        }

        [TestMethod()]
        public void Moq_GetAccessoireTest_RecuperationFailed()
        {
            // Act
            var res = controller_mock.GetAccessoire(0).Result;
            // Assert
            Assert.IsInstanceOfType(res.Result, typeof(NotFoundResult));
        }

        


        [TestMethod()]
        public void Moq_GetByIdMotoTest_RecuperationOK()
        {
            // Arrange
            var accessoires = new List<Accessoire>
                {
                    accessoire
                };
            mockRepository.Setup(x => x.GetByIdMotoAsync(1)).ReturnsAsync(accessoires);
            // Act
            var res = controller_mock.GetByIdMoto(1).Result;
            // Assert
            Assert.IsNotNull(res);
            Assert.IsNotNull(res.Value);
            Assert.AreEqual(accessoires, res.Value as IEnumerable<Accessoire>, "La liste n'est pas le même");
        }


        [TestMethod()]
        public void Moq_PostAccessoireTest()
        {
        // Act
        var actionResult = controller_mock.PostAccessoire(accessoire).Result;
        // Assert
        Assert.IsInstanceOfType(actionResult, typeof(ActionResult<Accessoire>), "Pas un ActionResult<Accessoire>");
        Assert.IsInstanceOfType(actionResult.Result, typeof(CreatedAtActionResult), "Pas un CreatedAtActionResult");
        var result = actionResult.Result as CreatedAtActionResult;
        Assert.IsInstanceOfType(result.Value, typeof(Accessoire), "Pas un Accessoire");
        accessoire.IdAccessoire = ((Accessoire) result.Value).IdAccessoire;
        Assert.AreEqual(accessoire, (Accessoire) result.Value, "Accessoires pas identiques");
        }

    [TestMethod]
        public void Moq_DeleteAccessoireTest_RecuperationOK()
        {
            // Arrange
            mockRepository.Setup(x => x.GetByIdAsync(1).Result).Returns(accessoire);

            // Act
            var actionResult = controller_mock.DeleteAccessoire(1).Result;
            // Assert
            Assert.IsInstanceOfType(actionResult, typeof(NoContentResult), "Pas un NoContentResult"); // Test du type de retour
        }
    }
}