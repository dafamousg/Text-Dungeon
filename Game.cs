using System;
using System.Collections.Generic;
using System.Text;
using Text_Dungeon.Model;
using Text_Dungeon.Secret;
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
            Player player = new Player(name)
            {
                SecretMessage = message
            };

            Choices.ClassSelection(player);

            //Initianalize Map
            Maps.AddStarsToMap(player,map1);


            do
            {
                foreach (var room in map1)
                {
                    if (player.SecretMessage.CollectedAllStars())
                    {
                        SecretMessage.Message(player.SecretMessage);
                        player.PlayerHasWon = true;
                        Text.Continue();
                        break;
                    }
                    else if (player.NextRoom == room)
                    {
                        CurrentRoom(player, room);
                        break;
                    }
                    else if (player.Health < 1)
                        player.PlayerHasLost = true;
                    //else
                    //    Console.WriteLine($"Something went wrong {room.Name}");
                }
                Console.Clear();

            } while (!player.PlayerHasLost && !player.PlayerHasWon);

            if(player.PlayerHasWon)
                Console.WriteLine("You have won.");
            else if (player.PlayerHasLost)
                Console.WriteLine("You Lost :/");
            else
                Console.WriteLine("Something went wrong");

            Text.Continue();            
        }


        //When player enters a room
        public static Player CurrentRoom(Player player, Room room)
        {
            var temp_player = (Player)player.Clone();

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


            if (!player.SecretMessage.CollectedAllStars())
            {
                player.NextRoom = Choices.ChooseDoor(room);
                room.Stars = 0;
            }


            return player;
        }



    }
}
