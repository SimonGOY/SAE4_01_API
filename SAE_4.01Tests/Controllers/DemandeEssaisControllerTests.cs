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
    public class DemandeEssaisControllerTests
    {
        private DemandeEssaisController controller;
        private BMWDBContext context;
        private IDataRepository<DemandeEssai> dataRepository;
        private DemandeEssai demande;

        [TestInitialize]
        public void InitTest()
        {
            var builder = new DbContextOptionsBuilder<BMWDBContext>().UseNpgsql("Server=51.83.36.122; port=5432; Database=sa11; uid=sa11; password=BMW-S4; SearchPath=bmw;");
            context = new BMWDBContext(builder.Options);
            dataRepository = new DemandeEssaiManager(context);
            controller = new DemandeEssaisController(dataRepository);

            demande = new DemandeEssai
            {
                IdDemandeEssai = 1,
                IdConcessionnaire = 1,
                IdMoto = 1,
                IdContact = 1,
                DescriptifDemandeEssai = "J'aimerais essayer la moto pour voir s'il le siège permet la possibilité de se chier dessus tout en gardant une expérience confortable :)"
            };
        }

        [TestMethod()]
        public void GetDemandeEssaisTest_RecuperationsOK()
        {
            //Arrange
            List<DemandeEssai> lesDems = context.DemandeEssais.ToList();
            // Act
            var res = controller.GetDemandeEssais().Result;
            // Assert
            Assert.IsNotNull(res);
            CollectionAssert.AreEqual(lesDems, res.Value.ToList(), "Les listes de demandes ne sont pas identiques");
        }

        [TestMethod()]
        public void GetDemandeEssaiTest_RecuperationOK()
        {
            // Arrange
            DemandeEssai? dem = context.DemandeEssais.Find(2);
            // Act
            var res = controller.GetDemandeEssai(2).Result;
            // Assert
            Assert.IsNotNull(res.Value);
            Assert.AreEqual(dem, res.Value, "La demande n'est pas la même");
        }

        [TestMethod()]
        public void GetDemandeEssaiTest_RecuperationFailed()
        {
            // Arrange
            DemandeEssai? dem = context.DemandeEssais.Find(20);
            // Act
            var res = controller.GetDemandeEssai(2).Result;
            // Assert
            Assert.IsNotNull(res.Value);
            Assert.AreNotEqual(dem, res.Value, "La demande est la même");
        }

        [TestMethod()]
        public void GetDemandeTest_DemandeNExistePas()
        {
            var res = controller.GetDemandeEssai(777777777).Result;
            // Assert
            Assert.IsNull(res.Result, "La demande existe");
            Assert.IsNull(res.Value, "La demande existe");
        }

        [TestMethod()]
        public void __PostDemandeEssaiTest_CreationOK()
        {
            // Act
            var result = controller.PostDemandeEssai(demande).Result;
            // Assert
            var demRecup = controller.GetDemandeEssai(demande.IdDemandeEssai).Result;
            demande.IdDemandeEssai = demRecup.Value.IdDemandeEssai;
            Assert.AreEqual(demande, demRecup.Value, "Demandes pas identiques");
        }

        [TestMethod()]
        public void __PutDemandeEssaiTest_ModificationOK()
        {
            // Arrange
            var demIni = controller.GetDemandeEssai(demande.IdDemandeEssai).Result;
            demIni.Value.DescriptifDemandeEssai = "J'aimerais essayer parce que j'ai envie";

            // Act
            var res = controller.PutDemandeEssai(demande.IdDemandeEssai, demIni.Value).Result;

            // Assert
            var demMaj = controller.GetDemandeEssai(demande.IdDemandeEssai).Result;
            Assert.IsNotNull(demMaj.Value);
            Assert.AreEqual(demIni.Value, demMaj.Value, "demandes pas identiques");
        }

        [TestMethod()]
        public void DeleteDemandeEssaiTest_SuppressionOK()
        {
            // Act
            var demSuppr = controller.GetDemandeEssai(demande.IdDemandeEssai).Result;
            _ = controller.DeleteDemandeEssai(demande.IdDemandeEssai).Result;

            // Assert
            var res = controller.GetDemandeEssai(demande.IdDemandeEssai).Result;
            Assert.IsNull(res.Value, "couleur non supprimé");
        }
    }
}