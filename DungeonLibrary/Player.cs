﻿using DungeonLibrary;
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
     

        //The beginning of a chain can be marked as abstract (incomplete), meaning it 
        //must be inherited to be used. 
        //Sealed denotes the end of an inheritance chain. Player cannot have children.
        //AKA Player cannot be inherited. 

        //Fields
        //No fields, no business rules

        //Props
        public string PlayerRace { get; set; }
        public Weapon EquippedWeapon { get; set; }
        public int Score { get; set; }


        //Ctors
        public Player(string name, int hitChance, int block, int maxLife, Race playerRace,
            Weapon equippedWeapon)
            : base(name, 70, 5, 40)//hitchance, block, maxlife/life
        {
           
            PlayerRace =  playerRace;
            EquippedWeapon = equippedWeapon;

            #region Potential Expansion: Racial Bonuses
            //build a switch based on the PlayerRace. Apply buffs/debuffs depending
            //on which race they picked. 
            switch (PlayerRace)
            {
                case Race.Lich:
                    HitChance += 5;
                    break;
                case Race.Zombie:
                    break;
                case Race.Skeleton:
                    break;
                case Race.Warlock:
                    break;
                case Race.Dragon:
                    break;
                case Race.Vampire:
                    break;
                case Race.Werewolf:
                    break;
                default:
                    break;
            }
        }

      

        public static string GetRaceDesc(Race race)
        {
            switch (race)
            {//replace break; with return "description";
                case Race.Beholder:
                    return "How are you holding a weapon right now? It's probably best to not think about that.";
                case Race.Zombie:
                    return "You sure won't make any friends with that pretty face of yours. ";
                case Race.Skeleton:
                    return "You aren't really sure how they plan on killing you since you're already dead. ";
                case Race.Warlock:
                    return "Hopefully your patron won't reject you after he sees you clearly haven't been using those home security spells. ";
                case Race.Dragon:
                    return "Honestly if you really wanted to, you could just barbecue all these people in your cave.";
                case Race.Vampire:
                    return "You really hope none of these dungeon delvers are Italian. ";
                case Race.Werewolf:
                    return "You spent 6 hours brushing your hair this morning.";
                default:
                    return "..";
            }
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
