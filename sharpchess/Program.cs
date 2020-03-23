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
                    Console.Clear();
                    Screen.PrintBoard(game.Board);

                    Console.WriteLine();
                    Console.Write("Origem: ");
                    Position origin = Screen.ReadPositionChess().ToPosition();
                    Console.Write("Destino: ");
                    Position destination = Screen.ReadPositionChess().ToPosition();

                    game.Move(origin, destination);
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
