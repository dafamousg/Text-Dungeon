using System;
using System.Collections.Generic;
using System.Text;

namespace Text_Dungeon.Model
{
    public enum PotionType
    {
        Health,
        Strength,
        Defense,
        Speed
    }
    public enum HealthBoost
    {
        Low = 10,
        Medium = 20,
        High = 30,
        Extreme = 40
    }
    public enum DefenseBoost
    {
        Low = 10,
        Medium = 20,
        High = 30,
        Extreme = 40
    }
    public class Potion
    {
        public string Name { get; set; }
        private int Boost { get; set; }
        private PotionType Type { get; set; }

        public Potion() { }
        public Potion(string name, int boost)
        {
            Name = name;
            Boost = boost;

            if (name.ToUpper().Contains("HEALTH"))
                Type = PotionType.Health;
            if (name.ToUpper().Contains("STRENGTH"))
                Type = PotionType.Strength;
            if (name.ToUpper().Contains("DEFENSE"))
                Type = PotionType.Defense;
            if (name.ToUpper().Contains("SPEED"))
                Type = PotionType.Speed;
        }
        

        public void GetPotionDetails()
        {
            Console.WriteLine($"\nName:        {Name}\nBoost:       {Boost}");
        }

        public string GetPotionType()
        {
            return Type.ToString();
        }
        public int GetPotionBoost()
        {
            return (int)Boost;
        }
    }
}
