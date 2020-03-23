namespace board
{
    class Board
    {
        public int Rows { get; set; }
        public int Cols { get; set; }
        private readonly Piece[,] pieces;

        public Board(int rows, int cols)
        {
            Rows = rows;
            Cols = cols;
            pieces = new Piece[rows, cols];
        }

        public Piece GetPiece(int row, int col)
        {
            return pieces[row, col];
        }

        public Piece GetPiece(Position pos)
        {
            return pieces[pos.Row, pos.Col];
        }

        public void AddPiece(Piece piece, Position pos)
        {
            if (HasPiece(pos))
            {
                throw new BoardException("There is already a piece in this position");
            }
            pieces[pos.Row, pos.Col] = piece;
            piece.Position = pos;
        }

        public Piece RemPiece(Position pos)
        {
            if (GetPiece(pos) == null)
            {
                return null;
            }
            Piece aux = GetPiece(pos);
            aux.Position = null;
            pieces[pos.Row, pos.Col] = null;
            return aux;
        }

        public bool HasPiece(Position pos)
        {
            ValidatePosition(pos);
            return GetPiece(pos) != null;
        }

        public bool IsValidPosition(Position pos)
        {
            return !(pos.Row < 0 || pos.Row >= Rows || pos.Col < 0 || pos.Col >= Cols);
        }

        public void ValidatePosition(Position pos)
        {
            if (!IsValidPosition(pos))
            {
                throw new BoardException("Invalid position");
            }
        }
    }
}
