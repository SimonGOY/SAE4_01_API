﻿using Microsoft.AspNetCore.Mvc;
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
    public class ReservationsControllerTests
    {
        private ReservationsController controller;
        private BMWDBContext context;
        private IDataRepository<Reservation> dataRepository;
        private Reservation reservation;
        private Mock<IDataRepository<Reservation>> mockRepository;
        private ReservationsController controller_mock;

        private MotoDisponiblesController controllerMoto;
        private MotoDisponible motoDispo;
        private IDataRepository<MotoDisponible> dataRepositoryMoto;

        [TestInitialize]
        public void InitTest()
        {
            var builder = new DbContextOptionsBuilder<BMWDBContext>().UseNpgsql("Server=51.83.36.122; port=5432; Database=sa11; uid=sa11; password=BMW-S4; SearchPath=bmw;");
            context = new BMWDBContext(builder.Options);
            dataRepository = new ReservationManager(context);
            controller = new ReservationsController(dataRepository);
            mockRepository = new Mock<IDataRepository<Reservation>>();
            controller_mock = new ReservationsController(mockRepository.Object);

            motoDispo = new MotoDisponible
            {
                IdMotoDisponible = 777777777,
                PrixMotoDisponible = 15000.00f,
                IdMoto = 1,
            };

            dataRepositoryMoto = new MotoDisponibleManager(context);
            controllerMoto = new MotoDisponiblesController(dataRepositoryMoto);
            

            reservation = new Reservation()
            {
                IdReservation = 777777777,
                IdMotoDisponible = 1,
                IdClient = 1,
                IdConcessionnaire = 1,
                FinancementReservation = "LLD",
                DateReservation = DateTime.Now,
            };
        }

        [TestMethod()]
        public void GetReservationsTest()
        {
            //Arrange
            List<Reservation> lesRes = context.Reservations.ToList();
            // Act
            var res = controller.GetReservations().Result;
            // Assert
            Assert.IsNotNull(res);
            CollectionAssert.AreEqual(lesRes, res.Value.ToList(), "Les listes de reservations ne sont pas identiques");
        }

        [TestMethod()]
        public void GetReservationTest()
        {
            // Arrange
            Reservation? rese = context.Reservations.Find(1);
            // Act
            var res = controller.GetReservation(1).Result;
            // Assert
            Assert.IsNotNull(res.Value);
            Assert.AreEqual(rese, res.Value, "La reservation n'est pas la même");
        }

        [TestMethod()]
        public void GetParametreTest_RecuperationFailed()
        {
            // Arrange
            Reservation? pri = context.Reservations.Find(1);
            // Act
            var res = controller.GetReservation(2).Result;
            // Assert
            Assert.IsNotNull(res.Value);
            Assert.AreNotEqual(pri, res.Value, "La reservation est la même");
        }

        [TestMethod()]
        public void GetParametreTest_EquipementNExistePas()
        {
            var res = controller.GetReservation(777777777).Result;
            // Assert
            Assert.IsNull(res.Result, "La reservation existe");
            Assert.IsNull(res.Value, "La reservation existe");
        }

        [TestMethod()]
        public void PostPutDelete()
        {
            PostReservationTest_CreationOK();
            PutReservationTest_ModificationOK();
            DeleteReservationTest_SuppressionOK();
        }

        public void PostReservationTest_CreationOK()
        {
            // Act
            var resultMoto = controllerMoto.PostMotoDisponible(motoDispo).Result;
            // Assert
            var motRecup = controllerMoto.GetMotoDisponible(motoDispo.IdMotoDisponible).Result;
            motoDispo.IdMotoDisponible = motRecup.Value.IdMotoDisponible;
            Assert.AreEqual(motoDispo, motRecup.Value, "moto pas identiques");

            // Act
            var result = controller.PostReservation(reservation).Result;
            // Assert
            var resRecup = controller.GetReservation(reservation.IdReservation).Result;
            reservation.IdReservation = resRecup.Value.IdReservation;
            Assert.AreEqual(reservation, resRecup.Value, "reservation pas identiques");
        }

        public void PutReservationTest_ModificationOK()
        {
            // Arrange
            var resIni = controller.GetReservation(reservation.IdReservation).Result;
            resIni.Value.FinancementReservation = "Crédit";

            // Act
            var res = controller.PutReservation(reservation.IdReservation, resIni.Value).Result;

            // Assert
            var resMaj = controller.GetReservation(reservation.IdReservation).Result;
            Assert.IsNotNull(resMaj.Value);
            Assert.AreEqual(resIni.Value, resMaj.Value, "reservation pas identiques");
        }

        public void DeleteReservationTest_SuppressionOK()
        {
            // Act
            var resSuppr = controller.GetReservation(reservation.IdReservation).Result;
            _ = controller.DeleteReservation(reservation.IdReservation).Result;

            // Assert
            var res = controller.GetReservation(reservation.IdReservation).Result;
            Assert.IsNull(res.Value, "reservation non supprimé");

            // Act
            var motSuppr = controllerMoto.GetMotoDisponible(motoDispo.IdMotoDisponible).Result;
            _ = controllerMoto.DeleteMotoDisponible(motoDispo.IdMotoDisponible).Result;

            // Assert
            var resMoto = controllerMoto.GetMotoDisponible(motoDispo.IdMotoDisponible).Result;
            Assert.IsNull(res.Value, "moto non supprimé");
        }
    }
}