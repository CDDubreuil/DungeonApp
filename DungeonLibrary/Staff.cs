using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DungeonLibrary;
namespace DungeonApp.DungeonLibrary
{
    public class Staff : Weapon
    {
        public string Effects { get; set; }

        public Staff(string effects, string name, int minDamage, int maxDamage, int bonusHitChance, string description, WeaponType weaponType) : base(name, minDamage, maxDamage, bonusHitChance, description, weaponType)
        {
            Effects = effects;
        }

    }
}

