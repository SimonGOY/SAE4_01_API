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
    public class ContactInfoControllerTests
    {
        private ContactInfoController controller;
        private BMWDBContext context;
        private IDataRepository<ContactInfo> dataRepository;
        private ContactInfo con;

        [TestInitialize]
        public void InitTest()
        {
            var builder = new DbContextOptionsBuilder<BMWDBContext>().UseNpgsql("Server=51.83.36.122; port=5432; Database=sa11; uid=sa11; password=BMW-S4; SearchPath=bmw;");
            context = new BMWDBContext(builder.Options);
            dataRepository = new ContactInfoManager(context);
            controller = new ContactInfoController(dataRepository);

            con = new ContactInfo
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
            ContactInfo? con = context.ContactInfos.Find(1);
            // Act
            var res = controller.GetContactInfo(1).Result;
            // Assert
            Assert.IsNotNull(res);
            Assert.AreEqual(con, res.Value, "Le contact n'est pas le même");
        }

        [TestMethod()]
        public void GetConcessionnaireTest_RecuperationFailed()
        {
            // Arrange
            ContactInfo? con = context.ContactInfos.Find(1);
            // Act
            var res = controller.GetContactInfo(2).Result;
            // Assert
            Assert.IsNotNull(res);
            Assert.AreNotEqual(con, res.Value, "Le contact est le même");
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
        public void PostContactInfoTest_CreationOK_MeublagePlusdeMeublage()//Meublage car le test ne s'effectue pas dans le bon ordre sinon (wtf)
        {
            // Act
            var result = controller.PostContactInfo(con).Result;
            // Assert
            var conRecup = controller.GetContactInfo(con.IdContact).Result;
            con.IdContact = conRecup.Value.IdContact;
            Assert.AreEqual(con, conRecup.Value, "Contacts pas identiques");
        }

        /*[TestMethod()]
        public void PutContactInfoTest_ModificationOK()
        {
            // Arrange
            var conIni = controller.GetContactInfo(con.IdContact).Result;
            conIni.Value.NomContact = "Beethoven";

            // Act
            var res = controller.PutContactInfo(con.IdContact, conIni.Value).Result;

            // Assert
            var conMaj = controller.GetContactInfo(con.IdContact).Result;
            Assert.IsNotNull(conMaj.Value);
            Assert.AreEqual(conIni.Value, conMaj.Value, "contacts pas identiques");
        }*/

        [TestMethod()]
        public void ZDeleteContactInfoTest_SuppressionOK()
        {
            // Act
            var conSuppr = controller.GetContactInfo(con.IdContact).Result;
            _ = controller.DeleteContactInfo(con.IdContact).Result;

            // Assert
            var res = controller.GetContactInfo(con.IdContact).Result;
            Assert.IsNull(res.Value, "contact non supprimé");
        }
    }
}