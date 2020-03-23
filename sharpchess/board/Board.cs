namespace board
{
    class Board
    {
        public int rows { get; set; }
        public int cols { get; set; }
        private Piece[,] pieces;

        public Board(int rows, int cols)
        {
            this.rows = rows;
            this.cols = cols;
            pieces = new Piece[rows, cols];
        }

        public Piece GetPiece(int row, int col)
        {
            return pieces[row, col];
        }

        public Piece GetPiece(Position pos)
        {
            return pieces[pos.row, pos.col];
        }

        public void AddPiece(Piece piece, Position pos)
        {
            pieces[pos.row, pos.col] = piece;
        }

        public bool HasPiece(Position pos)
        {
            ValidatePosition(pos);
            return GetPiece(pos) != null;
        }

        public bool IsValidPosition(Position pos)
        {
            return pos.row < 0 || pos.row >= rows || pos.col < 0 || pos.col >= cols;
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
