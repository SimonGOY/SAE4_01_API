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
        private UserPostRequest userPostRequest;
        private Mock<IDataRepository<User>> mockRepository;
        private UsersController controller_mock;

        [TestInitialize]
        public void InitTest()
        {
            var builder = new DbContextOptionsBuilder<BMWDBContext>().UseNpgsql("Server=51.83.36.122; port=5432; Database=sa11; uid=sa11; password=BMW-S4; SearchPath=bmw;");
            context = new BMWDBContext(builder.Options);
            dataRepository = new UserManager(context);
            controller = new UsersController(dataRepository, null, null);
            mockRepository = new Mock<IDataRepository<User>>();
            controller_mock = new UsersController(mockRepository.Object, null, null);

            userPostRequest = new UserPostRequest
            {
                Id = 666666666,
                FirstName = "Simon",
                Email = "test@test.com",
                Password = "test",
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                Gender = "M.",
                LastName = "GOY",
                //IdClient = 147,
                IsComplete = true,
                TypeCompte = 0,
                DoubleAuth = false,
                LastConnected = DateTime.Now,
                //ClientUsers = new Client()
            };

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
            List<User> lesUsers = context.LesUsers.ToList();
            // Act
            var res = controller.GetUsers().Result;
            // Assert
            Assert.IsNotNull(res);
            CollectionAssert.AreEqual(lesUsers, res.Value.ToList(), "Les listes de clients ne sont pas identiques");
        }

        [TestMethod()]
        public void GetUsersTest_RecuperationOK()
        {
            // Arrange
            User? clt = context.LesUsers.Find(1);
            // Act
            var res = controller.GetUserById(1).Result;
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
            var res = controller.GetUserById(2).Result;
            // Assert
            Assert.IsNotNull(res);
            Assert.AreNotEqual(clt, res.Value, "Le user est le même");
        }

        [TestMethod()]
        public void GetUsersTest_UsersNExistePas()
        {
            var res = controller.GetUserById(777777777).Result;
            // Assert
            Assert.IsNull(res.Result, "Le user existe");
            Assert.IsNull(res.Value, "Le user existe");
        }

        [TestMethod()]
        public void PostPutDeleteTest()
        {
            PostUserTest_CreationOK();
            /*PutClientTest_ModificationOK();
            DeleteClientTest_SuppressionOK();*/
        }

        [TestMethod()]
        public void PostUserTest_CreationOK()
        {

            //Act
            var result = controller.PostUser(userPostRequest).Result;
            // Assert
            var usrRecup = controller.GetUserById((int)userPostRequest.Id).Result;
            userPostRequest.Id = usrRecup.Value.IdClient;


            Assert.AreEqual(userPostRequest.Id, usrRecup.Value.Id, "telephone pas identiques");
            Assert.AreEqual(userPostRequest.FirstName, usrRecup.Value.FirstName, "telephone pas identiques");
            Assert.AreEqual(userPostRequest.LastName, usrRecup.Value.LastName, "telephone pas identiques");
            Assert.AreEqual(userPostRequest.Email, usrRecup.Value.Email, "telephone pas identiques");
            Assert.AreEqual(userPostRequest.Password, usrRecup.Value.Password, "telephone pas identiques");
            Assert.AreEqual(userPostRequest.IsComplete, usrRecup.Value.IsComplete, "telephone pas identiques");
            Assert.AreEqual(userPostRequest.CreatedAt, usrRecup.Value.CreatedAt, "telephone pas identiques");
            Assert.AreEqual(userPostRequest.UpdatedAt, usrRecup.Value.UpdatedAt, "telephone pas identiques");
            Assert.AreEqual(userPostRequest.TypeCompte, usrRecup.Value.TypeCompte, "telephone pas identiques");
            Assert.AreEqual(userPostRequest.DoubleAuth, usrRecup.Value.DoubleAuth, "telephone pas identiques");
            Assert.AreEqual(userPostRequest.LastName, usrRecup.Value.LastName, "telephone pas identiques");
        }

        /*public void PutClientTest_ModificationOK()
        {
            // Arrange
            var cltIni = controller.GetClient((int)client.IdClient).Result;
            cltIni.Value.NomClient = "CLIENT CLONE N°" + 2;

            // Act
            var res = controller.PutClient((int)client.IdClient, cltIni.Value).Result;

            // Assert
            var cltMaj = controller.GetClient((int)client.IdClient).Result;
            Assert.IsNotNull(cltMaj.Value);


            Assert.AreEqual(cltIni.Value.IdClient, cltMaj.Value.IdClient, "telephone pas identiques");
            Assert.AreEqual(cltIni.Value.Civilite, cltMaj.Value.Civilite, "telephone pas identiques");
            Assert.AreEqual(cltIni.Value.NomClient, cltMaj.Value.NomClient, "telephone pas identiques");
            Assert.AreEqual(cltIni.Value.PrenomClient, cltMaj.Value.PrenomClient, "telephone pas identiques");
            Assert.AreEqual(cltIni.Value.DateNaissanceClient, cltMaj.Value.DateNaissanceClient, "telephone pas identiques");
            Assert.AreEqual(cltIni.Value.NumAdresse, cltMaj.Value.NumAdresse, "telephone pas identiques");
            Assert.AreEqual(cltIni.Value.EmailClient, cltMaj.Value.EmailClient, "telephone pas identiques");
        }

        public void DeleteClientTest_SuppressionOK()
        {

            // Act
            var cltSuppr = controller.GetClient((int)client.IdClient).Result;
            _ = controller.DeleteClient((int)cltSuppr.Value.IdClient).Result;

            // Assert
            var res = controller.GetClient((int)client.IdClient).Result;
            Assert.IsNull(res.Value, "client non supprimé");
        }*/

        // ---------------------------------------- Tests Moq ----------------------------------------

        [TestMethod()]
        public void Moq_GetLesUsersTest_RecuperationOK()
        {
            // Arrange
            var users = new List<User>
                {
                    user
                };
            mockRepository.Setup(x => x.GetAllAsync()).ReturnsAsync(users);
            // Act
            var res = controller_mock.GetUsers().Result;
            // Assert
            Assert.IsNotNull(res);
            Assert.IsNotNull(res.Value);
            Assert.AreEqual(users, res.Value as IEnumerable<User>, "La liste n'est pas le même");
        }

        [TestMethod()]
        public void Moq_GetUsersTest_RecuperationOK()
        {
            // Arrange
            mockRepository.Setup(x => x.GetByIdAsync(15)).ReturnsAsync(user);
            // Act
            var res = controller_mock.GetUserById(15).Result;
            // Assert
            Assert.IsNotNull(res);
            Assert.IsNotNull(res.Value);
            Assert.AreEqual(user, res.Value as User, "Les infoCB n'est pas le même");
        }

        [TestMethod()]
        public void Moq_GetUsersTest_RecuperationNonOK()
        {
            // Act
            var res = controller_mock.GetUserById(0).Result;
            // Assert
            Assert.IsInstanceOfType(res.Result, typeof(NotFoundResult));
        }
    }
}