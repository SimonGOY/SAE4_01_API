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
    public class CategorieEquipementsControllerTests
    {

        private CategorieEquipementsController controller;
        private BMWDBContext context;
        private IDataRepository<CategorieEquipement> dataRepository;
        private CategorieEquipement categorieEquipement;
        private Mock<IDataRepository<CategorieEquipement>> mockRepository;
        private CategorieEquipementsController controller_mock;

        [TestInitialize()]
        public void InitTest()
        {
            var builder = new DbContextOptionsBuilder<BMWDBContext>().UseNpgsql("Server=51.83.36.122; port=5432; Database=sa11; uid=sa11; password=BMW-S4; SearchPath=bmw;");
            context = new BMWDBContext(builder.Options);
            dataRepository = new CategorieEquipementManager(context);
            controller = new CategorieEquipementsController(dataRepository);
            mockRepository = new Mock<IDataRepository<CategorieEquipement>>();
            controller_mock = new CategorieEquipementsController(mockRepository.Object);

            categorieEquipement = new CategorieEquipement
            {
                IdCatEquipement = 666666666,
                LibelleCatEquipement = "J'ai pas d'idée de blague",
                EquipementCategorieEquipement = null,
            };
        }

        [TestMethod()]
        public void GetCategorieEquipementsTest_RecuperationsOK()
        {
            //Arrange
            List<CategorieEquipement> lesCatCar = context.CategorieEquipements.ToList();
            // Act
            var res = controller.GetCategorieEquipements().Result;
            // Assert
            Assert.IsNotNull(res);
            CollectionAssert.AreEqual(lesCatCar, res.Value.ToList(), "Les listes de catégories caractéristiques ne sont pas identiques");
        }

        [TestMethod()]
        public void GetCategorieEquipementTest_RecuperationOK()
        {
            // Arrange
            CategorieEquipement? cat = context.CategorieEquipements.Find(1);
            // Act
            var res = controller.GetCategorieEquipement(1).Result;
            // Assert
            Assert.IsNotNull(res.Value);
            Assert.AreEqual(cat, res.Value, "La catégorie accessoire n'est pas la même");
        }

        [TestMethod()]
        public void GetCategorieEquipementAccessoireTest_RecuperationFailed()
        {
            // Arrange
            CategorieEquipement? cat = context.CategorieEquipements.Find(1);
            // Act
            var res = controller.GetCategorieEquipement(2).Result;
            // Assert
            Assert.IsNotNull(res.Value);
            Assert.AreNotEqual(cat, res.Value, "La categorie est la même");
        }

        [TestMethod()]
        public void GetCategorieEquipementTest_CategorieEquipementNExistePas()
        {
            var res = controller.GetCategorieEquipement(777777777).Result;
            // Assert
            Assert.IsNull(res.Result, "La categorie existe");
            Assert.IsNull(res.Value, "La categore existe");
        }

        [TestMethod()]
        public void PostDel()
        {
            PostCategorieEquipementTest_CreationOK();
            //Ne peut pas etre modifie du fait de sa configuration
            DeleteCategorieEquipementTest_SuppressionOK();
        }

        public void PostCategorieEquipementTest_CreationOK()
        {
            // Act
            var result = controller.PostCategorieEquipement(categorieEquipement).Result;
            // Assert
            var catRecup = controller.GetCategorieEquipement(categorieEquipement.IdCatEquipement).Result;
            categorieEquipement.IdCatEquipement = catRecup.Value.IdCatEquipement;
            Assert.AreEqual(categorieEquipement, catRecup.Value, "Catégories accessoires pas identiques"); ;
        }

        public void DeleteCategorieEquipementTest_SuppressionOK()
        {
            // Act
            var catSuppr = controller.GetCategorieEquipement(categorieEquipement.IdCatEquipement).Result;
            _ = controller.DeleteCategorieEquipement(catSuppr.Value.IdCatEquipement).Result;

            // Assert
            var res = controller.GetCategorieEquipement(categorieEquipement.IdCatEquipement).Result;
            Assert.IsNull(res.Value, "categorie accessoire non supprimé");
        }
        // ---------------------------------------- Tests Moq ----------------------------------------

        [TestMethod()]
        public void Moq_GetCategorieEquipementsTest_RecuperationOK()
        {
            // Arrange
            var categorieCaracteristiques = new List<CategorieEquipement>
                {
                    categorieEquipement
                };
            mockRepository.Setup(x => x.GetAllAsync()).ReturnsAsync(categorieCaracteristiques);

            // Act
            var res = controller_mock.GetCategorieEquipements().Result;
            // Assert
            Assert.IsNotNull(res);
            Assert.IsNotNull(res.Value);
            Assert.AreEqual(categorieCaracteristiques, res.Value as IEnumerable<CategorieEquipement>, "La liste n'est pas le même");
        }

        [TestMethod()]
        public void Moq_GetCategorieEquipementTest_RecuperationOK()
        {
            // Arrange
            mockRepository.Setup(x => x.GetByIdAsync(1).Result).Returns(categorieEquipement);
            // Act
            var res = controller_mock.GetCategorieEquipement(1).Result;
            // Assert
            Assert.IsNotNull(res);
            Assert.IsNotNull(res.Value);
            Assert.AreEqual(categorieEquipement, res.Value as CategorieEquipement, "La CategorieEquipement n'est pas le même");
        }

        [TestMethod()]
        public void Moq_GetCategorieEquipementTest_RecuperationFailed()
        {
            // Act
            var res = controller_mock.GetCategorieEquipement(0).Result;
            // Assert
            Assert.IsInstanceOfType(res.Result, typeof(NotFoundResult));
        }

        [TestMethod()]
        public void Moq_PostCategorieEquipementTest()
        {
            // Act
            var actionResult = controller_mock.PostCategorieEquipement(categorieEquipement).Result;
            // Assert
            Assert.IsInstanceOfType(actionResult, typeof(ActionResult<CategorieEquipement>), "Pas un ActionResult<CategorieEquipement>");
            Assert.IsInstanceOfType(actionResult.Result, typeof(CreatedAtActionResult), "Pas un CreatedAtActionResult");
            var result = actionResult.Result as CreatedAtActionResult;
            Assert.IsInstanceOfType(result.Value, typeof(CategorieEquipement), "Pas une CategorieEquipement");
            categorieEquipement.IdCatEquipement = ((CategorieEquipement)result.Value).IdCatEquipement;
            Assert.AreEqual(categorieEquipement, (CategorieEquipement)result.Value, "CategorieEquipement pas identiques");
        }

        [TestMethod]
        public void Moq_DeleteCategorieEquipementTest()
        {
            // Arrange
            mockRepository.Setup(x => x.GetByIdAsync(1).Result).Returns(categorieEquipement);

            // Act
            var actionResult = controller_mock.DeleteCategorieEquipement(1).Result;
            // Assert
            Assert.IsInstanceOfType(actionResult, typeof(NoContentResult), "Pas un NoContentResult"); // Test du type de retour
        }
    }
}