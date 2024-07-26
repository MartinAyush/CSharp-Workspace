using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.StriverDsa
{
    public class RotateImageLeetcode
    {
        public void Main()
        {
            int[][] matrix = [[1, 2, 3], [4, 5, 6], [7, 8, 9]];
            Rotate(matrix);
            PrintMatrix(matrix);
        }

        private void PrintMatrix(int[][] matrix)
        {
            foreach (var item in matrix)
            {
                foreach (var item2 in item)
                {
                    Console.Write(item2 + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        public void Rotate(int[][] matrix)
        {
            // Intution: Transpose the matrix and then reverse all the rows

            // In Transpose we swap the elements i, j => j, i
            for(int i = 0; i < matrix.Length; i++)
            {
                for(int j = i; j < matrix[0].Length; j++)
                {
                    (matrix[i][j], matrix[j][i]) = (matrix[j][i], matrix[i][j]);
                }
            }
            Console.WriteLine("After Transpose:");
            PrintMatrix(matrix);
            // reverse all rows
            for(int i = 0; i < matrix.Length; i++)
            {
                int start = 0, end = matrix[0].Length - 1;
                while(start < end)
                {
                    (matrix[i][start], matrix[i][end]) = (matrix[i][end], matrix[i][start]);
                    start++;
                    end--;
                }
            }
        }
    }
}
