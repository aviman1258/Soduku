using System;

namespace Sudoku_Backtracking
{
    class Sudoku
    {
        public static bool IsSafe(int[, ] board, int row, int col, int num)
        {
            //row has the unique (row-clash)
            for(int d=0; d < board.GetLength(0); d++)
            {
                //if the number we are trying to place is already presnt in the
                //row, return false;
                if (board[row, d] == num) return false;
            }

            //col has the unique numbers (column-clash)
            for(int r = 0; r < board.GetLength(0); r++)
            {
                //if the number we are trying to place is already presnt in the
                //column, return false;
                if (board[r, col] == num) return false;
            }

            //corresponding square has unique number (box-clash)
            int sqrt = (int)Math.Sqrt(board.GetLength(0));
            int boxRowStart = row - row % sqrt;
            int boxColStart = col - col % sqrt;

            for (int r = boxRowStart; r < boxRowStart + sqrt; r++)
            {
                for(int d = boxColStart; d < boxColStart + sqrt; d++)
                {
                    if (board[r, d] == num) return false;
                }
            }

            //There is no clash return true;
            return true;
        }

        public static bool SolveSudoku(int[, ] board, int n)
        {
            int row = -1;
            int col = -1;
            bool isEmpty = true;
            for(int i = 0; i < n; i++)
            {
                for(int j = 0; j < n; j++)
                {
                    if(board[i,j] == 0)
                    {
                        row = i;
                        col = j;

                        //we still have sine remaining missing values
                        isEmpty = false;
                        break;
                    }
                }

                if (!isEmpty) break;
            }

            //No empty space left
            if (isEmpty) return true;

            //else for each row backtrack
            for(int num = 1; num <= n; num++)
            {
                if(IsSafe(board, row, col, num))
                {
                    board[row, col] = num;

                    //if true print board
                    //else replace it
                    if (SolveSudoku(board, n)) return true;
                    else board[row, col] = 0;
                }
            }

            return false;
        }

        public static void Print(int[,] board, int N)
        {
            //answer obtained... print
            for(int r = 0; r < N; r++)
            {
                for(int d = 0; d < N; d++)
                {
                    Console.Write(board[r, d]);
                    Console.Write(" ");
                }

                Console.Write("\n");

                if ((r + 1) % (int)Math.Sqrt(N) == 0) Console.Write("");
            }
        }
    }
}
