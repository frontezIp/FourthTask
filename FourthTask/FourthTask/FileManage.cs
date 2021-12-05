using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.IO;

namespace FourthTask
{
    public class FileManage
    {
        private Regex checkReadingMatrix;
        public FileManage()
        {
            checkReadingMatrix = new Regex(@"\{\{[0-9,]+[0-9]\},+{[0-9,]+[0-9]\},*\}");
        }

        /// <summary>
        /// Reads data from file
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public string ReadDataFromFile(string path)
        {
            using (StreamReader sr = new StreamReader(path, System.Text.Encoding.Default))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    return line;
                }
            }
            return "";
        }

        /// <summary>
        /// Validate if the matrix in correct form
        /// </summary>
        /// <param name="matrix"></param>
        /// <returns></returns>
        public bool ValidateData(string matrix)
        {
            if (!checkReadingMatrix.IsMatch(matrix))
                return false;
            return true;
        }
    }
}
