using DungeonApp.DungeonLibrary;
using DungeonLibrary;//Added a reference to DungeonLibrary and this using statement to access Character and Weapon classes
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonApp
{
    internal class TestHarness
    {
        static void Main(string[] args)
        {
            //test your Character and your Weapon creation
            #region Character Testing
            //object initialization syntax using the Default CTOR
            //Character c1 = new()
            //{
            //    Name = "Gandalf",
            //    HitChance = 75,
            //    Block = 15,
            //    MaxLife = 120,
            //    Life = 120 //MaxLife MUST be set before Life
            //};
            ////testing the ToString()
            //Console.WriteLine(c1);
            ////Using the FQ CTOR
            //Character c2 = new("Storm Trooper", 35, 5, 130, 70);//Life(70) and MaxLife(130) are explicitly set to different values here.
            //Console.WriteLine(c2);

            ////Using the full health CTOR overload
            //Character c3 = new("Mario Mario", 60, 20, 200);//Here, MaxLife is set to 200, and Life will default to whatever MaxLife is.
            //Console.WriteLine(c3);
            //Commented out after marking "Character" as abstract. We cannot directly
            //create abstract objects. 

            #endregion

            #region Weapon Testing
            Console.Write("Equipped Weapon: ");
            Weapon w1 = new Weapon("Wooden Stick", 1, 5, 0, false);
            Console.WriteLine(w1.ToString());
            #endregion


            #region Player Testing
            Console.WriteLine("Player: ");
            Console.WriteLine("What is your name? ");
            string name = "Maggie";
            Race race = (Race)1;
            Player p1 = new Player(name, 75, 50, 100, Race.Human, w1);
            Console.WriteLine(p1);

            Console.WriteLine("Calc Damage: " + p1.CalcDamage());
            Console.WriteLine("Calc Block: " + p1.CalcBlock());
            Console.WriteLine("Calc Hit Chance: " + p1.CalcHitChance());



            #endregion


            #region Monster Testing
            Monster m1 = Monster.GetMonster();
            Console.WriteLine(m1);




            #endregion
            //An inventory could be made possible through the use of polymorphism, 
            //using enums
            //csf2 solution, block 3 enums and block 3 monsters enum for example on how to
            //show the user a list of enums and let them pick one. 
            //For weapon selection:
            //Create a method in Weapon.cs class to show a list of weapons and let 
            //the player pick one. "Return" the weapon to the main program and use it in 
            //the player CTOR.
        }
    }
}
