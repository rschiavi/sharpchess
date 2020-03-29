using board;

namespace chess
{
    class Rook : Piece
    {
        public Rook(Board board, Color color) : base(board, color)
        {
        }

        public override string ToString()
        {
            return "R";
        }

        public override bool[,] PossibleMovements()
        {
            bool[,] matrix = new bool[Board.Rows, Board.Cols];

            Position pos = new Position(0, 0);

            // up
            pos.Row = Position.Row - 1;
            pos.Col = Position.Col;
            while (Board.IsValidPosition(pos) && CanMove(pos))
            {
                matrix[pos.Row, pos.Col] = true;
                if (Board.GetPiece(pos) != null && Board.GetPiece(pos).Color != Color)
                {
                    break;
                }
                pos.Row--;
            }

            // down
            pos.Row = Position.Row + 1;
            pos.Col = Position.Col;
            while (Board.IsValidPosition(pos) && CanMove(pos))
            {
                matrix[pos.Row, pos.Col] = true;
                if (Board.GetPiece(pos) != null && Board.GetPiece(pos).Color != Color)
                {
                    break;
                }
                pos.Row++;
            }

            // right
            pos.Row = Position.Row;
            pos.Col = Position.Col + 1;
            while (Board.IsValidPosition(pos) && CanMove(pos))
            {
                matrix[pos.Row, pos.Col] = true;
                if (Board.GetPiece(pos) != null && Board.GetPiece(pos).Color != Color)
                {
                    break;
                }
                pos.Col++;
            }

            // left
            pos.Row = Position.Row;
            pos.Col = Position.Col - 1;
            while (Board.IsValidPosition(pos) && CanMove(pos))
            {
                matrix[pos.Row, pos.Col] = true;
                if (Board.GetPiece(pos) != null && Board.GetPiece(pos).Color != Color)
                {
                    break;
                }
                pos.Col--;
            }

            return matrix;
        }
    }
}
