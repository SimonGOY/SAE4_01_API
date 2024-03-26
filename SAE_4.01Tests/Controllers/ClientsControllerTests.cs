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

namespace SAE_4._01.Controllers.Tests
{
    [TestClass()]
    public class ClientsControllerTests
    {
        /*private ClientsController controller;
        private BMWDBContext context;
        private IDataRepository<Client> dataRepository;
        private Client client;

        [TestInitialize]
        public void InitTest()
        {
            // Arrange
            var builder = new DbContextOptionsBuilder<BMWDBContext>().UseNpgsql("Server=51.83.36.122; port=5432; Database=sa11; uid=sa11; password=BMW-S4; SearchPath=bmw;");
            context = new BMWDBContext(builder.Options);
            dataRepository = new ClientManager(context);
            controller = new ClientsController(dataRepository);

            client = new Client
            {
                IdClient = 666666666,
                NumAdresse = 1,
                Civilite = "Penis",
                NomClient = "BASTARD",
                PrenomClient = "Quentin",
                DateNaissanceClient = new DateTime(2004, 2, 18),
                EmailClient = "qbastard99@gmail.com"
            };
        }

        [TestMethod()]
        public void GetClientsTest()
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
        public void GetCLientTest()
        {
            // Arrange
            Client? clt = context.Clients.Find(1);
            // Act
            var res = controller.GetClient(1).Result;
            // Assert
            Assert.IsNotNull(res);
            Assert.AreEqual(clt, res.Value, "Le client n'est pas le même");
        }

        

        [TestMethod()]
        public void PostClientTest()
        {
            
            // Act
            var result = controller.PostClient(client).Result;
            // Assert
            Client? cltRecup = context.Clients.Where(e => e.IdClient == client.IdClient).FirstOrDefault();
            client.IdClient = cltRecup.IdClient;
            Assert.AreEqual(client, cltRecup, "Clients pas identiques"); ;
        }

        [TestMethod()]
        public void PutEtudiantTest()
        {
            // Arrange
            Client? cltIni = context.Clients.Find(client.IdClient);
            cltIni.NomClient = "CLIENT CLONE N°" + 2;

            // Act
            var res = controller.PutClient(client.IdClient, cltIni);

            // Arrange
            Client? cltMaj = context.Clients.Find(1);
            Assert.IsNotNull(cltMaj);
            Assert.AreEqual(cltIni, cltMaj);
        }

        [TestMethod()]
        public void ZDeleteCLientTest()
        {

            // Act
            Client? cltSuppr = context.Clients.Find(client.IdClient);
            _ = controller.DeleteClient(cltSuppr.IdClient).Result;

            // Arrange
            Client? res = context.Clients.FirstOrDefault(e => e.IdClient == client.IdClient);
            Assert.IsNull(res, "utilisateur non supprimé");
        }*/
    }
}