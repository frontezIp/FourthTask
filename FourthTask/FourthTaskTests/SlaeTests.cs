using Microsoft.VisualStudio.TestTools.UnitTesting;
using FourthTask;

namespace FourthTaskTests
{
    [TestClass]
    public class SlaeTests
    {
        Slae slae;

        [TestInitialize]
        public void TestInitizlie()
        {
            string matrix = "{{3,5,5,19},{4,7,9,10},{2,5,6,7}}";
            slae = new Slae(matrix);
        }
        
        /// <summary>
        /// Tests copy method
        /// </summary>
        [TestMethod]
        public void Copy_ShouldMadeCopyOfTheMatrix()
        {
            // Arrange
            double[,] expected = { { 3, 5, 5, 19 }, { 4, 7, 9, 10 }, { 2, 5, 6, 7 } };

            // Act
            double[,] actual = slae.Copy();

            // Arrange
            CollectionAssert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Tests CopySquare method
        /// </summary>
        [TestMethod]
        public void ÑopySquare_ShouldCopySquarePartOfTheMatrix()
        {
            // Arrange
            double[,] expected = { { 3, 5, 5 }, { 4, 7, 9 }, { 2, 5, 6 } };

            // Act
            double[,] actual = slae.CopySquare();

            CollectionAssert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Tests CopyColumn method
        /// </summary>
        [TestMethod]
        public void CopyColumn_ShouldCopyLastColumnOfTheMatrix()
        {
            // Arrange
            double[] expected = { 19,10,7 };

            // Act
            double[] actual = slae.CopyColumn();

            CollectionAssert.AreEqual(expected, actual);
        }


        /// <summary>
        /// Tests FindSize method
        /// </summary>
        [TestMethod]
        public void FindSize_ShouldFindCorrectSizesOfTheMatrix()
        {
            // Arrange
            (int, int) expected = (3, 4);

            // Act
            (int, int) actual = slae.Size;

            // Assert
            Assert.AreEqual(expected, actual);


        }
    }
}
