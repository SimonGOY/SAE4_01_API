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
    public class TelephonesControllerTests
    {
        private TelephonesController controller;
        private BMWDBContext context;
        private IDataRepository<Telephone> dataRepository;
        private Telephone telephone;

        [TestInitialize]
        public void InitTest()
        {
            var builder = new DbContextOptionsBuilder<BMWDBContext>().UseNpgsql("Server=51.83.36.122; port=5432; Database=sa11; uid=sa11; password=BMW-S4; SearchPath=bmw;");
            context = new BMWDBContext(builder.Options);
            dataRepository = new TelephoneManager(context);
            controller = new TelephonesController(dataRepository);

            telephone = new Telephone
            {
                Id = 666666666,
                IdClient = 1,
                NumTelephone = "0666666666",
                Type = "Mobile",
                Fonction = "Professionnel"
            };

        }

        [TestMethod()]
        public void GetTelephonesTest()
        {
            //Arrange
            List<Telephone> lesTels = context.Telephones.ToList();
            // Act
            var res = controller.GetTelephones().Result;
            // Assert
            Assert.IsNotNull(res);
            CollectionAssert.AreEqual(lesTels, res.Value.ToList(), "Les listes de telephones ne sont pas identiques");
        }

        [TestMethod()]
        public void GetTelephoneTest()
        {
            // Arrange
            Telephone? tel = context.Telephones.Find(135);
            // Act
            var res = controller.GetTelephone(135).Result;
            // Assert
            Assert.IsNotNull(res.Value);
            Assert.AreEqual(tel, res.Value, "Le telephone n'est pas le même");
        }

        [TestMethod()]
        public void GetTelephoneTest_RecuperationFailed()
        {
            // Arrange
            Telephone? tel = context.Telephones.Find(135);
            // Act
            var res = controller.GetTelephone(136).Result;
            // Assert
            Assert.IsNotNull(res.Value);
            Assert.AreNotEqual(tel, res.Value, "La taille est la même");
        }

        [TestMethod()]
        public void GetTelephoneTest_EquipementNExistePas()
        {
            var res = controller.GetTelephone(777777777).Result;
            // Assert
            Assert.IsNull(res.Result, "Le telephone existe");
            Assert.IsNull(res.Value, "Le tlephone existe");
        }

        [TestMethod()]
        public void PostUpdateDelete()
        {
            PostTelephoneTest_CreationOK();
            PutTelephoneTest_ModificationOK();
            DeleteTelephoneTest_SuppressionOK();
        }

        public void PostTelephoneTest_CreationOK()
        {
            // Act
            var result = controller.PostTelephone(telephone).Result;
            // Assert
            var telRecup = controller.GetTelephone(telephone.Id).Result;
            telephone.Id = telRecup.Value.Id;
            Assert.AreEqual(telephone, telRecup.Value, "telephone pas identiques");
        }

        public void PutTelephoneTest_ModificationOK()
        {
            // Arrange
            var telIni = controller.GetTelephone(telephone.Id).Result;
            telIni.Value.Type = "Fixe";

            // Act
            var res = controller.PutTelephone(telephone.Id, telIni.Value).Result;

            // Assert
            var telMaj = controller.GetTelephone(telephone.Id).Result;
            Assert.IsNotNull(telMaj.Value);
            Assert.AreEqual(telIni.Value, telMaj.Value, "telephone pas identiques");
        }

        public void DeleteTelephoneTest_SuppressionOK()
        {
            // Act
            var telSuppr = controller.GetTelephone(telephone.Id).Result;
            _ = controller.DeleteTelephone(telephone.Id).Result;

            // Assert
            var res = controller.GetTelephone(telephone.Id).Result;
            Assert.IsNull(res.Value, "telephone non supprimé");
        }
    }
}