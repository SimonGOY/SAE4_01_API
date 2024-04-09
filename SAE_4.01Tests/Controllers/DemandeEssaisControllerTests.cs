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
    public class DemandeEssaisControllerTests
    {
        private DemandeEssaisController controller;
        private BMWDBContext context;
        private IDataRepository<DemandeEssai> dataRepository;
        private DemandeEssai demande;
        private Mock<IDataRepository<DemandeEssai>> mockRepository;
        private DemandeEssaisController controller_mock;

        [TestInitialize]
        public void InitTest()
        {
            var builder = new DbContextOptionsBuilder<BMWDBContext>().UseNpgsql("Server=51.83.36.122; port=5432; Database=sa11; uid=sa11; password=BMW-S4; SearchPath=bmw;");
            context = new BMWDBContext(builder.Options);
            dataRepository = new DemandeEssaiManager(context);
            controller = new DemandeEssaisController(dataRepository);
            mockRepository = new Mock<IDataRepository<DemandeEssai>>();
            controller_mock = new DemandeEssaisController(mockRepository.Object);

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
        public void PostPutDeleteTest()
        {
            PostDemandeEssaiTest_CreationOK();
            PutDemandeEssaiTest_ModificationOK();
            DeleteDemandeEssaiTest_SuppressionOK();
        }

        
        public void PostDemandeEssaiTest_CreationOK()
        {
            // Act
            var result = controller.PostDemandeEssai(demande).Result;
            // Assert
            var demRecup = controller.GetDemandeEssai(demande.IdDemandeEssai).Result;
            demande.IdDemandeEssai = demRecup.Value.IdDemandeEssai;
            Assert.AreEqual(demande, demRecup.Value, "Demandes pas identiques");
        }

        public void PutDemandeEssaiTest_ModificationOK()
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
        
        public void DeleteDemandeEssaiTest_SuppressionOK()
        {
            // Act
            var demSuppr = controller.GetDemandeEssai(demande.IdDemandeEssai).Result;
            _ = controller.DeleteDemandeEssai(demande.IdDemandeEssai).Result;

            // Assert
            var res = controller.GetDemandeEssai(demande.IdDemandeEssai).Result;
            Assert.IsNull(res.Value, "couleur non supprimé");
        }

        // ---------------------------------------- Tests Moq ----------------------------------------

        [TestMethod()]
        public void Moq_GetDemandeEssaisTest_RecuperationOK()
        {
            // Arrange
            var demandes = new List<DemandeEssai>
                {
                    demande
                };
            mockRepository.Setup(x => x.GetAllAsync()).ReturnsAsync(demandes);

            // Act
            var res = controller_mock.GetDemandeEssais().Result;
            // Assert
            Assert.IsNotNull(res);
            Assert.IsNotNull(res.Value);
            Assert.AreEqual(demandes, res.Value as IEnumerable<DemandeEssai>, "La liste n'est pas le même");
        }

        [TestMethod()]
        public void Moq_GetDemandeEssaiTest_RecuperationOK()
        {
            // Arrange
            mockRepository.Setup(x => x.GetByIdAsync(1).Result).Returns(demande);
            // Act
            var res = controller_mock.GetDemandeEssai(1).Result;
            // Assert
            Assert.IsNotNull(res);
            Assert.IsNotNull(res.Value);
            Assert.AreEqual(demande, res.Value as DemandeEssai, "La demande n'est pas la même");
        }

        [TestMethod()]
        public void Moq_GetDemandeEssaiTest_RecuperationFailed()
        {
            // Act
            var res = controller_mock.GetDemandeEssai(0).Result;
            // Assert
            Assert.IsInstanceOfType(res.Result, typeof(NotFoundResult));
        }

        [TestMethod()]
        public void Moq_PostDemandeEssaiTest()
        {
            // Act
            var actionResult = controller_mock.PostDemandeEssai(demande).Result;
            // Assert
            Assert.IsInstanceOfType(actionResult, typeof(ActionResult<DemandeEssai>), "Pas un ActionResult<DemandeEssai>");
            Assert.IsInstanceOfType(actionResult.Result, typeof(CreatedAtActionResult), "Pas un CreatedAtActionResult");
            var result = actionResult.Result as CreatedAtActionResult;
            Assert.IsInstanceOfType(result.Value, typeof(DemandeEssai), "Pas une DemandeEssai");
            demande.IdDemandeEssai = ((DemandeEssai)result.Value).IdDemandeEssai;
            Assert.AreEqual(demande, (DemandeEssai)result.Value, "DemandeEssai pas identiques");
        }

        [TestMethod]
        public void Moq_DeleteContenuCommandeTest()
        {
            // Arrange
            mockRepository.Setup(x => x.GetByIdAsync(1).Result).Returns(demande);

            // Act
            var actionResult = controller_mock.DeleteDemandeEssai(1).Result;
            // Assert
            Assert.IsInstanceOfType(actionResult, typeof(NoContentResult), "Pas un NoContentResult"); // Test du type de retour
        }

        [TestMethod]
        public void Moq_PutDemandeEssaiTest()
        {
            // Arrange
            mockRepository.Setup(x => x.GetByIdAsync(1).Result).Returns(demande);
            var init = controller_mock.GetDemandeEssai(1).Result;
            init.Value.DescriptifDemandeEssai = "J'aimerais essayer parce que j'ai envie";


            // Act
            var res = controller_mock.PutDemandeEssai(demande.IdDemandeEssai, init.Value).Result;
            var maj = controller_mock.GetDemandeEssai(1).Result;

            // Assert

            Assert.IsNotNull(maj.Value);
            Assert.AreEqual(init.Value, maj.Value, "Valeurs pas identiques");
        }
    }
}