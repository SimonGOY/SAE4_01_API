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
    public class MediaControllerTests
    {
        private MediaController controller;
        private BMWDBContext context;
        private IDataRepository<Media> dataRepository;
        private Media medequ;
        private Media medmoto;

        [TestInitialize]
        public void InitTest()
        {
            var builder = new DbContextOptionsBuilder<BMWDBContext>().UseNpgsql("Server=51.83.36.122; port=5432; Database=sa11; uid=sa11; password=BMW-S4; SearchPath=bmw;");
            context = new BMWDBContext(builder.Options);
            dataRepository = new MediaManager(context);
            controller = new MediaController(dataRepository);

            medequ = new Media
            {
                IdMedia = 666666666,
                IdEquipement = 1,
                IdMoto = null,
                LienMedia = "monimoto.com/media/moto-sportives.jpg",
                IdPresentation = 1,
                IsPresentation = true
            };

            medmoto = new Media
            {
                IdMedia = 777777777,
                IdEquipement = 1,
                IdMoto = null,
                LienMedia = "monimoto.com/media/moto-sportives.jpg",
                IdPresentation = 1,
                IsPresentation = true
            };
        }

        /*[TestMethod()]
        public void GetMediaTest()
        {
            //Arrange
            List<Media> lesMediasCLients = context.Medias.ToList();
            // Act
            var res = controller.GetMedia().Result;
            // Assert
            Assert.IsNotNull(res);
            CollectionAssert.AreEqual(lesMedias, res.Value.ToList(), "Les listes de médias ne sont pas identiques");
        }*/

        [TestMethod()]
        public void GetByIdMotoTest()
        {

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
    }
}