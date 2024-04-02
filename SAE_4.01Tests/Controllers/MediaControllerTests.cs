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
        private MediaMotoController controller;
        private BMWDBContext context;
        private IDataRepository<MediaMoto> dataRepository;
        private MediaMoto medequ;
        private MediaMoto medmoto;

        [TestInitialize]
        public void InitTest()
        {
            var builder = new DbContextOptionsBuilder<BMWDBContext>().UseNpgsql("Server=51.83.36.122; port=5432; Database=sa11; uid=sa11; password=BMW-S4; SearchPath=bmw;");
            context = new BMWDBContext(builder.Options);
            dataRepository = new MediaMotoManager(context);
            controller = new MediaMotoController(dataRepository);

            medequ = new MediaMoto
            {
                IdMediaMoto = 666666666,
                IdMoto = 1,
                LienMedia = "monimoto.com/media/moto-sportives.jpg",

            };

            medmoto = new MediaMoto
            {
                IdMediaMoto = 777777777,
                IdMoto = 2,
                LienMedia = "monimoto.com/media/moto-sportives.jpg",
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