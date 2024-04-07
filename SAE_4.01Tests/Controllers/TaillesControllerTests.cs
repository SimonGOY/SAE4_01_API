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
    public class TaillesControllerTests
    {
        private TaillesController controller;
        private BMWDBContext context;
        private IDataRepository<Taille> dataRepository;
        private Taille taille;

        [TestInitialize]
        public void InitTest()
        {
            var builder = new DbContextOptionsBuilder<BMWDBContext>().UseNpgsql("Server=51.83.36.122; port=5432; Database=sa11; uid=sa11; password=BMW-S4; SearchPath=bmw;");
            context = new BMWDBContext(builder.Options);
            dataRepository = new TailleManager(context);
            controller = new TaillesController(dataRepository);

            taille = new Taille
            {
                IdTaille = 666666666,
                DescTaille = "Enorme",
                LibelleTaille = "XXXL"
            };
        }

        [TestMethod()]
        public void GetTaillesTest_RecuperationsOK()
        {
            //Arrange
            List<Taille> lesTais = context.Tailles.ToList();
            // Act
            var res = controller.GetTailles().Result;
            // Assert
            Assert.IsNotNull(res);
            CollectionAssert.AreEqual(lesTais, res.Value.ToList(), "Les listes de tailles ne sont pas identiques");
        }

        [TestMethod()]
        public void GetTailleTest_RecuperationOK()
        {
            // Arrange
            Taille? tai = context.Tailles.Find(1);
            // Act
            var res = controller.GetTaille(1).Result;
            // Assert
            Assert.IsNotNull(res.Value);
            Assert.AreEqual(tai, res.Value, "La taille n'est pas la même");
        }

        [TestMethod()]
        public void GetTailleTest_RecuperationFailed()
        {
            // Arrange
            Taille? tai = context.Tailles.Find(1);
            // Act
            var res = controller.GetTaille(2).Result;
            // Assert
            Assert.IsNotNull(res.Value);
            Assert.AreNotEqual(tai, res.Value, "La taille est la même");
        }

        [TestMethod()]
        public void GetTailleTest_EquipementNExistePas()
        {
            var res = controller.GetTaille(777777777).Result;
            // Assert
            Assert.IsNull(res.Result, "La taille existe");
            Assert.IsNull(res.Value, "La taille existe");
        }

        [TestMethod()]
        public void PostUpdateDelete()
        {
            PostTailleTest_CreationOK();
            PutTailleTest_ModificationOK();
            DeleteTailleTest_SuppressionOK();
        }

        
        public void PostTailleTest_CreationOK()
        {
            // Act
            var result = controller.PostTaille(taille).Result;
            // Assert
            var taiRecup = controller.GetTaille(taille.IdTaille).Result;
            taille.IdTaille = taiRecup.Value.IdTaille;
            Assert.AreEqual(taille, taiRecup.Value, "professionnel pas identiques");
        }

        
        public void PutTailleTest_ModificationOK()
        {
            // Arrange
            var taiIni = controller.GetTaille(taille.IdTaille).Result;
            taiIni.Value.DescTaille = "nom";

            // Act
            var res = controller.PutTaille(taille.IdTaille, taiIni.Value).Result;

            // Assert
            var taiMaj = controller.GetTaille(taille.IdTaille).Result;
            Assert.IsNotNull(taiMaj.Value);
            Assert.AreEqual(taiIni.Value, taiMaj.Value, "tailles pas identiques");
        }

        
        public void DeleteTailleTest_SuppressionOK()
        {
            // Act
            var taiSuppr = controller.GetTaille(taille.IdTaille).Result;
            _ = controller.DeleteTaille(taille.IdTaille).Result;

            // Assert
            var res = controller.GetTaille(taille.IdTaille).Result;
            Assert.IsNull(res.Value, "taille non supprimé");
        }
    }
}