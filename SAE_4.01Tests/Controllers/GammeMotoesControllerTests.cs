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
    public class GammeMotoesControllerTests
    {
        private GammeMotoesController controller;
        private BMWDBContext context;
        private IDataRepository<GammeMoto> dataRepository;
        private GammeMoto gammeMoto;


        [TestInitialize]
        public void InitTest()
        {
            var builder = new DbContextOptionsBuilder<BMWDBContext>().UseNpgsql("Server=51.83.36.122; port=5432; Database=sa11; uid=sa11; password=BMW-S4; SearchPath=bmw;");
            context = new BMWDBContext(builder.Options);
            dataRepository = new GammeMotoManager(context);
            controller = new GammeMotoesController(dataRepository);

            gammeMoto = new GammeMoto
            {
                IdGamme = 666666666,
                LibelleGamme = "Tout Terrain"
            };
        }

        [TestMethod()]
        public void GetGammeMotosTest_RecuperationsOK()
        {
            //Arrange
            List<GammeMoto> lesGams = context.GammeMotos.ToList();
            // Act
            var res = controller.GetGammeMotos().Result;
            // Assert
            Assert.IsNotNull(res);
            CollectionAssert.AreEqual(lesGams, res.Value.ToList(), "Les listes de gammes ne sont pas identiques");
        }

        [TestMethod()]
        public void GetGammeMotoTest_RecuperationOK()
        {
            // Arrange
            GammeMoto? gam = context.GammeMotos.Find(1);
            // Act
            var res = controller.GetGammeMoto(1).Result;
            // Assert
            Assert.IsNotNull(res.Value);
            Assert.AreEqual(gam, res.Value, "La gamme n'est pas la même");
        }

        [TestMethod()]
        public void GetGammeMotoTest_RecuperationFailed()
        {
            // Arrange
            GammeMoto? dem = context.GammeMotos.Find(2);
            // Act
            var res = controller.GetGammeMoto(1).Result;
            // Assert
            Assert.IsNotNull(res.Value);
            Assert.AreNotEqual(dem, res.Value, "La gamme est le même");
        }

        [TestMethod()]
        public void GetGammeMotoTest_EquipementNExistePas()
        {
            var res = controller.GetGammeMoto(777777777).Result;
            // Assert
            Assert.IsNull(res.Result, "La gamme existe");
            Assert.IsNull(res.Value, "La gamme existe");
        }


        [TestMethod()]
        public void PostDelete()
        {
            PostGammeMotoTest_CreationOK();
            DeleteGammeMotoTest();
        }

        public void PostGammeMotoTest_CreationOK()
        {
            // Act
            var result = controller.PostGammeMoto(gammeMoto).Result;
            // Assert
            var gamRecup = controller.GetGammeMoto(gammeMoto.IdGamme).Result;
            gammeMoto.IdGamme = gamRecup.Value.IdGamme;
            Assert.AreEqual(gammeMoto, gamRecup.Value, "Gammes pas identiques");
        }

        public void DeleteGammeMotoTest()
        {
            // Act
            var gamSuppr = controller.GetGammeMoto(gammeMoto.IdGamme).Result;
            _ = controller.DeleteGammeMoto(gammeMoto.IdGamme).Result;

            // Assert
            var res = controller.GetGammeMoto(gammeMoto.IdGamme).Result;
            Assert.IsNull(res.Value, "gammes non supprimé");
        }
    }
}