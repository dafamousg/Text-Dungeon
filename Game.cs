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
            var mainCharacter = new Character(name)
            {
                SecretMessage = message
            };

            var map1 = Maps.FirstMap(mainCharacter);

            Choices.ClassSelection(mainCharacter);


            do
            {
                foreach (var room in map1)
                {
                    if(mainCharacter.SecretMessage.CollectedAllStars())
                    {
                        SecretMessage.Message(mainCharacter.SecretMessage);
                        mainCharacter.PlayerHasWon = true;
                        Text.Continue();
                        break;
                    }
                    else if (mainCharacter.NextRoom == room)
                        CurrentRoom(mainCharacter,room);
                    else
                    {
                        Console.WriteLine("Something Went wrong..");
                        Console.ReadLine();
                    }
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
                Text.Continue();
            }
            else
            {
                Console.WriteLine("Room seems to be empty...");
            }

            if (room.HasItem())
                Stats.AddNewItemFromRoom(player, room);

            Stats.ResetStats(player, temp_player);


            player.NextRoom = Choices.ChooseDoor(room);


            return player;
        }



    }
}
