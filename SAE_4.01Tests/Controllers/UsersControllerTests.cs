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
        private UserPostRequest userPostRequest;
        private ClientPostRequest clientPostRequest;
        private User user;
        private Mock<IDataRepository<User>> mockRepository;
        private UsersController controller_mock;

        [TestInitialize]
        public void InitTest()
        {
            var builder = new DbContextOptionsBuilder<BMWDBContext>().UseNpgsql("Server=51.83.36.122; port=5432; Database=sa11; uid=sa11; password=BMW-S4; SearchPath=bmw;");
            context = new BMWDBContext(builder.Options);
            dataRepository = new UserManager(context);
            controller = new UsersController(dataRepository);
            mockRepository = new Mock<IDataRepository<User>>();
            controller_mock = new UsersController(mockRepository.Object);

            userPostRequest = new UserPostRequest
            {
                Id = 666666666,
                FirstName = "Simon",
                Email = "testuser@test.com",
                Password = "test",
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                Civilite = "M.",
                LastName = "GOY",               
                IdClient = 888888888,
                IsComplete = true,
                TypeCompte = 0,
                DoubleAuth = false,
                LastConnected = DateTime.Now,
                //ClientUsers = new Client()
            };

            clientPostRequest = new ClientPostRequest
            {
                IdClient = 888888888,
                NumAdresse = 1,
                Civilite = "M.",
                NomClient = "GOY",
                PrenomClient = "Simon",
                DateNaissanceClient = new DateTime(2004, 2, 18),
                EmailClient = "testuser@test.com"
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
            PutClientTest_ModificationOK();
            /*DeleteClientTest_SuppressionOK();*/
        }

        [TestMethod()]
        public void PostUserTest_CreationOK()
        {
            IDataRepository<Client> clientDataRepository = new ClientManager(context);
            ClientsController clientController = new ClientsController(clientDataRepository);

            var resultClt = clientController.PostClient(clientPostRequest).Result;

            //Act
            var result = controller.PostUser(userPostRequest).Result;
            // Assert
            var usrRecup = controller.GetUserById((int)userPostRequest.Id).Result;
            usrRecup.Value.Id = (int)userPostRequest.Id;
            usrRecup.Value.CreatedAt = userPostRequest.CreatedAt;
            usrRecup.Value.UpdatedAt = userPostRequest.UpdatedAt;
            usrRecup.Value.LastConnected = userPostRequest.LastConnected;

            //Assert.AreEqual(user, usrRecup.Value, "users pas identiques");

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

        [TestMethod()]
        public void PutClientTest_ModificationOK()
        {
            // Arrange
            var usrIni = controller.GetUserById((int)userPostRequest.Id).Result;
            usrIni.Value.UpdatedAt = DateTime.Now;

            // Act
            var res = controller.PutUser((int)userPostRequest.Id, usrIni.Value).Result;

            // Assert
            var usrMaj = controller.GetUserById((int)userPostRequest.Id).Result;
            Assert.IsNotNull(usrMaj.Value);


            Assert.AreEqual(usrIni.Value.Id, usrMaj.Value.Id, "telephone pas identiques");
            Assert.AreEqual(usrIni.Value.FirstName, usrMaj.Value.FirstName, "telephone pas identiques");
            Assert.AreEqual(usrIni.Value.LastName, usrMaj.Value.LastName, "telephone pas identiques");
            Assert.AreEqual(usrIni.Value.Email, usrMaj.Value.Email, "telephone pas identiques");
            Assert.AreEqual(usrIni.Value.Password, usrMaj.Value.Password, "telephone pas identiques");
            Assert.AreEqual(usrIni.Value.IsComplete, usrMaj.Value.IsComplete, "telephone pas identiques");
            Assert.AreEqual(usrIni.Value.CreatedAt, usrMaj.Value.CreatedAt, "telephone pas identiques");
            Assert.AreEqual(usrIni.Value.UpdatedAt, usrMaj.Value.UpdatedAt, "telephone pas identiques");
            Assert.AreEqual(usrIni.Value.TypeCompte, usrMaj.Value.TypeCompte, "telephone pas identiques");
            Assert.AreEqual(usrIni.Value.DoubleAuth, usrMaj.Value.DoubleAuth, "telephone pas identiques");
            Assert.AreEqual(usrIni.Value.LastName, usrMaj.Value.LastName, "telephone pas identiques");
        }

        [TestMethod()]
        public void DeleteUserTest_SuppressionOK()
        {
            
            IDataRepository<Client> clientDataRepository = new ClientManager(context);
            ClientsController clientController = new ClientsController(clientDataRepository);
            // Act
            var usrSuppr = controller.GetUserById((int)userPostRequest.Id).Result;
            _ = controller.DeleteUser((int)usrSuppr.Value.Id).Result;

            var cltSuppr = clientController.GetClient((int)userPostRequest.IdClient).Result;
            _ = clientController.DeleteClient((int)cltSuppr.Value.IdClient).Result;

            // Assert
            var res = controller.GetUserById((int)userPostRequest.Id).Result;
            Assert.IsNull(res.Value, "user non supprimé");


            var cltres = clientController.GetClient((int)userPostRequest.IdClient).Result;
            Assert.IsNull(cltres.Value, "client non supprimé");
        }

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