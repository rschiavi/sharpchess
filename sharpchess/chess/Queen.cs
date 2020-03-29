using board;

namespace chess
{
    class Queen : Piece
    {
        public Queen(Board board, Color color) : base(board, color)
        {
        }

        public override string ToString()
        {
            return "Q";
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
