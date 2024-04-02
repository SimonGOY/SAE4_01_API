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
    public class CaracteristiquesControllerTests
    {
        private CaracteristiquesController controller;
        private BMWDBContext context;
        private IDataRepository<Caracteristique> dataRepository;
        private Caracteristique caracteristique;


        [TestInitialize]
        public void InitTest()
        {
            var builder = new DbContextOptionsBuilder<BMWDBContext>().UseNpgsql("Server=51.83.36.122; port=5432; Database=sa11; uid=sa11; password=BMW-S4; SearchPath=bmw;");
            context = new BMWDBContext(builder.Options);
            dataRepository = new CaracteristiqueManager(context);
            controller = new CaracteristiquesController(dataRepository);

            caracteristique = new Caracteristique
            {
                IdCaracteristique = 666666666,
                IdMoto = 1,
                IdCatCaracteristique = 1,
                NomCaracteristique = "Pare-Choc",
                ValeurCaracteristique = "Pare-choc rembouré en plumes, coton et botox"
            };
        }

        [TestMethod()]
        public void GetCaracteristiquesTest_RecuperationOK()
        {
            //Arrange
            List<Caracteristique> lesCars = context.Caracteristiques.ToList();
            // Act
            var res = controller.GetCaracteristiques().Result;
            // Assert
            Assert.IsNotNull(res);
            CollectionAssert.AreEqual(lesCars, res.Value.ToList(), "Les listes de caracteristiques ne sont pas identiques");
        }

        [TestMethod()]
        public void GetCaracteristiqueTest_RecuperationOK()
        {
            // Arrange
            Caracteristique? car = context.Caracteristiques.Find(1);
            // Act
            var res = controller.GetCaracteristique(1).Result;
            // Assert
            Assert.IsNotNull(res);
            Assert.AreEqual(car, res.Value, "La caractéristique n'est pas le même");
        }

        [TestMethod()]
        public void PostCaracteristiqueTest_CreationOK()
        {
            // Act
            var result = controller.PostCaracteristique(caracteristique).Result;
            // Assert
            var carRecup = controller.GetCaracteristique(caracteristique.IdCaracteristique).Result;
            caracteristique.IdCaracteristique = carRecup.Value.IdCaracteristique;
            Assert.AreEqual(caracteristique, carRecup.Value, "Caractéristiques pas identiques"); ;
        }

        /*[TestMethod()]
        public void PutCaracteristiqueTest_ModificationOK()
        {
            // Arrange
            var carIni = controller.GetCaracteristique(caracteristique.IdCaracteristique).Result;
            carIni.Value.NomCaracteristique = "CAR CLONE N°" + 2;

            // Act
            var res = controller.PutCaracteristique(caracteristique.IdCaracteristique, carIni.Value).Result;

            // Assert
            var carMaj = controller.GetCaracteristique(caracteristique.IdCaracteristique).Result;
            Assert.IsNotNull(carMaj.Value);
            Assert.AreEqual(carIni.Value, carMaj.Value, "Caractéristiques pas identiques");
        }*/

        [TestMethod()]
        public void ZDeleteCaracteristiqueTest()
        {
            // Act
            var carSuppr = controller.GetCaracteristique(caracteristique.IdCaracteristique).Result;
            _ = controller.DeleteCaracteristique(carSuppr.Value.IdCaracteristique).Result;

            // Assert
            var res = controller.GetCaracteristique (caracteristique.IdCaracteristique).Result;
            Assert.IsNull(res.Value, "caracteristique non supprimé");
        }
    }
}