using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SAE_4._01.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SAE_4._01.Models.EntityFramework;
using SAE_4._01.Models.Repository;
using SAE_4._01.Models.DataManager;
using Moq;
using Microsoft.AspNetCore.Mvc;

namespace SAE_4._01.Controllers.Tests
{
    [TestClass()]
    public class ClientsControllerTests
    {
        private ClientsController controller;
        private BMWDBContext context;
        private IDataRepository<Client> dataRepository;
        private ClientPostRequest clientPostRequest;
        private Client client;
        private Mock<IDataRepository<Client>> mockRepository;
        private ClientsController controller_mock;

        [TestInitialize]
        public void InitTest()
        {
            var builder = new DbContextOptionsBuilder<BMWDBContext>().UseNpgsql("Server=51.83.36.122; port=5432; Database=sa11; uid=sa11; password=BMW-S4; SearchPath=bmw;");
            context = new BMWDBContext(builder.Options);
            dataRepository = new ClientManager(context);
            controller = new ClientsController(dataRepository);
            mockRepository = new Mock<IDataRepository<Client>>();
            controller_mock = new ClientsController(mockRepository.Object);

            clientPostRequest = new ClientPostRequest
            {
                IdClient = 666666666,
                NumAdresse = 1,
                Civilite = "M.",
                NomClient = "BASTARD",
                PrenomClient = "Quentin",
                DateNaissanceClient = new DateTime(2004, 2, 18),
                EmailClient = "qbastard99@gmail.com"
            };

            client = new Client
            {
                IdClient = 666666666,
                NumAdresse = 1,
                Civilite = "M.",
                NomClient = "BASTARD",
                PrenomClient = "Quentin",
                DateNaissanceClient = new DateTime(2004, 2, 18),
                EmailClient = "qbastard99@gmail.com"
            };


            /*client_post = new ClientPostRequest
            {
                Civilite = "M.",
                NomClient = "BASTARD",
                PrenomClient = "Quentin",
                DateNaissanceClient = new DateTime(2004, 2, 18),
                EmailClient = "qbastard99@gmail.com"
            };*/
        }

        [TestMethod()]
        public void GetClientsTest_RecuperationsOK()
        {
            //Arrange
            List<Client> lesClients = context.Clients.ToList();
            // Act
            var res = controller.GetClients().Result;
            // Assert
            Assert.IsNotNull(res);
            CollectionAssert.AreEqual(lesClients, res.Value.ToList(), "Les listes de clients ne sont pas identiques");
        }

        [TestMethod()]
        public void GetClientTest_RecuperationOK()
        {
            // Arrange
            Client? clt = context.Clients.Find(1);
            // Act
            var res = controller.GetClient(1).Result;
            // Assert
            Assert.IsNotNull(res.Value);
            Assert.AreEqual(clt, res.Value, "Le client n'est pas le même");
        }


        [TestMethod()]
        public void GetClientTest_RecuperationFailed()
        {
            // Arrange
            Client? clt = context.Clients.Find(1);
            // Act
            var res = controller.GetClient(2).Result;
            // Assert
            Assert.IsNotNull(res.Value);
            Assert.AreNotEqual(clt, res.Value, "Le client est le même");
        }

        [TestMethod()]
        public void GetClientTest_ClientNExistePas()
        {
            var res = controller.GetClient(777777777).Result;
            // Assert
            Assert.IsNull(res.Result, "Le client existe");
            Assert.IsNull(res.Value, "Le client existe");
        }


        [TestMethod()]
        public void PostPutDeleteTest()
        {
            PostClientTest_CreationOK();
            PutClientTest_ModificationOK();
            DeleteClientTest_SuppressionOK();
        }

        
        public void PostClientTest_CreationOK()
        {
            
            //Act
            var result = controller.PostClient(clientPostRequest).Result;
            // Assert
            var cltRecup = controller.GetClient((int)client.IdClient).Result;
            client.IdClient = cltRecup.Value.IdClient;


            Assert.AreEqual(clientPostRequest.IdClient, cltRecup.Value.IdClient, "telephone pas identiques");
            Assert.AreEqual(clientPostRequest.Civilite, cltRecup.Value.Civilite, "telephone pas identiques");
            Assert.AreEqual(clientPostRequest.NomClient, cltRecup.Value.NomClient, "telephone pas identiques");
            Assert.AreEqual(clientPostRequest.PrenomClient, cltRecup.Value.PrenomClient, "telephone pas identiques");
            Assert.AreEqual(clientPostRequest.DateNaissanceClient, cltRecup.Value.DateNaissanceClient, "telephone pas identiques");
            Assert.AreEqual(clientPostRequest.NumAdresse, cltRecup.Value.NumAdresse, "telephone pas identiques");
            Assert.AreEqual(clientPostRequest.EmailClient, cltRecup.Value.EmailClient, "telephone pas identiques");
        }

        public void PutClientTest_ModificationOK()
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
        }

        // ---------------------------------------- Tests Moq ----------------------------------------

        [TestMethod()]
        public void Moq_GetClientsTest_RecuperationOK()
        {
            // Arrange
            var clients = new List<Client>
                {
                    client
                };
            mockRepository.Setup(x => x.GetAllAsync()).ReturnsAsync(clients);

            // Act
            var res = controller_mock.GetClients().Result;
            // Assert
            Assert.IsNotNull(res);
            Assert.IsNotNull(res.Value);
            Assert.AreEqual(clients, res.Value as IEnumerable<Client>, "La liste n'est pas le même");
        }

        [TestMethod()]
        public void Moq_GetClientTest_RecuperationOK()
        {
            // Arrange
            mockRepository.Setup(x => x.GetByIdAsync(1).Result).Returns(client);
            // Act
            var res = controller_mock.GetClient(1).Result;
            // Assert
            Assert.IsNotNull(res);
            Assert.IsNotNull(res.Value);
            Assert.AreEqual(client, res.Value as Client, "Le client n'est pas le même");
        }

        [TestMethod()]
        public void Moq_GetClientTest_RecuperationFailed()
        {
            // Act
            var res = controller_mock.GetClient(0).Result;
            // Assert
            Assert.IsInstanceOfType(res.Result, typeof(NotFoundResult));
        }

        [TestMethod()]
        public void Moq_PostClientTest()
        {
            // Act

            var liste = new List<Client>
                {
                    client
                };
            mockRepository.Setup(x => x.GetAllAsync().Result).Returns(liste);
            var actionResult = controller_mock.PostClient(clientPostRequest).Result;
            
            // Assert
            Assert.IsInstanceOfType(actionResult, typeof(ActionResult<Client>), "Pas un ActionResult<Client>");
            Assert.IsInstanceOfType(actionResult.Result, typeof(CreatedAtActionResult), "Pas un CreatedAtActionResult");
            var result = actionResult.Result as CreatedAtActionResult;
            Assert.IsInstanceOfType(result.Value, typeof(Client), "Pas une Client");
            client.IdClient = ((Client)result.Value).IdClient;
            Assert.AreEqual(client.EmailClient, ((Client)result.Value).EmailClient, "Email pas identiques");
            Assert.AreEqual(client.NomClient, ((Client)result.Value).NomClient, "Nom pas identiques");
            Assert.AreEqual(client.PrenomClient, ((Client)result.Value).PrenomClient, "PrenomClient pas identiques");
            Assert.AreEqual(client.Civilite, ((Client)result.Value).Civilite, "Civilite pas identiques");
            Assert.AreEqual(client.DateNaissanceClient, ((Client)result.Value).DateNaissanceClient, "DateNaissanceClient pas identiques");
        }

        [TestMethod]
        public void Moq_DeleteClientTest()
        {
            // Arrange
            mockRepository.Setup(x => x.GetByIdAsync(1).Result).Returns(client);

            // Act
            var actionResult = controller_mock.DeleteClient(1).Result;
            // Assert
            Assert.IsInstanceOfType(actionResult, typeof(NoContentResult), "Pas un NoContentResult"); // Test du type de retour
        }

        [TestMethod]
        public void Moq_PutClientTest()
        {
            // Arrange
            mockRepository.Setup(x => x.GetByIdAsync(1).Result).Returns(client);
            var init = controller_mock.GetClient(1).Result;
            init.Value.NomClient = "CLIENT CLONE N°" + 2;

            // Act
            var res = controller_mock.PutClient(1, init.Value).Result;
            var maj = controller_mock.GetClient(1).Result;

            // Assert

            Assert.IsNotNull(maj.Value);
            Assert.AreEqual(init.Value, maj.Value, "Valeurs pas identiques");
        }
    }
}