using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    public class RatInAMaze
    {
        public void Main()
        {
            int[][] mat = [[1, 0, 0, 0],
                [1, 1, 0, 1],
                [1, 1, 0, 0],
                [0, 1, 1, 1]];

            var ans = FindPath(mat);
            foreach(var item in ans)
            {
                Console.WriteLine(item + " ");
            }
            Console.WriteLine();
        }
        List<string> FindPath(int[][] mat)
        {
            List<string> ans = new List<string>();
            int rows = mat.Length;
            RatInAMazeHelper(mat, ref ans, "", 0, 0, rows, rows);
            return ans;
        }

        private void RatInAMazeHelper(int[][] mat, ref List<string> ans, string route, int row, int col, int rows, int cols)
        {
            if(row == rows-1 && col == cols-1)
            {
                ans.Add(route);
                return;
            }

            // marking current cell as visited
            mat[row][col] = 0;

            if (IsSafe(mat, row + 1, col, rows, cols))
            {
                RatInAMazeHelper(mat, ref ans, route + "D", row + 1, col, rows, cols);
            }
            if (IsSafe(mat, row, col - 1, rows, cols))
            {
                RatInAMazeHelper(mat, ref ans, route + "L", row, col - 1, rows, cols);
            }
            if (IsSafe(mat, row, col + 1, rows, cols))
            {
                RatInAMazeHelper(mat, ref ans, route + "R", row, col + 1, rows, cols);
            }
            if(IsSafe(mat, row - 1, col, rows, cols))
            {
                RatInAMazeHelper(mat, ref ans, route + "U", row - 1, col, rows, cols);
            }

            // marking current cell as unvisited
            mat[row][col] = 1;
        }

        private bool IsSafe(int[][] mat, int row, int col, int rows, int cols)
        {
            // if row and col within the box and the element is 1
            // here mat[row][col] = 1 represents that cell can be taken for route
            return col < cols && col >= 0 && row < rows && row >= 0 && mat[row][col] == 1;
        }
    }
}
