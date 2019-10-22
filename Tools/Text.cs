using System;
using System.Collections.Generic;
using System.Text;
using Text_Dungeon.Model.Character;

namespace Text_Dungeon.Tools
{
    public class Text
    {
        public static string infoRoom1E = "You have entered 1E";
        public static string infoRoom1N = "You have entered 1N";
        public static string enemyRoom1E = "Enemy text for 1E";
        public static string enemyRoom1N = "Enemy text for 1N";


        public static void TestUI(string text)
        {
            Console.WriteLine(text);
            Console.ReadLine();
            Console.WriteLine();
        }

        //Continue..
        public static void Continue()
        {
            Console.WriteLine();
            Console.WriteLine("Press enter to continue");
            Console.ReadLine();
            Console.Clear();
        }
    }
}
