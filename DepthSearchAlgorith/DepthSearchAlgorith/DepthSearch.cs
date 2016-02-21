using System.Collections.Generic;

namespace DepthSearchAlgorith
{
    public class DepthSearch
    {
        private int[,] matrix;
        private readonly int amountOfObjects;
        private ChessBoard chessBoard;

        public DepthSearch(int[,] matrix, List<string> possibleMoves, int amountOfObjects)
        {
            this.matrix = matrix;
            this.amountOfObjects = amountOfObjects;

            chessBoard = new ChessBoard(matrix, possibleMoves);
        }

        public int[,] Run()
        {
            InitializeMatrixGeneration();
            if (IsMatrixValid(chessBoard.Matrix))
            {
                return chessBoard.Matrix;
            }
            return new int[0,0];
        }

        private void InitializeMatrixGeneration()
        {
            for (var i = 0; i < amountOfObjects; i++)
            {
                GeneratePaths(0);

                if (IsMatrixValid(chessBoard.Matrix))
                {
                    break;
                }

                chessBoard.Matrix = new int[matrix.GetLength(0), matrix.GetLength(1)];
            }

            matrix = chessBoard.Matrix;
        }

        private bool IsMatrixValid(int[,] tempMatrix)
        {
            var count = 0;
            for (var i = 0; i < tempMatrix.GetLength(0); i++)
            {
                for (var j = 0; j < tempMatrix.GetLength(1); j++)
                {
                    if (tempMatrix[i, j] == 1)
                    {
                        count++;
                    }
                }
            }

            return count == amountOfObjects;
        }

        private void GeneratePaths(int col)
        {
            var localCol = col;
            var possibleAssigments = new List<Postion>();
            for (int i = 0; i < amountOfObjects && localCol < amountOfObjects; i++)
            {
                if (chessBoard.TryAssignElement(localCol, i))
                {
                    possibleAssigments.Add(new Postion {Column = localCol, Row = i});
                }
            }

            foreach (var possibleAssigment in possibleAssigments)
            {
                chessBoard.AssignElement(possibleAssigment.Column, possibleAssigment.Row);
                GeneratePaths(possibleAssigment.Column + 1);

                if (!IsMatrixValid(chessBoard.Matrix))
                {
                    chessBoard.UnassignElements(possibleAssigment.Column);
                }
                if (IsMatrixValid(chessBoard.Matrix))
                {
                    break;
                }
            }
        }
    }

    internal class Postion
    {
        public int Column { get; set; }
        public int Row { get; set; }
    }
}
