using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    public class SudokuSolver
    {
        public void Main()
        {
            char[][] board = new char[][]
            {
                new char[] {'5','3','.','.','7','.','.','.','.'},
                new char[] {'6','.','.','1','9','5','.','.','.'},
                new char[] {'.','9','8','.','.','.','.','6','.'},
                new char[] {'8','.','.','.','6','.','.','.','3'},
                new char[] {'4','.','.','8','.','3','.','.','1'},
                new char[] {'7','.','.','.','2','.','.','.','6'},
                new char[] {'.','6','.','.','.','.','2','8','.'},
                new char[] {'.','.','.','4','1','9','.','.','5'},
                new char[] {'.','.','.','.','8','.','.','7','9'}
            };

            SolveSudoku(board);


            foreach(var item in board)
            {
                foreach(var ch in item)
                {
                    Console.Write(ch + " ");
                }
                Console.WriteLine();
            }
        }

        public void SolveSudoku(char[][] board)
        {
            SudokuSolverHelper(board);
        }

        private bool SudokuSolverHelper(char[][] board)
        {
            for (int i = 0; i < board.Length; i++)
            {
                for (int j = 0; j < board[0].Length; j++)
                {
                    if (board[i][j] == '.')
                    {
                        for (char ch = '1'; ch <= '9'; ch++)
                        {
                            if (IsSafe(ch, board, i, j)) // if this number is safe to place at this location
                            {
                                board[i][j] = ch;
                                if(SudokuSolverHelper(board) == true)
                                {
                                    return true;
                                }
                                else
                                {
                                    board[i][j] = '.';
                                }
                            }
                        }

                        return false;
                    }
                }
            }

            return true;
        }

        private bool IsSafe(char ch, char[][] board, int i, int j)
        {
            for(int k = 0; k < 9; k++)
            {
                // checking all rows in a column
                if (board[k][j] == ch)
                {
                    return false;
                }

                // checking all columns in a row
                if (board[i][k] == ch)
                {
                    return false;
                }

                // checking if smaller 9 * 9 grid have the same element
                int row = 3 * (i / 3) + k / 3;
                int column = 3 * (j / 3) + k % 3;
                if (board[row][column] == ch)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
