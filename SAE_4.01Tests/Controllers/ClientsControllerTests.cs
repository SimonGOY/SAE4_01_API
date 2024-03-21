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
        private ClientsController controller;
        private BMWDBContext context;
        private IDataRepository<Client> dataRepository;

        [TestInitialize]
        public void InitTest()
        {
            // Arrange
            var builder = new DbContextOptionsBuilder<BMWDBContext>().UseNpgsql("Server=51.83.36.122; port=5432; Database=sa11; uid=sa11; password=BMW-S4; SearchPath=bmw;");
            context = new BMWDBContext(builder.Options);
            dataRepository = new ClientManager(context);
            controller = new ClientsController(dataRepository);
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
        public void PutEtudiantTest()
        {
            // Arrange
            Random rnd = new Random();
            int chiffre = rnd.Next(1, 1000000000);
            Client? cltIni = context.Clients.Find(1);
            cltIni.NomClient = "CLIENT CLONE N°" + chiffre;

            // Act
            var res = controller.PutClient(1, cltIni);

            // Arrange
            Client? cltMaj = context.Clients.Find(1);
            Assert.IsNotNull(cltMaj);
            Assert.AreEqual(cltIni, cltMaj);
        }

        [TestMethod()]
        public void PostClientTest()
        {
            // Arrange
            Random rnd = new Random();
            int chiffre = rnd.Next(100000000, 999999999);

            Client client = new Client
            {
                IdClient = chiffre,
                NumAdresse = 123,
                Civilite = "",
                NomClient = "BASTARD",
                PrenomClient = "Quentin",
                DateNaissanceClient = new DateTime(2, 18, 2040),
                EmailClient = "qbastard99@gmail.com"
            };
            // Act

            // Assert
            var result = controller.PostClient(client).Result;
            // Assert
            Client? cltRecup = context.Clients.Where(e => e.EmailClient == client.EmailClient).FirstOrDefault();
            client.IdClient = cltRecup.IdClient;
            Assert.AreEqual(client, cltRecup, "Clients pas identiques"); ;
        }
        /*
        [TestMethod()]
        public void DeleteEtudiantTest()
        {
            // Arrange
            Random rnd = new Random();
            int chiffre = rnd.Next(100000000, 999999999);

            Etudiant etu = new Etudiant
            {
                Ine = chiffre.ToString() + "69",
                NomEtudiant = "BASTARD",
                PrenomEtudiant = "Moua",
                FormationId = 1
            };
            context.Etudiants.Add(etu);
            context.SaveChanges();

            // Act
            Etudiant? etuSuppr = context.Etudiants.Where(e => e.Ine == etu.Ine).FirstOrDefault();
            _ = controller.DeleteEtudiant(etuSuppr.EtudiantId).Result;

            // Arrange
            Etudiant res = context.Etudiants.FirstOrDefault(e => e.Ine == etu.Ine);
            Assert.IsNull(res, "utilisateur non supprimé");
        }*/
    }
}