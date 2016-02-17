namespace DepthSearchAlgorith
{
    class Program
    {
        private const int matrixLenght = 10;
        private const int matrixWidth = 10;

        //H - horizontal
        //V - vertical
        //O - obliquely
        //KS - knight style
        private const string possibleMoves = "H|V|O|KS";

        static void Main(string[] args)
        {
            var matrix = new int[matrixLenght,matrixWidth];

            var chessBoard = new ChessBoard(matrix);
            var generatedChessBoard = chessBoard.Run();
        }
    }
}
