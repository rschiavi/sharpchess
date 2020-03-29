using board;

namespace chess
{
    class Game
    {
        public Board Board { get; private set; }
        public int Round { get; private set; }
        public Color CurrentPlayer { get; private set; }
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

        public void ExecuteRound(Position origin, Position destination)
        {
            Move(origin, destination);
            ChangePlayer();
            Round++;
        }

        public void ValidateOriginPosition(Position pos)
        {
            if (Board.GetPiece(pos) == null)
            {
                throw new BoardException("There is no piece in the chosen origin position!");
            }
            if (CurrentPlayer != Board.GetPiece(pos).Color)
            {
                throw new BoardException("The original piece chosen is not yours!");
            }
            if (!Board.GetPiece(pos).HasPossibleMovements())
            {
                throw new BoardException("There are no possible movements for the chosen piece!");
            }
        }

        public void ValidateDestinationPosition(Position origin, Position destination)
        {
            if (!Board.GetPiece(origin).CanMoveTo(destination))
            {
                throw new BoardException("Invalid target position!");
            }
        }

        private void ChangePlayer()
        {
            if (CurrentPlayer == Color.White)
            {
                CurrentPlayer = Color.Black;
            }
            else
            {
                CurrentPlayer = Color.White;
            }
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
