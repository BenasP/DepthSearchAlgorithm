namespace DepthSearchAlgorith
{
    public class ChessBoard
    {
        private int[,] matrix;

        public ChessBoard(int[,] matrix)
        {
            this.matrix = matrix;
        }

        public int[,] Run()
        {
            for (int obj = 0; obj < 10; obj++)
            {
                matrix[obj, 0] = 1;
            }
            return matrix;
        }
    }
}