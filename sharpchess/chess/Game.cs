using System.Collections.Generic;
using board;

namespace chess
{
    class Game
    {
        public Board Board { get; private set; }
        public int Round { get; private set; }
        public Color CurrentPlayer { get; private set; }
        public bool Finished { get; private set; }
        private HashSet<Piece> Pieces;
        private HashSet<Piece> CapturedPieces;

        public Game()
        {
            Board = new Board(8, 8);
            Round = 1;
            CurrentPlayer = Color.White;
            Finished = false;
            Pieces = new HashSet<Piece>();
            CapturedPieces = new HashSet<Piece>();
            PlacePieces();
        }

        public void Move(Position origin, Position destination)
        {
            Piece piece = Board.RemPiece(origin);
            piece.IncrementQtyMovement();
            Piece capturedPiece = Board.RemPiece(destination);
            Board.AddPiece(piece, destination);
            if (capturedPiece != null)
            {
                CapturedPieces.Add(capturedPiece);
            }
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

        public HashSet<Piece> CapturedPiecesByColor(Color color)
        {
            HashSet<Piece> aux = new HashSet<Piece>();
            foreach (Piece piece in CapturedPieces)
            {
                if (piece.Color == color)
                {
                    aux.Add(piece);
                }
            }
            return aux;
        }

        public HashSet<Piece> PiecesInGameByColor(Color color)
        {
            HashSet<Piece> aux = new HashSet<Piece>();
            foreach (Piece piece in Pieces)
            {
                if (piece.Color == color)
                {
                    aux.Add(piece);
                }
            }
            aux.ExceptWith(CapturedPiecesByColor(color));
            return aux;
        }

        public void AddNewPiece(char col, int row, Piece piece)
        {
            Board.AddPiece(piece, new ChessPosition(col, row).ToPosition());
            Pieces.Add(piece);
        }

        public void PlacePieces()
        {
            AddNewPiece('c', 1, new Tower(Board, Color.White));
            AddNewPiece('c', 2, new Tower(Board, Color.White));
            AddNewPiece('d', 2, new Tower(Board, Color.White));
            AddNewPiece('e', 2, new Tower(Board, Color.White));
            AddNewPiece('e', 1, new Tower(Board, Color.White));
            AddNewPiece('d', 1, new King(Board, Color.White));

            AddNewPiece('c', 7, new Tower(Board, Color.Black));
            AddNewPiece('c', 8, new Tower(Board, Color.Black));
            AddNewPiece('d', 7, new Tower(Board, Color.Black));
            AddNewPiece('e', 7, new Tower(Board, Color.Black));
            AddNewPiece('e', 8, new Tower(Board, Color.Black));
            AddNewPiece('d', 8, new King(Board, Color.Black));
        }
    }
}
