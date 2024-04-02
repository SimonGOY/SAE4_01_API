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
    public class EstInclusControllerTests
    {
        private EstInclusController controller;
        private BMWDBContext context;
        private IDataRepository<EstInclus> dataRepository;
        private EstInclus equipement;

        [TestInitialize]
        public void initTest()
        {
            var builder = new DbContextOptionsBuilder<BMWDBContext>().UseNpgsql("Server=51.83.36.122; port=5432; Database=sa11; uid=sa11; password=BMW-S4; SearchPath=bmw;");
            context = new BMWDBContext(builder.Options);
            dataRepository = new EstInclusManager(context);
            controller = new EstInclusController(dataRepository);

            equipement = new EstInclus
            {
                IdOption = 1,
                IdStyle = 1,
            };
        }

        [TestMethod()]
        public void GetSontInclusTest()
        {
            //Arrange
            List<EstInclus> lesEsts = context.SontInclus.ToList();
            // Act
            var res = controller.GetSontInclus().Result;
            // Assert
            Assert.IsNotNull(res);
            CollectionAssert.AreEqual(lesEsts, res.Value.ToList(), "Les listes de estInclus ne sont pas identiques");
        }

        [TestMethod()]
        public void GetByIdOptionTest()
        {

        }

        [TestMethod()]
        public void GetByIdStyleTest()
        {

        }

        [TestMethod()]
        public void PutEstInclusTest()
        {

        }

        [TestMethod()]
        public void PostEstInclusTest()
        {

        }

        [TestMethod()]
        public void DeleteEstInclusTest()
        {

        }
    }
}