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
    public class InfoCBsControllerTests
    {
        private InfoCBsController controller;
        private BMWDBContext context;
        private IDataRepository<InfoCB> dataRepository;
        private InfoCB infoCB;
        private Mock<IDataRepository<InfoCB>> mockRepository;
        private InfoCBsController controller_mock;

        [TestInitialize]
        public void InitTest()
        {
            var builder = new DbContextOptionsBuilder<BMWDBContext>().UseNpgsql("Server=51.83.36.122; port=5432; Database=sa11; uid=sa11; password=BMW-S4; SearchPath=bmw;");
            context = new BMWDBContext(builder.Options);
            dataRepository = new InfoCBManager(context);
            controller = new InfoCBsController(dataRepository);
            mockRepository = new Mock<IDataRepository<InfoCB>>();
            controller_mock = new InfoCBsController(mockRepository.Object);

            infoCB = new InfoCB
            {
                IdCarte = 666666666,
                IdClient = 1,
                NumCarte ="1234 7895 4257 7485",
                DateExpiration = "02/25",
                TitulaireCompte = "BASTARD"
            };
        }

        [TestMethod()]
        public void GetInfoCBsTest_RecuperationsOK()
        {
            //Arrange
            List<InfoCB> lesInfos = context.InfoCBs.ToList();
            // Act
            var res = controller.GetInfoCBs().Result;
            // Assert
            Assert.IsNotNull(res);
            CollectionAssert.AreEqual(lesInfos, res.Value.ToList(), "Les listes d'infos ne sont pas identiques");
        }

        [TestMethod()]
        public void GetInfoCBTest_RecuperationOK()
        {
            // Arrange
            InfoCB? inf = context.InfoCBs.Find(15);
            // Act
            var res = controller.GetInfoCB(15).Result;
            // Assert
            Assert.IsNotNull(res.Value);
            Assert.AreEqual(inf, res.Value, "L'info n'est pas la même");
        }

        [TestMethod()]
        public void GetInfoCBTest_RecuperationFailed()
        {
            // Arrange
            InfoCB? inf = context.InfoCBs.Find(15);
            // Act
            var res = controller.GetInfoCB(20).Result;
            // Assert
            Assert.IsNotNull(res.Value);
            Assert.AreNotEqual(inf, res.Value, "L'info est la même");
        }

        [TestMethod()]
        public void GetInfoCBTest_EquipementNExistePas()
        {
            var res = controller.GetInfoCB(777777777).Result;
            // Assert
            Assert.IsNull(res.Result, "L'info existe");
            Assert.IsNull(res.Value, "L'info existe");
        }

        [TestMethod()]
        public void PostPutDeleteTest()
        {
            PostInfoCBTest_CreationOK();
            PutInfoCBTest_ModificationOK();
            DeleteInfoCBTest_SuppressionOK();
        }

        public void PostInfoCBTest_CreationOK()
        {
            // Act
            var result = controller.PostInfoCB(infoCB).Result;
            // Assert
            var infRecup = controller.GetInfoCB(infoCB.IdCarte).Result;
            infoCB.IdCarte = infRecup.Value.IdCarte;
            Assert.AreEqual(infoCB, infRecup.Value, "Gammes pas identiques");
        }

        public void PutInfoCBTest_ModificationOK()
        {
            // Arrange
            var infIni = controller.GetInfoCB(infoCB.IdCarte).Result;
            infIni.Value.TitulaireCompte = "GOY";

            // Act
            var res = controller.PutInfoCB(infoCB.IdCarte, infIni.Value).Result;

            // Assert
            var infMaj = controller.GetInfoCB(infoCB.IdCarte).Result;
            Assert.IsNotNull(infMaj.Value);
            Assert.AreEqual(infIni.Value, infMaj.Value, "demandes pas identiques");
        }

        public void DeleteInfoCBTest_SuppressionOK()
        {
            // Act
            var infSuppr = controller.GetInfoCB(infoCB.IdCarte).Result;
            _ = controller.DeleteInfoCB(infoCB.IdCarte).Result;

            // Assert
            var res = controller.GetInfoCB(infoCB.IdCarte).Result;
            Assert.IsNull(res.Value, "infoCB non supprimé");
        }

        // ---------------------------------------- Tests Moq ----------------------------------------

        [TestMethod()]
        public void Moq_GetInfoCBsTest_RecuperationOK()
        {
            // Arrange
            var infos = new List<InfoCB>
                {
                    infoCB
                };
            mockRepository.Setup(x => x.GetAllAsync()).ReturnsAsync(infos);
            // Act
            var res = controller_mock.GetInfoCBs().Result;
            // Assert
            Assert.IsNotNull(res);
            Assert.IsNotNull(res.Value);
            Assert.AreEqual(infos, res.Value as IEnumerable<InfoCB>, "La liste n'est pas le même");
        }

        [TestMethod()]
        public void Moq_GetByIdClientTest_RecuperationOK()
        {
            // Arrange
            mockRepository.Setup(x => x.GetByIdAsync(15)).ReturnsAsync(infoCB);
            // Act
            var res = controller_mock.GetInfoCB(15).Result;
            // Assert
            Assert.IsNotNull(res);
            Assert.IsNotNull(res.Value);
            Assert.AreEqual(infoCB, res.Value as InfoCB, "Les infoCB n'est pas le même");
        }

        [TestMethod()]
        public void Moq_GetByIdClientTest_RecuperationNonOK()
        {
            // Act
            var res = controller_mock.GetInfoCB(0).Result;
            // Assert
            Assert.IsInstanceOfType(res.Result, typeof(NotFoundResult));
        }
    }
}