using System;
using System.Collections.Generic;
using System.Text;

namespace Text_Dungeon.Model.Character
{
    public class Room
    {
        public string Name { get; set; }
        public string InfoText { get; set; }
        public string EnemyText { get; set; }
        public bool HasEnemy { get; set; }
        public bool HasMark { get; set; }
        public string WestDoor { get; set; }
        public string EastDoor { get; set; }
        public string NorthDoor { get; set; }
        public string SouthDoor { get; set; }
        public Character Enemy { get; set; }
        public Armour ArmourItem { get; set; }
        public Weapon WeaponItem { get; set; }
        public Potion PotionItem { get; set; }
        public Key KeyItem { get; set; }

        public Room()
        {
            if (Enemy != null)
                HasEnemy = true;
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
            Console.WriteLine($"Room name: {Name}");
            if (HasEnemy)
                Console.WriteLine(EnemyText);
            else
                Console.WriteLine(InfoText);
        }
        public void GetAvailableDoors()
        {
            Console.WriteLine("Choose a door to enter.");
            Console.WriteLine("Press 'B' to enter the door you came in from.\n");

            if (NorthDoor != null)
                Console.WriteLine("Press 'N' to enter the Nort Door");

            if (EastDoor != null)
                Console.WriteLine("Press 'E' to enter the East door");

            if (WestDoor != null)
                Console.WriteLine("Press 'W' to enter the West door");

            else if (WestDoor == null && EastDoor == null && NorthDoor == null)
                Console.WriteLine("There seems to be no other doors here..\nGo back to the previous room.");
        }

    }
}
