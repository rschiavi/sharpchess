using board;

namespace chess
{
    class Game
    {
        public Board Board { get; private set; }
        private int Round;
        private Color CurrentPlayer;
        public bool Finished { get; private set; }

        public Game()
        {
            Board = new Board(8, 8);
            Round = 1;
            CurrentPlayer = Color.White;
            Finished = false;
            SetPieces();
        }

        public void Move(Position origin, Position destination)
        {
            Piece piece = Board.RemPiece(origin);
            piece.IncrementQtyMovement();
            Piece capturedPiece = Board.RemPiece(destination);
            Board.AddPiece(piece, destination);
        }

        public void SetPieces()
        {
            Board.AddPiece(new Tower(Board, Color.White), new PositionChess('c', 1).ToPosition());
            Board.AddPiece(new Tower(Board, Color.White), new PositionChess('c', 2).ToPosition());
            Board.AddPiece(new Tower(Board, Color.White), new PositionChess('d', 2).ToPosition());
            Board.AddPiece(new Tower(Board, Color.White), new PositionChess('e', 2).ToPosition());
            Board.AddPiece(new Tower(Board, Color.White), new PositionChess('e', 1).ToPosition());
            Board.AddPiece(new King(Board, Color.White), new PositionChess('d', 1).ToPosition());

            Board.AddPiece(new Tower(Board, Color.Black), new PositionChess('c', 7).ToPosition());
            Board.AddPiece(new Tower(Board, Color.Black), new PositionChess('c', 8).ToPosition());
            Board.AddPiece(new Tower(Board, Color.Black), new PositionChess('d', 7).ToPosition());
            Board.AddPiece(new Tower(Board, Color.Black), new PositionChess('e', 7).ToPosition());
            Board.AddPiece(new Tower(Board, Color.Black), new PositionChess('e', 8).ToPosition());
            Board.AddPiece(new King(Board, Color.Black), new PositionChess('d', 8).ToPosition());
        }
    }
}
