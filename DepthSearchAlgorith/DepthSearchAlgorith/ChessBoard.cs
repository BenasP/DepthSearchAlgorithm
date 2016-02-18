using System.Collections.Generic;

namespace DepthSearchAlgorith
{
    public class ChessBoard
    {
        private int[,] matrix;
        private List<string> possibleMoves;
        private readonly int amountOfObjects;

        public ChessBoard(int[,] matrix, List<string> possibleMoves, int amountOfObjects)
        {
            this.matrix = matrix;
            this.possibleMoves = possibleMoves;
            this.amountOfObjects = amountOfObjects;
        }

        public int[,] Run()
        {
            InitializeMatrixGeneration();
            //for (var obj = 0; obj < amountOfObjects; obj++)
            //{
            //    for (int lengthIndex = 0; lengthIndex < matrix.GetLength(0); lengthIndex++)
            //    {
            //        for (int widthIndex = 0; widthIndex < matrix.GetLength(1); widthIndex++)
            //        {
            //            if ((matrix[lengthIndex, widthIndex] != 1) || (matrix[lengthIndex, widthIndex] != 2))
            //            {
            //                matrix[lengthIndex, widthIndex] = 1;
            //                GenerateCrossingOutPaths(lengthIndex, widthIndex);
            //            }
            //        }
            //    }
            //}
            return matrix;
        }

        private void InitializeMatrixGeneration()
        {
            var tempMatrix = new int[matrix.GetLength(0), matrix.GetLength(1)];
            for (var i = 0; i < amountOfObjects; i++)
            {
                AssignElement(tempMatrix, 0, i);

                GeneratePaths(tempMatrix, 1);
            }
        }

        private void GeneratePaths(int[,] tempMatrix, int col)
        {
            for (int i = 0; i < amountOfObjects && col < amountOfObjects; i++)
            {
                if ((matrix[col, i] != 1) || (matrix[col, i] != 2))
                {
                    AssignElement(tempMatrix, col, i);
                    GeneratePaths(tempMatrix, ++col);
                }
                if (col == 9)
                {
                    
                }
            }
        }

        private void AssignElement(int[,] tempMatrix, int col, int row)
        {
            tempMatrix[col, row] = 1;
            GenerateCrossingOutPaths(tempMatrix, col, row);
        }

        private void GenerateCrossingOutPaths(int[,] tempMatrix, int col, int row)
        {
            if (possibleMoves.Contains("H"))
            {
                CrossOutRow(tempMatrix, col, row);
            }
            if (possibleMoves.Contains("V"))
            {
                CrossOutColumn(tempMatrix, col, row);
            }
        }

        private void CrossOutColumn(int[,] tempMatrix, int col, int row)
        {
            for (int i = 0; i < col; i++)
            {
                tempMatrix[i, row] = 2;
            }
        }

        private void CrossOutRow(int[,] tempMatrix, int col, int row)
        {
            for (int i = 0; i < row; i++)
            {
                tempMatrix[col, i] = 2;
            }
        }
    }
}