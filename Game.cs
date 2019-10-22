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
            Console.Clear();

            //Maps
            var map1 = Maps.FirstMap();
            
            //Secret Messages
            SecretMessage message = new SecretMessage(name);

            //Player
            var mainCharacter = new Character(name)
            {
                SecretMessage = message
            };

            Choices.ClassSelection(mainCharacter);

            //Initianalize Map
            Maps.AddStarsToMap(mainCharacter,map1);


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
                    {
                        CurrentRoom(mainCharacter,room);
                        break;
                    }
                    //else
                    //    Console.WriteLine($"Something went wrong {room.Name}");
                }
                Console.Clear();

            } while (!mainCharacter.PlayerHasLost && !mainCharacter.PlayerHasWon);

            if(mainCharacter.PlayerHasWon)
                Console.WriteLine("You have won.");
            else if (mainCharacter.PlayerHasLost)
                Console.WriteLine("You Lost :/");
            else
                Console.WriteLine("Something went wrong");

            Text.Continue();            
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

            Stats.ResetStats(player, temp_player);

            if (room.HasItem())
                Stats.AddNewItemFromRoom(player, room);
            if (room.Stars != 0)
                player.SecretMessage.CollectStar(room.Stars);


            if(!player.SecretMessage.CollectedAllStars())
                player.NextRoom = Choices.ChooseDoor(room);


            return player;
        }



    }
}
