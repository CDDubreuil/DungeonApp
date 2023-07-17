using DungeonApp;
using DungeonApp.DungeonLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    //MAKE IT PUBLIC!
    public class Weapon
    {
        //Fields (private type _camelCase;)
        private string _name;
        private int _minDamage;
        private int _maxDamage;
        private int _bonusHitChance;
        private string _description;
  
        //Properties (public type PascalCase { get {} set {} }
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        public int MinDamage
        {
            get { return _minDamage; }
            //Min damage must be greater than 0 and less than Max. If not, default to 1.
            set { _minDamage = value > 0 && value < MaxDamage ? value : 1; }
        }
        public int MaxDamage
        {
            get { return _maxDamage; }
            set { _maxDamage = value; }
        }
        public int BonusHitChance
        {
            get { return _bonusHitChance; }
            set { _bonusHitChance = value; }
        }

        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }
        //auto props -> can only be used if you don't have business rules.
        //They don't require fields, so we can save a ton of space and time typing.
      
        public WeaponType Type { get; set; }
        //CTORS
        public Weapon(string name, int minDamage, int maxDamage, int bonusHitChance, string description, WeaponType type)
        {
            Name = name;
            MaxDamage = maxDamage;//Max Damage MUST be ASSIGNED before MinDamage, regardless of how it appears in the parameter list.
            MinDamage = minDamage;
            BonusHitChance = bonusHitChance;
            Description = description;
            Type = type;
            //added after introducing enums

        }//FQ CTOR
    


    //Methods
    public override string ToString()
        {
            //return base.ToString(); -> DungeonLibrary.Weapon
            return $"{Name}\n" +
                   $"Damage: {MinDamage} - {MaxDamage}\n" +
                   $"Bonus Hit: {BonusHitChance}%\n" +
                   $"{Description}";
        }

        public void CalculateWeapon(Player player)
        {
            switch (Type)
            {
                case WeaponType.Unarmed:
                    MinDamage += 5;
                    MaxDamage += 10;
                    BonusHitChance += 5;
                    break;
                case WeaponType.Rusty_Sword:
                    MinDamage += 5;
                    MaxDamage += 10;
                    BonusHitChance += 10;
                    break;
                case WeaponType.Big_Bonk:
                    MinDamage += 5;
                    MaxDamage += 10;
                    BonusHitChance += 10;
                    break;
                case WeaponType.Wooden_Bow:
                    MinDamage += 5;
                    MaxDamage += 10;
                    BonusHitChance += 10;
                    break;
                case WeaponType.Flame_Staff:
                    MinDamage += 5;
                    MaxDamage += 10;
                    BonusHitChance += 10;
                    break;
                default: return;
                    break;
            }
        }
}
}


    

