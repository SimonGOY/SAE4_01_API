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
    }
}