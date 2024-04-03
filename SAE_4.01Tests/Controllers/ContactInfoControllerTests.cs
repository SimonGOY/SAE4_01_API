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
using System.Text;
using System.Threading.Tasks;

namespace SAE_4._01.Controllers.Tests
{
    [TestClass()]
    public class ContactInfoControllerTests
    {
        private ContactInfoController controller;
        private BMWDBContext context;
        private IDataRepository<ContactInfo> dataRepository;
        private ContactInfo contactInfo;

        [TestInitialize]
        public void InitTest()
        {
            var builder = new DbContextOptionsBuilder<BMWDBContext>().UseNpgsql("Server=51.83.36.122; port=5432; Database=sa11; uid=sa11; password=BMW-S4; SearchPath=bmw;");
            context = new BMWDBContext(builder.Options);
            dataRepository = new ContactInfoManager(context);
            controller = new ContactInfoController(dataRepository);

            contactInfo = new ContactInfo
            {
                IdContact = 666666666,
                NomContact = "Von Koopa",
                PrenomContact = "Ludwig",
                DateNaissanceContact = new DateTime(1995, 12, 30),
                EmailContact = "musicalturtle@gmail.com",
                TelContact = "0123456789"
            };
        }

        [TestMethod()]
        public void GetContactInfosTest_RecuperationOK()
        {
            //Arrange
            List<ContactInfo> lesCons = context.ContactInfos.ToList();
            // Act
            var res = controller.GetContactInfos().Result;
            // Assert
            Assert.IsNotNull(res);
            CollectionAssert.AreEqual(lesCons, res.Value.ToList(), "Les listes de contacts ne sont pas identiques");
        }

        [TestMethod()]
        public void GetContactInfoTest_RecuperationOK()
        {
            // Arrange
            ContactInfo? contactInfo = context.ContactInfos.Find(1);
            // Act
            var res = controller.GetContactInfo(1).Result;
            // Assert
            Assert.IsNotNull(res.Value);
            Assert.AreEqual(contactInfo, res.Value, "Le contact n'est pas le même");
        }

        [TestMethod()]
        public void GetConcessionnaireTest_RecuperationFailed()
        {
            // Arrange
            ContactInfo? contactInfo = context.ContactInfos.Find(1);
            // Act
            var res = controller.GetContactInfo(2).Result;
            // Assert
            Assert.IsNotNull(res.Value);
            Assert.AreNotEqual(contactInfo, res.Value, "Le contact est le même");
        }

        [TestMethod()]
        public void GetConcessionnaireTest_CollecNExistePas()
        {
            var res = controller.GetContactInfo(777777777).Result;
            // Assert
            Assert.IsNull(res.Result, "Le contact existe");
            Assert.IsNull(res.Value, "Le contact existe");
        }

        [TestMethod()]
        public void __PostContactInfoTest_CreationOK()
        {
            // Act
            var result = controller.PostContactInfo(contactInfo).Result;
            // Assert
            var conRecup = controller.GetContactInfo(contactInfo.IdContact).Result;
            contactInfo.IdContact = conRecup.Value.IdContact;
            Assert.AreEqual(contactInfo, conRecup.Value, "Contacts pas identiques");
        }

        [TestMethod()]
        public void _PutContactInfoTest_ModificationOK()
        {
            // Arrange
            var conIni = controller.GetContactInfo(contactInfo.IdContact).Result;
            conIni.Value.NomContact = "Beethoven";

            // Act
            var res = controller.PutContactInfo(contactInfo.IdContact, conIni.Value).Result;

            // Assert
            var conMaj = controller.GetContactInfo(contactInfo.IdContact).Result;
            Assert.IsNotNull(conMaj.Value);
            Assert.AreEqual(conIni.Value, conMaj.Value, "contacts pas identiques");
        }

        [TestMethod()]
        public void DeleteContactInfoTest_SuppressionOK()
        {
            // Act
            var conSuppr = controller.GetContactInfo(contactInfo.IdContact).Result;
            _ = controller.DeleteContactInfo(contactInfo.IdContact).Result;

            // Assert
            var res = controller.GetContactInfo(contactInfo.IdContact).Result;
            Assert.IsNull(res.Value, "contact non supprimé");
        }

        // ---------------------------------------- Tests Moq ----------------------------------------

        [TestMethod()]
        public void Moq_GetConcessionnairesTest_RecuperationOK()
        {
            // Arrange
            var mockRepository = new Mock<IDataRepository<ContactInfo>>();
            var contacts = new List<ContactInfo>
                {
                    contactInfo
                };
            mockRepository.Setup(x => x.GetAllAsync()).ReturnsAsync(contacts);

            var controller = new ContactInfoController(mockRepository.Object);

            // Act
            var res = controller.GetContactInfos().Result;
            // Assert
            Assert.IsNotNull(res);
            Assert.IsNotNull(res.Value);
            Assert.AreEqual(contacts, res.Value as IEnumerable<ContactInfo>, "La liste n'est pas le même");
        }

        [TestMethod()]
        public void Moq_GetContactInfoTest_RecuperationOK()
        {
            // Arrange
            var mockRepository = new Mock<IDataRepository<ContactInfo>>();
            mockRepository.Setup(x => x.GetByIdAsync(1).Result).Returns(contactInfo);

            var controller = new ContactInfoController(mockRepository.Object);
            // Act
            var res = controller.GetContactInfo(1).Result;
            // Assert
            Assert.IsNotNull(res);
            Assert.IsNotNull(res.Value);
            Assert.AreEqual(contactInfo, res.Value as ContactInfo, "Le contactInfo n'est pas le même");
        }
    }
}