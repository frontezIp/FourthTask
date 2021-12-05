using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace FourthTask
{
    public class Slae
    {
        private double[][] _matrix;

        private (int, int) _size;

        public (int, int) Size { get => _size; }

        public Slae(string matrix)
        {
            TransformIntoMatrix(matrix);
            FindSize();
        }

        /// <summary>
        /// Copy current matrix and return it
        /// </summary>
        /// <returns></returns>
        public double[,] Copy()
        {
            double[,] array = new double[_size.Item1, _size.Item2];
            for(int i = 0; i < _size.Item1; i++)
            {
                for(int j = 0; j<_size.Item2; j++)
                {
                    array[i, j] = _matrix[i][j];
                }
            }
            return array;
        }

        /// <summary>
        /// Copy square of the current matrix and return it
        /// </summary>
        /// <returns></returns>
        public double[,] CopySquare()
        {
            double[,] array = new double[_size.Item1, _size.Item1];
            for (int i = 0; i < _size.Item1; i++)
            {
                for (int j = 0; j < _size.Item1; j++)
                {
                    array[i, j] = _matrix[i][j];
                }
            }
            return array;
        }

        /// <summary>
        /// Copy last column of the current matrix and return it
        /// </summary>
        /// <returns></returns>
        public double[] CopyColumn()
        {
            double[] array = new double[_size.Item1];
            for (int i = 0; i < _size.Item1; i++)
            {
                array[i] = _matrix[i][_size.Item2-1];
            }
            return array;
        }

        public double[][] Matrix { get => _matrix; }
       
        /// <summary>
        /// Find size of the current matrix
        /// </summary>
        public void FindSize()
        {
            _size.Item1=_matrix.GetLength(0);
            _size.Item2 = _matrix[0].Length;
        }

        /// <summary>
        /// Transform matrix from string to double
        /// </summary>
        /// <param name="matrix"></param>
        public void TransformIntoMatrix(string matrix)
        {
            matrix = matrix.Replace(" ", string.Empty);

            _matrix =
            // match groups
            Regex.Matches(matrix, @"{(\d+,?)+},?").Cast<Match>()
            .Select(m =>
               // match digits in a group
               Regex.Matches(m.Groups[0].Value, @"\d+(?=,?)").Cast<Match>()
               // parse digits into an array
               .Select(ma => double.Parse(ma.Groups[0].Value)).ToArray())
                // put everything into an array
                .ToArray(); 
        }
    }
}
