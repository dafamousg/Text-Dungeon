using System;
using System.Collections.Generic;
using System.Text;
using Text_Dungeon.Tools;

namespace Text_Dungeon.Model
{
    public class Enemy : Character
    {
        public Enemy(string name)
        {
            Name = name;
            Magic = 1;
            Health = 100;
            Strength = 10;
            Defense = 10;
            Speed = 1;
            MaxHealth = Health;

        }

        public void GetInfo()
        {
            Console.WriteLine($"Name: {Name}");
            Console.WriteLine($"Health: {Health}");
            Console.WriteLine($"Strength: {Strength}");
            Console.WriteLine($"Defense: {Defense}");
            Console.WriteLine($"Speed: {Speed}");
            Console.WriteLine($"Magic: {Magic}");
            //Console.WriteLine($"Weapon: {Weapon.Name}, Boost: {Weapon.Boost}");
            //Console.WriteLine($"Armour: {Armour.Name}, Boost: {Armour.Boost}");
            Text.Continue();
        }
    }
}
