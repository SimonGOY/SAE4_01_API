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
    public class CategorieCaracteristiquesControllerTests
    {
        private CategorieCaracteristiquesController controller;
        private BMWDBContext context;
        private IDataRepository<CategorieCaracteristique> dataRepository;
        private CategorieCaracteristique categorieCaracteristique;
        private Mock<IDataRepository<CategorieCaracteristique>> mockRepository;
        private CategorieCaracteristiquesController controller_mock;

        [TestInitialize()]
        public void InitTest()
        {
            var builder = new DbContextOptionsBuilder<BMWDBContext>().UseNpgsql("Server=51.83.36.122; port=5432; Database=sa11; uid=sa11; password=BMW-S4; SearchPath=bmw;");
            context = new BMWDBContext(builder.Options);
            dataRepository = new CategorieCaracteristiqueManager(context);
            controller = new CategorieCaracteristiquesController(dataRepository);
            mockRepository = new Mock<IDataRepository<CategorieCaracteristique>>();
            controller_mock = new CategorieCaracteristiquesController(mockRepository.Object);

            categorieCaracteristique = new CategorieCaracteristique
            {
                IdCatCaracteristique = 666666666,
                NomCatCaracteristique = "J'ai pas d'idée de blague",
            };
        }

        [TestMethod()]
        public void GetCategorieCaracteristiquesTest_RecuperationsOK()
        {
            //Arrange
            List<CategorieCaracteristique> lesCatCar = context.CategorieCaracteristiques.ToList();
            // Act
            var res = controller.GetCategorieCaracteristiques().Result;
            // Assert
            Assert.IsNotNull(res);
            CollectionAssert.AreEqual(lesCatCar, res.Value.ToList(), "Les listes de catégories caractéristiques ne sont pas identiques");
        }

        [TestMethod()]
        public void GetCategorieCaracteristiqueTest_RecuperationOK()
        {
            // Arrange
            CategorieCaracteristique? cat = context.CategorieCaracteristiques.Find(1);
            // Act
            var res = controller.GetCategorieCaracteristique(1).Result;
            // Assert
            Assert.IsNotNull(res.Value);
            Assert.AreEqual(cat, res.Value, "La catégorie accessoire n'est pas la même");
        }

        [TestMethod()]
        public void GetCategorieCaracteristiqueAccessoireTest_RecuperationFailed()
        {
            // Arrange
            CategorieCaracteristique? cat = context.CategorieCaracteristiques.Find(1);
            // Act
            var res = controller.GetCategorieCaracteristique(2).Result;
            // Assert
            Assert.IsNotNull(res.Value);
            Assert.AreNotEqual(cat, res.Value, "La categorie est la même");
        }

        [TestMethod()]
        public void GetCategorieCaracteristiqueTest_CategorieCaracteristiqueNExistePas()
        {
            var res = controller.GetCategorieCaracteristique(777777777).Result;
            // Assert
            Assert.IsNull(res.Result, "La categorie existe");
            Assert.IsNull(res.Value, "La categore existe");
        }

        [TestMethod()]
        public void PostDel()
        {
            PostCategorieCaracteristiqueTest_CreationOK();
            //Ne peut pas etre modifie du fait de sa configuration
            //PutCategorieAccessoireTest_ModificationOK();
            DeleteCategorieCaracteristiqueTest_SuppressionOK();
        }

        public void PostCategorieCaracteristiqueTest_CreationOK()
        {
            // Act
            var result = controller.PostCategorieCaracteristique(categorieCaracteristique).Result;
            // Assert
            var catRecup = controller.GetCategorieCaracteristique(categorieCaracteristique.IdCatCaracteristique).Result;
            categorieCaracteristique.IdCatCaracteristique = catRecup.Value.IdCatCaracteristique;
            Assert.AreEqual(categorieCaracteristique, catRecup.Value, "Catégories accessoires pas identiques"); ;
        }

        public void DeleteCategorieCaracteristiqueTest_SuppressionOK()
        {
            // Act
            var catSuppr = controller.GetCategorieCaracteristique(categorieCaracteristique.IdCatCaracteristique).Result;
            _ = controller.DeleteCategorieCaracteristique(catSuppr.Value.IdCatCaracteristique).Result;

            // Assert
            var res = controller.GetCategorieCaracteristique(categorieCaracteristique.IdCatCaracteristique).Result;
            Assert.IsNull(res.Value, "categorie accessoire non supprimé");
        }
        // ---------------------------------------- Tests Moq ----------------------------------------

        [TestMethod()]
        public void Moq_GetCategorieCaracteristiquesTest_RecuperationOK()
        {
            // Arrange
            var categorieCaracteristiques = new List<CategorieCaracteristique>
                {
                    categorieCaracteristique
                };
            mockRepository.Setup(x => x.GetAllAsync()).ReturnsAsync(categorieCaracteristiques);

            // Act
            var res = controller_mock.GetCategorieCaracteristiques().Result;
            // Assert
            Assert.IsNotNull(res);
            Assert.IsNotNull(res.Value);
            Assert.AreEqual(categorieCaracteristiques, res.Value as IEnumerable<CategorieCaracteristique>, "La liste n'est pas le même");
        }

        [TestMethod()]
        public void Moq_GetCategorieCaracteristiqueTest_RecuperationOK()
        {
            // Arrange
            mockRepository.Setup(x => x.GetByIdAsync(1).Result).Returns(categorieCaracteristique);
            // Act
            var res = controller_mock.GetCategorieCaracteristique(1).Result;
            // Assert
            Assert.IsNotNull(res);
            Assert.IsNotNull(res.Value);
            Assert.AreEqual(categorieCaracteristique, res.Value as CategorieCaracteristique, "La CategorieCaracteristique n'est pas le même");
        }

    }
}