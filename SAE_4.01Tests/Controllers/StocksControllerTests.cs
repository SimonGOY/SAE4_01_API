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
    public class StocksControllerTests
    {
        private StocksController controller;
        private BMWDBContext context;
        private IDataRepository<Stock> dataRepository;
        private Stock stock;
        private Mock<IDataRepository<Stock>> mockRepository;
        private StocksController controller_mock;

        [TestInitialize]
        public void InitTest()
        {
            var builder = new DbContextOptionsBuilder<BMWDBContext>().UseNpgsql("Server=51.83.36.122; port=5432; Database=sa11; uid=sa11; password=BMW-S4; SearchPath=bmw;");
            context = new BMWDBContext(builder.Options);
            dataRepository = new StockManager(context);
            controller = new StocksController(dataRepository);
            mockRepository = new Mock<IDataRepository<Stock>>();
            controller_mock = new StocksController(mockRepository.Object);

            stock = new Stock
            {
                IdEquipement = 1,
                IdTaille = 2,
                IdColoris = 23,
                Quantite = 1,
            };
        }

        [TestMethod()]
        public void GetStocksTest_RecuperationsOK()
        {
            //Arrange
            List<Stock> lesStos = context.Stocks.ToList();
            // Act
            var res = controller.GetStocks().Result;
            // Assert
            Assert.IsNotNull(res);
            CollectionAssert.AreEqual(lesStos, res.Value.ToList(), "Les listes de stocks ne sont pas identiques");
        }

        [TestMethod()]
        public void GetByIdsTest()
        {
            // Arrange
            var sto = context.Stocks.Find(1, 17, 1);
            // Act
            var res = controller.GetByIds(1, 1, 17).Result;
            // Assert
            Assert.IsNotNull(res.Value);
            Assert.AreEqual(sto, res.Value, "Le specifie n'est pas le même");
        }

        [TestMethod()]
        public void GetByIdsTest_RecuperationFailed()
        {
            // Arrange
            var spe = controller.GetByIds(1, 1, 17).Result;
            // Act
            var res = controller.GetByIds(1, 1, 18).Result;
            // Assert
            Assert.IsNotNull(res.Value);
            Assert.AreNotEqual(spe, res.Value, "Le specifie est le même");
        }

        [TestMethod()]
        public void GetByIdsTest_estInclusNExistePas()
        {
            var res = controller.GetByIds(1, 777777777, 1).Result;
            // Assert
            Assert.IsNull(res.Result, "Le specifie existe");
            Assert.IsNull(res.Value, "Le specifie existe");
        }

        [TestMethod()]
        public void PostPutDelete()
        {
            PostStockTest_CreationOK();
            PutStockTest_ModificationOK();
            DeleteStockTest_SuppressionOK();
        }

        public void PostStockTest_CreationOK()
        {
            // Act
            var result = controller.PostStock(stock).Result;
            // Assert
            var stoRecup = controller.GetByIds(stock.IdEquipement, stock.IdTaille, stock.IdColoris).Result;
            stock.IdEquipement = stoRecup.Value.IdEquipement;
            stock.IdTaille = stoRecup.Value.IdTaille;
            Assert.AreEqual(stock, stoRecup.Value, "stock pas identiques");
        }

        public void PutStockTest_ModificationOK()
        {
            // Arrange
            var stoIni = controller.GetByIds(stock.IdEquipement, stock.IdTaille, stock.IdColoris).Result;
            stoIni.Value.Quantite = 2;

            // Act
            var res = controller.PutStock(stock.IdEquipement, stock.IdTaille, stock.IdColoris, stoIni.Value).Result;

            // Assert
            var stoMaj = controller.GetByIds(stock.IdEquipement, stock.IdTaille, stock.IdColoris).Result;
            Assert.IsNotNull(stoMaj.Value);
            Assert.AreEqual(stoIni.Value, stoMaj.Value, "stocks pas identiques");
        }

        public void DeleteStockTest_SuppressionOK()
        {
            // Act
            var stoSuppr = controller.GetByIds(stock.IdEquipement, stock.IdTaille, stock.IdColoris).Result;
            _ = controller.DeleteStock(stock.IdEquipement, stock.IdTaille, stock.IdColoris).Result;

            // Assert
            var res = controller.GetByIds(stock.IdEquipement, stock.IdTaille, stock.IdColoris).Result;
            Assert.IsNull(res.Value, "specifie non supprimé");
        }
    }
}