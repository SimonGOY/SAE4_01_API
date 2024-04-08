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
using System.Security.Cryptography.Pkcs;
using System.Text;
using System.Threading.Tasks;

namespace SAE_4._01.Controllers.Tests
{
    [TestClass()]
    public class ContenuCommandesControllerTests
    {
        private ContenuCommandesController controller;
        private BMWDBContext context;
        private IDataRepository<ContenuCommande> dataRepository;
        private ContenuCommande contenuCommande;
        private Mock<IDataRepository<ContenuCommande>> mockRepository;
        private ContenuCommandesController controller_mock;

        [TestInitialize]
        public void ContenuCommandesControllerTest()
        {
            var builder = new DbContextOptionsBuilder<BMWDBContext>().UseNpgsql("Server=51.83.36.122; port=5432; Database=sa11; uid=sa11; password=BMW-S4; SearchPath=bmw;");
            context = new BMWDBContext(builder.Options);
            dataRepository = new ContenuCommandeManager(context);
            controller = new ContenuCommandesController(dataRepository);
            mockRepository = new Mock<IDataRepository<ContenuCommande>>();
            controller_mock = new ContenuCommandesController(mockRepository.Object);

            contenuCommande = new ContenuCommande
            {
                IdCommande = 1,
                IdColoris = 1,
                IdEquipement = 1,
                IdTaille = 1,
                Quantite = 5,
            };
        }

        [TestMethod()]
        public void GetContenuCommandesTest_RecuperationsOK()
        {
            //Arrange
            List<ContenuCommande> lesCons = context.ContenuCommandes.ToList();
            // Act
            var res = controller.GetContenuCommandes().Result;
            // Assert
            Assert.IsNotNull(res);
            CollectionAssert.AreEqual(lesCons, res.Value.ToList(), "Les listes de contenucommandes ne sont pas identiques");
        }

        [TestMethod()]
        public void GetByIdCommandeTest_RecuperationOK()
        {
            // Arrange
            var contenuCommande = controller.GetByIds(3, 3, 2, 1).Result;
            // Act
            var res = controller.GetByIds(3,3,2,1).Result;
            // Assert
            Assert.IsNotNull(res.Value);
            Assert.AreEqual(contenuCommande.Value, res.Value, "Le contenucommande n'est pas le même");
        }

        [TestMethod()]
        public void GetContenuCommandeTest_RecuperationFailed()
        {
            // Arrange
            var contenuCommande = controller.GetByIds(3,3,2,1).Result;
            // Act
            var res = controller.GetByIds(2, 2, 2, 1).Result;
            // Assert
            Assert.IsNotNull(res.Value);
            Assert.AreNotEqual(contenuCommande, res.Value, "Le contenucommande est le même");
        }

        [TestMethod()]
        public void GetContenuCommandeTest_ContenuNExistePas()
        {
            var res = controller.GetByIds(777777777, 2, 2, 2).Result;
            // Assert
            Assert.IsNull(res.Result, "Le contenu existe");
            Assert.IsNull(res.Value, "Le contenu existe");
        }

        [TestMethod()]
        public void PostPutDeleteTest()
        {
            PostContenuCommandeTest_CreationOK();
            PutContenuCommandeTest_ModificationOK();
            DeleteContenuCommandeTest_SuppressionOK();
        }

        public void PostContenuCommandeTest_CreationOK()
        {
            // Act
            var result = controller.PostContenuCommande(contenuCommande).Result;
            // Assert
            var conRecup = controller.GetByIds(contenuCommande.IdCommande, contenuCommande.IdEquipement, contenuCommande.IdTaille, contenuCommande.IdColoris).Result;
            contenuCommande.IdCommande = conRecup.Value.IdCommande;
            contenuCommande.IdEquipement = conRecup.Value.IdEquipement;
            contenuCommande.IdTaille = conRecup.Value.IdTaille;
            contenuCommande.IdColoris = conRecup.Value.IdColoris;
            Assert.AreEqual(contenuCommande, conRecup.Value, "Contenucommandes pas identiques");
        }

        public void PutContenuCommandeTest_ModificationOK()
        {
            // Arrange
            var conIni = controller.GetByIds(contenuCommande.IdCommande, contenuCommande.IdEquipement, contenuCommande.IdTaille, contenuCommande.IdColoris).Result;
            conIni.Value.Quantite = 6;

            // Act
            var res = controller.PutContenuCommande(contenuCommande.IdCommande, contenuCommande.IdEquipement, contenuCommande.IdTaille, contenuCommande.IdColoris, conIni.Value).Result;

            // Assert
            var conMaj = controller.GetByIds(contenuCommande.IdCommande, contenuCommande.IdEquipement, contenuCommande.IdTaille, contenuCommande.IdColoris).Result;
            Assert.IsNotNull(conMaj.Value);
            Assert.AreEqual(conIni.Value, conMaj.Value, "Contenucommandes pas identiques");
        }

        public void DeleteContenuCommandeTest_SuppressionOK()
        {
            // Act
            var conSuppr = controller.GetByIds(contenuCommande.IdCommande, contenuCommande.IdEquipement, contenuCommande.IdTaille, contenuCommande.IdColoris).Result;
            _ = controller.DeleteContenuCommande(contenuCommande.IdCommande, contenuCommande.IdEquipement, contenuCommande.IdTaille, contenuCommande.IdColoris).Result;

            // Assert
            var res = controller.GetByIds(contenuCommande.IdCommande, contenuCommande.IdEquipement, contenuCommande.IdTaille, contenuCommande.IdColoris).Result;
            Assert.IsNull(res.Value, "contact non supprimé");
        }

        // ---------------------------------------- Tests Moq ----------------------------------------

        [TestMethod()]
        public void Moq_GetContenuCommandesTest_RecuperationOK()
        {
            // Arrange
            var commande = new List<ContenuCommande>
                {
                    contenuCommande
                };
            mockRepository.Setup(x => x.GetAllAsync()).ReturnsAsync(commande);
            // Act
            var res = controller_mock.GetContenuCommandes().Result;
            // Assert
            Assert.IsNotNull(res);
            Assert.IsNotNull(res.Value);
            Assert.AreEqual(commande, res.Value as IEnumerable<ContenuCommande>, "La liste n'est pas le même");
        }

        [TestMethod()]
        public void Moq_GetByIdCommandeTest_RecuperationOK()
        {
            // Arrange
            List<ContenuCommande> commande = new List<ContenuCommande>
                {
                    contenuCommande
                };
            mockRepository.Setup(x => x.GetByIdCommandeAsync(1)).ReturnsAsync(commande);

            // Act
            var res = controller_mock.GetByIdCommande(1).Result;

            // Assert
            Assert.IsNotNull(res);
            Assert.IsNotNull(res.Result);
            var res_cast = ((Microsoft.AspNetCore.Mvc.ActionResult<System.Collections.Generic.IEnumerable<SAE_4._01.Models.EntityFramework.ContenuCommande>>)((Microsoft.AspNetCore.Mvc.ObjectResult)res.Result).Value).Value;
            Assert.AreEqual(commande, res_cast as IEnumerable<ContenuCommande>, "La commande n'est pas le même");
        }

        [TestMethod()]
        public void Moq_GetByIdCommandeTest_RecuperationNonOK()
        {
            // Act
            var res = controller_mock.GetByIdCommande(0).Result;

            // Assert
            Assert.IsInstanceOfType(res.Result, typeof(NotFoundResult));
        }
    }
}