using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Text_Dungeon.Model.Character;

namespace Text_Dungeon
{
    public class Battle
    {
        public static Character Battleground(Character player, Character enemy)
        {
            string s;
            do
            {
                Console.WriteLine("Choose what action to do");
                Console.WriteLine("1: Attack");
                Console.WriteLine("2: Magic");
                Console.WriteLine("3: Player Info");
                Console.WriteLine("4: Enemy Info");
                s = Console.ReadLine();
                Console.Clear();
                switch (s)
                {
                    case "1":
                        Attack(player, enemy);
                        if (enemy.Health > 0)
                            Attack(enemy, player);
                        break;
                    case "2":
                        Magic(player, enemy);
                        if (enemy.Health > 0)
                            Attack(enemy, player);
                        break;
                    case "3":
                        player.GetInfo();
                        break;
                    case "4":
                        enemy.GetInfo();
                        break;
                }

                if (enemy.Health != 0)
                    Game.Continue();

            } while (enemy.Health > 0);


            return player;
        }

        public static Character Attack(Character attacker, Character defender)
        {
            Random rnd = new Random();
            int trueAttack;
            int attackTurns = attacker.Speed;

            do
            {
                Console.WriteLine($"{attacker.Name} has: {attackTurns} moves left");
                trueAttack = rnd.Next(Game.MakeZeroIfLess(attacker.Strength - defender.Defense), attacker.Strength);
                Console.WriteLine($"Damage from attack: {trueAttack}");

                defender.Health -= trueAttack;

                defender.Health = Game.MakeZeroIfLess(defender.Health);
                Console.WriteLine($"{defender.Name} health: {defender.Health}");


                if (defender.Health == 0)
                    attackTurns = 0;
                else
                    attackTurns--;

                if (attackTurns > 0)
                    Console.WriteLine();

                Thread.Sleep(1000);
            } while (attackTurns != 0);

            Console.WriteLine();
            attacker.IsTurnToFight = false;
            defender.IsTurnToFight = true;

            return defender;
        }

        public static void TestUI()
        {
            Console.WriteLine("Test UI\nPress enter to continue..");
            Console.ReadLine();
        }

        public static void Magic(Character player, Character boss)
        {
            var temp = (Character)player.Clone();

            Console.WriteLine("Choose Magic for:");
            Console.WriteLine("Enter blank to do normal attack.");
            Console.WriteLine("'1': Strength");
            Console.WriteLine("'2': Defense");
            string s = Console.ReadLine();
            Console.Clear();

            switch (s)
            {
                case "1":
                    temp.Strength = (int)Math.Round(temp.Strength * temp.Magic);
                    Attack(temp, boss);
                    break;
                case "2":
                    temp.Defense = (int)Math.Round(temp.Defense * temp.Magic);
                    Attack(temp, boss);
                    break;
                default:
                    Attack(temp, boss);
                    break;
            }


        }

    }
}
