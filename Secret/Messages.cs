using System;
using System.Collections.Generic;
using System.Text;

namespace Text_Dungeon.Secret
{
    public partial class SecretMessage
    {

        public static void Message(SecretMessage messageReciever)
        {
            switch (messageReciever.Name.ToUpper())
            {
                case "ALVA":
                    Alva();
                    break;
                default:
                    Default();
                    break;
            }
        }

        public static void Alva()
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
        public static void Default()
        {
            //string[,] array = new string[,] {
            //      { "*", " ", " ", "*", " ", "*", "*", "*", "*", " ", " ", "*", "*", "*", " ", " ", "*", "*", "*", "*", " ", "*", "*", "*", "*", " ", "*", " ", " ", " ", "*" },
            //      { "*", " ", " ", "*", " ", "*", " ", " ", " ", " ", " ", " ", "*", " ", " ", " ", "*", " ", " ", "*", " ", "*", " ", " ", "*", " ", " ", "*", " ", "*", " " },
            //      { "*", "*", "*", "*", " ", "*", "*", "*", " ", " ", " ", " ", "*", " ", " ", " ", "*", "*", "*", " ", " ", "*", "*", "*", " ", " ", " ", " ", "*", " ", " " },
            //      { "*", " ", " ", "*", " ", "*", " ", " ", " ", " ", "*", " ", "*", " ", " ", " ", "*", " ", " ", "*", " ", "*", " ", " ", "*", " ", " ", " ", "*", " ", " " },
            //      { "*", " ", " ", "*", " ", "*", "*", "*", "*", " ", "*", "*", "*", " ", " ", " ", "*", "*", "*", "*", " ", "*", "*", "*", "*", " ", " ", " ", "*", " ", " " }
            //};

            string[,] array = new string[,] {
              { "*", " ", "*", " ", "*", "*", " ", " ", " ", "*", "*", "*", " ", " ", " ", " ", "*", " ", " ", " "},
              { "*", " ", "*", " ", "*", " ", "*", " ", " ", "*", " ", "*", " ", " ", "*", "*", "*", "*", "*", " "},
              { "*", " ", "*", " ", "*", "*", " ", " ", " ", "*", "*", "*", " ", " ", " ", "*", "*", "*", " ", " "},
              { "*", "*", "*", " ", "*", " ", "*", " ", " ", "*", " ", "*", " ", " ", "*", "*", "*", "*", "*", " "},
              { " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "*", " ", " ", " "}
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
