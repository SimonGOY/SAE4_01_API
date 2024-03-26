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
    public class AccessoiresControllerTests
    {
        private AccessoiresController controller;
        private BMWDBContext context;
        private IDataRepository<Accessoire> dataRepository;
        private Accessoire accessoire;

        [TestInitialize]
        public void InitTest()
        {
            var builder = new DbContextOptionsBuilder<BMWDBContext>().UseNpgsql("Server=51.83.36.122; port=5432; Database=sa11; uid=sa11; password=BMW-S4; SearchPath=bmw;");
            context = new BMWDBContext(builder.Options);
            dataRepository = new AccessoireManager(context);
            controller = new AccessoiresController(dataRepository);

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
        public void GetAccessoires_RecuperationOK()
        {
            //Arrange
            List<Accessoire> lesAccessoires = context.Accessoires.ToList();
            // Act
            var res = controller.GetAccessoires().Result;
            // Assert
            Assert.IsNotNull(res);
            CollectionAssert.AreEqual(lesAccessoires, res.Value.ToList(), "Les listes de clients ne sont pas identiques");
        }
    }
}