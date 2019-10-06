using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Text_Dungeon.Model.Character;

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
        }
        public void CollectStar()
        {
            if (Stars != MaxStars)
            {
                Stars++;
                Console.WriteLine("Star Added To Collection!");
                this.GetStars();
            }
            else
                Console.WriteLine("You collected all stars!\nYou are ready to unlock the secret message.");


        }
    }
}
