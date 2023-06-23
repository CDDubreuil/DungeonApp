using DungeonLibrary;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DungeonApp.DungeonLibrary
{
    public sealed class Player : Character
    {
        private string v;
        private Race human;
        private Weapon sword;

        //The beginning of a chain can be marked as abstract (incomplete), meaning it 
        //must be inherited to be used. 
        //Sealed denotes the end of an inheritance chain. Player cannot have children.
        //AKA Player cannot be inherited. 

        //Fields
        //No fields, no business rules

        //Props
        public Race PlayerRace { get; set; }
        public Weapon EquippedWeapon { get; set; }
        public int Score { get; set; }


        //Ctors
        public Player(string name, int hitChance, int block, int maxLife, Race playerRace,
            Weapon equippedWeapon)
            : base(name, 70, 5, 40)//hitchance, block, maxlife/life
        {
            PlayerRace = playerRace;
            EquippedWeapon = equippedWeapon;

            #region Potential Expansion: Racial Bonuses
            //build a switch based on the PlayerRace. Apply buffs/debuffs depending
            //on which race they picked. 
            switch (PlayerRace)
            {
                case Race.Human:
                    HitChance += 5;
                    break;
                case Race.Tiefling:
                    break;
                case Race.Dwarf:
                    break;
                case Race.Giant:
                    break;
                case Race.Orc:
                    break;
                case Race.Cyborg:
                    break;
                default:
                    break;
            }
        }

        public Player(string v, Race human, Weapon sword)
        {
            this.v = v;
            this.human = human;
            this.sword = sword;
        }

        private static string GetRaceDesc(Race race)
        {
            switch (race)
            {//replace break; with return "description";
                case Race.Human:

                    return "Human";
                case Race.Tiefling:
                    return "Tiefling";
                case Race.Dwarf:
                    return "Dwarf";
                case Race.Giant:
                    return "Giant";
                case Race.Orc:
                    return "Orc";
                case Race.Cyborg:
                    return "Cyborg";
                default:
                    return "";

            }
        }

 public override string ToString()
        {
            return base.ToString() + $"\nWeapon: \n{EquippedWeapon}\n" +
                $"Description: \n{GetRaceDesc(PlayerRace)}";
        }
        public override int CalcDamage()
        {         //throw new NotImplementedException();
            Random rand = new Random();
            
                //.Next() 0 to int.MaxValue
                //.Next(int value) 0 to value - 1
                //.Next(int value1, int value2) value1 to value 2 - 1
                int damage = rand.Next(EquippedWeapon.MinDamage, EquippedWeapon.MaxDamage + 1);
            //upper bound is exclusive, so we add 1 to the max damage. 
            return damage;
        }
        public override int CalcHitChance()
        {
            return HitChance + EquippedWeapon.BonusHitChance;
            //You could also do 
            //int chance = HitChance + EquippedWeapon.BonusHitChance;
            //return chance;
        }
        //To get a random damage number, we use rand.Next
    }//CalcHitChance() override -> return the Hitchance + EquippedWeapon's BonusHitChance property.

}
   


#endregion
