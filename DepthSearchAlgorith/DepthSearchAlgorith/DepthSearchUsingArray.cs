using System.Collections.Generic;

namespace DepthSearchAlgorith
{
    public class DepthSearchUsingArray
    {
        private int[] array;
        private readonly int amountOfObjects;
        private ChessBoard chessBoard;

        public DepthSearchUsingArray(int[] array, List<string> possibleMoves, int amountOfObjects)
        {
            this.array = array;
            this.amountOfObjects = amountOfObjects;

            chessBoard = new ChessBoard(array, possibleMoves);
        }

        public int[] Run()
        {
            InitializeArrayGeneration();
            return chessBoard.PositionArray;
        }

        private void InitializeArrayGeneration()
        {
            for (int i = 0; i < amountOfObjects; i++)
            {
                GeneratePaths(0);
            }
        }

        private void GeneratePaths(int position)
        {
            var localCol = position;
            var possibleAssigments = new List<int>();
            for (int i = 0; i < amountOfObjects && localCol < amountOfObjects; i++)
            {
                if (chessBoard.TryAssignArrayElement(localCol, i))
                {
                    possibleAssigments.Add(i);
                }
            }

            foreach (var possibleAssigment in possibleAssigments)
            {
                chessBoard.AssignArrayElement(localCol, possibleAssigment);
                GeneratePaths(localCol + 1);

                if (!IsArrayValid(chessBoard.PositionArray))
                {
                    chessBoard.UnassignArrayElements(localCol);
                }
                if (IsArrayValid(chessBoard.PositionArray))
                {
                    break;
                }
            }
        }

        private bool IsArrayValid(int[] positionArray)
        {
            if (positionArray[amountOfObjects - 1] != -1)
            {
                return true;
            }

            return false;
        }
    }
}
