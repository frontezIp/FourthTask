using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FourthTask;

namespace FourthTaskTests
{
    [TestClass]
    public class ClientTests
    {
        Client _client;

        [TestInitialize]
        public void TestInitialize()
        {
            int port = 9000;
            _client = new Client(port);
        }

        /// <summary>
        /// Creates server and validates that ip endpoint and socket are not empty
        /// </summary>
        [TestMethod]
        public void CreatServer_ShouldCreateTheServer()
        {
            // Arrange
            bool expected = true;
            bool actual = true;

            // Act
            _client.CreateClient();
            if (_client.Ip == null & _client.Socket == null)
                actual = false;

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}