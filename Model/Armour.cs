using System;
using System.Collections.Generic;
using System.Text;

namespace Text_Dungeon.Model
{
    public class Armour
    {
        private string Name { get; set; }
        private int Boost { get; set; }
        private int Durability { get; set; }

        public Armour() { }
        public Armour(string name, int boost, int durability)
        {
            Name = name;
            Boost = boost;
            Durability = durability;
        }
        public Armour(Armour armour)
        {
            Name = armour.Name;
            Boost = armour.Boost;
            Durability = armour.Durability;
        }

        public int GetBoost()
        {
            return Boost;
        }
        public string GetName()
        {
            return Name;
        }

        public void ShowStats()
        {
            Console.WriteLine($"Name: {Name}\nBoost {Boost}\nDurability: {Durability}\n");
        }
    }
}
