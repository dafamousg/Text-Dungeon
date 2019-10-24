using System;
using System.Collections.Generic;
using System.Text;
using Text_Dungeon.Model;
using Text_Dungeon.Model.Character;

namespace Text_Dungeon.Tools
{
    public class Choices
    {
        //Intro to the game and character select
        public static Character ClassSelection(Character player)
        {
            int classSelected = 0;
            double elf = 0.20;
            double magician = 0.5;
            double martial_Artist = 0.5;

            do
            {
                Console.WriteLine("Press a number between 1-3 to continue");
                Console.WriteLine("Class '1': Alva (Elf Princess)");
                Console.WriteLine("Class '2': Gino (Black Magician)");
                Console.WriteLine("Class '3': Kelly (Martial artist)");

                string characterSelection = Console.ReadLine();

                switch (characterSelection)
                {
                    case "1":
                        player.Name = "Alva";
                        player.Magic += elf;
                        player.Health = Stats.Increase(player.Health, elf);
                        player.Strength = Stats.Increase(player.Strength, elf);
                        player.Defense = Stats.Increase(player.Defense, elf);
                        classSelected = 1;
                        break;
                    case "2":
                        player.Name = "Gino";
                        player.Magic += magician;
                        classSelected = 1;
                        break;
                    case "3":
                        player.Name = "Kelly";
                        player.Strength = Stats.Increase(player.Strength, martial_Artist);
                        player.Defense = Stats.Increase(player.Defense, martial_Artist);
                        classSelected = 1;
                        break;
                    default:
                        Console.Clear();
                        break;
                }

            } while (classSelected != 1);

            Console.Clear();
            Console.WriteLine($"You chose:");
            player.GetInfo();

            return player;
        }
        public static Character Choose_Weapon(Character player, Weapon new_Weapon)
        {
            string s;
            bool done = false;

            do
            {
                Console.WriteLine("You already have a weapon on..\nWould You like to change?");
                Console.WriteLine("'1' Show stats of both weapons");
                Console.WriteLine("'2': Yes");
                Console.WriteLine("'3': No");
                s = Console.ReadLine();
                Console.Clear();
                switch (s)
                {
                    case "1":
                        Console.WriteLine("Current Weapon:");
                        player.Weapon.ShowStats();
                        Console.WriteLine("\nNew Weapon:");
                        new_Weapon.ShowStats();
                        Text.Continue();
                        break;
                    case "2":
                        player.PickupWeapon(new_Weapon);
                        done = true;
                        break;
                    case "3":
                        done = true;
                        break;
                    default:
                        break;
                }

            } while (!done);

            return player;
        }
        public static Character Choose_Armour(Character player, Armour new_Armour)
        {
            string s;
            bool done = false;

            do
            {
                Console.WriteLine("You already have armour on..\nWould You like to change?");
                Console.WriteLine("'1' Show stats of both armours");
                Console.WriteLine("'2': Yes");
                Console.WriteLine("'3': No");
                s = Console.ReadLine();
                Console.Clear();
                switch (s)
                {
                    case "1":
                        Console.WriteLine("Current Armour:");
                        player.Armour.ShowStats();
                        Console.WriteLine("New Armour:");
                        new_Armour.ShowStats();
                        break;
                    case "2":
                        player.PickupArmour(new_Armour);
                        done = true;
                        break;
                    case "3":
                        done = true;
                        break;
                    default:
                        Console.Clear();
                        break;
                }

            } while (!done);

            return player;
        }
        public static Room ChooseDoor(Room room)
        {
            Room selectedRoom;
            string door;

            do
            {
                room.GetAvailableDoors();
                door = Console.ReadLine();

                switch (door.ToUpper())
                {
                    case "S":
                        selectedRoom = room.SouthDoor;
                        break;
                    case "N":
                        selectedRoom = room.NorthDoor;
                        break;
                    case "E":
                        selectedRoom = room.EastDoor;
                        break;
                    case "W":
                        selectedRoom = room.WestDoor;
                        break;
                    default:
                        selectedRoom = null;
                        break;
                }
                Console.Clear();
            } while (selectedRoom == null);

            return selectedRoom;
        }

    }
}
