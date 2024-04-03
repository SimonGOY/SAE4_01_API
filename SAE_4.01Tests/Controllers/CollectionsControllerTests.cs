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
    public class CollectionsControllerTests
    {
        private CollectionsController controller;
        private BMWDBContext context;
        private IDataRepository<Collection> dataRepository;
        private Collection collection;

        [TestInitialize]
        public void InitTest()
        {
            var builder = new DbContextOptionsBuilder<BMWDBContext>().UseNpgsql("Server=51.83.36.122; port=5432; Database=sa11; uid=sa11; password=BMW-S4; SearchPath=bmw;");
            context = new BMWDBContext(builder.Options);
            dataRepository = new CollectionManager(context);
            controller = new CollectionsController(dataRepository);

            collection = new Collection
            {
                IdCollection = 666666666,
                NomCollection = "Printemps été 2024"
            };
        }

        [TestMethod()]
        public void GetCollectionsTest_RécupérationsOK()
        {
            //Arrange
            List<Collection> lesCollecs = context.Collections.ToList();
            // Act
            var res = controller.GetCollections().Result;
            // Assert
            Assert.IsNotNull(res);
            CollectionAssert.AreEqual(lesCollecs, res.Value.ToList(), "Les listes de collection ne sont pas identiques");
        }

        [TestMethod()]
        public void GetCollectionTest_RecuperationOK()
        {
            // Arrange
            Collection? col = context.Collections.Find(1);
            // Act
            var res = controller.GetCollection(1).Result;
            // Assert
            Assert.IsNotNull(res.Value);
            Assert.AreEqual(col, res.Value, "La collection n'est pas la même");
        }


        [TestMethod()]
        public void GetCollectionTest_RecuperationFailed()
        {
            // Arrange
            Collection? clt = context.Collections.Find(1);
            // Act
            var res = controller.GetCollection(2).Result;
            // Assert
            Assert.IsNotNull(res.Value);
            Assert.AreNotEqual(clt, res.Value, "La collection est la même");
        }

        [TestMethod()]
        public void GetCollectionTest_CollecNExistePas()
        {
            var res = controller.GetCollection(777777777).Result;
            // Assert
            Assert.IsNull(res.Result, "La collection existe");
            Assert.IsNull(res.Value, "La collection existe");
        }

        [TestMethod()]
        public void __PostCollectionTest_CreationOK()
        {
            // Act
            var result = controller.PostCollection(collection).Result;
            // Assert
            var colRecup = controller.GetCollection(collection.IdCollection).Result;
            collection.IdCollection = colRecup.Value.IdCollection;
            Assert.AreEqual(collection, colRecup.Value, "Clients pas identiques");
        }

        [TestMethod()]
        public void __PutCollectionTest_ModificationOK()
        {
            // Arrange
            var colIni = controller.GetCollection(collection.IdCollection).Result;
            colIni.Value.NomCollection = "COLLEC CLONE N°" + 2;

            // Act
            var res = controller.PutCollection(collection.IdCollection, colIni.Value).Result;

            // Assert
            var cltMaj = controller.GetCollection(collection.IdCollection).Result;
            Assert.IsNotNull(cltMaj.Value);
            Assert.AreEqual(colIni.Value, cltMaj.Value, "Collec pas identiques");
        }

        [TestMethod()]
        public void DeleteCollectionTest_SuppressionOK()
        {
            // Act
            var colSuppr = controller.GetCollection(collection.IdCollection).Result;
            _ = controller.DeleteCollection(collection.IdCollection).Result;

            // Assert
            var res = controller.GetCollection(collection.IdCollection).Result;
            Assert.IsNull(res.Value, "collection non supprimé");
        }

        // ---------------------------------------- Tests Moq ----------------------------------------

        [TestMethod()]
        public void Moq_GetCollectionTest_RecuperationOK()
        {
            // Arrange
            var mockRepository = new Mock<IDataRepository<Collection>>();
            mockRepository.Setup(x => x.GetByIdAsync(1).Result).Returns(collection);

            var controller = new CollectionsController(mockRepository.Object);
            // Act
            var res = controller.GetCollection(1).Result;
            // Assert
            Assert.IsNotNull(res);
            Assert.IsNotNull(res.Value);
            Assert.AreEqual(collection, res.Value as Collection, "La collection n'est pas le même");
        }
    }
}