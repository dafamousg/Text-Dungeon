using System;
using System.Collections.Generic;
using System.Text;

namespace Text_Dungeon.Tools
{
    public class Text
    {


        public static void TestUI()
        {
            Console.WriteLine("Test UI\nPress enter to continue..");
            Console.ReadLine();
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
