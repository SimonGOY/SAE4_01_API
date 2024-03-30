using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SAE_4._01.Controllers;
using SAE_4._01.Models.DataManager;
using SAE_4._01.Models.EntityFramework;
using SAE_4._01.Models.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace SAE_4._01.Controllers.Tests
{
    [TestClass()]
    public class UsersControllerTests
    {
        private UsersController controller;
        private BMWDBContext context;
        private IDataRepository<User> dataRepository;
        private User user;

        [TestInitialize]
        public void InitTest()
        {
            var builder = new DbContextOptionsBuilder<BMWDBContext>().UseNpgsql("Server=51.83.36.122; port=5432; Database=sa11; uid=sa11; password=BMW-S4; SearchPath=bmw;");
            context = new BMWDBContext(builder.Options);
            dataRepository = new UserManager(context);
            controller = new UsersController(dataRepository);

            user = new User
            {
                Id = 666666666,
                FirstName = "Simon",
                Email = "test@test.com",
                Password = "test",
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                Civilite = "M.",
                LastName = "GOY",
                IdClient = 147,
                IsComplete = true,
                TypeCompte = 0,
                DoubleAuth = false,
                LastConnected = DateTime.Now,
                ClientUsers = new Client()
            };
        }

        [TestMethod()]
        public void GetUserssTest_RecuperationOK()
        {
            //Arrange
            List<User> lesCLients = context.LesUsers.ToList();
            // Act
            var res = controller.GetLesUsers().Result;
            // Assert
            Assert.IsNotNull(res);
            CollectionAssert.AreEqual(lesCLients, res.Value.ToList(), "Les listes de clients ne sont pas identiques");
        }

        [TestMethod()]
        public void GetUsersTest_RecuperationOK()
        {
            // Arrange
            User? clt = context.LesUsers.Find(1);
            // Act
            var res = controller.GetUsers(1).Result;
            // Assert
            Assert.IsNotNull(res);
            Assert.AreEqual(clt, res.Value, "Le user n'est pas le même");
        }


        [TestMethod()]
        public void GetUsersTest_RecuperationFailed()
        {
            // Arrange
            User? clt = context.LesUsers.Find(1);
            // Act
            var res = controller.GetUsers(2).Result;
            // Assert
            Assert.IsNotNull(res);
            Assert.AreNotEqual(clt, res.Value, "Le user est le même");
        }

        [TestMethod()]
        public void GetUsersTest_UsersNExistePas()
        {
            var res = controller.GetUsers(777777777).Result;
            // Assert
            Assert.IsNull(res.Result, "Le user existe");
            Assert.IsNull(res.Value, "Le user existe");
        }


        /*[TestMethod()]
        public void PostUsersTest_CreationOK()
        {

            // Act
            var result = controller.PostUsers(user).Result;
            // Assert
            var cltRecup = controller.GetUsers(user.Id).Result;
            user.Id = cltRecup.Value.Id;
            Assert.AreEqual(user, cltRecup.Value, "LesUsers pas identiques"); ;
        }

        [TestMethod()]
        public void PutUsersTest_ModificationOK()
        {
            // Arrange
            var cltIni = controller.GetUsers(user.Id).Result;
            cltIni.Value.FirstName = "CLIENT CLONE N°" + 2;

            // Act
            var res = controller.PutUser(user.Id, cltIni.Value).Result;

            // Assert
            var cltMaj = controller.GetUsers(user.Id).Result;
            Assert.IsNotNull(cltMaj.Value);
            Assert.AreEqual(cltIni.Value, cltMaj.Value, "Users pas identiques");
        }

        [TestMethod()]
        public void ZDeleteCLientTest_SuppressionOK()
        {

            // Act
            var cltSuppr = controller.GetUsers(user.Id).Result;
            _ = controller.DeleteUsers(cltSuppr.Value.Id).Result;

            // Assert
            var res = controller.GetUsers(user.Id).Result;
            Assert.IsNull(res.Value, "user non supprimé");
        }*/
    }
}