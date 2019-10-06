using System;
using System.Collections.Generic;
using System.Text;

namespace Text_Dungeon.Model
{
    public class Weapon
    {
        private string Name { get; set; }
        private int Boost { get; set; }
        private int Durability { get; set; }

        public Weapon() { }

        public Weapon(string name, int boost, int durability)
        {
            Name = name;
            Boost = boost;
            Durability = durability;
        }

        public Weapon(Weapon weapon)
        {
            Name = weapon.Name;
            Boost = weapon.Boost;
            Durability = weapon.Durability;
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
            Console.WriteLine($"Name: {Name}\nBoost {Boost}\nDurability: {Durability}");
        }
    }
}
