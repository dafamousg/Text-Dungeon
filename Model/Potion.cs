using System;
using System.Collections.Generic;
using System.Text;

namespace Text_Dungeon.Model
{
    public class Potion
    {
        public string Name { get; set; }
        private int Boost { get; set; }
        private string Type { get; set; }

        public Potion(string name, int boost)
        {
            Name = name;
            Boost = boost;

            if (name.ToUpper().Contains("HEALTH"))
                Type = "Health";
            if (name.ToUpper().Contains("STRENGTH"))
                Type = "Strength";
            if (name.ToUpper().Contains("DEFENSE"))
                Type = "Defense";
            if (name.ToUpper().Contains("SPEED"))
                Type = "Speed";
        }

        public void GetPotionDetails(Potion potion)
        {
            Console.WriteLine($"\nPotion Type: {potion.Type}\nName:        {potion.Name}\nBoost:       {potion.Boost}");
        }

        public string GetPotionType()
        {
            return Type;
        }
    }
}
