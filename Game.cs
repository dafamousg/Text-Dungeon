using System;
using System.Collections.Generic;
using System.Text;
using Text_Dungeon.Model;
using Text_Dungeon.Model.Character;

namespace Text_Dungeon
{
    public class Game
    {
        public void GameStart()
        {
            //Player
            var mainCharacter = new Character(string.Empty)
            {
                NextRoom = "1E",
                Speed = 2
            };

            //Armour
            var sheeld2 = new Armour("Shield of the Devil", 15, 20);
            var sheeld = new Armour("Shield of Destiny", 10, 20);

            //Weapon
            var weapon1 = new Weapon("Sword of Destiny", 10, 20);

            //Potion
            var health = new Potion("Health potion", 10);
            var health2 = new Potion("Health of a dragon", 15);
            var speed = new Potion("Speed potion", 1);

            //Key
            var key1 = new Key("Dragon-Key");
            var key2 = new Key("Troll-Key");

            //Enemy
            var enemy = new Character("Enemy1");

            //Rooms
            var room1E = new Room()
            {
                EnemyText = "Text",
                InfoText = "This room is very dark except a light beside a door.",
                Name = "1E",
                WestDoor = "1C",
                ArmourItem = sheeld
            };
            var room1C = new Room()
            {
                EnemyText = "Text",
                InfoText = "Info",
                Name = "1C",
                WestDoor = "1W",
                EastDoor = room1E.Name,
                ArmourItem = sheeld,
                Enemy = enemy
            };
            var room1W = new Room()
            {
                EnemyText = "Text",
                InfoText = "Info",
                Name = "1W",
                EastDoor = "1C",
                ArmourItem = sheeld2,
                WeaponItem = weapon1,
                Enemy = enemy
            };


            ClassSelection(mainCharacter);
            //AddNewItemFromRoom(mainCharacter, room1C);
            //AddNewItemFromRoom(mainCharacter, room1E);
            //AddNewItemFromRoom(mainCharacter, room1W);
            //mainCharacter.Inventory.PickupPotion(health);
            //mainCharacter.Inventory.PickupPotion(speed);
            //mainCharacter.Inventory.PickupPotion(health2);
            //mainCharacter.Inventory.PickupKey(key1);
            //mainCharacter.Inventory.PickupKey(key2);

            do
            {
                switch (mainCharacter.NextRoom.ToUpper())
                {
                    case "1E":
                        CurrentRoom(mainCharacter, room1C);
                        break;
                    case "1C":
                        CurrentRoom(mainCharacter, room1E);
                        break;
                    case "1W":
                        CurrentRoom(mainCharacter, room1W);
                        mainCharacter.PlayerHasWon = true;
                        break;
                    case "SURPRISEMESSAGE":
                        SecretMessage.Message(mainCharacter);
                        mainCharacter.PlayerHasWon = true;
                        Continue();
                        break;
                    default:
                        break;
                }
                Console.Clear();
            } while (!mainCharacter.PlayerHasLost && !mainCharacter.PlayerHasWon);

            Console.WriteLine("Outside of loop\nYou have won.");

            Console.ReadKey();
        }


        //When player enters a room
        public static Character CurrentRoom(Character player, Room room)
        {
            var temp_player = (Character)player.Clone();

            room.GetRoomStats();

            if (room.Enemy != null && room.Enemy.Health > 0)
            {
                Battle.Battleground(temp_player, room.Enemy);
                if (temp_player.Health > 0)
                    Console.WriteLine("Enemy has fallen");
                Continue();
            }
            else
            {
                Console.WriteLine("Room seems to be empty...");
            }

            if (room.HasItem())
                AddNewItemFromRoom(player, room);

            player.Health = temp_player.Health;

            player.NextRoom = ChooseDoor(room);

            return player;
        }



        public static void AddNewItemFromRoom(Character player, Room room)
        {
            if (room.KeyItem != null)
                player.Inventory.PickupKey(room.KeyItem);

            if (room.PotionItem != null)
                player.Inventory.PickupPotion(room.PotionItem);

            if (room.ArmourItem != null)
            {
                if (player.Armour == null)
                    player.PickupArmour(room.ArmourItem);
                else if (player.Armour != room.ArmourItem)
                    Choose_Armour(player, room.ArmourItem);
            }

            if (room.WeaponItem != null)
            {
                if (player.Weapon == null)
                    player.PickupWeapon(room.WeaponItem);
                else if (player.Weapon != room.WeaponItem)
                    Choose_Weapon(player, room.WeaponItem);
            }
        }


        //Intro to the game and character select
        public static Character ClassSelection(Character player)
        {
            int classSelected = 0;
            double elf = 0.20;
            double magician = 0.5;
            double martial_Artist = 0.5;

            do
            {
                Console.WriteLine("Press a number between 0-3 to continue");
                Console.WriteLine("Enter '0' to see info about class");
                Console.WriteLine("Class '1': Alva (Elf Princess)");
                Console.WriteLine("Class '2': Gino (Black Magician");
                Console.WriteLine("Class '3': Kelly (Martial artist)");

                string characterSelection = Console.ReadLine();

                switch (characterSelection)
                {
                    case "0":
                        Console.WriteLine("");
                        Console.WriteLine("");
                        Console.WriteLine("");
                        Console.WriteLine("");
                        break;
                    case "1":
                        player.Name = "Alva";
                        player.Magic += elf;
                        player.Health = Increase(player.Health, elf);
                        player.Strength = Increase(player.Strength, elf);
                        player.Defense = Increase(player.Defense, elf);
                        classSelected = 1;
                        break;
                    case "2":
                        player.Name = "Gino";
                        player.Magic += magician;
                        classSelected = 1;
                        break;
                    case "3":
                        player.Name = "Kelly";
                        player.Strength = Increase(player.Strength, martial_Artist);
                        player.Defense = Increase(player.Defense, martial_Artist);
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

            Console.WriteLine("You already have a weapon on..\nWould You like to change?");
            do
            {
                Console.WriteLine("'1' Show stats of both weapons");
                Console.WriteLine("'2': Yes");
                Console.WriteLine("'3': No");
                s = Console.ReadLine();
                switch (s)
                {
                    case "1":
                        Console.WriteLine("Current Weapon:");
                        player.Armour.ShowStats();
                        Console.WriteLine("\nNew Weapon:");
                        new_Weapon.ShowStats();
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
        public static string ChooseDoor(Room room)
        {
            room.GetAvailableDoors();
            string door;

            door = Console.ReadLine();

            switch (door.ToUpper())
            {
                case "B":
                    return room.Name;
                case "N":
                    return room.NorthDoor;
                case "E":
                    return room.EastDoor;
                case "W":
                    return room.WestDoor;
                default:
                    return room.Name;
            }
        }



        public static int MakeZeroIfLess(int s)
        {
            if (s < 0)
                s = 0;

            return s;
        }
        //Increase value
        public static int Increase(double value, double character)
        {
            double increase = 1;

            return (int)(value * (increase + character));
        }
        //Continue..
        public static void Continue()
        {
            Console.WriteLine();
            Console.WriteLine("Press enter to continue");
            Console.ReadLine();
            Console.Clear();
        }

    }
}
