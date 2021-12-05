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
    public class ServerTests
    {
        Server _server;
        
        [TestInitialize]
        public void TestInitialize()
        {
            int port = 9000;
            _server = new Server(port);
        }

        /// <summary>
        /// Create server and validate that ip endpoint and socket are not empty
        /// </summary>
        [TestMethod]
        public void CreatServer_ShouldCreateTheServer()
        {
            // Arrange
            bool expected = true;
            bool actual = true;

            // Act
            _server.CreateServer();
            if (_server.IP == null & _server.Socket == null)
                actual = false;

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
