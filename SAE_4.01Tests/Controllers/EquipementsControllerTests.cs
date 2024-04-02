﻿using Microsoft.EntityFrameworkCore;
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
    public class EquipementsControllerTests
    {
        private EquipementsController controller;
        private BMWDBContext context;
        private IDataRepository<Equipement> dataRepository;
        private Equipement equipement;

        [TestInitialize]
        public void InitTest()
        {
            var builder = new DbContextOptionsBuilder<BMWDBContext>().UseNpgsql("Server=51.83.36.122; port=5432; Database=sa11; uid=sa11; password=BMW-S4; SearchPath=bmw;");
            context = new BMWDBContext(builder.Options);
            dataRepository = new EquipementManager(context);
            controller = new EquipementsController(dataRepository);

            equipement = new Equipement
            {
                IdEquipement = 666666666,
                IdCatEquipement = 1,
                NomEquipement = "Gant",
                DescriptionEquipement = "Ce sont des gants",
                SexeEquipement = "uni",
                PrixEquipement = 88.00f,
                DureeGarantie = 0,
                Tendance = true,
                Segment = "Sport",
                IdCollection = 1

            };
        }

        [TestMethod()]
        public void GetEquipementsTest()
        {
            //Arrange
            List<Equipement> lesEqus = context.Equipements.ToList();
            // Act
            var res = controller.GetEquipements().Result;
            // Assert
            Assert.IsNotNull(res);
            CollectionAssert.AreEqual(lesEqus, res.Value.ToList(), "Les listes de couleurs ne sont pas identiques");
        }

        [TestMethod()]
        public void GetEquipementTest()
        {
            // Arrange
            Equipement? dem = context.Equipements.Find(1);
            // Act
            var res = controller.GetEquipement(1).Result;
            // Assert
            Assert.IsNotNull(res.Value);
            Assert.AreEqual(dem, res.Value, "L' equipement n'est pas le même");
        }

        [Priority(2)]
        [TestMethod()]
        public void __PostEquipementTest_CreationOK()
        {
            // Act
            var result = controller.PostEquipement(equipement).Result;
            // Assert
            var demRecup = controller.GetEquipement(equipement.IdEquipement).Result;
            equipement.IdEquipement = demRecup.Value.IdEquipement;
            Assert.AreEqual(equipement, demRecup.Value, "Equipements pas identiques");
        }

        [Priority(0)]
        [TestMethod()]
        public void _PutEquipementTest_ModificationOK()
        {
            // Arrange
            var equIni = controller.GetEquipement(equipement.IdEquipement).Result;
            equIni.Value.PrixEquipement = 4.50f;

            // Act
            var res = controller.PutEquipement(equipement.IdEquipement, equIni.Value).Result;

            // Assert
            var equMaj = controller.GetEquipement(equipement.IdEquipement).Result;
            Assert.IsNotNull(equMaj.Value);
            Assert.AreEqual(equIni.Value, equMaj.Value, "equipements pas identiques");
        }

        
        [TestMethod()]
        public void DeleteEquipementTest_SuppressionOK()
        {
            // Act
            var equSuppr = controller.GetEquipement(equipement.IdEquipement).Result;
            _ = controller.DeleteEquipement(equipement.IdEquipement).Result;

            // Assert
            var res = controller.GetEquipement(equipement.IdEquipement).Result;
            Assert.IsNull(res.Value, "equipement non supprimé");
        }
    }
}