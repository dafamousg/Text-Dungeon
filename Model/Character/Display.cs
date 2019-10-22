using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Text_Dungeon.Tools;

namespace Text_Dungeon.Model.Character
{
    public partial class Character
    {

        public void PickupArmour(Armour armour)
        {
            if (Armour != armour)
            {
                if (Armour != null)
                    Defense -= Armour.GetBoost();

                Armour = armour;
                Defense += armour.GetBoost();

                Console.WriteLine($"{Armour.GetName()} got added.");
                Console.WriteLine($"New Defense: {Defense}");
                Thread.Sleep(3000);
                Console.Clear();
            }
        }
        public void PickupWeapon(Weapon weapon)
        {
            if (Weapon != weapon)
            {
                if (Weapon != null)
                    Strength -= weapon.GetBoost();

                Weapon = weapon;
                Strength += weapon.GetBoost();
                Console.WriteLine($"{Weapon.GetName()} got added.");
                Console.WriteLine($"New strength: {Strength}");
                Thread.Sleep(3000);
                Console.Clear();
            }
        }

        public void DrinkPotion()
        {
            Potion selection;
            string choice;
            bool exit;
            do
            {
                exit = true;
                selection = Inventory.UsePotion();
                if (selection == null)
                    choice = "";
                else if (selection.Name.ToUpper() == "EXIT")
                    choice = selection.Name.ToUpper();
                else if (selection.Name.ToUpper() == "EMPTY")
                    choice = selection.Name.ToUpper();
                else
                    choice = selection.GetPotionType().ToUpper();

                switch (choice)
                {
                    case "HEALTH":
                        Health += selection.GetPotionBoost();
                        break;
                    case "DENESE":
                        Defense += selection.GetPotionBoost();
                        break;
                    case "STRENGTH":
                        Strength += selection.GetPotionBoost();
                        break;
                    case "SPEED":
                        Speed += selection.GetPotionBoost();
                        break;
                    case "EXIT":
                        selection = null;
                        break;
                    case "EMPTY":
                        selection = null;
                        exit = false;
                        break;
                    default:
                        Console.WriteLine("Potion not available");
                        Thread.Sleep(3000);
                        exit = false;
                        Console.Clear();
                        break;
                }
                if(selection != null && exit)
                {
                    Console.WriteLine($"You drank: {selection.GetPotionType()} Potion.");
                    Thread.Sleep(3000);
                    Console.Clear();
                }

            } while (!exit);
        }



        public void GetInfo()
        {
            Console.WriteLine($"Name: {Name}");
            Console.WriteLine($"Health: {Health}");
            Console.WriteLine($"Strength: {Strength}");
            Console.WriteLine($"Defense: {Defense}");
            Console.WriteLine($"Speed: {Speed}");
            Console.WriteLine($"Magic: {Magic}");
            //Console.WriteLine($"Weapon: {Weapon.Name}, Boost: {Weapon.Boost}");
            //Console.WriteLine($"Armour: {Armour.Name}, Boost: {Armour.Boost}");
            Text.Continue();

            if (!Inventory.InventoryIsEmpty())
            {
                Inventory.GetInventory();
                Text.Continue();
            }
            if(SecretMessage != null)
                SecretMessage.GetStars();
        }
    }
}
