using System.Collections.Generic;

namespace DepthSearchAlgorith
{
    class Program
    {
        private const int matrixLenght = 10;
        private const int matrixWidth = 10;
        private const int amountOfObjects = 10;

        static void Main(string[] args)
        {
            var matrix = new int[matrixLenght,matrixWidth];
            //H - horizontal
            //V - vertical
            //O - obliquely
            //KS - knight style
            var possibleMoves = new List<string> { "H", "V", "O", "KS" };

            var chessBoard = new ChessBoard(matrix, possibleMoves, amountOfObjects);
            var generatedChessBoard = chessBoard.Run();
        }
    }
}
