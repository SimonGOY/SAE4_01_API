using Microsoft.VisualStudio.TestTools.UnitTesting;
using SAE_4._01.Controllers;
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
    public class MediaControllerTests
    {
        private MediaController controller;
        private BMWDBContext context;
        private IDataRepository<Media> dataRepository;
        private Media client;

        [TestInitialize]
        public void InitTest()
        {

        }

        [TestMethod()]
        public void GetMediaTest()
        {

        }

        [TestMethod()]
        public void GetByIdMotoTest()
        {

        }

        [TestMethod()]
        public void GetByIdEquipementTest()
        {

        }

        [TestMethod()]
        public void PutMediaTest()
        {

        }

        [TestMethod()]
        public void PostMediaTest()
        {

        }

        [TestMethod()]
        public void DeleteMediaTest()
        {

        }
    }
}