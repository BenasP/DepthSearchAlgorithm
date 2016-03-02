using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace DepthSearchAlgorith
{
    class Program
    {
        private const int matrixLenght = 10;
        private const int matrixWidth = 10;
        private const int amountOfObjects = 10;

        static void Main(string[] args)
        {
            var matrix = new int[matrixLenght, matrixWidth];
            var array = new int[amountOfObjects].Select(x => x = -1).ToArray();

            //H - horizontal
            //V - vertical
            //O - obliquely
            //KS - knight style
            var possibleMoves = new List<string> { "H", "V", "O", "KS" };
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            //var chessBoard = new DepthSearch(matrix, possibleMoves, amountOfObjects);
            //var generatedChessBoard = chessBoard.Run();
            var chessBoard = new DepthSearchUsingArray(array, possibleMoves, amountOfObjects);
            var generatedChessBoard = chessBoard.Run();
            stopWatch.Stop();
            TimeSpan ts = stopWatch.Elapsed;
            // PrintMatrix(generatedChessBoard);
            PrintArray(generatedChessBoard);
            Console.WriteLine($"Time consumed: { ts.TotalSeconds }");

            Console.ReadLine();
        }

        private static void PrintArray(int[] generatedChessBoard)
        {
            for (int i = 0; i < generatedChessBoard.Length; i++)
            {
                for (int j = 0; j < amountOfObjects; j++)
                {
                    if (generatedChessBoard[i] == j)
                    {
                        Console.Write($" 1");
                    }
                    else
                    {
                        Console.Write($" 0");
                    }
                }
                Console.WriteLine();
            }
        }

        private static void PrintMatrix(int[,] generatedChessBoard)
        {
            for (int i = 0; i < matrixLenght; i++)
            {
                for (int j = 0; j < matrixWidth; j++)
                {
                    Console.Write(generatedChessBoard[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
