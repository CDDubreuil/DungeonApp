using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    //MAKE IT PUBLIC!
    public class Weapon
    {
        //Fields (private type _camelCase;)
        private string _name;
        private int _maxDamage;
        private int _minDamage;
        private int _bonusHitChance;
        private bool _isTwoHanded;
        private string _description;
      

        //Properties (public type PascalCase { get {} set {} }
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public int MaxDamage
        {
            get { return _maxDamage; }
            set { _maxDamage = value; }
        }

        public int MinDamage
        {
            get { return _minDamage; }
            //Min damage must be greater than 0 and less than Max. If not, default to 1.
            set { _minDamage = value > 0 && value < MaxDamage ? value : 1; }
        }       

           

        public int BonusHitChance
        {
            get { return _bonusHitChance; }
            set { _bonusHitChance = value; }
        }      

        public bool IsTwoHanded
        {
            get { return _isTwoHanded; }
            set { _isTwoHanded = value; }
        }

        public string Description
        {
            get { return _description; }
            set { _name = value;  }
        }

        public WeaponType Type { get; set; }

        public enum WeaponType
        {
            Sword,
            Dagger,
            Club,
            Staff
        }
        //CTORS
        public Weapon(string name, int minDamage, int maxDamage, int bonusHitChance, bool isTwoHanded, string description, Type weaponType)
        {
            Name = name;
            MaxDamage = maxDamage;//Max Damage MUST be ASSIGNED before MinDamage, regardless of how it appears in the parameter list.
            MinDamage = minDamage;
            BonusHitChance = bonusHitChance;
            IsTwoHanded = isTwoHanded;//added after introducing enums
            Description = description;
            Type = Type;
        }//FQ CTOR

        public static List <Weapon> GetWeapons()
        {
            Weapon w1 = new Weapon("Saw Cleaver", 50, 25, 15, false, "A blood soaked sawblade covered in wickedly sharp teeth. You feel like this would be useful for hunting beasts", WeaponType.Sword);
            Weapon w2 = new Weapon("Big Bonk", 60, 45, 20, true, "Unga Bunga ", WeaponType.Club);


            List<Weapon> weapons = new()
            {
                w1,w2,
            };
            return weapons;
        }

        //Methods
        public override string ToString()
        {
            //return base.ToString(); -> DungeonLibrary.Weapon
            return $"{Name}\n" +
                   $"Damage: {MinDamage} - {MaxDamage}\n" +
                   $"{(IsTwoHanded ? "Two" : "One")}-Handed";
        }
       
    }
}
