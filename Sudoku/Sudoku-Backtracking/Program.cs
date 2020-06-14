using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku_Backtracking
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] board = new int[,]
            {
                { 0, 0, 0, 0, 9, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 5, 0, 0, 8 },
                { 0, 0, 0, 8, 3, 0, 4, 9, 6 },
                { 0, 0, 5, 0, 0, 0, 0, 6, 0 },
                { 0, 0, 0, 4, 0, 0, 1, 8, 0 },
                { 9, 2, 0, 0, 0, 1, 0, 0, 0 },
                { 6, 0, 0, 0, 0, 0, 0, 3, 0 },
                { 0, 0, 0, 2, 0, 0, 0, 4, 0 },
                { 5, 0, 0, 6, 0, 3, 0, 0, 0 }
            };

            int N = board.GetLength(0);

            if (Sudoku.SolveSudoku(board, N)) Sudoku.Print(board, N);
            else Console.Write("No solution");

        }
    }
}
