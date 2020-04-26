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
        Low = 40,
        Medium = 60,
        High = 80,
        Extreme = 100
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
        public Potion(string name)
        {
            Name = name;

            if (name.ToUpper().Contains("HEALTH"))
            {
                Type = PotionType.Health;
                Boost = (int)HealthBoost.Low;
            }
            if (name.ToUpper().Contains("STRENGTH"))
            {
                Type = PotionType.Strength;
                Boost = (int)DefenseBoost.Low;
            }
            if (name.ToUpper().Contains("DEFENSE"))
            {
                Type = PotionType.Defense;
                Boost = (int)DefenseBoost.Low;
            }
            if (name.ToUpper().Contains("SPEED"))
            {
                Type = PotionType.Speed;
                Boost = 1;
            }
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
