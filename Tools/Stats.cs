using System;
using System.Collections.Generic;
using System.Text;
using Text_Dungeon.Model;

namespace Text_Dungeon.Tools
{
    public class Stats
    {
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

        public static void AddNewItemFromRoom(Player player, Room room)
        {
            if (room.KeyItem != null)
            {
                player.Inventory.PickupKey(room.KeyItem);
                room.KeyItem = null;
            }

            if (room.PotionItem != null)
            {
                player.Inventory.PickupPotion(room.PotionItem);
                room.PotionItem = null;
            }

            if (room.ArmourItem != null)
            {
                if (player.Armour == null)
                    player.PickupArmour(room.ArmourItem);
                else if (player.Armour != room.ArmourItem)
                    Choices.Choose_Armour(player, room.ArmourItem);
                if (player.Armour == room.ArmourItem)
                    room.ArmourItem = null;
            }

            if (room.WeaponItem != null)
            {
                if (player.Weapon == null)
                    player.PickupWeapon(room.WeaponItem);
                else if (player.Weapon != room.WeaponItem)
                    Choices.Choose_Weapon(player, room.WeaponItem);
                if (player.Weapon == room.WeaponItem)
                    room.WeaponItem = null;
            }
        }

        public static void ResetStats(Player player, Player temp)
        {
            player.Health = temp.Health;

            if (player.Defense < temp.Defense)
                player.Defense = temp.Defense;

            if (player.Strength < temp.Strength)
                player.Strength = temp.Strength;

            if (player.Speed < temp.Speed)
                player.Speed = temp.Speed;
        }
    }
}
