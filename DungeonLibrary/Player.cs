using DungeonLibrary;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks.Sources;

namespace DungeonApp.DungeonLibrary
{
    public sealed class Player : Character
    {


        public Race PlayerRace { get; set; }
        public Weapon EquippedWeapon{ get; set; }
        public int Score { get; set; }
        public int RaceStrength { get; set; }
        public int RaceAgility { get; set; }
        public int RaceDefense { get; set; }
        public int RaceHealth { get; set; }


    
        public Player(Race playerRace, Weapon equippedWeapon, int score, int raceStrength, int raceAgility, int raceDefense, int raceHealth, string name, int hitChance, int block, int maxLife, int life
       ) : base(name, hitChance, block, maxLife, life)
        {
            PlayerRace = playerRace;
            EquippedWeapon = equippedWeapon;
            Score = score;
            RaceStrength = raceStrength;
            RaceAgility = raceAgility;
            RaceDefense = raceDefense;
            RaceHealth = raceHealth;
        }
            
        

    public override int CalcDamage()
    {       
        Random rand = new Random();

   
        int damage = rand.Next(EquippedWeapon.MinDamage, EquippedWeapon.MaxDamage + 1);
 
        return damage;
    }
    public override int CalcHitChance()
    {
        return HitChance + EquippedWeapon.BonusHitChance;
      
        }
        public void CalculateStats()
        {
            switch (PlayerRace)
            {
                case Race.Skeleton:
                RaceStrength -= 10;
                RaceAgility += 15;
                RaceDefense += 15;
                RaceHealth -= 20;
                    break;
                case Race.Necromancer:
                RaceStrength += 15;
                RaceAgility += 15;
                RaceDefense -=  10;
                RaceHealth += 15;
                    break;
                case Race.Dragon:
                RaceStrength += 20;
                RaceAgility -= 20;
                RaceDefense += 10;
                RaceHealth -= 20;
                    break;
                case Race.Vampire:
                RaceStrength -= 10;
                RaceAgility += 15;
                RaceDefense -= 15;
                RaceHealth += 10;
                    break;
                case Race.Werewolf:
                RaceStrength += 10;
                RaceAgility  -= 10;
                RaceDefense += 10;
                RaceHealth += 15;
                    break;
                default:
                return;
                break;
            }


           



        }

        public override string ToString()
        {
           string playerStats =
                $"Player Name: {Name} \n" +
                $"Player Race: {PlayerRace} \n" +
                $"Equipped Weapon: {EquippedWeapon.Name} \n" +
                $"Hit Chance: {HitChance} \n" +
                $"Block: {Block} \n" +
                $"Max Life: {MaxLife} \n" +
                $"Life: {Life} \n" +
         
                $"Race Health Bonus: {RaceHealth} \n" +
                $"Race Strength Bonus: {RaceStrength} \n" +
                $"Race Agility Bonus: {RaceAgility} \n" +
                $"Race Defense Bonus: {RaceDefense} \n" ;
            return playerStats;
        }





    }
}
   



