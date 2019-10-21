using System;
using System.Collections.Generic;
using System.Text;
using Text_Dungeon.Model;
using Text_Dungeon.Secret;
using Text_Dungeon.Model.Character;
using Text_Dungeon.Tools;

namespace Text_Dungeon
{
    public class Game
    {
        public void GameStart()
        {
            Console.WriteLine("Enter your name:");
            string name = Console.ReadLine();
            //Secret Messages
            SecretMessage message = new SecretMessage(name);

            //Player
            var mainCharacter = new Character(string.Empty)
            {
                NextRoom = "1E",
                Speed = 2,
                SecretMessage = message
            };

            //Armour
            var sheeld2 = new Armour("Shield of the Devil", 15, 20);
            var sheeld = new Armour("Shield of Destiny", 10, 20);

            //Weapon
            var weapon1 = new Weapon("Sword of Destiny", 10, 20);

            //Potion
            var health = new Potion("Healt", (int)HealthBoost.Low);
            var health2 = new Potion("Health1", (int)HealthBoost.Low);
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


            Choices.ClassSelection(mainCharacter);

            mainCharacter.Inventory.PickupPotion(health);
            mainCharacter.Inventory.PickupPotion(speed);
            mainCharacter.Inventory.PickupPotion(health2);

            //AddNewItemFromRoom(mainCharacter, room1C);
            //AddNewItemFromRoom(mainCharacter, room1E);
            //AddNewItemFromRoom(mainCharacter, room1W);
            //mainCharacter.Inventory.PickupPotion(speed);
            //mainCharacter.Inventory.PickupKey(key1);
            //mainCharacter.Inventory.PickupKey(key2);

            do
            {
                switch (mainCharacter.NextRoom.ToUpper())
                {
                    case "1E":
                        CurrentRoom(mainCharacter, room1E);
                        break;
                    case "1C":
                        CurrentRoom(mainCharacter, room1C);
                        break;
                    case "1W":
                        CurrentRoom(mainCharacter, room1W);
                        break;
                    case "SURPRISEMESSAGE":
                        SecretMessage.Message(mainCharacter.SecretMessage);
                        mainCharacter.PlayerHasWon = true;
                        Text.Continue();
                        break;
                    default:
                        break;
                }
                Console.Clear();
                if(mainCharacter.SecretMessage.CollectedAllStars())
                    mainCharacter.NextRoom = "SURPRISEMESSAGE";

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
                Text.Continue();
            }
            else
            {
                Console.WriteLine("Room seems to be empty...");
            }

            if (room.HasItem())
                Stats.AddNewItemFromRoom(player, room);

            Console.WriteLine($"Player health {player.Health}");

            ResetStats(player, temp_player);

            player.NextRoom = Choices.ChooseDoor(room);



            Console.WriteLine($"Player health {player.Health}");

            return player;
        }

        public static void ResetStats(Character player, Character temp)
        {
            player.Health = temp.Health;

            if(player.Defense < temp.Defense)
                player.Defense = temp.Defense;

            if (player.Strength < temp.Strength)
                player.Strength = temp.Strength;

            if (player.Speed < temp.Speed)
                player.Speed = temp.Speed;

        }

    }
}
