using System;
using board;
using chess;

namespace sharpchess
{
    class Screen
    {
        public static void PrintBoard(Board board)
        {
            for (int i=0; i < board.Rows; i++)
            {
                Console.Write($"{8 - i} ");
                for (int j=0; j < board.Cols; j++)
                {
                    PrintPiece(board.GetPiece(i, j));
                }
                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h");
        }

        public static void PrintBoard(Board board, bool[,] possibleMovements)
        {
            ConsoleColor originalBackground = Console.BackgroundColor;
            ConsoleColor alteredBackground = ConsoleColor.DarkGray;
            for (int i = 0; i < board.Rows; i++)
            {
                Console.Write($"{8 - i} ");
                for (int j = 0; j < board.Cols; j++)
                {
                    if (possibleMovements[i, j])
                    {
                        Console.BackgroundColor = alteredBackground;
                    }
                    else
                    {
                        Console.BackgroundColor = originalBackground;
                    }
                    PrintPiece(board.GetPiece(i, j));
                    Console.BackgroundColor = originalBackground;
                }
                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h");
        }

        public static PositionChess ReadPositionChess()
        {
            string s = Console.ReadLine();
            char col = s[0];
            int row = int.Parse(s[1] + "");
            return new PositionChess(col, row);
        }

        public static void PrintPiece(Piece piece)
        {
            if (piece == null)
            {
                Console.Write("- ");
            }
            else
            {
                if (piece.Color == Color.White)
                {
                    Console.Write(piece);
                }
                else
                {
                    ConsoleColor aux = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                    Console.Write(piece);
                    Console.ForegroundColor = aux;
                }
                Console.Write(" ");
            }
        }
    }
}
