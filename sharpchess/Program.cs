using System;
using board;
using chess;

namespace sharpchess
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Game game = new Game();

                while (!game.Finished)
                {
                    try
                    {
                        Console.Clear();
                        Screen.PrintGame(game);

                        Console.WriteLine();
                        Console.Write("Origin: ");
                        Position origin = Screen.ReadPositionChess().ToPosition();
                        game.ValidateOriginPosition(origin);

                        bool[,] possibleMovements = game.Board.GetPiece(origin).PossibleMovements();

                        Console.Clear();
                        Screen.PrintBoard(game.Board, possibleMovements);

                        Console.WriteLine();
                        Console.Write("Destination: ");
                        Position destination = Screen.ReadPositionChess().ToPosition();
                        game.ValidateDestinationPosition(origin, destination);

                        game.ExecuteRound(origin, destination);
                    }
                    catch (BoardException e)
                    {
                        Console.WriteLine(e.Message);
                        Console.Write("Continue...");
                        Console.ReadLine();
                    }
                }
            }
            catch (BoardException e)
            {
                Console.WriteLine(e.Message);
            }
            Console.ReadLine();
        }
    }
}
