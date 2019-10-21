using System;
using System.Collections.Generic;
using System.Text;

namespace Text_Dungeon.Tools
{
    public class Text
    {
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
