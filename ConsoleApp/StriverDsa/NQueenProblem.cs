using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.StriverDsa
{
    public class NQueenProblem
    {
        public void Main()
        {
            int n = 4;
            var ans = SolveNQueens(n);
            foreach(var item in ans)
            {
                foreach(var item2 in item)
                {
                    Console.Write(item2 + " ");
                }
                Console.WriteLine();
            }
            
        }

        public IList<IList<string>> SolveNQueens(int n)
        {
            IList<IList<string>> ans = new List<IList<string>>();
            List<StringBuilder> board = new List<StringBuilder>();
            int[] left = new int[n];
            int[] upperDiagonal = new int[2 * n - 1];
            int[] lowerDiagonal = new int[2 * n - 1];

            for (int i = 0; i < n; i++)
            {
                board.Add(new StringBuilder(new string('.', n)));
            }
            NQueenHelper(0, n, ref ans, board, left, upperDiagonal, lowerDiagonal);
            return ans;
        }

        // here n is the total columns or rows because it's n * n board.
        private void NQueenHelper(int currCol, int n, ref IList<IList<string>> ans, List<StringBuilder> board, int[] left, int[] upperDiagonal, int[] lowerDiagonal)
        {
            if(currCol == n)
            {
                List<string> temp = new List<string>();
                foreach(var item in board)
                {
                    temp.Add(item.ToString());
                }
                ans.Add(new List<string>(temp));
                return;
            }

            for(int i = 0; i < n; i++) // go over all rows in curr column to find where I can place a queen safely
            {
                //if (IsSafe(i, currCol, board, n))
                if (left[i] == 0 && lowerDiagonal[i + currCol] == 0 && upperDiagonal[n - 1 + currCol - i] == 0)
                {
                    board[i][currCol] = 'Q';
                    left[i] = 1;
                    lowerDiagonal[i + currCol] = 1;
                    upperDiagonal[n - 1 + currCol - i] = 1;
                    NQueenHelper(currCol + 1, n, ref ans, board, left, upperDiagonal, lowerDiagonal);
                    left[i] = 0;
                    lowerDiagonal[i + currCol] = 0;
                    upperDiagonal[n - 1 + currCol - i] = 0;
                    board[i][currCol] = '.';
                }
            }

            return;
        }

        private bool IsSafe(int row, int col, List<StringBuilder> board, int n)
        {
            // only check left, upper left diagonal and lower left diagonal
            int tempRow = row;
            int tempCol = col;

            while(tempCol >= 0)
            {
                if (board[tempRow][tempCol] == 'Q')
                {
                    return false;
                }
                tempCol--;
            }

            tempCol = col;

            while(tempRow >= 0 && tempCol >= 0)
            {
                if (board[tempRow][tempCol] == 'Q')
                {
                    return false;
                }
                tempRow--;
                tempCol--;
            }

            tempRow = row;
            tempCol = col;

            while(tempCol >= 0 && tempRow < n) 
            {
                if (board[tempRow][tempCol] == 'Q')
                {
                    return false;
                }
                tempCol--;
                tempRow++;
            }

            return true;
        }
    }
}
