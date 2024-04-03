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
    public class OptionsControllerTests
    {
        private OptionsController controller;
        private BMWDBContext context;
        private IDataRepository<Option> dataRepository;
        private Option option;

        [TestInitialize]
        public void InitTest()
        {
            var builder = new DbContextOptionsBuilder<BMWDBContext>().UseNpgsql("Server=51.83.36.122; port=5432; Database=sa11; uid=sa11; password=BMW-S4; SearchPath=bmw;");
            context = new BMWDBContext(builder.Options);
            dataRepository = new OptionManager(context);
            controller = new OptionsController(dataRepository);

            option = new Option
            {
                IdOption = 666666666,
                NomOption = "Vidangeage",
                PrixOption = new decimal (2.00),
                DetailOption = "Sucaaaaaaaaaaaaage........... d'huile",
                PhotoOption = "google.com"
            };
        }

        [TestMethod()]
        public void GetOptionsTest_RecuperationsOK()
        {
            //Arrange
            List<Option> lesMots = context.Options.ToList();
            // Act
            var res = controller.GetOptions().Result;
            // Assert
            Assert.IsNotNull(res);
            CollectionAssert.AreEqual(lesMots, res.Value.ToList(), "Les listes de moto dispo ne sont pas identiques");
        }

        [TestMethod()]
        public void GetOptionTest_RecuperationOK()
        {
            // Arrange
            Option? mot = context.Options.Find(1);
            // Act
            var res = controller.GetOption(1).Result;
            // Assert
            Assert.IsNotNull(res.Value);
            Assert.AreEqual(mot, res.Value, "La moto dispo n'est pas la même");
        }

        [TestMethod()]
        public void GetMotoConfigurableTest_RecuperationFailed()
        {
            // Arrange
            Option? opt = context.Options.Find(1);
            // Act
            var res = controller.GetOption(2).Result;
            // Assert
            Assert.IsNotNull(res.Value);
            Assert.AreNotEqual(opt, res.Value, "La moto est la même");
        }

        [TestMethod()]
        public void GetMotoConfigurableTest_EquipementNExistePas()
        {
            var res = controller.GetOption(777777777).Result;
            // Assert
            Assert.IsNull(res.Result, "La moto existe");
            Assert.IsNull(res.Value, "La moto existe");
        }

        [TestMethod()]
        public void PostDeleteTest()
        {
            PostOptionTest_CreationOK();
            PutOptionTest_ModificationOK();
            DeleteOptionTest_SuppressionOK();
        }


        public void PostOptionTest_CreationOK()
        {
            // Act
            var result = controller.PostOption(option).Result;
            // Assert
            var optRecup = controller.GetOption(option.IdOption).Result;
            option.IdOption = optRecup.Value.IdOption;
            Assert.AreEqual(option, optRecup.Value, "option pas identiques");
        }


        public void PutOptionTest_ModificationOK()
        {
            // Arrange
            var optIni = controller.GetOption(option.IdOption).Result;
            optIni.Value.PrixOption= 10000;

            // Act
            var res = controller.PutOption(option.IdOption, optIni.Value).Result;

            // Assert
            var optMaj = controller.GetOption(option.IdOption).Result;
            Assert.IsNotNull(optMaj.Value);
            Assert.AreEqual(optIni.Value, optMaj.Value, "moto pas identiques");
        }

        public void DeleteOptionTest_SuppressionOK()
        {
            // Act
            var optSuppr = controller.GetOption(option.IdOption).Result;
            _ = controller.DeleteOption(option.IdOption).Result;

            // Assert
            var res = controller.GetOption(option.IdOption).Result;
            Assert.IsNull(res.Value, "moto non supprimé");
        }
    }
}