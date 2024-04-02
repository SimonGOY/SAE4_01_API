using Microsoft.AspNetCore.Mvc;
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
    public class CollectionsControllerTests
    {
        private CollectionsController controller;
        private BMWDBContext context;
        private IDataRepository<Collection> dataRepository;
        private Collection collec;

        [TestInitialize]
        public void InitTest()
        {
            var builder = new DbContextOptionsBuilder<BMWDBContext>().UseNpgsql("Server=51.83.36.122; port=5432; Database=sa11; uid=sa11; password=BMW-S4; SearchPath=bmw;");
            context = new BMWDBContext(builder.Options);
            dataRepository = new CollectionManager(context);
            controller = new CollectionsController(dataRepository);

            collec = new Collection
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
            CollectionAssert.AreEqual(lesCollecs, res.Value.ToList(), "Les listes de collec ne sont pas identiques");
        }

        [TestMethod()]
        public void GetCollectionTest_RecuperationOK()
        {
            // Arrange
            Collection? col = context.Collections.Find(1);
            // Act
            var res = controller.GetCollection(1).Result;
            // Assert
            Assert.IsNotNull(res);
            Assert.AreEqual(col, res.Value, "La collec n'est pas la même");
        }


        [TestMethod()]
        public void GetCollectionTest_RecuperationFailed()
        {
            // Arrange
            Collection? clt = context.Collections.Find(1);
            // Act
            var res = controller.GetCollection(2).Result;
            // Assert
            Assert.IsNotNull(res);
            Assert.AreNotEqual(clt, res.Value, "La collec est la même");
        }

        [TestMethod()]
        public void GetCollectionTest_CollecNExistePas()
        {
            var res = controller.GetCollection(777777777).Result;
            // Assert
            Assert.IsNull(res.Result, "La collec existe");
            Assert.IsNull(res.Value, "La collec existe");
        }

        [TestMethod()]
        public void PostCollectionTest_CreationOK()
        {
            // Act
            var result = controller.PostCollection(collec).Result;
            // Assert
            var colRecup = controller.GetCollection(collec.IdCollection).Result;
            collec.IdCollection = colRecup.Value.IdCollection;
            Assert.AreEqual(collec, colRecup.Value, "Clients pas identiques");
        }

        /*[TestMethod()]
        public void PutCollectionTest_ModificationOK()
        {
            // Arrange
            var colIni = controller.GetCollection(collec.IdCollection).Result;
            colIni.Value.NomCollection = "COLLEC CLONE N°" + 2;

            // Act
            var res = controller.PutCollection(collec.IdCollection, colIni.Value).Result;

            // Assert
            var cltMaj = controller.GetCollection(collec.IdCollection).Result;
            Assert.IsNotNull(cltMaj.Value);
            Assert.AreEqual(colIni.Value, cltMaj.Value, "Collec pas identiques");
        }*/

        [TestMethod()]
        public void ZDeleteCollectionTest_SuppressionOK()
        {
            // Act
            var colSuppr = controller.GetCollection(collec.IdCollection).Result;
            _ = controller.DeleteCollection(collec.IdCollection).Result;

            // Assert
            var res = controller.GetCollection(collec.IdCollection).Result;
            Assert.IsNull(res.Value, "collec non supprimé");
        }
    }
}