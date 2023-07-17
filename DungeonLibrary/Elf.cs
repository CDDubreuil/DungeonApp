using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using DungeonLibrary;

namespace DungeonApp.DungeonLibrary
{
    public class Elf : Monster
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
        public Elf(string name, int HitChance, int block, int maxLife, int life, int maxDamage, int minDamage, string description)
            : base(name, HitChance, block, maxLife, life, maxDamage, minDamage, description)

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


        public static Elf GetElf()
        {

            Elf e1 = new Elf("Woodsy Ranger", 50, 20, 100, 35, 15, 5, "This elf smells like patchouli . ");
            Elf e2 = new Elf("Sharp-Eyed Archer", 70, 40, 600, 60, 30, 10, "You barely see this elf, who was camping in the shadows, hoping to snipe you. ");
            Elf e3 = new Elf("Crafty Artificer", 55, 350, 75, 75, 40, 15, "An elf is tinkering with some magical contraption it has built to explore your ruins.");
            Elf e4 = new Elf("Wise Archmage", 65, 60, 125, 125, 50, 25, "Powerful spells swirl around this ancient elf, who radiates an incredible energy.");

            List<Elf> elves = new()
            { e1, e1,
            e2, e2, e2, e2,
            e3, e3, e3,
            e4
            };

            return elves[new Random().Next(0, elves.Count)];


        }
    }

}

