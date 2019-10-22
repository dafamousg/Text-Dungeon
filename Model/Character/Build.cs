using System;
using System.Collections.Generic;
using System.Text;
using Text_Dungeon.Secret;

namespace Text_Dungeon.Model.Character
{
    public partial class Character : ICloneable
    {
        public string Name { get; set; }        //Name
        public double Magic { get; set; }       //Magic to increse stats
        public int Health { get; set; }         //Health
        private int MaxHealth { get; set; }     //Max Health
        public int Strength { get; set; }       //Attack damage
        public int Defense { get; set; }        //Defense against attack
        public int Speed { get; set; }          //Speed of attacks
        public Room NextRoom { get; set; }    //Next room to enter
        public bool IsInBattle { get; set; }    //If player is in battle
        public bool IsTurnToFight { get; set; } //Who's turn it is
        public SecretMessage SecretMessage { get; set; }
        public Weapon Weapon { get; set; }      //Weapon for stronger attack
        public Armour Armour { get; set; }      //Armour for protection

        public Inventory Inventory = new Inventory(); //Inventory
        public bool PlayerHasWon { get; set; }  //When player wins the game
        public bool PlayerHasLost { get; set; } //When player loses the game

        public Character(string name)
        {
            Name = name;
            Magic = 1;
            Health = 100;
            Strength = 10;
            Defense = 10;
            Speed = 1;
            MaxHealth = Health;

        }
        public Character(string name, double magic, int health, int strength, int defense, int speed)
        {
            Name = name;
            Magic = magic;
            Health = health;
            Strength = strength;
            Defense = defense;
            Speed = speed;
            MaxHealth = health;
        }

        public object Clone()
        {
            var clone = (Character)this.MemberwiseClone();
            if (Weapon != null)
                clone.Weapon = new Weapon(Weapon);
            else
                clone.Weapon = new Weapon();

            if (Armour != null)
                clone.Armour = new Armour(Armour);
            else
                clone.Armour = new Armour();

            return clone;
        }

    }
}
