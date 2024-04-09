using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SAE_4._01.Controllers;
using SAE_4._01.Models.DataManager;
using SAE_4._01.Models.EntityFramework;
using SAE_4._01.Models.Repository;
using System;
using System.Collections;
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

        // ---------------------------------------- Tests Moq ----------------------------------------

        [TestMethod()]
        public void Moq_GetSpecifiesTest_RecuperationOK()
        {
            // Arrange
            var styles = new List<Style>
                {
                    style
                };
            mockRepository.Setup(x => x.GetAllAsync()).ReturnsAsync(styles);
            // Act
            var res = controller_mock.GetStyles().Result;
            // Assert
            Assert.IsNotNull(res);
            Assert.IsNotNull(res.Value);
            Assert.AreEqual(styles, res.Value as IEnumerable<Style>, "La liste n'est pas le même");
        }

        [TestMethod()]
        public void Moq_GetProfessionnelTest_RecuperationOK()
        {
            // Arrange
            mockRepository.Setup(x => x.GetByIdAsync(1)).ReturnsAsync(style);

            // Act
            var res = controller_mock.GetStyle(1).Result;

            // Assert
            Assert.IsNotNull(res);
            Assert.IsNotNull(res.Value);

            Assert.AreEqual(style, res.Value, "Les objets ne sont pas égaux");
        }


        [TestMethod()]
        public void Moq_GetProfessionnelTest_RecuperationFailed()
        {
            // Act
            var res = controller_mock.GetStyle(0).Result;
            // Assert
            Assert.IsInstanceOfType(res.Result, typeof(NotFoundResult));
        }


        [TestMethod()]
        public void Moq_PostSpecifieTest()
        {
            // Act
            var actionResult = controller_mock.PostStyle(style).Result;
            // Assert
            Assert.IsInstanceOfType(actionResult, typeof(ActionResult<Style>), "Pas un ActionResult<Style>");
            Assert.IsInstanceOfType(actionResult.Result, typeof(CreatedAtActionResult), "Pas un CreatedAtActionResult");
            var result = actionResult.Result as CreatedAtActionResult;
            Assert.IsInstanceOfType(result.Value, typeof(Style), "Pas une Style");
            style.IdStyle = ((Style)result.Value).IdStyle;
            Assert.AreEqual(style, (Style)result.Value, "Style pas identiques");
        }

        [TestMethod]
        public void Moq_DeleteSpecifieTest()
        {
            // Arrange
            mockRepository.Setup(x => x.GetByIdAsync(1).Result).Returns(style);

            // Act
            var actionResult = controller_mock.DeleteStyle(1).Result;
            // Assert
            Assert.IsInstanceOfType(actionResult, typeof(NoContentResult), "Pas un NoContentResult");
        }
    }
}