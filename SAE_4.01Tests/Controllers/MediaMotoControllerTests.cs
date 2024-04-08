using Microsoft.AspNetCore.Mvc;
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
    public class MediaMotoControllerTests
    {
        private MediaMotoController controller;
        private BMWDBContext context;
        private IDataRepository<MediaMoto> dataRepository;
        private MediaMoto mediaMoto;
        private Mock<IDataRepository<MediaMoto>> mockRepository;
        private MediaMotoController controller_mock;

        [TestInitialize]
        public void InitTest()
        {
            var builder = new DbContextOptionsBuilder<BMWDBContext>().UseNpgsql("Server=51.83.36.122; port=5432; Database=sa11; uid=sa11; password=BMW-S4; SearchPath=bmw;");
            context = new BMWDBContext(builder.Options);
            dataRepository = new MediaMotoManager(context);
            controller = new MediaMotoController(dataRepository);
            mockRepository = new Mock<IDataRepository<MediaMoto>>();
            controller_mock = new MediaMotoController(mockRepository.Object);

            mediaMoto = new MediaMoto
            {
                IdMediaMoto = 666666666,
                IdMoto = 1,
                LienMedia = "poketerra.com/upload/uploads/1302722783.png",
            };
        }

        [TestMethod()]
        public void GetMediaMotoTest_RecuperationsOK()
        {
            //Arrange
            List<MediaMoto> lesMeds = context.MediasMoto.ToList();
            // Act
            var res = controller.GetMediaMotos().Result;
            // Assert
            Assert.IsNotNull(res);
            CollectionAssert.AreEqual(lesMeds, res.Value.ToList(), "Les listes de mediaMot ne sont pas identiques");
        }

        [TestMethod()]
        public void GetMediaTest_RecuperationOK()
        {
            // Arrange
            MediaMoto? med = context.MediasMoto.Find(16);
            // Act
            var res = controller.GetMedia(16).Result;
            // Assert
            Assert.IsNotNull(res.Value);
            Assert.AreEqual(med, res.Value, "Le mediaMot n'est pas le même");
        }

        /*[TestMethod()]
        public void GetByIdMotoTest_RecuperationOK()
        {
            //Arrange
            List<MediaMoto> lesMeds = context.MediasMoto.ToList();
            // Act
            var res = controller.GetByIdMoto(1).Result;
            // Assert
            Assert.IsNotNull(res);
            CollectionAssert.AreEqual(lesMeds, res.Value.ToList(), "Les listes de mediaMot ne sont pas identiques");
        }*/

        [TestMethod()]
        public void GetReferenceTest_RecuperationOK()
        {
            // Arrange
            MediaMoto? med = context.MediasMoto.Find(9);
            // Act
            var res = controller.GetReference(1).Result;
            // Assert
            Assert.IsNotNull(res.Value);
            Assert.AreEqual(med, res.Value, "Le mediaMoto n'est pas le même");
        }

        [TestMethod()]
        public void GetMediaMotoTest_RecuperationFailed()
        {
            // Arrange
            MediaMoto? med = context.MediasMoto.Find(17);
            // Act
            var res = controller.GetMedia(16).Result;
            // Assert
            Assert.IsNotNull(res.Value);
            Assert.AreNotEqual(med, res.Value, "Le media est le même");
        }

        [TestMethod()]
        public void GetMediaMotoTest_EquipementNExistePas()
        {
            var res = controller.GetMedia(777777777).Result;
            // Assert
            Assert.IsNull(res.Result, "Le media existe");
            Assert.IsNull(res.Value, "Le media existe");
        }

        [TestMethod()]
        public void PostPutDeleteTest()
        {
            PostMediaTest_CreationOK();
            PutMediaTest_ModificationOK();
            DeleteMediaTest_SuppressionOK();
        }

        public void PostMediaTest_CreationOK()
        {
            // Act
            var result = controller.PostMedia(mediaMoto).Result;
            // Assert
            var medRecup = controller.GetMedia(mediaMoto.IdMediaMoto).Result;
            mediaMoto.IdMediaMoto = medRecup.Value.IdMediaMoto;
            Assert.AreEqual(mediaMoto, medRecup.Value, "medias pas identiques");
        }

        public void PutMediaTest_ModificationOK()
        {
            // Arrange
            var medIni = controller.GetMedia(mediaMoto.IdMediaMoto).Result;
            medIni.Value.LienMedia = "ih1.redbubble.net/image.4757907321.6347/flat,750x,075,f-pad,750x1000,f8f8f8.jpg";

            // Act
            var res = controller.PutMedia(mediaMoto.IdMediaMoto, medIni.Value).Result;

            // Assert
            var medMaj = controller.GetMedia(mediaMoto.IdMediaMoto).Result;
            Assert.IsNotNull(medMaj.Value);
            Assert.AreEqual(medIni.Value, medMaj.Value, "media pas identiques");
        }

        public void DeleteMediaTest_SuppressionOK()
        {
            // Act
            var infSuppr = controller.GetMedia(mediaMoto.IdMediaMoto).Result;
            _ = controller.DeleteMedia(mediaMoto.IdMediaMoto).Result;

            // Assert
            var res = controller.GetMedia(mediaMoto.IdMediaMoto).Result;
            Assert.IsNull(res.Value, "media non supprimé");
        }

        // ---------------------------------------- Tests Moq ----------------------------------------

        [TestMethod()]
        public void Moq_GetMediaEquipementsTest_RecuperationOK()
        {
            // Arrange
            var medias = new List<MediaMoto>
                {
                    mediaMoto
                };
            mockRepository.Setup(x => x.GetAllAsync()).ReturnsAsync(medias);
            // Act
            var res = controller_mock.GetMediaMotos().Result;
            // Assert
            Assert.IsNotNull(res);
            Assert.IsNotNull(res.Value);
            Assert.AreEqual(medias, res.Value as IEnumerable<MediaMoto>, "La liste n'est pas le même");
        }

        [TestMethod()]
        public void Moq_GetByIdEquipementTest_RecuperationOK()
        {
            // Arrange
            var medias = new List<MediaMoto>
                {
                    mediaMoto
                };
            mockRepository.Setup(x => x.GetByIdMotoAsync(1)).ReturnsAsync(medias);
            // Act
            var res = controller_mock.GetByIdMoto(1).Result;
            var res_cast = ((Microsoft.AspNetCore.Mvc.ActionResult<System.Collections.Generic.IEnumerable<SAE_4._01.Models.EntityFramework.MediaMoto>>)((Microsoft.AspNetCore.Mvc.ObjectResult)res.Result).Value).Value;
            // Assert
            Assert.IsNotNull(res);
            Assert.IsNotNull(res.Result);
            Assert.AreEqual(medias, res_cast as IEnumerable<MediaMoto>, "Le media n'est pas le même");
        }

    }
}