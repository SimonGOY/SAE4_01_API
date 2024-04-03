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
    public class MediaEquipementControllerTests
    {
        private MediaEquipementController controller;
        private BMWDBContext context;
        private IDataRepository<MediaEquipement> dataRepository;
        private MediaEquipement mediaEquipement;

        [TestInitialize]
        public void InitTest()
        {
            var builder = new DbContextOptionsBuilder<BMWDBContext>().UseNpgsql("Server=51.83.36.122; port=5432; Database=sa11; uid=sa11; password=BMW-S4; SearchPath=bmw;");
            context = new BMWDBContext(builder.Options);
            dataRepository = new MediaEquipementManager(context);
            controller = new MediaEquipementController(dataRepository);

            mediaEquipement = new MediaEquipement
            {
                IdMediaEquipement = 666666666,
                IdEquipement = 1,
                LienMedia = "media.nouvelobs.com/referentiel/633x306/16397249.png",
            };
        }

        [TestMethod()]
        public void GetMediaEquipementsTest_RecuperationsOK()
        {
            //Arrange
            List<MediaEquipement> lesInfos = context.MediasEquipement.ToList();
            // Act
            var res = controller.GetMediaEquipements().Result;
            // Assert
            Assert.IsNotNull(res);
            CollectionAssert.AreEqual(lesInfos, res.Value.ToList(), "Les listes de mediaEqu ne sont pas identiques");
        }

        [TestMethod()]
        public void GetMediaTest()
        {
            // Arrange
            MediaEquipement? inf = context.MediasEquipement.Find(1);
            // Act
            var res = controller.GetMedia(1).Result;
            // Assert
            Assert.IsNotNull(res.Value);
            Assert.AreEqual(inf, res.Value, "L'e mediaEqu n'est pas le même");
        }

        [TestMethod()]
        public void GetByIdEquipementTest()
        {

        }

        [TestMethod()]
        public void PutMediaTest()
        {

        }

        [TestMethod()]
        public void PostMediaTest()
        {

        }

        [TestMethod()]
        public void DeleteMediaTest()
        {

        }

        // ---------------------------------------- Tests Moq ----------------------------------------

        [TestMethod()]
        public void Moq_GetByIdEquipementTest_RecuperationOK()
        {
            // Arrange
            var mockRepository = new Mock<IDataRepository<MediaEquipement>>();
            var medias = new List<MediaEquipement>
                {
                    mediaEquipement
                };
            mockRepository.Setup(x => x.GetByIdEquipementAsync(1)).ReturnsAsync(medias);

            var controller = new MediaEquipementController(mockRepository.Object);

            // Act
            var res = controller.GetByIdEquipement(1).Result;
            var res_cast = ((Microsoft.AspNetCore.Mvc.ActionResult<System.Collections.Generic.IEnumerable<SAE_4._01.Models.EntityFramework.MediaEquipement>>)((Microsoft.AspNetCore.Mvc.ObjectResult)res.Result).Value).Value;
            // Assert
            Assert.IsNotNull(res);
            Assert.IsNotNull(res.Result);
            Assert.AreEqual(medias, res_cast as IEnumerable<MediaEquipement>, "Le media n'est pas le même");
        }
    }
}