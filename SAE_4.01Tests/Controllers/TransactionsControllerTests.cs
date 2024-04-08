﻿using Microsoft.AspNetCore.Mvc;
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
    public class TransactionsControllerTests
    {
        private TransactionsController controller;
        private BMWDBContext context;
        private IDataRepository<Transaction> dataRepository;
        private Transaction transaction;

        [TestInitialize]
        public void InitTest()
        {
            var builder = new DbContextOptionsBuilder<BMWDBContext>().UseNpgsql("Server=51.83.36.122; port=5432; Database=sa11; uid=sa11; password=BMW-S4; SearchPath=bmw;");
            context = new BMWDBContext(builder.Options);
            dataRepository = new TransactionManager(context);
            controller = new TransactionsController(dataRepository);

            transaction = new Transaction
            {
                IdTransaction = 666666666,
                IdCommande = 129,
                Type = "CB",
                Montant = 1
            };
        }

        [TestMethod()]
        public void GetTransactionsTest_RecuperationsOK()
        {
            //Arrange
            List<Transaction> lesTras = context.Transactions.ToList();
            // Act
            var res = controller.GetTransactions().Result;
            // Assert
            Assert.IsNotNull(res);
            CollectionAssert.AreEqual(lesTras, res.Value.ToList(), "Les listes de transactions ne sont pas identiques");
        }

        [TestMethod()]
        public void GetTransactionTest_RecuperationOK()
        {
            // Arrange
            Transaction? tra = context.Transactions.Find(6);
            // Act
            var res = controller.GetTransaction(6).Result;
            // Assert
            Assert.IsNotNull(res.Value);
            Assert.AreEqual(tra, res.Value, "La transaction n'est pas la même");
        }

        [TestMethod()]
        public void GetTelephoneTest_RecuperationFailed()
        {
            // Arrange
            Transaction? tel = context.Transactions.Find(6);
            // Act
            var res = controller.GetTransaction(7).Result;
            // Assert
            Assert.IsNotNull(res.Value);
            Assert.AreNotEqual(tel, res.Value, "La transaction est la même");
        }

        [TestMethod()]
        public void GetTelephoneTest_EquipementNExistePas()
        {
            var res = controller.GetTransaction(777777777).Result;
            // Assert
            Assert.IsNull(res.Result, "La transaction existe");
            Assert.IsNull(res.Value, "La trasaction existe");
        }

        [TestMethod()]
        public void PostUpdateDelete()
        {
            PostTransactionTest_CreationOK();
            PutTransactionTest_ModificationOK();
            DeleteTransactionTest_SuppressionOK();
        }

        public void PostTransactionTest_CreationOK()
        {
            // Act
            var result = controller.PostTransaction(transaction).Result;
            // Assert
            var telRecup = controller.GetTransaction(transaction.IdTransaction).Result;
            transaction.IdTransaction = telRecup.Value.IdTransaction;
            Assert.AreEqual(transaction, telRecup.Value, "transaction pas identiques");
        }

        public void PutTransactionTest_ModificationOK()
        {
            // Arrange
            var traIni = controller.GetTransaction(transaction.IdTransaction).Result;
            traIni.Value.Type = "Fixe";

            // Act
            var res = controller.PutTransaction(transaction.IdTransaction, traIni.Value).Result;

            // Assert
            var traMaj = controller.GetTransaction(transaction.IdTransaction).Result;
            Assert.IsNotNull(traMaj.Value);
            Assert.AreEqual(traIni.Value, traMaj.Value, "telephone pas identiques");
        }

        public void DeleteTransactionTest_SuppressionOK()
        {
            // Act
            var traSuppr = controller.GetTransaction(transaction.IdTransaction).Result;
            _ = controller.DeleteTransaction(transaction.IdTransaction).Result;

            // Assert
            var res = controller.GetTransaction(transaction.IdTransaction).Result;
            Assert.IsNull(res.Value, "transaction non supprimé");
        }
    }
}