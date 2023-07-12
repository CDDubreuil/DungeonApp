//using DungeonLibrary;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Security.Cryptography.X509Certificates;
//using System.Text;
//using System.Threading.Tasks;

//namespace DungeonApp.DungeonLibrary
//{
//    public class Combat
//    {


//        //Let's create a method to handle a one sided attack

//        public static void DoAttack(Character attacker, Character defender) 
//        {
//            //Find the chance that the attacker lands a hit.
//            int chance = attacker.CalcHitChance() - defender.CalcBlock();
//            int roll = new Random().Next(1, 101);
//            //if the roll is less than or equal to the adjusted hit chance, we hit!
//            bool hit = roll <= chance;

//            //Thread.Sleep() will temporarily suspend the program, giving the illusion
//            //that something is happening, like a dice roll for instance.
//            Thread.Sleep(300);

//            if (hit) //if (roll <=chance) 
//            {
//                //calculate the damage
//                int damage = attacker.CalcDamage();
//                //subtract and assign it to the defender's life
//                defender.Life -= damage;
//                //output the result
//                Console.ForegroundColor = ConsoleColor.Red;
//                Console.WriteLine($"{attacker.Name} hit {defender.Name} for {damage} damage!");
//                //reset the color
//                Console.ResetColor();
//            }
//            else
//            {
//                Console.ForegroundColor = ConsoleColor.Yellow;
//                Console.Write($"{attacker.Name}");
//                Console.ResetColor();
//                Console.WriteLine(" missed!");
//                // To randomly select colors : var colors = Enum.GetValues<ConsoleColor>();
               
//            }
//            //end DoAttack()
           
             


//        }

//        public static bool DoBattle(Player player, Monster monster)
//        {
//            //Potential expansion: initiative
//            //Consider adding an "initiative" property to Character.cs
//            //Then check the initiative to determine who attacks first.
//            //if player.initiative > monster.initiative then DoAttack(player, monster)
//            //for this example, we will give player initiative by default

//            //potential expansion: give certain player races or characters with a certain
//            //weapon an extra attack or some other advantage.
//            DoAttack(player, monster);
//            if (monster.Life > 0) 
//            {
//                DoAttack(monster, player);
//                return false;
//            }
//            else
//            {
//                //possible expansion: Combat rewards.
//                //monsters could drop loot (item class & inventory)
//                //inventory (List<Item>)
//                //Gold could be used to heal between battles
//                //loot could be gotten from drops selected the same way as monsters are generated.

//                player.Score++;

//                Console.ForegroundColor = ConsoleColor.Green;
//                Console.WriteLine($"\nYou killed {monster.Name}!");
//                Console.ResetColor();
//                return true;
//            }

//        }

//    }
//}
