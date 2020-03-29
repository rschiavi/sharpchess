namespace board
{
    abstract class Piece
    {
        public Position Position { get; set; }
        public Color Color { get; protected set; }
        public int QtyMovements { get; protected set; }
        public Board Board { get; protected set; }

        public Piece(Board board, Color color)
        {
            Position = null;
            Color = color;
            Board = board;
            QtyMovements = 0;
        }

        public void IncrementQtyMovement()
        {
            QtyMovements++;
        }

        public void DecrementQtyMovement()
        {
            QtyMovements--;
        }

        public bool HasPossibleMovements()
        {
            bool[,] matrix = PossibleMovements();
            for (int i = 0; i < Board.Rows; i++)
            {
                for (int j = 0; j < Board.Cols; j++)
                {
                    if (matrix[i, j])
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public bool PossibleMovement(Position pos)
        {
            return PossibleMovements()[pos.Row, pos.Col];
        }

        public abstract bool[,] PossibleMovements();
    }
}
