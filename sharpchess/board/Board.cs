﻿namespace board
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

        public Piece piece(int row, int col)
        {
            return pieces[row, col];
        }
    }
}
