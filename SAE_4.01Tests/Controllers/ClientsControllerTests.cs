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

namespace SAE_4._01.Controllers.Tests
{
    [TestClass()]
    public class ClientsControllerTests
    {
        private ClientsController controller;
        private BMWDBContext context;
        private IDataRepository<Client> dataRepository;
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
        }

        [TestMethod()]
        public void GetClientsTest_RecuperationOK()
        {
            //Arrange
            List<Client> lesCLients = context.Clients.ToList();
            // Act
            var res = controller.GetClients().Result;
            // Assert
            Assert.IsNotNull(res);
            CollectionAssert.AreEqual(lesCLients, res.Value.ToList(), "Les listes de clients ne sont pas identiques");
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
        public void __PostClientTest_CreationOK()
        {
            
            // Act
            //var result = controller.PostClient(client).Result;
            // Assert
            var cltRecup = controller.GetClient(client.IdClient).Result;
            client.IdClient = cltRecup.Value.IdClient;
            Assert.AreEqual(client, cltRecup.Value, "Clients pas identiques");
        }

        [TestMethod()]
        public void _PutClientTest_ModificationOK()
        {
            // Arrange
            var cltIni = controller.GetClient(client.IdClient).Result;
            cltIni.Value.NomClient = "CLIENT CLONE N°" + 2;

            // Act
            var res = controller.PutClient(client.IdClient, cltIni.Value).Result;

            // Assert
            var cltMaj = controller.GetClient(client.IdClient).Result;
            Assert.IsNotNull(cltMaj.Value);
            Assert.AreEqual(cltIni.Value, cltMaj.Value, "Client pas identiques");
        }

        [TestMethod()]
        public void DeleteCLientTest_SuppressionOK()
        {

            // Act
            var cltSuppr = controller.GetClient(client.IdClient).Result;
            _ = controller.DeleteClient(cltSuppr.Value.IdClient).Result;

            // Assert
            var res = controller.GetClient(client.IdClient).Result;
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
    }
}