using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Text_Dungeon.Model.Character;
using Text_Dungeon.Tools;

namespace Text_Dungeon.Secret
{
    public partial class SecretMessage
    {
        public string Name { get; set; }
        private int Stars { get; set; }    //Collect all secret stars and see a secret message
        private int MaxStars { get; set; }       //Max Stars to collect
        public SecretMessage(string name)
        {
            Stars = 0;
            switch (name.ToUpper())
            {
                case "ALVA":
                    Name = name;
                    MaxStars = 26;
                    break;
                default:
                    Name = "Default";
                    MaxStars = 16;
                    break;
            }
        }
        public bool CollectedAllStars()
        {
            if(Stars == MaxStars)
                return true;
            return false;
        }
        public void GetStars()
        {
            Console.WriteLine($"Stars: {Stars}/{MaxStars}");
            Thread.Sleep(3000);
            Console.Clear();
        }
        public void CollectStar(int star)
        {
            if (Stars != MaxStars)
            {
                if ((Stars + star) > MaxStars)
                    Stars = MaxStars;
                else
                {
                    Stars += star;
                    Console.WriteLine($"{star} Stars Added To Collection!");
                    Thread.Sleep(3000);
                    Console.Clear();
                }

                this.GetStars();
            }
            if(Stars == MaxStars)
            {
                //Console.WriteLine("You collected all stars!\nFinish the game to unlock the secret message.");
                Console.WriteLine($"You have won!\nYou collected all {MaxStars} Stars!");
                Console.WriteLine();
                Console.WriteLine("Press any button to display the secret message!");
                Console.ReadKey();
            }


        }

        public int GetMaxStars()
        {
            return MaxStars;
        }
    }
}
