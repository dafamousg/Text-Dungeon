using System;

namespace Text_Dungeon
{
    class Program
    {
        static void Main(string[] args)
        {
            Game firstGame = new Game();

            firstGame.GameStart();

            Console.ReadKey();
        }
    }
}
