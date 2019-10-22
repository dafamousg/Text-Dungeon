using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Text_Dungeon.Tools;

namespace Text_Dungeon.Model
{
    public class Inventory
    {
        readonly List<Potion> potionInventory = new List<Potion>();

        readonly List<Key> keyInventory = new List<Key>();

        public void PickupPotion(Potion potion)
        {
            potionInventory.Add(potion);
            Console.WriteLine($"{potion.GetPotionType()} Potion got picked up.");
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
        public Potion UsePotion()
        {
            bool Selected = false;
            string select;
            do
            {
                Console.WriteLine("Choose which potion to drink");
                Console.WriteLine("1: Show potions");
                Console.WriteLine("2: Health");
                Console.WriteLine("3: Strength");
                Console.WriteLine("4: Defense");
                Console.WriteLine("5: Speed");
                Console.WriteLine("6: Exit");
                Console.WriteLine("Just click enter to continue");
                select = Console.ReadLine();
                Console.Clear();
                switch (select)
                {
                    case "1":
                        PotionAmount();
                        Thread.Sleep(3000);
                        break;
                    case "2":
                        select = PotionType.Health.ToString();
                        Selected = true;
                        break;
                    case "3":
                        select = PotionType.Strength.ToString();
                        Selected = true;
                        break;
                    case "4":
                        select = PotionType.Defense.ToString();
                        Selected = true;
                        break;
                    case "5":
                        select = PotionType.Speed.ToString();
                        Selected = true;
                        break;
                    case "6":
                        return new Potion("Exit");
                    default:
                        return new Potion("Empty");
                }
                Console.Clear();
            } while (!Selected);

            foreach (var i in potionInventory)
            {
                if (i.GetPotionType().ToUpper() == select.ToUpper())
                {
                    potionInventory.Remove(i);
                    return i;
                }
            }

            return null;
        }
        public void GetAllPotionDetails()
        {
            var healthPotion = new List<Potion>();
            var defensePotion = new List<Potion>();
            var strengthPotions = new List<Potion>();
            var speedPotion = new List<Potion>();

            foreach (var item in potionInventory)
            {
                if (item.GetPotionType() == PotionType.Health.ToString())
                    healthPotion.Add(item);
                if (item.GetPotionType() == PotionType.Defense.ToString())
                    defensePotion.Add(item);
                if (item.GetPotionType() == PotionType.Strength.ToString())
                    strengthPotions.Add(item);
                if (item.GetPotionType() == PotionType.Speed.ToString())
                    speedPotion.Add(item);
            }
            if(healthPotion.Count != 0)
            {
                Console.WriteLine("Health potions;");
                foreach (var item in healthPotion)
                    item.GetPotionDetails();
            }
            if(defensePotion.Count != 0)
            {
                Console.WriteLine("Defense potions;");
                foreach (var item in defensePotion)
                    item.GetPotionDetails();
            }
            if (strengthPotions.Count != 0)
            {
                Console.WriteLine("Strength potions;");
                foreach (var item in strengthPotions)
                    item.GetPotionDetails();
            }
            if (speedPotion.Count != 0)
            {
                Console.WriteLine("Speed potions;");
                foreach (var item in speedPotion)
                    item.GetPotionDetails();
            }

        }
        public void GetInventory()
        {
            var showDetails = false;
            Console.WriteLine("Inventory:");
            if (keyInventory.Count != 0)
            {
                Console.WriteLine("Keys in Inventory:");
                foreach (var i in keyInventory)
                {
                    Console.WriteLine($"{i.Name}");
                }
            }
            if (potionInventory.Count != 0)
            {

                Console.WriteLine("Would you like detailed view of all Potions?");
                Console.WriteLine("'1' Yes");
                Console.WriteLine("'2' No");

                string s = Console.ReadLine();
                Console.Clear();
                if (s == "1")
                    showDetails = true;
                else if (s == "2")
                    showDetails = false;


                if (showDetails)
                {
                    GetAllPotionDetails();
                }
                else
                {
                    PotionAmount();
                }
            }
        }

        public void PotionAmount()
        {

            var health = 0;
            var strength = 0;
            var defense = 0;
            var speed = 0;

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
        public bool InventoryIsEmpty()
        {
            if (potionInventory.Count == 0 && keyInventory.Count == 0)
                return true;
            else
                return false;
        }
    }
}
