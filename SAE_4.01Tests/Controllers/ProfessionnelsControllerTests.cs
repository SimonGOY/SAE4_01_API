using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SAE_4._01.Controllers;
using SAE_4._01.Models.DataManager;
using SAE_4._01.Models.EntityFramework;
using SAE_4._01.Models.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace SAE_4._01.Controllers.Tests
{
    [TestClass()]
    public class ProfessionnelsControllerTests
    {
        private ProfessionnelsController controller;
        private BMWDBContext context;
        private IDataRepository<Professionnel> dataRepository;
        private Professionnel professionnel;

        [TestInitialize]
        public void InitTest()
        {
            var builder = new DbContextOptionsBuilder<BMWDBContext>().UseNpgsql("Server=51.83.36.122; port=5432; Database=sa11; uid=sa11; password=BMW-S4; SearchPath=bmw;");
            context = new BMWDBContext(builder.Options);
            dataRepository = new ProfessionnelManager(context);
            controller = new ProfessionnelsController(dataRepository);

            professionnel = new Professionnel()
            {
                IdPro = 666666666,
                IdClient = 1,
                NomCompagnie = "Pro Inc.",
            };
        }

        [TestMethod()]
        public void GetProfessionnelsTest_RecuperationsOK()
        {
            //Arrange
            List<Professionnel> lesPros = context.Professionnels.ToList();
            // Act
            var res = controller.GetProfessionnels().Result;
            // Assert
            Assert.IsNotNull(res);
            CollectionAssert.AreEqual(lesPros, res.Value.ToList(), "Les listes de professionnel ne sont pas identiques");
        }

        [TestMethod()]
        public void GetProfessionnelTest_RecuperationOK()
        {
            // Arrange
            Professionnel? pro = context.Professionnels.Find(17);
            // Act
            var res = controller.GetProfessionnel(17).Result;
            // Assert
            Assert.IsNotNull(res.Value);
            Assert.AreEqual(pro, res.Value, "Le prive n'est pas le même");
        }

        [TestMethod()]
        public void GetParametreTest_RecuperationFailed()
        {
            // Arrange
            Prive? pri = context.Prives.Find(17);
            // Act
            var res = controller.GetProfessionnel(18).Result;
            // Assert
            Assert.IsNotNull(res.Value);
            Assert.AreNotEqual(pri, res.Value, "Le professionnel est le même");
        }

        [TestMethod()]
        public void GetParametreTest_EquipementNExistePas()
        {
            var res = controller.GetProfessionnel(777777777).Result;
            // Assert
            Assert.IsNull(res.Result, "Le professionnel existe");
            Assert.IsNull(res.Value, "Le professionnel existe");
        }

        [TestMethod()]
        public void PostDelete()
        {
            PostProfessionnelTest_CreationOK();
            PutProfessionnelTest_ModificationOK();
            DeleteProfessionnelTest_SuppressionOK();
        }

        public void PostProfessionnelTest_CreationOK()
        {
            // Act
            var result = controller.PostProfessionnel(professionnel).Result;
            // Assert
            var proRecup = controller.GetProfessionnel(professionnel.IdPro).Result;
            professionnel.IdPro = proRecup.Value.IdPro;
            Assert.AreEqual(professionnel, proRecup.Value, "professionnel pas identiques");
        }

        public void PutProfessionnelTest_ModificationOK()
        {
            // Arrange
            var proIni = controller.GetProfessionnel(professionnel.IdPro).Result;
            proIni.Value.NomCompagnie = "non";

            // Act
            var res = controller.PutProfessionnel(professionnel.IdPro, proIni.Value).Result;

            // Assert
            var proMaj = controller.GetProfessionnel(professionnel.IdPro).Result;
            Assert.IsNotNull(proMaj.Value);
            Assert.AreEqual(proIni.Value, proMaj.Value, "professionel pas identiques");
        }

        public void DeleteProfessionnelTest_SuppressionOK()
        {
            // Act
            var proSuppr = controller.GetProfessionnel(professionnel.IdPro).Result;
            _ = controller.DeleteProfessionnel(professionnel.IdPro).Result;

            // Assert
            var res = controller.GetProfessionnel(professionnel.IdPro).Result;
            Assert.IsNull(res.Value, "professionnel non supprimé");
        }
    }
}