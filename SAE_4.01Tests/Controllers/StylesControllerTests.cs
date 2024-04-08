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
    public class StylesControllerTests
    {
        private StylesController controller;
        private BMWDBContext context;
        private IDataRepository<Style> dataRepository;
        private Style style;
        private Mock<IDataRepository<Style>> mockRepository;
        private StylesController controller_mock;


        [TestInitialize]
        public void InitTest()
        {
            var builder = new DbContextOptionsBuilder<BMWDBContext>().UseNpgsql("Server=51.83.36.122; port=5432; Database=sa11; uid=sa11; password=BMW-S4; SearchPath=bmw;");
            context = new BMWDBContext(builder.Options);
            dataRepository = new StyleManager(context);
            controller = new StylesController(dataRepository);
            mockRepository = new Mock<IDataRepository<Style>>();
            controller_mock = new StylesController(mockRepository.Object);

            style = new Style
            {
                IdStyle = 666666666,
                NomStyle = "Style",
                PrixStyle = 1,
                DescriptionStyle = "un style",
                IdMoto = 1,
                PhotoMoto = "",
                PhotoStyle = ""
            };
        }

        [TestMethod()]
        public void GetStylesTest_RecuperationsOK()
        {
            //Arrange
            List<Style> lesStys = context.Styles.ToList();
            // Act
            var res = controller.GetStyles().Result;
            // Assert
            Assert.IsNotNull(res);
            CollectionAssert.AreEqual(lesStys, res.Value.ToList(), "Les listes de styles ne sont pas identiques");

        }

        [TestMethod()]
        public void GetStyleTest_RecuperationOK()
        {
            
            // Arrange
            Style? sty = context.Styles.Find(1);
            // Act
            var res = controller.GetStyle(1).Result;
            // Assert
            Assert.IsNotNull(res.Value);
            Assert.AreEqual(sty, res.Value, "Le prive n'est pas le même");
        }

        [TestMethod()]
        public void GetParametreTest_RecuperationFailed()
        {
            // Arrange
            Style? sty = context.Styles.Find(1);
            // Act
            var res = controller.GetStyle(2).Result;
            // Assert
            Assert.IsNotNull(res.Value);
            Assert.AreNotEqual(sty, res.Value, "Le style est le même");
        }

        [TestMethod()]
        public void GetParametreTest_EquipementNExistePas()
        {
            var res = controller.GetStyle(777777777).Result;
            // Assert
            Assert.IsNull(res.Result, "Le style existe");
            Assert.IsNull(res.Value, "Le style existe");
        }

        [TestMethod()]
        public void GetCouleurByIdMotoTest()
        {

        }

        [TestMethod()]
        public void PostUpdateDelete()
        {
            PostStyleTest_CreationOK();
            PutStyleTest_ModificationOK();
            DeleteStyleTest_SuppressionOK();
        }

        
        public void PostStyleTest_CreationOK()
        {
            // Act
            var result = controller.PostStyle(style).Result;
            // Assert
            var styRecup = controller.GetStyle(style.IdStyle).Result;
            style.IdStyle = styRecup.Value.IdStyle;
            Assert.AreEqual(style, styRecup.Value, "style pas identiques");
        }

        
        public void PutStyleTest_ModificationOK()
        {
            // Arrange
            var styIni = controller.GetStyle(style.IdStyle).Result;
            styIni.Value.PhotoMoto = "nom";

            // Act
            var res = controller.PutStyle(style.IdStyle, styIni.Value).Result;

            // Assert
            var styMaj = controller.GetStyle(style.IdStyle).Result;
            Assert.IsNotNull(styMaj.Value);
            Assert.AreEqual(styIni.Value, styMaj.Value, "style pas identiques");
        }

        public void DeleteStyleTest_SuppressionOK()
        {
            // Act
            var proSuppr = controller.GetStyle(style.IdStyle).Result;
            _ = controller.DeleteStyle(style.IdStyle).Result;

            // Assert
            var res = controller.GetStyle(style.IdStyle).Result;
            Assert.IsNull(res.Value, "style non supprimé");
        }
    }
}