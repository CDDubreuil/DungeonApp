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


        //The beginning of a chain can be marked as abstract (incomplete), meaning it 
        //must be inherited to be used. 
        //Sealed denotes the end of an inheritance chain. Player cannot have children.
        //AKA Player cannot be inherited. 

        //Fields
        //No fields, no business rules

        //Props
        public Race PlayerRace { get; set; }
        public Weapon EquippedWeapon{ get; set; }
        public int Score { get; set; }



        //Ctors
        public Player(Race playerRace, Weapon equippedWeapon, int score, string name, int hitChance, int block, int maxLife, int life
       ) : base(name, hitChance, block, maxLife, life)
        {
            PlayerRace = playerRace;
            EquippedWeapon = equippedWeapon;
            Score = score;
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
   



