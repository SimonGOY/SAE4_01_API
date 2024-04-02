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
    public class ContenuCommandesControllerTests
    {
        private ContenuCommandesController controller;
        private BMWDBContext context;
        private IDataRepository<ContenuCommande> dataRepository;
        private ContenuCommande con;

        [TestInitialize]
        public void ContenuCommandesControllerTest()
        {
            var builder = new DbContextOptionsBuilder<BMWDBContext>().UseNpgsql("Server=51.83.36.122; port=5432; Database=sa11; uid=sa11; password=BMW-S4; SearchPath=bmw;");
            context = new BMWDBContext(builder.Options);
            dataRepository = new ContenuCommandeManager(context);
            controller = new ContenuCommandesController(dataRepository);

            con = new ContenuCommande
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
            ContenuCommande? con = context.ContenuCommandes.Find(1,1,1,1);
            // Act
            var res = controller.GetByIds(1,1,1,1).Result;
            // Assert
            Assert.IsNotNull(res);
            Assert.AreEqual(con, res.Value, "Le contenucommande n'est pas le même");
        }

        [TestMethod()]
        public void GetContenuCommandeTest_RecuperationFailed()
        {
            // Arrange
            ContenuCommande? con = context.ContenuCommandes.Find(1,1,1,1);
            // Act
            var res = controller.GetByIds(2, 2, 2, 2).Result;
            // Assert
            Assert.IsNotNull(res);
            Assert.AreNotEqual(con, res.Value, "Le contenucommande est le même");
        }

        [TestMethod()]
        public void GetContenuCommandeTest_CollecNExistePas()
        {
            var res = controller.GetByIds(777777777, 2, 2, 2).Result;
            // Assert
            Assert.IsNull(res.Result, "Le contenu existe");
            Assert.IsNull(res.Value, "Le contenu existe");
        }

        [TestMethod()]
        public void PostContenuCommandeTest()
        {
            // Act
            var result = controller.PostContenuCommande(con).Result;
            // Assert
            var conRecup = controller.GetByIds(con.IdCommande, con.IdEquipement, con.IdTaille, con.IdColoris).Result;
            con.IdCommande = conRecup.Value.IdCommande;
            con.IdEquipement = conRecup.Value.IdEquipement;
            con.IdTaille = conRecup.Value.IdTaille;
            con.IdColoris = conRecup.Value.IdColoris;
            Assert.AreEqual(con, conRecup.Value, "Contenucommandes pas identiques");
        }

        [TestMethod()]
        public void PutContenuCommandeTest()
        {
            // Arrange
            var conIni = controller.GetByIds(con.IdCommande, con.IdEquipement, con.IdTaille, con.IdColoris).Result;
            conIni.Value.Quantite = 6;

            // Act
            var res = controller.PutContenuCommande(con.IdCommande, con.IdEquipement, con.IdTaille, con.IdColoris, conIni.Value).Result;

            // Assert
            var conMaj = controller.GetByIds(con.IdCommande, con.IdEquipement, con.IdTaille, con.IdColoris).Result;
            Assert.IsNotNull(conMaj.Value);
            Assert.AreEqual(conIni.Value, conMaj.Value, "Contenucommandes pas identiques");
        }

        [TestMethod()]
        public void ZDeleteContenuCommandeTest()
        {
            // Act
            var conSuppr = controller.GetByIds(con.IdCommande, con.IdEquipement, con.IdTaille, con.IdColoris).Result;
            _ = controller.DeleteContenuCommande(con.IdCommande, con.IdEquipement, con.IdTaille, con.IdColoris).Result;

            // Assert
            var res = controller.GetByIds(con.IdCommande, con.IdEquipement, con.IdTaille, con.IdColoris).Result;
            Assert.IsNull(res.Value, "contact non supprimé");
        }
    }
}