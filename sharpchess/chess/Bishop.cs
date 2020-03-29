using board;

namespace chess
{
    class Bishop : Piece
    {
        public Bishop(Board board, Color color) : base(board, color)
        {
        }

        public override string ToString()
        {
            return "B";
        }

        public override bool[,] PossibleMovements()
        {
            bool[,] matrix = new bool[Board.Rows, Board.Cols];

            Position pos = new Position(0, 0);

            // up right
            pos.Row = Position.Row - 1;
            pos.Col = Position.Col + 1;
            while (Board.IsValidPosition(pos) && CanMove(pos))
            {
                matrix[pos.Row, pos.Col] = true;
                if (Board.GetPiece(pos) != null && Board.GetPiece(pos).Color != Color)
                {
                    break;
                }
                pos.Row--;
                pos.Col++;
            }

            // down right
            pos.Row = Position.Row + 1;
            pos.Col = Position.Col + 1;
            while (Board.IsValidPosition(pos) && CanMove(pos))
            {
                matrix[pos.Row, pos.Col] = true;
                if (Board.GetPiece(pos) != null && Board.GetPiece(pos).Color != Color)
                {
                    break;
                }
                pos.Row++;
                pos.Col++;
            }

            // down left
            pos.Row = Position.Row + 1;
            pos.Col = Position.Col - 1;
            while (Board.IsValidPosition(pos) && CanMove(pos))
            {
                matrix[pos.Row, pos.Col] = true;
                if (Board.GetPiece(pos) != null && Board.GetPiece(pos).Color != Color)
                {
                    break;
                }
                pos.Row++;
                pos.Col--;
            }

            // up left
            pos.Row = Position.Row - 1;
            pos.Col = Position.Col - 1;
            while (Board.IsValidPosition(pos) && CanMove(pos))
            {
                matrix[pos.Row, pos.Col] = true;
                if (Board.GetPiece(pos) != null && Board.GetPiece(pos).Color != Color)
                {
                    break;
                }
                pos.Row--;
                pos.Col--;
            }

            return matrix;
        }
    }
}
