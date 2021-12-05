using Microsoft.VisualStudio.TestTools.UnitTesting;
using FourthTask;

namespace FourthTaskTests
{
    [TestClass]
    public class DistributedrProcessTests
    {
        /// <summary>
        /// Tests Process method in distributed version
        /// </summary>
        [TestMethod]
        public void Process_ShouldProcessMatrix()
        {
            // Arrange
            ProcessingResults.Reset();
            string expected = "4,111111111111093,9,222222222222234,-7,88888888888889";
            GaussianHandler gaussian = new GaussianHandler();
            DistributedProcess process = new DistributedProcess();
            gaussian.ConnectProcess(process);

            // Act
            object temp = new object();
            gaussian.GaussSolve(temp, "{{ 3,5,5,19},{ 4,7,9,10},{ 2,5,6,7}}");
            string actual = ProcessingResults.Solution;

            // Assert
            Assert.AreEqual(expected, actual);
        }

    }
}
