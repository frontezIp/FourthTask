using Microsoft.VisualStudio.TestTools.UnitTesting;
using FourthTask;

namespace FourthTaskTests
{
    [TestClass]
    public class ProcessingResultsTests
    {
     
        /// <summary>
        /// Tests SetResults method
        /// </summary>
        [TestMethod]
        public void SetResults_ShoudInitializeResultOfTheOperation()
        {
            // Arrange
            double[] array = { 5, 6, 7 };
            ProcessingResults.Reset();
            string expected = "Linear:543";

            // Act
            ProcessingResults.SetResults("Linear", array, 543);
            string actual = ProcessingResults.TimeUsage;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Tests GetResults Method
        /// </summary>
        [TestMethod]
        public void GetResults_ShouldReturnCorrectResults()
        {
            // Arrange
            double[] array = { 5, 6, 7 };
            ProcessingResults.Reset();

            string expected = "5,6,7. Linear:543";

            // Act
            ProcessingResults.SetResults("Linear", array, 543);
            string actual = ProcessingResults.GetResults();

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
