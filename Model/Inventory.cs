using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Text_Dungeon.Model
{
    public class Inventory
    {
        readonly List<Potion> potionInventory = new List<Potion>();
        readonly List<Key> keyInventory = new List<Key>();

        public void PickupPotion(Potion potion)
        {
            potionInventory.Add(potion);
            Console.WriteLine($"{potion.Name} got picked up.\nType: {potion.GetPotionType()}");
            Thread.Sleep(3000);
            Console.Clear();
        }
        public void PickupKey(Key key)
        {
            keyInventory.Add(key);
            Console.WriteLine($"{key.Name} got picked up.");
            Thread.Sleep(3000);
            Console.Clear();
        }
        public void GetInventory()
        {
            Console.WriteLine("Inventory:");
            bool showDetails = true;
            int health = 0;
            int strength = 0;
            int defense = 0;
            int speed = 0;
            if (keyInventory.Count != 0)
            {
                foreach (var i in keyInventory)
                {
                    Console.WriteLine($"\nKey name:    {i.Name}");
                }
            }
            if (potionInventory.Count != 0)
            {
                Console.WriteLine("Would you like detailed view of all Potions?");
                Console.WriteLine("'1' Yes");
                Console.WriteLine("'2' No");

                string s = Console.ReadLine();
                if (s == "1")
                    showDetails = true;
                else if (s == "2")
                    showDetails = false;


                if (showDetails)
                {
                    foreach (var i in potionInventory)
                    {
                        i.GetPotionDetails(i);
                    }
                }
                else
                {
                    foreach (var i in potionInventory)
                    {
                        switch (i.GetPotionType().ToUpper())
                        {
                            case "HEALTH":
                                health++;
                                break;
                            case "STRENGTH":
                                strength++;
                                break;
                            case "DEFENSE":
                                defense++;
                                break;
                            case "SPEED":
                                speed++;
                                break;
                            default:
                                break;
                        }
                    }

                    Console.WriteLine($"Health potions: {health}");
                    Console.WriteLine($"Strength potions: {strength}");
                    Console.WriteLine($"Defense potions: {defense}");
                    Console.WriteLine($"Speed potions: {speed}");
                }
            }
        }

        public bool InventoryIsEmpty()
        {
            if (potionInventory.Count == 0 && keyInventory.Count == 0)
                return true;
            else
                return false;
        }
    }
}
