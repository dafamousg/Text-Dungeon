using System;
using System.Collections.Generic;
using System.Text;
using Text_Dungeon.Model.Character;

namespace Text_Dungeon
{
    public class SecretMessage
    {
        public static void Message(Character player)
        {
            if (player.Name.ToUpper() == "ALVA")
            {
                string[,] array = new string[,] {
                  { "*", "*", "*", " ", "*", " ", "*", " ", "*", " ", " ", "*" },
                  { " ", "*", " ", "*", " ", "*", " ", "*", "*", " ", " ", "*" },
                  { " ", "*", " ", " ", "*", " ", "*", " ", "*", " ", " ", "*" },
                  { "*", "*", "*", " ", " ", "*", " ", " ", "*", "*", "*", "*" }
                };

                int rowLength = array.GetLength(0);
                int colLength = array.GetLength(1);

                for (int i = 0; i < rowLength; i++)
                {
                    for (int j = 0; j < colLength; j++)
                    {
                        Console.Write(string.Format("{0} ", array[i, j]));
                    }
                    Console.Write("\n");
                }

            }
            else
            {
                string[,] array = new string[,] {
                  { "*", "*", "*", " ", "*", " ", "*", " ", "*", " ", " ", "*" },
                  { " ", "*", " ", "*", " ", "*", " ", "*", "*", " ", " ", "*" },
                  { " ", "*", " ", " ", "*", " ", "*", " ", "*", " ", " ", "*" },
                  { "*", "*", "*", " ", " ", "*", " ", " ", "*", "*", "*", "*" }
                };

                int rowLength = array.GetLength(0);
                int colLength = array.GetLength(1);

                for (int i = 0; i < rowLength; i++)
                {
                    for (int j = 0; j < colLength; j++)
                    {
                        Console.Write(string.Format("{0} ", array[i, j]));
                    }
                    Console.Write("\n");
                }
            }
        }
    }
}
