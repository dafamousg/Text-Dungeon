using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Text_Dungeon.Tools;

namespace Text_Dungeon.Model.Character
{
    public class Room
    {
        public string Name { get; set; }
        public string RoomText { get; set; }
        public string EnemyText { get; set; }
        public int Stars { get; set; }
        public Room WestDoor { get; set; }
        public Room EastDoor { get; set; }
        public Room NorthDoor { get; set; }
        public Room SouthDoor { get; set; }
        public Character Enemy { get; set; }
        public Armour ArmourItem { get; set; }
        public Weapon WeaponItem { get; set; }
        public Potion PotionItem { get; set; }
        public Key KeyItem { get; set; }

        public Room()
        {
            
        }
        public Room(string info, string enemyText,Character enemy, Armour armour, Weapon weapon, Potion potion, Key key)
        {
            RoomText = info;
            EnemyText = enemyText;
            Enemy = enemy;
            ArmourItem = armour;
            WeaponItem = weapon;
            PotionItem = potion;
            KeyItem = key;
        }
        
        public void AddDoors(Room westDoor, Room eastDoor, Room northDoor, Room southDoor)
        {
            WestDoor = westDoor;
            EastDoor = eastDoor;
            NorthDoor = northDoor;
            SouthDoor = southDoor;

        }

        public void AddStars(int star)
        {
            Stars = star;
        }

        public bool HasItem()
        {
            if (ArmourItem != null || WeaponItem != null || PotionItem != null || KeyItem != null)
                return true;
            else
                return false;
        }

        public void GetRoomStats()
        {
            Console.WriteLine(RoomText);
            
            if (Enemy != null)
                Console.WriteLine(EnemyText);

            Text.Continue();
        }
        public void GetAvailableDoors()
        {
            Console.WriteLine("Choose a door to enter.");

            if (NorthDoor != null)
                Console.WriteLine("Press 'N' to enter the Nort Door");

            if (EastDoor != null)
                Console.WriteLine("Press 'E' to enter the East door");

            if (WestDoor != null)
                Console.WriteLine("Press 'W' to enter the West door");

            if (SouthDoor != null)
                Console.WriteLine("Press 'S' to enter the South door.");
        }

    }
}
