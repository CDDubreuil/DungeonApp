using DungeonLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace DungeonApp.DungeonLibrary
{
    public class Combat
    {



        public static void DoAttack(Character attacker, Character defender)
        {
    
            int chance = attacker.CalcHitChance() - defender.CalcBlock();
            int roll = new Random().Next(1, 101);

            bool hit = roll <= chance;

            Thread.Sleep(300);

            if (hit)
            {
   
                int damage = attacker.CalcDamage();
              
                defender.Life -= damage;
   
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"{attacker.Name} hit {defender.Name} for {damage} damage!");
             
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write($"{attacker.Name}");
                Console.ResetColor();
                Console.WriteLine(" missed!");
               
            }
         



        }

        public static bool DoBattle(Player player, Monster monster)
        {
         
            DoAttack(player, monster);
            if (monster.Life > 0)
            {
                DoAttack(monster, player);
                return false;
            }
            else
            {
                player.Score++;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"\nYou killed {monster.Name}!");
                Console.ResetColor();
                return true;
            }

        }

    }
}
