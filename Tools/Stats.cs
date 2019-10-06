﻿using System;
using System.Collections.Generic;
using System.Text;
using Text_Dungeon.Model.Character;

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
                    Choices.Choose_Armour(player, room.ArmourItem);
            }

            if (room.WeaponItem != null)
            {
                if (player.Weapon == null)
                    player.PickupWeapon(room.WeaponItem);
                else if (player.Weapon != room.WeaponItem)
                    Choices.Choose_Weapon(player, room.WeaponItem);
            }
        }
    }
}
