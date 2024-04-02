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
    public class ConcessionnairesControllerTests
    {
        private ConcessionnairesController controller;
        private BMWDBContext context;
        private IDataRepository<Concessionnaire> dataRepository;
        private Concessionnaire con;

        [TestInitialize]
        public void InitTest()
        {
            var builder = new DbContextOptionsBuilder<BMWDBContext>().UseNpgsql("Server=51.83.36.122; port=5432; Database=sa11; uid=sa11; password=BMW-S4; SearchPath=bmw;");
            context = new BMWDBContext(builder.Options);
            dataRepository = new ConcessionnaireManager(context);
            controller = new ConcessionnairesController(dataRepository);

            con = new Concessionnaire
            {
                IdConcessionnaire = 666666666,
                NomConcessionnaire = "Vroum",
                EmailConcessionnaire = "vroum.motorad@gmail.com",
                TelephoneConcessionnaire = "0123456789",
                SiteConcessionnaire = "vroum.fr",
                AdresseConcessionnaire = "42 rue des petits rigolos 69420 Montcul"
            };

            
        }

        [TestMethod()]
        public void GetConcessionnairesTest_RecuperationsOK()
        {
            //Arrange
            List<Concessionnaire> lesCons = context.Concessionnaires.ToList();
            // Act
            var res = controller.GetConcessionnaires().Result;
            // Assert
            Assert.IsNotNull(res);
            CollectionAssert.AreEqual(lesCons, res.Value.ToList(), "Les listes de concessionnaire ne sont pas identiques");
        }

        [TestMethod()]
        public void GetConcessionnaireTest_RecuperationOK()
        {
            // Arrange
            Concessionnaire? con = context.Concessionnaires.Find(1);
            // Act
            var res = controller.GetConcessionnaire(1).Result;
            // Assert
            Assert.IsNotNull(res);
            Assert.AreEqual(con, res.Value, "Le concessionnaire n'est pas la même");
        }

        [TestMethod()]
        public void GetConcessionnaireTest_RecuperationFailed()
        {
            // Arrange
            Concessionnaire? con = context.Concessionnaires.Find(1);
            // Act
            var res = controller.GetConcessionnaire(2).Result;
            // Assert
            Assert.IsNotNull(res);
            Assert.AreNotEqual(con, res.Value, "Le concessionnaire est le même");
        }

        [TestMethod()]
        public void GetConcessionnaireTest_CollecNExistePas()
        {
            var res = controller.GetConcessionnaire(777777777).Result;
            // Assert
            Assert.IsNull(res.Result, "Le concessionnaire existe");
            Assert.IsNull(res.Value, "Le concessionnaire existe");
        }

        [TestMethod()]
        public void PostConcessionnaireTest_CreationOK()
        {
            // Act
            var result = controller.PostConcessionnaire(con).Result;
            // Assert
            var conRecup = controller.GetConcessionnaire(con.IdConcessionnaire).Result;
            con.IdConcessionnaire = conRecup.Value.IdConcessionnaire;
            Assert.AreEqual(con, conRecup.Value, "Concessionnaires pas identiques");
        }

        /*[TestMethod()]
        public void PutConcessionnaireTest()
        {
            // Arrange
            var conIni = controller.GetConcessionnaire(con.IdConcessionnaire).Result;
            conIni.Value.EmailConcessionnaire = "crash.motorad@gmail.gov";

            // Act
            var res = controller.PutConcessionnaire(con.IdConcessionnaire, conIni.Value).Result;

            // Assert
            var conMaj = controller.GetConcessionnaire(con.IdConcessionnaire).Result;
            Assert.IsNotNull(conMaj.Value);
            Assert.AreEqual(conIni.Value, conMaj.Value, "concessionnaire pas identiques");
        }*/

        [TestMethod()]
        public void ZDeleteConcessionnaireTest_SuppressionOK()
        {
            // Act
            var conSuppr = controller.GetConcessionnaire(con.IdConcessionnaire).Result;
            _ = controller.DeleteConcessionnaire(con.IdConcessionnaire).Result;

            // Assert
            var res = controller.GetConcessionnaire(con.IdConcessionnaire).Result;
            Assert.IsNull(res.Value, "concessionnaire non supprimé");
        }
    }
}