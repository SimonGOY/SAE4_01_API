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
    public class PreferesControllerTests
    {
        private PreferesController controller;
        private BMWDBContext context;
        private IDataRepository<Prefere> dataRepository;
        private Prefere prefere;

        [TestInitialize]
        public void InitTest()
        {
            var builder = new DbContextOptionsBuilder<BMWDBContext>().UseNpgsql("Server=51.83.36.122; port=5432; Database=sa11; uid=sa11; password=BMW-S4; SearchPath=bmw;");
            context = new BMWDBContext(builder.Options);
            dataRepository = new PrefereManager(context);
            controller = new PreferesController(dataRepository);

            prefere = new Prefere()
            {
                IdClient = 75,
                IdConcessionnaire = 2,
            };

        }

        [TestMethod()]
        public void GetPreferesTest_RecuperationsOK()
        {
            //Arrange
            List<Prefere> lesPres = context.Preferes.ToList();
            // Act
            var res = controller.GetPreferes().Result;
            // Assert
            Assert.IsNotNull(res);
            CollectionAssert.AreEqual(lesPres, res.Value.ToList(), "Les listes de prefere ne sont pas identiques");
        }

        [TestMethod()]
        public void GetByIdsTest_RecuperationOK()
        {
            // Arrange
            var pre = context.Preferes.Find(1, 1);
            // Act
            var res = controller.GetByIds(1, 1).Result;
            // Assert
            Assert.IsNotNull(res.Value);
            Assert.AreEqual(pre, res.Value, "Le prefere n'est pas le même");
        }

        [TestMethod()]
        public void GetByIdsTest_RecuperationFailed()
        {
            // Arrange
            var pre = controller.GetByIds(1, 1).Result;
            // Act
            var res = controller.GetByIds(2, 2).Result;
            // Assert
            Assert.IsNotNull(res.Value);
            Assert.AreNotEqual(pre, res.Value, "Le estLie est le même");
        }

        [TestMethod()]
        public void GetByIdsTest_estInclusNExistePas()
        {
            var res = controller.GetByIds(777777777, 1).Result;
            // Assert
            Assert.IsNull(res.Result, "Le estLie existe");
            Assert.IsNull(res.Value, "Le estLie existe");
        }

        [TestMethod()]
        public void PostDelete()
        {
            PostPrefereTest_CreationOK();
            DeletePrefereTest_SuppressionOK();
        }

        
        public void PostPrefereTest_CreationOK()
        {
            // Act
            var result = controller.PostPrefere(prefere).Result;
            // Assert
            var preRecup = controller.GetByIds(prefere.IdClient, prefere.IdConcessionnaire).Result;
            prefere.IdClient = preRecup.Value.IdClient;
            prefere.IdConcessionnaire = preRecup.Value.IdConcessionnaire;
            Assert.AreEqual(prefere, preRecup.Value, "prefere pas identiques");
        }

        public void DeletePrefereTest_SuppressionOK()
        {
            // Act
            var preSuppr = controller.GetByIds(prefere.IdClient, prefere.IdConcessionnaire).Result;
            _ = controller.DeletePrefere(prefere.IdClient, prefere.IdConcessionnaire).Result;

            // Assert
            var res = controller.GetByIds(prefere.IdClient, prefere.IdConcessionnaire).Result;
            Assert.IsNull(res.Value, "prefere non supprimé");
        }
    }
}