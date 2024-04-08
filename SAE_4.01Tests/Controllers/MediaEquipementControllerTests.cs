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
    public class MediaEquipementControllerTests
    {
        private MediaEquipementController controller;
        private BMWDBContext context;
        private IDataRepository<MediaEquipement> dataRepository;
        private MediaEquipement mediaEquipement;
        private Mock<IDataRepository<MediaEquipement>> mockRepository;
        private MediaEquipementController controller_mock;

        [TestInitialize]
        public void InitTest()
        {
            var builder = new DbContextOptionsBuilder<BMWDBContext>().UseNpgsql("Server=51.83.36.122; port=5432; Database=sa11; uid=sa11; password=BMW-S4; SearchPath=bmw;");
            context = new BMWDBContext(builder.Options);
            dataRepository = new MediaEquipementManager(context);
            controller = new MediaEquipementController(dataRepository);
            mockRepository = new Mock<IDataRepository<MediaEquipement>>();
            controller_mock = new MediaEquipementController(mockRepository.Object);

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
            List<MediaEquipement> lesMeds = context.MediasEquipement.ToList();
            // Act
            var res = controller.GetMediaEquipements().Result;
            // Assert
            Assert.IsNotNull(res);
            CollectionAssert.AreEqual(lesMeds, res.Value.ToList(), "Les listes de mediaEqu ne sont pas identiques");
        }

        [TestMethod()]
        public void GetMediaTest_RecuperationOK()
        {
            // Arrange
            MediaEquipement? med = context.MediasEquipement.Find(1);
            // Act
            var res = controller.GetMedia(1).Result;
            // Assert
            Assert.IsNotNull(res.Value);
            Assert.AreEqual(med, res.Value, "Le mediaEqu n'est pas le même");
        }

        [TestMethod()]
        public void GetByIdEquipementTest_RecuperationOK()
        {
            //Arrange
            List<MediaEquipement> lesMeds = context.MediasEquipement.Where(p=> p.IdEquipement == 1).ToList();
            // Act
            var res = controller.GetByIdEquipement(1).Result;
            var res_cast = ((Microsoft.AspNetCore.Mvc.ActionResult<System.Collections.Generic.IEnumerable<SAE_4._01.Models.EntityFramework.MediaEquipement>>)((Microsoft.AspNetCore.Mvc.ObjectResult)res.Result).Value).Value;

            // Assert
            Assert.IsNotNull(res);
            CollectionAssert.AreEqual(lesMeds, res_cast as List<MediaEquipement> , "Les listes de mediaEqu ne sont pas identiques");
        }

        [TestMethod()]
        public void GetInfoCBTest_RecuperationFailed()
        {
            // Arrange
            MediaEquipement? med = context.MediasEquipement.Find(1);
            // Act
            var res = controller.GetMedia(2).Result;
            // Assert
            Assert.IsNotNull(res.Value);
            Assert.AreNotEqual(med, res.Value, "Le media est le même");
        }

        [TestMethod()]
        public void GetInfoCBTest_EquipementNExistePas()
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
            var result = controller.PostMedia(mediaEquipement).Result;
            // Assert
            var medRecup = controller.GetMedia(mediaEquipement.IdMediaEquipement).Result;
            mediaEquipement.IdEquipement = medRecup.Value.IdEquipement;
            Assert.AreEqual(mediaEquipement, medRecup.Value, "medias pas identiques");
        }

        public void PutMediaTest_ModificationOK()
        {
            // Arrange
            var medIni = controller.GetMedia(mediaEquipement.IdMediaEquipement).Result;
            medIni.Value.LienMedia = "nintendo-town.fr/wp-content/uploads/2018/09/Professeur_Layton_et_l_Etrange_Village.jpg";

            // Act
            var res = controller.PutMedia(mediaEquipement.IdMediaEquipement, medIni.Value).Result;

            // Assert
            var medMaj = controller.GetMedia(mediaEquipement.IdMediaEquipement).Result;
            Assert.IsNotNull(medMaj.Value);
            Assert.AreEqual(medIni.Value, medMaj.Value, "medias pas identiques");
        }

        public void DeleteMediaTest_SuppressionOK()
        {
            // Act
            var infSuppr = controller.GetMedia(mediaEquipement.IdMediaEquipement).Result;
            _ = controller.DeleteMedia(mediaEquipement.IdMediaEquipement).Result;

            // Assert
            var res = controller.GetMedia(mediaEquipement.IdMediaEquipement).Result;
            Assert.IsNull(res.Value, "medias non supprimé");
        }

        // ---------------------------------------- Tests Moq ----------------------------------------

        [TestMethod()]
        public void Moq_GetMediaEquipementsTest_RecuperationOK()
        {
            // Arrange
            var medias = new List<MediaEquipement>
                {
                    mediaEquipement
                };
            mockRepository.Setup(x => x.GetAllAsync()).ReturnsAsync(medias);
            // Act
            var res = controller_mock.GetMediaEquipements().Result;
            // Assert
            Assert.IsNotNull(res);
            Assert.IsNotNull(res.Value);
            Assert.AreEqual(medias, res.Value as IEnumerable<MediaEquipement>, "La liste n'est pas le même");
        }

        [TestMethod()]
        public void Moq_GetByIdEquipementTest_RecuperationOK()
        {
            // Arrange
            var medias = new List<MediaEquipement>
                {
                    mediaEquipement
                };
            mockRepository.Setup(x => x.GetByIdEquipementAsync(1)).ReturnsAsync(medias);
            // Act
            var res = controller_mock.GetByIdEquipement(1).Result;
            var res_cast = ((Microsoft.AspNetCore.Mvc.ActionResult<System.Collections.Generic.IEnumerable<SAE_4._01.Models.EntityFramework.MediaEquipement>>)((Microsoft.AspNetCore.Mvc.ObjectResult)res.Result).Value).Value;
            // Assert
            Assert.IsNotNull(res);
            Assert.IsNotNull(res.Result);
            Assert.AreEqual(medias, res_cast as IEnumerable<MediaEquipement>, "Le media n'est pas le même");
        }

        [TestMethod()]
        public void Moq_GetByIdEquipementTest_RecuperationNonOK()
        {
            // Act
            var res = controller_mock.GetByIdEquipement(0).Result;
            // Assert
            Assert.IsInstanceOfType(res.Result, typeof(NotFoundResult));
        }
    }
}