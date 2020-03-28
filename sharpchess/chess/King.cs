﻿using board;

namespace chess
{
    class King : Piece
    {
        public King(Board board, Color color) : base(board, color)
        {
        }

        public override string ToString()
        {
            return "K";
        }

        private bool canMove(Position pos)
        {
            Piece p = Board.GetPiece(pos);
            return p == null || p.Color != Color;
        }

        public override bool[,] PossibleMovements()
        {
            bool[,] matrix = new bool[Board.Rows, Board.Cols];

            Position pos = new Position(0, 0);

            // up
            pos.Row = Position.Row -1;
            pos.Col = Position.Col;
            if (Board.IsValidPosition(pos) && canMove(pos))
            {
                matrix[pos.Row, pos.Col] = true;
            }

            // up right
            pos.Row = Position.Row -1;
            pos.Col = Position.Col + 1;
            if (Board.IsValidPosition(pos) && canMove(pos))
            {
                matrix[pos.Row, pos.Col] = true;
            }

            // right
            pos.Row = Position.Row;
            pos.Col = Position.Col + 1;
            if (Board.IsValidPosition(pos) && canMove(pos))
            {
                matrix[pos.Row, pos.Col] = true;
            }

            // down right
            pos.Row = Position.Row + 1;
            pos.Col = Position.Col + 1;
            if (Board.IsValidPosition(pos) && canMove(pos))
            {
                matrix[pos.Row, pos.Col] = true;
            }

            // down
            pos.Row = Position.Row + 1;
            pos.Col = Position.Col;
            if (Board.IsValidPosition(pos) && canMove(pos))
            {
                matrix[pos.Row, pos.Col] = true;
            }

            // down left
            pos.Row = Position.Row + 1;
            pos.Col = Position.Col - 1;
            if (Board.IsValidPosition(pos) && canMove(pos))
            {
                matrix[pos.Row, pos.Col] = true;
            }

            // left
            pos.Row = Position.Row;
            pos.Col = Position.Col - 1;
            if (Board.IsValidPosition(pos) && canMove(pos))
            {
                matrix[pos.Row, pos.Col] = true;
            }

            // up left
            pos.Row = Position.Row - 1;
            pos.Col = Position.Col - 1;
            if (Board.IsValidPosition(pos) && canMove(pos))
            {
                matrix[pos.Row, pos.Col] = true;
            }

            return matrix;
        }
    }
}
