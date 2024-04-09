using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Options;
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
    public class PacksControllerTests
    {
        private PacksController controller;
        private BMWDBContext context;
        private IDataRepository<Pack> dataRepository;
        private Pack pack;
        private Mock<IDataRepository<Pack>> mockRepository;
        private PacksController controller_mock;

        [TestInitialize]
        public void InitTest()
        {
            var builder = new DbContextOptionsBuilder<BMWDBContext>().UseNpgsql("Server=51.83.36.122; port=5432; Database=sa11; uid=sa11; password=BMW-S4; SearchPath=bmw;");
            context = new BMWDBContext(builder.Options);
            dataRepository = new PackManager(context);
            controller = new PacksController(dataRepository);
            mockRepository = new Mock<IDataRepository<Pack>>();
            controller_mock = new PacksController(mockRepository.Object);

            pack = new Pack
            {
                IdPack = 666666666,
                IdMoto = 1,
                NomPack = "PackTest",
                DescriptionPack = "My name is Yoshikage Kira. I’m 33 years old. My house is in the northeast section of Morioh, where all the villas are, and I am not married. I work as an employee for the Kame Yu department stores, and I get home every day by 8 PM at the latest. I don’t smoke, but I occasionally drink. I’m in bed by 11 PM, and make sure I get eight hours of sleep, no matter what. After having a glass of warm milk and doing about twenty minutes of stretches before going to bed, I usually have no problems sleeping until morning. Just like a baby, I wake up without any fatigue or stress in the morning. I was told there were no issues at my last check-up. I’m trying to explain that I’m a person who wishes to live a very quiet life. I take care not to trouble myself with any enemies, like winning and losing, that would cause me to lose sleep at night. That is how I deal with society, and I know that is what brings me happiness. Although, if I were to fight I wouldn’t lose to anyone.",
                PhotoPack = "static.tvtropes.org/pmwiki/pub/images/yoshikage_kira_anime.png",
                PrixPack = new decimal(1),
            };
        }

        [TestMethod()]
        public void GetPacksTest_RecuperationsOK()
        {
            //Arrange
            List<Pack> lesPacs = context.Packs.ToList();
            // Act
            var res = controller.GetPacks().Result;
            // Assert
            Assert.IsNotNull(res);
            CollectionAssert.AreEqual(lesPacs, res.Value.ToList(), "Les listes de pack ne sont pas identiques");
        }

        [TestMethod()]
        public void GetPackTest_RecuperationOK()
        {
            // Arrange
            Pack? pac = context.Packs.Find(1);
            // Act
            var res = controller.GetPack(1).Result;
            // Assert
            Assert.IsNotNull(res.Value);
            Assert.AreEqual(pac, res.Value, "Le pack n'est pas le même");
        }

        [TestMethod()]
        public void GetPackTest_RecuperationFailed()
        {
            // Arrange
            Pack? opt = context.Packs.Find(1);
            // Act
            var res = controller.GetPack(2).Result;
            // Assert
            Assert.IsNotNull(res.Value);
            Assert.AreNotEqual(opt, res.Value, "Le pack est le même");
        }

        [TestMethod()]
        public void GetPackTest_EquipementNExistePas()
        {
            var res = controller.GetPack(777777777).Result;
            // Assert
            Assert.IsNull(res.Result, "Le pack existe");
            Assert.IsNull(res.Value, "Le pack existe");
        }

        [TestMethod()]
        public void GetPackByIdMotoTest_RecuperationOK()
        {
            //Arrange
            List<Pack> lesPacs = context.Packs.Where(p => p.IdMoto == 1).ToList();
            // Act
            var res = controller.GetPackByIdMoto(1).Result;

            // Assert
            Assert.IsNotNull(res);
            CollectionAssert.AreEqual(lesPacs, res.Value as List<Pack>, "Les listes de couleur ne sont pas identiques");
        }

        [TestMethod()]
        public void PostPutDelete()
        {
            PostPackTest_CreationOk();
            PutPackTest_ModificationOK();
            DeletePackTest_SuppressionOK();
        }
        

        public void PostPackTest_CreationOk()
        {
            // Act
            var result = controller.PostPack(pack).Result;
            // Assert
            var pacRecup = controller.GetPack(pack.IdPack).Result;
            pack.IdPack = pacRecup.Value.IdPack;
            Assert.AreEqual(pack, pacRecup.Value, "pack pas identiques");
        }

        public void PutPackTest_ModificationOK()
        {
            // Arrange
            var pacIni = controller.GetPack(pack.IdPack).Result;
            pacIni.Value.PrixPack = 100;

            // Act
            var res = controller.PutPack(pack.IdPack, pacIni.Value).Result;

            // Assert
            var pacMaj = controller.GetPack(pack.IdPack).Result;
            Assert.IsNotNull(pacMaj.Value);
            Assert.AreEqual(pacIni.Value, pacMaj.Value, "pack pas identiques");
        }

        public void DeletePackTest_SuppressionOK()
        {
            // Act
            var pacSuppr = controller.GetPack(pack.IdPack).Result;
            _ = controller.DeletePack(pack.IdPack).Result;

            // Assert
            var res = controller.GetPack(pack.IdPack).Result;
            Assert.IsNull(res.Value, "pack non supprimé");
        }

        // ---------------------------------------- Tests Moq ----------------------------------------

        [TestMethod()]
        public void Moq_GetPacksTest_RecuperationOK()
        {
            // Arrange
            var packs = new List<Pack>
                {
                    pack
                };
            mockRepository.Setup(x => x.GetAllAsync()).ReturnsAsync(packs);
            // Act
            var res = controller_mock.GetPacks().Result;
            // Assert
            Assert.IsNotNull(res);
            Assert.IsNotNull(res.Value);
            Assert.AreEqual(packs, res.Value as IEnumerable<Pack>, "La liste n'est pas le même");
        }

        [TestMethod()]
        public void Moq_GetPackTest_RecuperationOK()
        {
            // Arrange
            mockRepository.Setup(x => x.GetByIdAsync(1)).ReturnsAsync(pack);

            // Act
            var res = controller_mock.GetPack(1).Result;

            // Assert
            Assert.IsNotNull(res);
            Assert.IsNotNull(res.Value);

            Assert.AreEqual(pack, res.Value, "Les objets ne sont pas égaux");
        }


        [TestMethod()]
        public void Moq_GetPackTest_RecuperationFailed()
        {
            // Act
            var res = controller_mock.GetPack(0).Result;
            // Assert
            Assert.IsInstanceOfType(res.Result, typeof(NotFoundResult));
        }

        [TestMethod()]
        public void Moq_GetByIdCouleurTest_RecuperationOk()
        { 
            // Arrange
            var packs = new List<Pack>
                {
                    pack
                };
            mockRepository.Setup(x => x.GetByIdMotoAsync(1)).ReturnsAsync(packs);
            // Act
            var res = controller_mock.GetPackByIdMoto(1).Result;
            
            // Assert
            Assert.IsNotNull(res);
            Assert.IsNotNull(res.Value);
            Assert.AreEqual(packs, res.Value as IEnumerable<Pack>, "La liste n'est pas le même");
        }


        [TestMethod()]
        public void Moq_PostPackTest()
        {
            // Act
            var actionResult = controller_mock.PostPack(pack).Result;
            // Assert
            Assert.IsInstanceOfType(actionResult, typeof(ActionResult<Pack>), "Pas un ActionResult<Pack>");
            Assert.IsInstanceOfType(actionResult.Result, typeof(CreatedAtActionResult), "Pas un CreatedAtActionResult");
            var result = actionResult.Result as CreatedAtActionResult;
            Assert.IsInstanceOfType(result.Value, typeof(Pack), "Pas une Pack");
            pack.IdPack = ((Pack)result.Value).IdPack;
            Assert.AreEqual(pack, (Pack)result.Value, "Pack pas identiques");
        }

        [TestMethod]
        public void Moq_DeletePackTest()
        {
            // Arrange
            mockRepository.Setup(x => x.GetByIdAsync(1).Result).Returns(pack);

            // Act
            var actionResult = controller_mock.DeletePack(1).Result;
            // Assert
            Assert.IsInstanceOfType(actionResult, typeof(NoContentResult), "Pas un NoContentResult");
        }
    }
}