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
            Assert.AreEqual(sto, res.Value, "Le stock n'est pas le même");
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
            Assert.AreNotEqual(spe, res.Value, "Le stock est le même");
        }

        [TestMethod()]
        public void GetByIdsTest_estInclusNExistePas()
        {
            var res = controller.GetByIds(1, 777777777, 1).Result;
            // Assert
            Assert.IsNull(res.Result, "Le stock existe");
            Assert.IsNull(res.Value, "Le stock existe");
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
            Assert.IsNull(res.Value, "stock non supprimé");
        }

        // ---------------------------------------- Tests Moq ----------------------------------------

        [TestMethod()]
        public void Moq_GetSpecifiesTest_RecuperationOK()
        {
            // Arrange
            var stocks = new List<Stock>
                {
                    stock
                };
            mockRepository.Setup(x => x.GetAllAsync()).ReturnsAsync(stocks);
            // Act
            var res = controller_mock.GetStocks().Result;
            // Assert
            Assert.IsNotNull(res);
            Assert.IsNotNull(res.Value);
            Assert.AreEqual(stocks, res.Value as IEnumerable<Stock>, "La liste n'est pas le même");
        }

        [TestMethod()]
        public void Moq_GetProfessionnelTest_RecuperationOK()
        {
            // Arrange
            mockRepository.Setup(x => x.GetBy3CompositeKeysAsync(1, 1, 1)).ReturnsAsync(stock);

            // Act
            var res = controller_mock.GetByIds(1, 1, 1).Result;

            // Assert
            Assert.IsNotNull(res);
            Assert.IsNotNull(res.Value);

            Assert.AreEqual(stock, res.Value, "Les objets ne sont pas égaux");
        }


        [TestMethod()]
        public void Moq_GetProfessionnelTest_RecuperationFailed()
        {
            // Act
            var res = controller_mock.GetByIds(0, 0, 0).Result;
            // Assert
            Assert.IsInstanceOfType(res.Result, typeof(NotFoundResult));
        }


        [TestMethod()]
        public void Moq_PostSpecifieTest()
        {
            // Act
            var actionResult = controller_mock.PostStock(stock).Result;
            // Assert
            Assert.IsInstanceOfType(actionResult, typeof(ActionResult<Stock>), "Pas un ActionResult<Stock>");
            Assert.IsInstanceOfType(actionResult.Result, typeof(CreatedAtActionResult), "Pas un CreatedAtActionResult");
            var result = actionResult.Result as CreatedAtActionResult;
            Assert.IsInstanceOfType(result.Value, typeof(Stock), "Pas une Stock");
            stock.IdColoris = ((Stock)result.Value).IdColoris;
            stock.IdTaille = ((Stock)result.Value).IdTaille;
            stock.IdEquipement = ((Stock)result.Value).IdEquipement;
            Assert.AreEqual(stock, (Stock)result.Value, "Stock pas identiques");
        }

        [TestMethod]
        public void Moq_DeleteSpecifieTest()
        {
            // Arrange
            mockRepository.Setup(x => x.GetBy3CompositeKeysAsync(1, 1, 1).Result).Returns(stock);

            // Act
            var actionResult = controller_mock.DeleteStock(1, 1,1).Result;
            // Assert
            Assert.IsInstanceOfType(actionResult, typeof(NoContentResult), "Pas un NoContentResult");
        }
    }
}