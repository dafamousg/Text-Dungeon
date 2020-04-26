using System;
using System.Collections.Generic;
using System.Text;

namespace Text_Dungeon.Tools
{
    public class Text
    {
        public static string infoRoom1E = "You have entered 1E";
        public static string infoRoom1C = "You have entered 1C";
        public static string infoRoom2E = "You have entered 2E";
        public static string enemyRoom1E = "Enemy text for 1E";
        public static string enemyRoom2E = "Enemy text for 2E";
        public static string enemyRoom1C = "Enemy text for 1C";


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
            Console.WriteLine("Press any button to continue");
            Console.ReadKey();
            Console.Clear();
        }
    }
}
