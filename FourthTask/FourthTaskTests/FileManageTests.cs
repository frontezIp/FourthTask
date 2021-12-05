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
    public class FileManageTests
    {
        /// <summary>
        /// Tests ValidateData by sending correct matrix
        /// </summary>
        [TestMethod]
        public void ValidateData_ValidMatrix_ShouldReturnTrue()
        {
            // Arrange
            bool expected = true;
            string matrix = "{{3,5,6},{3,13,6}}";
            FileManage manage = new FileManage();

            // Act
            bool actual = manage.ValidateData(matrix);

            // Assert
            Assert.AreEqual(expected, actual);
        }
        /// <summary>
        /// Tests ValidateData by sending incorrect matrix
        /// </summary>
        [TestMethod]
        public void ValidateData_InvalidMatrix_ShouldReturnFalse()
        {
            // Arrange
            bool expected = false;
            string matrix = "{{3,5,6},{3sfafsa}";
            FileManage manage = new FileManage();

            // Act
            bool actual = manage.ValidateData(matrix);

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
