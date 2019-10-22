using System;
using System.Collections.Generic;
using System.Text;
using Text_Dungeon.Model;
using Text_Dungeon.Model.Character;
using Text_Dungeon.Secret;
using Text_Dungeon.Tools;

namespace Text_Dungeon
{
    public class Maps
    {

        public static List<Room> TesttMap()
        {
            List<Room> map = new List<Room>();

            //Armour
            var sheeld2 = new Armour("Shield of the Devil", 15, 20);
            var sheeld = new Armour("Shield of Destiny", 10, 20);

            //Weapon
            var weapon1 = new Weapon("Sword of Destiny", 10, 20);

            //Potion
            var health = new Potion("Spiritual Health");
            var health2 = new Potion("SHealth");
            var speed = new Potion("Speed potion");

            //Key
            var key1 = new Key("Dragon-Key");
            var key2 = new Key("Troll-Key");

            //Enemy
            var enemy = new Character("Enemy1");

            //Rooms
            //var room1E = new Room()
            //{
            //    EnemyText = "Text",
            //    RoomText = "This room is very dark except a light beside a door.",
            //    Name = "1E",
            //    WestDoor = "1C",
            //    ArmourItem = sheeld
            //};
            //var room1C = new Room()
            //{
            //    EnemyText = "Text",
            //    RoomText = "Info",
            //    Name = "1C",
            //    WestDoor = "1W",
            //    EastDoor = room1E,
            //    ArmourItem = sheeld,
            //    Enemy = enemy
            //};
            //var room1W = new Room()
            //{
            //    EnemyText = "Text",
            //    RoomText = "Info",
            //    Name = "1W",
            //    EastDoor = "1C",
            //    ArmourItem = sheeld2,
            //    WeaponItem = weapon1,
            //    Enemy = enemy
            //};


            

            return map;

        }



        public static List<Room> FirstMap()
        {
            List<Room> map = new List<Room>();

            //Armour
            var RustyArmour = new Armour("Rusty Armour",10,2);
            var ElfeArmour = new Armour("Elfe Pride", 15, 1);
            var GoblinArmour = new Armour("Gobliln Strength", 20, 1);
            var DragonArmour = new Armour("Dragon Breath", 25, 2);

            //Weapon
            var SilverSword = new Weapon("Traning Swrod", 10, 2);
            var DimondClub = new Weapon("Club of Suffering", 20, 1);

            //Potion
            var h1 = new Potion("Health of a Horse");
            var sp1 = new Potion("Speed of a Cheetah");
            var st3 = new Potion("Strength of an OX");

            //Key
            var DragonKey = new Key("Dragon");
            var GoblinKey = new Key("Goblin");

            //Enemy
            var ElfeEnemy = new Character("Elfe Warrior");
            var GoblinEnemy = new Character("Goblin King");
            var DragonEnemy = new Character("Dragan of Darkness");

            //Rooms
            Room room1E = new Room(Text.infoRoom1E, Text.infoRoom1E, null, null, null, st3, null);
            Room room2E = new Room(Text.infoRoom1N,Text.enemyRoom1N,GoblinEnemy, null, DimondClub, null, null);


            room1E.AddDoors(null,null,room2E,null);
            room2E.AddDoors(null,null, null, room1E);

            map.Add(room1E);
            map.Add(room2E);

            return map;
        }


        public static void AddStarsToMap(Character player, List<Room> map)
        {
            int amount = 0;
            int roomsWithEnemy = 0;

            foreach (var item in map)
            {
                if (item.Enemy != null)
                    roomsWithEnemy++;
            }

            int stars = player.SecretMessage.GetMaxStars() / roomsWithEnemy;
            foreach (var item in map)
            {
                amount++;
                if(amount == 1)
                    player.NextRoom = item;
                if(item.Enemy != null)
                    item.AddStars((int)Math.Round((decimal)stars));
            }

        }
    }
}
