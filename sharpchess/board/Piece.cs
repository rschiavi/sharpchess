namespace board
{
    class Piece
    {
        public Position position { get; set; }
        public Color color { get; protected set; }
        public int qtyMovements { get; protected set; }
        public Board board { get; protected set; }

        public Piece(Board board, Color color)
        {
            this.position = null;
            this.color = color;
            this.board = board;
            qtyMovements = 0;
        }
    }
}
