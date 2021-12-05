using Microsoft.VisualStudio.TestTools.UnitTesting;
using FourthTask;
using System.Text;


namespace FourthTaskTests
{
    [TestClass]
    public class HttpServerTests
    {

        HttpServer http;

        [TestInitialize]
        public void TestInitizlie()
        {
            http = new HttpServer(9000);
        }
        
        /// <summary>
        /// Tests ValidateHttpRequest method by sending correct request
        /// </summary>
        [TestMethod]
        public void ValidateHttpRequest_CorrectRequest_ShouldReturnTrue()
        {
            // Arrange
            string request = "GET / HTTP / 1.1\r\nHost: 127.0.0.1\r\nConnection: keep - alive\r\nAccept: text / html\r\nUser - Agent: CSharpTests\r\n\r\n";
            bool expected = true;

            // Act
            bool actual = http.ValidateHttpRequest(Encoding.ASCII.GetBytes(request));

            // Assert
            Assert.AreEqual(expected, actual);
        }
        /// <summary>
        /// Tests ValidateHttpRequest method by sending incorrect request
        /// </summary>
        [TestMethod]
        public void ValidateHttpRequest_IncorrectRequest_ShouldReturnFalse()
        {
            // Arrange
            string request = "Random words";
            bool expected = false;

            // Act
            bool actual = http.ValidateHttpRequest(Encoding.ASCII.GetBytes(request));

            // Assert
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Tests ParseBody of the request method
        /// </summary>
        [TestMethod]
        public void ParseBody_ShouldParseBodyOfTheIncomingRequest()
        {
            // Arrange
            string request = "GET / HTTP / 1.1\r\nHost: 127.0.0.1\r\nConnection: keep - alive\r\nAccept: text / html\r\nUser - Agent: CSharpTests\r\n\r\n";
            string expected = "text";


            // Act
            http.ValidateHttpRequest(Encoding.ASCII.GetBytes(request));
            string actual = http.ParseBody();

            // Assert
            Assert.AreEqual(expected, actual);
        }


    }
}
