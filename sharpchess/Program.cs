using System;
using board;
using pieces;

namespace sharpchess
{
    class Program
    {
        static void Main(string[] args)
        {
            Board board = new Board(8, 8);

            board.AddPiece(new Tower(board, Color.Black), new Position(0, 0));
            
            Screen.PrintBoard(board);

            Console.ReadLine();
        }
    }
}
