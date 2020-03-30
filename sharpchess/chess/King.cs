using board;

namespace chess
{
    class King : Piece
    {
        private Game Game;

        public King(Board board, Color color, Game game) : base(board, color)
        {
            Game = game;
        }

        public override string ToString()
        {
            return "K";
        }

        private bool CheckRookForCastling(Position pos)
        {
            Piece piece = Board.GetPiece(pos);
            return piece != null && piece is Rook && piece.QtyMovements == 0 && piece.Color == Color;
        }

        public override bool[,] PossibleMovements()
        {
            bool[,] matrix = new bool[Board.Rows, Board.Cols];

            Position pos = new Position(0, 0);

            // up
            pos.Row = Position.Row -1;
            pos.Col = Position.Col;
            if (Board.IsValidPosition(pos) && CanMove(pos))
            {
                matrix[pos.Row, pos.Col] = true;
            }

            // up right
            pos.Row = Position.Row -1;
            pos.Col = Position.Col + 1;
            if (Board.IsValidPosition(pos) && CanMove(pos))
            {
                matrix[pos.Row, pos.Col] = true;
            }

            // right
            pos.Row = Position.Row;
            pos.Col = Position.Col + 1;
            if (Board.IsValidPosition(pos) && CanMove(pos))
            {
                matrix[pos.Row, pos.Col] = true;
            }

            // down right
            pos.Row = Position.Row + 1;
            pos.Col = Position.Col + 1;
            if (Board.IsValidPosition(pos) && CanMove(pos))
            {
                matrix[pos.Row, pos.Col] = true;
            }

            // down
            pos.Row = Position.Row + 1;
            pos.Col = Position.Col;
            if (Board.IsValidPosition(pos) && CanMove(pos))
            {
                matrix[pos.Row, pos.Col] = true;
            }

            // down left
            pos.Row = Position.Row + 1;
            pos.Col = Position.Col - 1;
            if (Board.IsValidPosition(pos) && CanMove(pos))
            {
                matrix[pos.Row, pos.Col] = true;
            }

            // left
            pos.Row = Position.Row;
            pos.Col = Position.Col - 1;
            if (Board.IsValidPosition(pos) && CanMove(pos))
            {
                matrix[pos.Row, pos.Col] = true;
            }

            // up left
            pos.Row = Position.Row - 1;
            pos.Col = Position.Col - 1;
            if (Board.IsValidPosition(pos) && CanMove(pos))
            {
                matrix[pos.Row, pos.Col] = true;
            }

            // Castling
            if (QtyMovements == 0 && !Game.Check)
            {
                Position posRook1 = new Position(Position.Row, Position.Col + 3);
                if (CheckRookForCastling(posRook1))
                {
                    Position pos1 = new Position(Position.Row, Position.Col + 1);
                    Position pos2 = new Position(Position.Row, Position.Col + 2);
                    if (Board.GetPiece(pos1) == null && Board.GetPiece(pos2) == null)
                    {
                        matrix[Position.Row, Position.Col + 2] = true;
                    }
                }
                Position posRook2 = new Position(Position.Row, Position.Col - 4);
                if (CheckRookForCastling(posRook2))
                {
                    Position pos1 = new Position(Position.Row, Position.Col - 1);
                    Position pos2 = new Position(Position.Row, Position.Col - 2);
                    Position pos3 = new Position(Position.Row, Position.Col - 3);
                    if (Board.GetPiece(pos1) == null && Board.GetPiece(pos2) == null && Board.GetPiece(pos3) == null)
                    {
                        matrix[Position.Row, Position.Col - 2] = true;
                    }
                }
            }

            return matrix;
        }
    }
}
