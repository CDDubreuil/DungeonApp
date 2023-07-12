using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using DungeonLibrary;

namespace DungeonApp.DungeonLibrary
    {
        public class Dwarf : Monster
        {

            private int _minDamage;
            public int MaxDamage { get; set; }

            public int MinDamage
            {
                get
                {
                    return _minDamage;
                }

                set
                {
                    _minDamage = (value > 0 && value < MaxDamage) ? value : 1;
                }
            }
            public string Description { get; set; }
            public Dwarf(string name, int HitChance, int block, int maxLife, int life, int maxDamage, int minDamage, string description)
                : base(name, HitChance, block, maxLife, life,  maxDamage, minDamage, description)

            {
                MinDamage = minDamage;
                MaxDamage = maxDamage;
                Description = description;

            }
            
            public override string ToString()
            {
                return $"*****MONSTER*****\n{base.ToString()}\n" +
                    $"Damage: {MinDamage} = {MaxDamage}\n" +
                    $"Description: {Description}";
            }
            public override int CalcDamage()
            {

                return new Random().Next(MinDamage, MaxDamage + 1);
            }


            public static Dwarf GetDwarf()
            {

                Dwarf d1 = new Dwarf("Lone Wanderer", 50, 20, 25, 8, 2, 5, "A wretched soul, moving aimlessly through the lands. ");
                Dwarf d2 = new Dwarf("Cheery Digger", 70, 20, 25, 8, 2, 5, "He won't. stop. whistling. ");
                Dwarf d3 = new Dwarf("General Foreman", 55, 20, 25, 8, 2, 5, "A gruff old dwarf who is much stronger than his aged frame suggests. ");
                Dwarf d4 = new Dwarf("Tiny Miner", 65, 20, 25, 8, 2, 5, "Just a tiny lil fella with a big ol' pickaxe.  ");

                List<Dwarf> dwarves = new()
            { d1, d1,
            d2, d2, d2, d2,
            d3, d3, d3,
            d4
            };

                return dwarves[new Random().Next(0, dwarves.Count)];

          
            }
        }

    }

