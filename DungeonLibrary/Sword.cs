using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using DungeonLibrary;
namespace DungeonApp.DungeonLibrary
{
    public class Sword : Weapon
    {
        private bool _isTwoHanded;

        public bool IsTwoHanded { get; set; }

        public Sword(bool isTwoHanded, string name, int minDamage, int maxDamage, int bonusHitChance, string description) : base(name, minDamage, maxDamage, bonusHitChance, description)
        {
            IsTwoHanded = isTwoHanded;
        }


        //Methods
        public override string ToString()
        {
            //return base.ToString(); -> DungeonLibrary.Weapon
            return $"{Name}\n" +
                   $"Damage: {MinDamage} - {MaxDamage}\n"+
                   $"{Description}";
        }


    }
}
