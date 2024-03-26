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
    public class AdressesControllerTests { 
        private AdressesController controller;
        private BMWDBContext context;
        private IDataRepository<Adresse> dataRepository;
        private Adresse accessoire;

        [TestInitialize]
        public void InitTest()
        {
            var builder = new DbContextOptionsBuilder<BMWDBContext>().UseNpgsql("Server=51.83.36.122; port=5432; Database=sa11; uid=sa11; password=BMW-S4; SearchPath=bmw;");
            context = new BMWDBContext(builder.Options);
            dataRepository = new AdresseManager(context);
            controller = new AdressesController(dataRepository);

            accessoire = new Adresse
            {
                NumAdresse = 666666666,
                NomPays = "Testanie",
                AdresseAdresse = "42 rue du Test",
            };
        }

        /*[TestMethod()]
        public void GetAccessoires_RecuperationOK()
        {
            //Arrange
            List<Adresse> lesAccessoires = context.Adresses.ToList();
            // Act
            var res = controller.GetAdresses().Result;
            // Assert
            Assert.IsNotNull(res);
            CollectionAssert.AreEqual(lesAccessoires, res.Value.ToList(), "Les listes de clients ne sont pas identiques");
        }*/
    }
}