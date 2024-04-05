using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SAE_4._01.Controllers;
using SAE_4._01.Models.DataManager;
using SAE_4._01.Models.EntityFramework;
using SAE_4._01.Models.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace SAE_4._01.Controllers.Tests
{
    [TestClass()]
    public class PresentationEquipementsControllerTests
    {
        private PresentationEquipementsController controller;
        private BMWDBContext context;
        private IDataRepository<PresentationEquipement> dataRepository;
        private PresentationEquipement presentation;

        [TestInitialize]
        public void InitTest()
        {
            var builder = new DbContextOptionsBuilder<BMWDBContext>().UseNpgsql("Server=51.83.36.122; port=5432; Database=sa11; uid=sa11; password=BMW-S4; SearchPath=bmw;");
            context = new BMWDBContext(builder.Options);
            dataRepository = new PresentationEquipementManager(context);
            controller = new PresentationEquipementsController(dataRepository);

            presentation = new PresentationEquipement()
            {
                IdPresentation = 666666666,
                IdEquipement = 1,
                IdColoris = 1,
            };
        }

        [TestMethod()]
        public void GetPresentationEquipementsTest_RecuperationsOK()
        {
            //Arrange
            List<PresentationEquipement> lesPres = context.PresentationEquipements.ToList();
            // Act
            var res = controller.GetPresentationEquipements().Result;
            // Assert
            Assert.IsNotNull(res);
            CollectionAssert.AreEqual(lesPres, res.Value.ToList(), "Les listes de presentation ne sont pas identiques");
        }

        [TestMethod()]
        public void GetPresentationEquipementTest_RecuperationOK()
        {
            // Arrange
            PresentationEquipement? pre = context.PresentationEquipements.Find(1);
            // Act
            var res = controller.GetPresentationEquipement(1).Result;
            // Assert
            Assert.IsNotNull(res.Value);
            Assert.AreEqual(pre, res.Value, "La presentation n'est pas le même");
        }

        [TestMethod()]
        public void GetParametreTest_RecuperationFailed()
        {
            // Arrange
            PresentationEquipement? par = context.PresentationEquipements.Find(2);
            // Act
            var res = controller.GetPresentationEquipement(1).Result;
            // Assert
            Assert.IsNotNull(res.Value);
            Assert.AreNotEqual(par, res.Value, "La presentation est la même");
        }

        [TestMethod()]
        public void GetParametreTest_EquipementNExistePas()
        {
            var res = controller.GetPresentationEquipement(777777777).Result;
            // Assert
            Assert.IsNull(res.Result, "La presentation existe");
            Assert.IsNull(res.Value, "La presentation existe");
        }

        [TestMethod()]
        public void PostDelete()
        {
            PostPresentationEquipementTest_CreationOK();
            DeletePresentationEquipementTest_SuppressionOK();
        }

        public void PostPresentationEquipementTest_CreationOK()
        {
            // Act
            var result = controller.PostPresentationEquipement(presentation).Result;
            // Assert
            var preRecup = controller.GetPresentationEquipement(presentation.IdPresentation).Result;
            presentation.IdPresentation = preRecup.Value.IdPresentation;
            Assert.AreEqual(presentation, preRecup.Value, "presentation pas identiques");
        }

        public void DeletePresentationEquipementTest_SuppressionOK()
        {
            // Act
            var preSuppr = controller.GetPresentationEquipement(presentation.IdPresentation).Result;
            _ = controller.DeletePresentationEquipement(presentation.IdPresentation).Result;

            // Assert
            var res = controller.GetPresentationEquipement(presentation.IdPresentation).Result;
            Assert.IsNull(res.Value, "presentation non supprimé");
        }
    }
}