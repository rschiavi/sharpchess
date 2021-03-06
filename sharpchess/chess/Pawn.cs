﻿using board;

namespace chess
{
    class Pawn : Piece
    {
        private Game Game;

        public Pawn(Board board, Color color, Game game) : base(board, color)
        {
            Game = game;
        }

        public override string ToString()
        {
            return "P";
        }

        private bool HasOpponent(Position pos)
        {
            Piece piece = Board.GetPiece(pos);
            return piece != null && piece.Color != Color;
        }

        private bool FreePosition(Position pos)
        {
            return Board.GetPiece(pos) == null;
        }

        public override bool[,] PossibleMovements()
        {
            bool[,] matrix = new bool[Board.Rows, Board.Cols];

            Position pos = new Position(0, 0);

            if (Color == Color.White)
            {
                pos.Row = Position.Row - 1;
                pos.Col = Position.Col;
                if (Board.IsValidPosition(pos) && FreePosition(pos))
                {
                    matrix[pos.Row, pos.Col] = true;
                }

                pos.Row = Position.Row - 2;
                pos.Col = Position.Col;
                if (Board.IsValidPosition(pos) && FreePosition(pos) && QtyMovements == 0)
                {
                    matrix[pos.Row, pos.Col] = true;
                }

                pos.Row = Position.Row - 1;
                pos.Col = Position.Col - 1;
                if (Board.IsValidPosition(pos) && HasOpponent(pos))
                {
                    matrix[pos.Row, pos.Col] = true;
                }

                pos.Row = Position.Row - 1;
                pos.Col = Position.Col + 1;
                if (Board.IsValidPosition(pos) && HasOpponent(pos))
                {
                    matrix[pos.Row, pos.Col] = true;
                }

                // En Passant
                if (Position.Row == 3)
                {
                    Position leftPos = new Position(Position.Row, Position.Col - 1);
                    if (Board.IsValidPosition(leftPos) && HasOpponent(leftPos) && Board.GetPiece(leftPos) == Game.VulnerableEnPassant)
                    {
                        matrix[leftPos.Row - 1, leftPos.Col] = true;
                    }
                    Position rightPos = new Position(Position.Row, Position.Col + 1);
                    if (Board.IsValidPosition(rightPos) && HasOpponent(rightPos) && Board.GetPiece(rightPos) == Game.VulnerableEnPassant)
                    {
                        matrix[rightPos.Row - 1, rightPos.Col] = true;
                    }
                }
            }
            else
            {
                pos.Row = Position.Row + 1;
                pos.Col = Position.Col;
                if (Board.IsValidPosition(pos) && FreePosition(pos))
                {
                    matrix[pos.Row, pos.Col] = true;
                }

                pos.Row = Position.Row + 2;
                pos.Col = Position.Col;
                if (Board.IsValidPosition(pos) && FreePosition(pos) && QtyMovements == 0)
                {
                    matrix[pos.Row, pos.Col] = true;
                }

                pos.Row = Position.Row + 1;
                pos.Col = Position.Col - 1;
                if (Board.IsValidPosition(pos) && HasOpponent(pos))
                {
                    matrix[pos.Row, pos.Col] = true;
                }

                pos.Row = Position.Row + 1;
                pos.Col = Position.Col + 1;
                if (Board.IsValidPosition(pos) && HasOpponent(pos))
                {
                    matrix[pos.Row, pos.Col] = true;
                }

                // En Passant
                if (Position.Row == 4)
                {
                    Position leftPos = new Position(Position.Row, Position.Col - 1);
                    if (Board.IsValidPosition(leftPos) && HasOpponent(leftPos) && Board.GetPiece(leftPos) == Game.VulnerableEnPassant)
                    {
                        matrix[leftPos.Row + 1, leftPos.Col] = true;
                    }
                    Position rightPos = new Position(Position.Row, Position.Col + 1);
                    if (Board.IsValidPosition(rightPos) && HasOpponent(rightPos) && Board.GetPiece(rightPos) == Game.VulnerableEnPassant)
                    {
                        matrix[rightPos.Row + 1, rightPos.Col] = true;
                    }
                }
            }


            return matrix;
        }
    }
}
