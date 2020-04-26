using System;
using System.Collections.Generic;
using System.Text;
using Text_Dungeon.Model;
using Text_Dungeon.Secret;
using Text_Dungeon.Tools;

namespace Text_Dungeon
{
    public class Maps
    {

        /// <summary>
        /// Adds maps to a list
        /// </summary>
        /// <returns> Map list</returns>
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
            Enemy ElfeEnemy = new Enemy("Elfe Warrior");
            Enemy GoblinEnemy = new Enemy("Goblin King");
            Enemy DragonEnemy = new Enemy("Dragan of Darkness");

            //Rooms
            Room room1E = new Room(Text.infoRoom1E, Text.infoRoom1E, ElfeEnemy, null, SilverSword, st3, null);
            Room room2E = new Room(Text.infoRoom2E,Text.enemyRoom2E,GoblinEnemy, null, DimondClub, null, null);
            Room room1C = new Room(Text.infoRoom1C, Text.enemyRoom1C, null, DragonArmour, null, sp1, DragonKey);


            room2E.AddDoors(null,null, null, room1E);
            room1E.AddDoors(room1C,null,room2E,null);
            room1C.AddDoors(null,room1E, null, null);

            map.Add(room1C);
            map.Add(room1E);
            map.Add(room2E);



            return map;
        }


        /// <summary>
        /// Adds random amount of stars to maps in list calculated from player max stars
        /// </summary>
        /// <param name="player">main character</param>
        /// <param name="map"> List of maps in game</param>
        public static void AddStarsToMap(Player player, List<Room> map)
        {
            Random rnd = new Random();
            int amount = 0;
            int maxStars = player.SecretMessage.GetMaxStars();
            int rndStars;

            do
            {
                foreach (var item in map)
                {
                    amount++;
                    rndStars = rnd.Next(0, maxStars +1);

                    if(amount == 1)
                        player.NextRoom = item;

                    if (item.Enemy != null)
                    {
                        item.AddStars(rndStars);
                        maxStars -= rndStars;
                    }
                }
            } while (maxStars != 0);
        }
    }
}
