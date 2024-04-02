using Microsoft.AspNetCore.Mvc;
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
    public class CouleursControllerTests
    {
        private CouleursController controller;
        private BMWDBContext context;
        private IDataRepository<Couleur> dataRepository;
        private Couleur couleur;

        [TestInitialize]
        public void InitTest()
        {
            var builder = new DbContextOptionsBuilder<BMWDBContext>().UseNpgsql("Server=51.83.36.122; port=5432; Database=sa11; uid=sa11; password=BMW-S4; SearchPath=bmw;");
            context = new BMWDBContext(builder.Options);
            dataRepository = new CouleurManager(context);
            controller = new CouleursController(dataRepository);

            couleur = new Couleur
            {
                IdCouleur = 666666666,
                IdMoto = 1,
                NomCouleur = "Bleu bébé",
                PrixCouleur = 6.66,
                DescriptionCouleur = "Un bleu pour les gros bb",
                MotoCouleur = "cloud.leparking-moto.fr/2021/10/10/04/30/piaggio-vespa-vespa-piaggio-lx-150_158906857.jpg",
                PhotoCouleur = "rachel-plantier.fr/106/baby-blue.jpg"
            };
        }

        [TestMethod()]
        public void GetCouleursTest_RecuperationsOK()
        {
            // Arrange
            Couleur? cou = context.Couleurs.Find(1);
            // Act
            var res = controller.GetCouleur(1).Result;
            // Assert
            Assert.IsNotNull(res);
            Assert.AreEqual(cou, res.Value, "La couleur n'est pas la même");
        }

        [TestMethod()]
        public void GetCouleurTest_RecuperationOK()
        {
            // Arrange
            Couleur? cou = context.Couleurs.Find(1);
            // Act
            var res = controller.GetCouleur(1).Result;
            // Assert
            Assert.IsNotNull(res);
            Assert.AreEqual(cou, res.Value, "La couleur n'est pas la même");
        }

        [TestMethod()]
        public void GetCouleurTest_RecuperationFailed()
        {
            // Arrange
            ContactInfo? cou = context.ContactInfos.Find(1);
            // Act
            var res = controller.GetCouleur(2).Result;
            // Assert
            Assert.IsNotNull(res);
            Assert.AreNotEqual(cou, res.Value, "La couleur est la même");
        }

        [TestMethod()]
        public void GetCouleurTest_CouleurNExistePas()
        {
            var res = controller.GetCouleur(777777777).Result;
            // Assert
            Assert.IsNull(res.Result, "La couleur existe");
            Assert.IsNull(res.Value, "La couleur existe");
        }

        [TestMethod()]
        public void PostCouleurTest_CreationOK()
        {
            // Act
            var result = controller.PostCouleur(couleur).Result;
            // Assert
            var couRecup = controller.GetCouleur(couleur.IdCouleur).Result;
            couleur.IdCouleur = couRecup.Value.IdCouleur;
            Assert.AreEqual(couleur, couRecup.Value, "Couleur pas identiques");
        }

        /*[TestMethod()]
        public void PutCouleurTest_ModificationOK()
        {
            // Arrange
            var couIni = controller.GetCouleur(couleur.IdCouleur).Result;
            couIni.Value.PrixCouleur = 9.99;

            // Act
            var res = controller.PutCouleur(couleur.IdCouleur, couIni.Value).Result;

            // Assert
            var couMaj = controller.GetCouleur(couleur.IdCouleur).Result;
            Assert.IsNotNull(couMaj.Value);
            Assert.AreEqual(couIni.Value, couMaj.Value, "couleurs pas identiques");
        }*/

        [TestMethod()]
        public void ZDeleteCouleurTest()
        {
            // Act
            var couSuppr = controller.GetCouleur(couleur.IdCouleur).Result;
            _ = controller.DeleteCouleur(couleur.IdCouleur).Result;

            // Assert
            var res = controller.GetCouleur(couleur.IdCouleur).Result;
            Assert.IsNull(res.Value, "couleur non supprimé");
        }
    }
}