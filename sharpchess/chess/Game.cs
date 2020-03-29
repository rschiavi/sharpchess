using System.Collections.Generic;
using board;

namespace chess
{
    class Game
    {
        public Board Board { get; private set; }
        public int Round { get; private set; }
        public Color CurrentPlayer { get; private set; }
        public bool Check { get; private set; }
        public bool Finished { get; private set; }
        private HashSet<Piece> Pieces;
        private HashSet<Piece> CapturedPieces;

        public Game()
        {
            Board = new Board(8, 8);
            Round = 1;
            CurrentPlayer = Color.White;
            Check = false;
            Finished = false;
            Pieces = new HashSet<Piece>();
            CapturedPieces = new HashSet<Piece>();
            PlacePieces();
        }

        public Piece Move(Position origin, Position destination)
        {
            Piece piece = Board.RemPiece(origin);
            piece.IncrementQtyMovement();
            Piece capturedPiece = Board.RemPiece(destination);
            Board.AddPiece(piece, destination);
            if (capturedPiece != null)
            {
                CapturedPieces.Add(capturedPiece);
            }
            return capturedPiece;
        }

        public void UndoMove(Position origin, Position destination, Piece capturedPiece)
        {
            Piece piece = Board.RemPiece(destination);
            piece.DecrementQtyMovement();
            if (capturedPiece != null)
            {
                Board.AddPiece(capturedPiece, destination);
                CapturedPieces.Remove(capturedPiece);
            }
            Board.AddPiece(piece, origin);
        }

        public void ExecuteRound(Position origin, Position destination)
        {
            Piece capturedPiece = Move(origin, destination);
            if (IsInCheck(CurrentPlayer))
            {
                UndoMove(origin, destination, capturedPiece);
                throw new BoardException("You cannot put yourself in Check!");
            }
            Check = IsInCheck(OpponentColor(CurrentPlayer));
            if (IsInCheckMate(OpponentColor(CurrentPlayer)))
            {
                Finished = true;
            } else
            {
                ChangePlayer();
                Round++;
            }
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
            if (!Board.GetPiece(origin).PossibleMovement(destination))
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

        private Color OpponentColor(Color color)
        {
            return color == Color.White ? Color.Black : Color.White;
        }

        private Piece GetKing(Color color)
        {
            foreach (Piece piece in PiecesInGameByColor(color))
            {
                if (piece is King)
                {
                    return piece;
                }
            }
            return null;
        }

        public bool IsInCheck(Color color)
        {
            Piece King = GetKing(color);
            foreach (Piece piece in PiecesInGameByColor(OpponentColor(color)))
            {
                bool[,] matrix = piece.PossibleMovements();
                if (matrix[King.Position.Row, King.Position.Col])
                {
                    return true;
                }
            }
            return false;
        }

        public bool IsInCheckMate(Color color)
        {
            if (!IsInCheck(color))
            {
                return false;
            }
            foreach (Piece piece in PiecesInGameByColor(color))
            {
                bool[,] matrix = piece.PossibleMovements();
                for (int i = 0; i < Board.Rows; i++)
                {
                    for (int j = 0; j < Board.Cols; j++)
                    {
                        if (matrix[i, j])
                        {
                            Position origin = piece.Position;
                            Position destination = new Position(i, j);
                            Piece capturedPiece = Move(origin, destination);
                            bool isInCheck = IsInCheck(color);
                            UndoMove(origin, destination, capturedPiece);
                            if (!isInCheck)
                            {
                                return false;
                            }
                        }
                    }
                }
            }
            return true;
        }

        public void AddNewPiece(char col, int row, Piece piece)
        {
            Board.AddPiece(piece, new ChessPosition(col, row).ToPosition());
            Pieces.Add(piece);
        }

        public void PlacePieces()
        {
            AddNewPiece('a', 1, new Rook(Board, Color.White));
            AddNewPiece('b', 1, new Knight(Board, Color.White));
            AddNewPiece('c', 1, new Bishop(Board, Color.White));
            AddNewPiece('d', 1, new Queen(Board, Color.White));
            AddNewPiece('e', 1, new King(Board, Color.White));
            AddNewPiece('f', 1, new Bishop(Board, Color.White));
            AddNewPiece('g', 1, new Knight(Board, Color.White));
            AddNewPiece('h', 1, new Rook(Board, Color.White));
            AddNewPiece('a', 2, new Pawn(Board, Color.White));
            AddNewPiece('b', 2, new Pawn(Board, Color.White));
            AddNewPiece('c', 2, new Pawn(Board, Color.White));
            AddNewPiece('d', 2, new Pawn(Board, Color.White));
            AddNewPiece('e', 2, new Pawn(Board, Color.White));
            AddNewPiece('f', 2, new Pawn(Board, Color.White));
            AddNewPiece('g', 2, new Pawn(Board, Color.White));
            AddNewPiece('h', 2, new Pawn(Board, Color.White));

            AddNewPiece('a', 8, new Rook(Board, Color.Black));
            AddNewPiece('b', 8, new Knight(Board, Color.Black));
            AddNewPiece('c', 8, new Bishop(Board, Color.Black));
            AddNewPiece('d', 8, new Queen(Board, Color.Black));
            AddNewPiece('e', 8, new King(Board, Color.Black));
            AddNewPiece('f', 8, new Bishop(Board, Color.Black));
            AddNewPiece('g', 8, new Knight(Board, Color.Black));
            AddNewPiece('h', 8, new Rook(Board, Color.Black));
            AddNewPiece('a', 7, new Pawn(Board, Color.Black));
            AddNewPiece('b', 7, new Pawn(Board, Color.Black));
            AddNewPiece('c', 7, new Pawn(Board, Color.Black));
            AddNewPiece('d', 7, new Pawn(Board, Color.Black));
            AddNewPiece('e', 7, new Pawn(Board, Color.Black));
            AddNewPiece('f', 7, new Pawn(Board, Color.Black));
            AddNewPiece('g', 7, new Pawn(Board, Color.Black));
            AddNewPiece('h', 7, new Pawn(Board, Color.Black));
        }
    }
}
