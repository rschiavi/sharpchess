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


                Screen.PrintBoard(game.Board);

            }
            catch (BoardException e)
            {
                Console.WriteLine(e.Message);
            }
            Console.ReadLine();
        }
    }
}
