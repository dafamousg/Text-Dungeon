using System;
using System.Collections.Generic;
using System.Text;
using Text_Dungeon.Secret;

namespace Text_Dungeon.Model
{
    public class Character
    {
        string _name;
        double _magic;
        int _health;
        int _maxHealth;
        int _strength;
        int _defense;
        int _speed;
        Weapon _weapon;
        Armour _armour;

        //Properties
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        public double Magic
        {
            get { return _magic; }
            set { _magic = value; }
        }
        public int Health
        {
            get { return _health; }
            set { _health = value; }
        }
        public int MaxHealth
        {
            get { return _maxHealth; }
            set { _maxHealth = value; }
        }
        public int Strength
        {
            get { return _strength; }
            set{_strength = value;}
        }
        public int Defense
        {
            get { return _defense; }
            set { _defense = value; }
        }
        public int Speed
        {
            get { return _speed; }
            set { _speed = value; }
        }
        public bool IsInBattle { get; set; }
        public bool IsTurnToFight { get; set; }
        public Weapon Weapon
        {
            get { return _weapon; }
            set { _weapon = value; }
        }
        public Armour Armour
        {
            get { return _armour; }
            set { _armour = value; }
        }
        public bool PlayerHasWon { get; set; }
        public bool PlayerHasLost { get; set; }

        public Character() { }

    }
}
