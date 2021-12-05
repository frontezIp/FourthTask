using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text;
using FourthTask;

namespace FourthTaskTests
{
    [TestClass]
    public class ProcessDataTests
    {

        ProcessData data;

        [TestInitialize]
        public void TestInitizlie()
        {
            int port = 9000;
            GaussianHandler gaussian = new GaussianHandler();
            HttpServer http = new HttpServer(port);
            Server server = new Server(port);
            Client client = new Client(port);

            data = new ProcessData(gaussian, http, server, client);
        }

        /// <summary>
        /// Test Process method in scenario when request is not http
        /// </summary>
        [TestMethod]
        public void Process_ShouldProcessIncomingData()
        {
            // Arrange
            string matrix = "{{ 3,5,5,19},{ 4,7,9,10},{ 2,5,6,7}}";
            string expected = "4,111111111111093,9,222222222222234,-7,88888888888889";

            // Act
            object obj = new object();
            data.Gauss.ConnectProcess(new DistributedProcess());
            data.Process(obj, Encoding.UTF8.GetBytes(matrix));
            string actual = ProcessingResults.Solution;

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
