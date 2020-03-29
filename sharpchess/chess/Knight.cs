using board;

namespace chess
{
    class Knight : Piece
    {
        public Knight(Board board, Color color) : base(board, color)
        {
        }

        public override string ToString()
        {
            return "N";
        }

        public override bool[,] PossibleMovements()
        {
            bool[,] matrix = new bool[Board.Rows, Board.Cols];

            Position pos = new Position(0, 0);

            pos.Row = Position.Row - 1;
            pos.Col = Position.Col - 2;
            if (Board.IsValidPosition(pos) && CanMove(pos))
            {
                matrix[pos.Row, pos.Col] = true;
            }

            pos.Row = Position.Row - 1;
            pos.Col = Position.Col + 2;
            if (Board.IsValidPosition(pos) && CanMove(pos))
            {
                matrix[pos.Row, pos.Col] = true;
            }

            pos.Row = Position.Row - 2;
            pos.Col = Position.Col - 1;
            if (Board.IsValidPosition(pos) && CanMove(pos))
            {
                matrix[pos.Row, pos.Col] = true;
            }

            pos.Row = Position.Row - 2;
            pos.Col = Position.Col + 1;
            if (Board.IsValidPosition(pos) && CanMove(pos))
            {
                matrix[pos.Row, pos.Col] = true;
            }

            pos.Row = Position.Row + 1;
            pos.Col = Position.Col + 2;
            if (Board.IsValidPosition(pos) && CanMove(pos))
            {
                matrix[pos.Row, pos.Col] = true;
            }

            pos.Row = Position.Row + 1;
            pos.Col = Position.Col - 2;
            if (Board.IsValidPosition(pos) && CanMove(pos))
            {
                matrix[pos.Row, pos.Col] = true;
            }

            pos.Row = Position.Row + 2;
            pos.Col = Position.Col - 1;
            if (Board.IsValidPosition(pos) && CanMove(pos))
            {
                matrix[pos.Row, pos.Col] = true;
            }

            pos.Row = Position.Row + 2;
            pos.Col = Position.Col + 1;
            if (Board.IsValidPosition(pos) && CanMove(pos))
            {
                matrix[pos.Row, pos.Col] = true;
            }

            return matrix;
        }
    }
}
