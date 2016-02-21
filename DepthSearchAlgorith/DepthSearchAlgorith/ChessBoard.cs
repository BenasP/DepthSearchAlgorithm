using System.Collections.Generic;

namespace DepthSearchAlgorith
{
    public class ChessBoard
    {
        private int[,] request;

        public int[,] Matrix { get; set; }
        public List<string> PossibleMoves { get; set; }
        public bool IsAssignmentSuccessful { get; set; } = true;

        public ChessBoard(int[,] matrix)
        {
            Matrix = matrix;
        }

        public ChessBoard(int[,] matrix, List<string> possibleMoves)
        {
            Matrix = matrix;
            PossibleMoves = possibleMoves;
        }

        public bool IsRowClear(int col, int row)
        {
            var tempCol = col - 1;
            for (int i = tempCol; i >= 0 && col != 0; i--)
            {
                if (Matrix[row, i] == 1)
                {
                    return false;
                }
            }

            return true;
        }

        public bool IsColumnClear(int col, int row)
        {
            var tempRow = row - 1;
            for (int i = tempRow; i >= 0 && row != 0; i--)
            {
                if (Matrix[i, col] == 1)
                {
                    return false;
                }
            }

            return true;
        }

        public bool IsObliqueliesClear(int col, int row)
        {
            var descRow = row - 1;
            var ascRow = row + 1;
            for (var tempCol = col - 1; descRow >= 0 && tempCol >= 0; descRow--, tempCol--)
            {
                if (Matrix[descRow, tempCol] == 1)
                {
                    return false;
                }
            }

            for (var tempCol = col - 1; ascRow < Matrix.GetLength(0) && tempCol >= 0; ascRow++, tempCol--)
            {
                if (Matrix[ascRow, tempCol] == 1)
                {
                    return false;
                }
            }

            return true;
        }

        public bool IsKnightStyleCrossingOutClear(int col, int row)
        {
            if (!IsCellClear(col, -1, row, -2))   ////
            {                                       //
                return false;                       //
            }

            if (!IsCellClear(col, -2, row, -1))   //////
            {                                         //
                return false;                     
            }

            if (!IsCellClear(col, -2, row, 1))       //
            {                                    //////
                return false;                     
            }

            if (!IsCellClear(col, -1, row, 2))       //
            {                                        //
                return false;                      ////
            }
            
            return true;
        }

        private bool IsCellClear(int col, int pCol, int row, int pRow)
        {
            var tempCol = col + pCol;
            var tempRow = row + pRow;
            if ((tempCol > -1)
                && (tempRow > -1)
                && (tempCol < Matrix.GetLength(0))
                && (tempRow < Matrix.GetLength(1)))     
            {
                if (Matrix[tempRow, tempCol] != 0)
                {
                    return false;
                }
            }

            return true;
        }

        public bool TryAssignElement(int col, int row)
        {
            if (IsCrossingOutPathsClear(col, row))
            {
                return true;
            }

            return false;
        }

        public void AssignElement(int col, int row)
        {
            Matrix[row, col] = 1;
        }

        public void UnassignElements(int col)
        {
            for (int i = col; col < Matrix.GetLength(0); col++)
            {
                for (int j = 0; j < Matrix.GetLength(0); j++)
                {
                    Matrix[j, i] = 0;
                }
            }
        }

        private bool IsCrossingOutPathsClear(int col, int row)
        {
            if (PossibleMoves.Contains("H"))
            {
                if (!IsRowClear(col, row))
                {
                    return false;
                }
            }

            if (PossibleMoves.Contains("V"))
            {
                if (!IsColumnClear(col, row))
                {
                    return false;
                }
            }

            if (PossibleMoves.Contains("V"))
            {
                if (!IsObliqueliesClear(col, row))
                {
                    return false;
                }
            }

            if (PossibleMoves.Contains("KS"))
            {
                if (!IsKnightStyleCrossingOutClear(col, row))
                {
                    return false;
                }
            }

            return true;
        }
    }
}